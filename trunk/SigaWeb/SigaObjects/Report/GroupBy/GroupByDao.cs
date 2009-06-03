using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.GroupBy
{
    public class GroupByDao : SELECT
    {
        #region Members
        /// <summary>
        /// Campo predefinido para exibição ao usuário
        /// </summary>
        public static String DisplayMember
        { get { return "displaymember"; } }
        /// <summary>
        /// Campo predifinido para armazenamento de valor no controle
        /// </summary>
        public static String ValueMember
        { get { return "valuemember"; } }
        #endregion

        #region Listas
        /// <summary>
        /// Retorna uma lista de strings
        /// </summary>
        /// <param name="mainId"> Id do controle que o contém</param>
        /// <returns>Lista de strings</returns>
        public List<string> getValuesAsList(int mainId)
        {
            return this.getColunaAsList(getColunas(mainId, "valuemember"));
        }
        #endregion

        #region Load
        /// <summary>
        /// Objeto Virtual groupBy para ser preenchido com os campos restantes pela chave
        /// </summary>
        /// <param name="groups">Lista de objetos a ser preenchido.</param>
        /// <param name="mainId">A quem pertence esta lista ?</param>
        public void load(List<GroupByVo> groups, int mainId)
        {
            GroupByVo group;

            int i = 0;
            do
            {
                group = new GroupByVo(i++, mainId);
                load(group);
                if (group.ID == 0) break;
                groups.Add(group);
            }
            while (true);
        }
        /// <param name="group">Parâmetro a ser preenchido.</param>
        public void load(GroupByVo group)
        {
            DataTable table = select(
                group.MAINID,
                "indice = " + group.INDICE,
                true
            );
        }
        #endregion

        #region Select
        /// <summary>
        /// Retorna um conjunto de dados do banco de dados
        /// </summary>
        /// <param name="mainId"> Id do controle que o contém</param>
        public DataTable select(int mainId)
        { return select(mainId, null, false); }
        /// <param name="mainId"> Id do controle que o contém</param>
        /// <param name="filtro"> Qualquer restrição ao banco de dados</param>
        public DataTable select(int mainId, string filtro)
        { return select(mainId, filtro, false); }
        /// <param name="filtro"> Qualquer restrição ao banco de dados</param>
        /// <param name="firstOnly"> Apenas o primeiro registro ?</param>
        public DataTable select(int mainId, bool firstOnly)
        { return select(mainId, null, firstOnly); }
        /// <param name="mainId"> Id do controle que o contém</param>
        /// <param name="filtro"> Qualquer restrição ao banco de dados</param>
        /// <param name="firstOnly"> Apenas o primeiro registro ?</param>
        /// <returns></returns>
        public DataTable select(int mainId, string filtro, bool firstOnly)
        {
            new SELECT  (firstOnly ? "TOP 1 *" : "*")
            .From       ("groupBy")
            .Where      ("mainId = " + mainId)
            .And        (filtro)
            .OrderBy    ("indice");

            return getData();
        }

        /// <summary>
        /// Retorna sem repetições o conjunto de colunas
        /// </summary>
        /// <param name="mainId">Id do controle pai</param>
        /// <returns>Retorna os valores para o group by</returns>
        public DataTable getValues(int mainId)
        {
            return getColunas(mainId, "valuemember");
        }
        /// <summary>
        /// Retorna sem repetições o conjunto de colunas
        /// </summary>
        /// <param name="mainId">Id do controle pai</param>
        /// <param name="colunas">Conjunto de colunas para retornar na consulta</param>
        /// <returns>Retorna um conjunto de dados</returns>
        public DataTable getColunas(int mainId, string colunas)
        {
            QUERY = new StringBuilder();

            QUERY.AppendLine("use SigaWeb");
            QUERY.AppendLine("SELECT DISTINCT " + colunas);
            QUERY.AppendLine("  FROM groupBy");
            QUERY.AppendLine(" WHERE mainId = " + mainId + "");

            return getData();
        }
        #endregion

        #region Save
        /// <summary>
        /// Atualiza os objetos possuem Id e insere o objeto que não possue Id
        /// </summary>
        /// <param name="groups">Uma lista de objetos GroupByVo</param>
        /// <returns>Quantidade de registros atualizados</returns>
        public int save(List<GroupByVo> groups)
        {
            int cont = 0;
            foreach (GroupByVo group in groups)
                cont += save(group);
            return cont;
        }
        /// <summary>
        /// Atualiza se o objeto possuir Id e insere caso contrário
        /// </summary>
        /// <param name="group">Objeto para o filtro da cláusula groupBy</param>
        /// <returns>Registro atualizado (1) não atualizado (0)</returns>
        public int save(GroupByVo group)
        {
            int iRet = 0;

            if (group.ID == 0)
                iRet = insert(group);
            else
                iRet = update(group);
            return iRet;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insere objeto GroupByVo
        /// </summary>
        /// <param name="group">Objeto para o filtro da cláusula groupBy</param>
        /// <returns>Registro atualizado (1) não atualizado (0)</returns>
        private int insert(GroupByVo group)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery("use SigaWeb");
            this.addInQuery("INSERT INTO groupBy (mainId, indice, displaymember, valuemember)");
            this.QUERY.Append("VALUES (");
            this.QUERY.Append(""  + group.MAINID  + "," );
            this.QUERY.Append(""  + group.INDICE  + "," );
            this.QUERY.Append("'" + group.DISPLAY + "',");
            this.QUERY.Append("'" + group.VALUE + "'" );
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        /// <summary>
        /// Atualiza objeto GroupByVo
        /// </summary>
        /// <param name="group">Objeto para o filtro da cláusula groupBy</param>
        /// <returns>Registro atualizado (1) não atualizado (0)</returns>
        private int update(GroupByVo group)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery("use SigaWeb");
            this.addInQuery("UPDATE groupBy");
            this.addInQuery("   SET indice          = "  + group.INDICE  + "" );
            this.addInQuery("      ,displaymember   = '" + group.DISPLAY + "'");
            this.addInQuery("      ,valuemember     = '" + group.VALUE   + "'");
            this.addInQuery(" WHERE id              = "  + group.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<GroupByVo> groups)
        {
            int cont = 0;
            foreach(GroupByVo group in groups)
                cont += delete(group);
            return cont;
        }
        public int delete(GroupByVo group)
        {
            return delete(group.MAINID, " indice = " + group.INDICE);
        }
        public int delete(int mainId)
        {
            return delete(mainId, null);
        }
        public int delete(int mainId, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM groupBy");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId);
            if(filtro != null)
                this.QUERY.AppendLine("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion
    }
}