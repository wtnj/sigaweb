using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.Params
{
    public class ParamsDao : SELECT
    {
        #region Members
        public static String ValueMember
        {
            get { return ""; }
        }
        public static String DisplayMember
        {
            get { return ""; }
        }
        #endregion

        #region Listas

        public List<string> getTamanhosAsList(int mainId)
        {
            return getColunaAsList(getTamanhos(mainId));
        }
        public List<string> getTabelaAsList(int mainId)
        {
            return getColunaAsList(getTabelas(mainId));
        }
        public List<string> getCamposAsList(int mainId)
        {
            return getColunaAsList(getCampos(mainId));
        }
        public List<string> getFormatoAsList(int mainId)
        {
            return getColunaAsList(getFormatos(mainId));
        }

        #endregion

        #region Load
        public void Load(ParamsVo param, int mainId)
        {
            List<ParamsVo> parameters = new List<ParamsVo>();
            parameters.Add(param);

            Load(parameters,mainId,"id = " + param.ID);
        }
        public void Load(List<ParamsVo> parameters, int mainId)
        {
            Load(parameters,mainId,null);
        }
        public void Load(List<ParamsVo> parameters, int mainId, string filtro)
        {
            DataTable table = select(mainId,filtro,false);
            for(int i = 0;i < table.DefaultView.Count;i++)
            {
                ParamsVo param = new ParamsVo();
                param.MAINID    = mainId;

                param.ID        = (int)   table.DefaultView[i]["id"];
                param.TABELA    = (string)table.DefaultView[i]["tabela"];
                param.TAMANHO   = (int)   table.DefaultView[i]["tamanho"];
                param.CAMPO     = (string)table.DefaultView[i]["campo"];
                param.FORMATO   = (string)table.DefaultView[i]["formato"];

                parameters.Add(param);
            }
        }
        #endregion

        #region Select
        public DataTable select(int mainId)
        {
            return select(mainId, null, false);
        }
        public DataTable select(int mainId, string filtro)
        {
            return select(mainId,filtro,false);
        }
        public DataTable select(int mainId, bool firstOnly)
        {
            return select(mainId, null, firstOnly);
        }
        public DataTable select(int mainId, string filtro, bool firstOnly)
        {
            new SELECT(firstOnly ? "TOP 1 * " : "*")
            .From("params")
            .Where("mainId = " + mainId)
            .And(filtro);

            return getData();
        }

        public DataTable getTamanhos(int mainId)
        {
            return getColunas(mainId,"tamanho");
        }
        public DataTable getTabelas(int mainId)
        {
            return getColunas(mainId,"tabela");
        }
        public DataTable getCampos(int mainId)
        {
            return getColunas(mainId,"campo");
        }
        public DataTable getFormatos(int mainId)
        {
            return getColunas(mainId,"formato");
        }
        public DataTable getColunas(int mainId, string colunas)
        {
            this.QUERY = new StringBuilder();

            this.QUERY.AppendLine("use SigaWeb");
            this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
            this.QUERY.AppendLine("  FROM params");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId);

            return getData();
        }
        #endregion

        #region Save
        public int save(List<ParamsVo> parameters)
        {
            int cont = 0;
            foreach(ParamsVo param in parameters)
                cont += save(param);
            return cont;
        }
        public int save(ParamsVo param)
        {
            int iRet = 0;

            if(param.ID == 0)
                iRet = insert(param);
            else
                iRet = update(param);
            return iRet;
        }
        #endregion

        #region Insert
        public int insert(ParamsVo param)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery("use Sigaweb");
            this.addInQuery("INSERT INTO params (mainId, tabela, campo, formato, tamanho)");
            this.QUERY.Append("VALUES (");
            this.QUERY.Append(""  + param.MAINID  + ",");
            this.QUERY.Append("'" + param.TABELA  + "',");
            this.QUERY.Append("'" + param.CAMPO   + "',");
            this.QUERY.Append("'" + param.FORMATO + "',");
            this.QUERY.Append("'" + param.TAMANHO + "'");
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(ParamsVo param)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery("use SigaWeb");
            this.addInQuery("UPDATE params");
            this.addInQuery("   SET tamanho = "  + param.TAMANHO + "");
            this.addInQuery("      ,tabela  = '" + param.TABELA  + "'" );
            this.addInQuery("      ,campo   = '" + param.CAMPO   + "'");
            this.addInQuery("      ,formato = '" + param.FORMATO + "'");
            this.addInQuery(" WHERE id = " + param.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<ParamsVo> parameters)
        {
            int cont = 0;
            foreach(ParamsVo param in parameters)
                cont += delete(param);
            return cont;
        }
        public int delete(ParamsVo param)
        {
            return delete(param.MAINID, "id = " + param.ID);
        }
        public int delete(int mainId)
        {
            return delete(mainId,null);
        }
        public int delete(int mainId, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.addInQuery("DELETE FROM params");
            this.addInQuery(" WHERE mainId = " + mainId);
            if(filtro != null)
                this.addInQuery("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion
    }
}
