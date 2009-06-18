using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.OrderBy
{
    public class OrderByDao : SELECT
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
            return this.getColunaAsList(getColunas(mainId, "value"));
        }
        #endregion

        #region Load
        /// <summary>
        /// Objeto Virtual OrderBy para ser preenchido com os campos restantes pela chave
        /// </summary>
        /// <param name="orders">Lista de objetos a ser preenchido.</param>
        /// <param name="mainId">A quem pertence esta lista ?</param>
        public void load(List<OrderByVo> orders, int mainId)
        {
            OrderByVo order;

            int i = 0;
            do
            {
                order = new OrderByVo(i++, mainId);
                load(order);
                if (order.ID == 0) break;
                orders.Add(order);
            }
            while (true);
        }
        /// <param name="order">Parâmetro a ser preenchido.</param>
        public void load(OrderByVo order)
        {
            DataTable table = select(
                order.MAINID,
                "indice = " + order.INDICE,
                true
            );

            order.ID        = (int)     table.DefaultView[0]["id"];
            order.DISPLAY   = (string)  table.DefaultView[0]["displaymember"];
            order.VALUE     = (string)  table.DefaultView[0]["valuemember"];
        }
        #endregion

        #region Select
        /// <summary>
        /// Retorna um conjunto de dados do banco de dados
        /// </summary>
        /// <param name="mainId"> Id do controle que o contém</param>
        public DataTable select(int mainId)
            {return select(mainId,null,false);}
        /// <param name="mainId"> Id do controle que o contém</param>
        /// <param name="filtro"> Qualquer restrição ao banco de dados</param>
        public DataTable select(int mainId, string filtro)
            {return select(mainId, filtro, false);}
        /// <param name="filtro"> Qualquer restrição ao banco de dados</param>
        /// <param name="firstOnly"> Apenas o primeiro registro ?</param>
        public DataTable select(int mainId, bool firstOnly)
            {return select(mainId, null, firstOnly);}
        /// <param name="mainId"> Id do controle que o contém</param>
        /// <param name="filtro"> Qualquer restrição ao banco de dados</param>
        /// <param name="firstOnly"> Apenas o primeiro registro ?</param>
        /// <returns></returns>
        public DataTable select(int mainId, string filtro, bool firstOnly)
        {
            new SELECT  (firstOnly ? "TOP 1 *" : "*") 
            .From       ("orderBy")
            .Where      ("mainId = " + mainId)
            .And        (filtro)
            .OrderBy    ("indice");

            return getData();
        }

        /// <summary>
        /// Retorna sem repetições o conjunto de colunas
        /// </summary>
        /// <param name="mainId">Id do controle pai</param>
        /// <returns>Retorna os valores para o order by</returns>
        public DataTable getValues(int mainId)
        {
            return getColunas(mainId, "value");
        }
        /// <summary>
        /// Retorna sem repetições o conjunto de colunas
        /// </summary>
        /// <param name="mainId">Id do controle pai</param>
        /// <param name="colunas">Conjunto de colunas para retornar na consulta</param>
        /// <returns>Retorna um conjunto de dados</returns>
        public DataTable getColunas(int mainId, string colunas)
        {
            this.QUERY = new StringBuilder();

            this.QUERY.AppendLine(fromDatabase);
            this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
            this.QUERY.AppendLine("  FROM orderBy");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId + "");

            return getData();
        }
        #endregion

        #region Save
        /// <summary>
        /// Atualiza os objetos possuem Id e insere o objeto que não possue Id
        /// </summary>
        /// <param name="orders">Uma lista de objetos OrderByVo</param>
        /// <returns>Quantidade de registros atualizados</returns>
        public int save(List<OrderByVo> orders)
        {
            int cont = 0;
            foreach (OrderByVo order in orders)
                cont += save(order);
            return cont;
        }
        /// <summary>
        /// Atualiza se o objeto possuir Id e insere caso contrário
        /// </summary>
        /// <param name="order">Objeto para o filtro da cláusula orderBy</param>
        /// <returns>Registro atualizado (1) não atualizado (0)</returns>
        public int save(OrderByVo order)
        {
            int iRet = 0;

            if (order.ID == 0)
                iRet = insert(order);
            else
                iRet = update(order);

            load(order);
            return iRet;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insere objeto OrderByVo
        /// </summary>
        /// <param name="order">Objeto para o filtro da cláusula orderBy</param>
        /// <returns>Registro atualizado (1) não atualizado (0)</returns>
        private int insert(OrderByVo order)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery(fromDatabase);
            this.addInQuery("INSERT INTO orderBy (mainId, indice, displaymember, valuemember)");
            this.QUERY.Append("VALUES (");
            this.QUERY.Append(""  + order.MAINID  + ",");
            this.QUERY.Append(""  + order.INDICE  + ",");
            this.QUERY.Append("'" + order.DISPLAY + "',");
            this.QUERY.Append("'" + order.VALUE + "'");
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        /// <summary>
        /// Atualiza objeto OrderByVo
        /// </summary>
        /// <param name="order">Objeto para o filtro da cláusula orderBy</param>
        /// <returns>Registro atualizado (1) não atualizado (0)</returns>
        private int update(OrderByVo order)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery(fromDatabase);
            this.addInQuery("UPDATE orderBy");
            this.addInQuery("   SET indice        = " + order.INDICE + "");
            this.addInQuery("     , displaymember = '" + order.DISPLAY + "'");
            this.addInQuery("     , valuemember   = '" + order.VALUE + "'");
            this.addInQuery(" WHERE id = " + order.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<OrderByVo> orders)
        {
            int cont = 0;
            foreach(OrderByVo order in orders)
                cont += delete(order);
            return cont;
        }
        public int delete(OrderByVo order)
        {
            return delete(order.MAINID, " indice = " + order.INDICE);
        }
        public int delete(int mainId)
        {
            return delete(mainId, null);
        }
        public int delete(int mainId, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM orderBy");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId);
            if(filtro != null)
                this.QUERY.AppendLine("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion
    }
}