using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.Filters
{
    public class FiltersDao : SELECT
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
        public List<string> getTabelasAsList(int mainId)
        {
            return this.getColunaAsList(getTabelas(mainId));
        }
        public List<string> getCamposAsList(int mainId)
        {
            return this.getColunaAsList(getCampos(mainId));
        }
        public List<string> getFiltrosAsList(int mainId)
        {
            return this.getColunaAsList(getFiltros(mainId));
        }
        public List<string> getTipofiltrosAsList(int mainId)
        {
            return this.getColunaAsList(getTipofiltros(mainId));
        }
        #endregion

        #region Load
        public void Load(FiltersVo filter, int mainId)
        {
            List<FiltersVo> filters = new List<FiltersVo>();
            filters.Add(filter);

            Load(filters, mainId, "id = " + filter.ID);
        }
        public void Load(List<FiltersVo> filters, int mainId)
        {
            Load(filters,mainId,null);
        }
        public void Load(List<FiltersVo> filters, int mainId, string filtro)
        {
            DataTable table = select(mainId, filtro, false);
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                FiltersVo filter = new FiltersVo();
                filter.MAINID = mainId;

                filter.ID           = (int)   table.DefaultView[i]["id"];
                filter.TABELA       = (string)table.DefaultView[i]["tabela"];
                filter.TIPOFILTRO   = (string)table.DefaultView[i]["tipofiltro"];
                filter.FILTRO       = (string)table.DefaultView[i]["filtro"];
                filter.CAMPO        = (string)table.DefaultView[i]["campo"];

                filters.Add(filter);
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
           return select(mainId, filtro, false);
        }
        public DataTable select(int mainId, bool firstOnly)
        {
            return select(mainId, null, firstOnly);
        }
        public DataTable select(int mainId, string filtro, bool firstOnly)
        {
            new SELECT(firstOnly ? "TOP 1 *" : "*")
            .From("filters")
            .Where("mainId = " + mainId)
            .And(filtro);

            return getData();
        }


        public DataTable getTabelas(int mainId)
        {
            return getColunas(mainId, "tabela");
        }
        public DataTable getCampos(int mainId)
        {
            return getColunas(mainId, "campo");
        }
        public DataTable getFiltros(int mainId)
        {
            return getColunas(mainId, "filtro");
        }
        public DataTable getTipofiltros(int mainId)
        {
            return getColunas(mainId, "tipofiltro");
        }
        public DataTable getColunas(int mainId, string colunas)
        {
            this.QUERY = new StringBuilder();

            this.QUERY.AppendLine("use SigaWeb");
            this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
            this.QUERY.AppendLine("  FROM filters");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId);

            return getData();
        }
        #endregion

        #region Save
        public int save(List<FiltersVo> filters)
        {
            int cont = 0;
            foreach (FiltersVo filter in filters)
                cont += save(filter);
            return cont;
        }
        public int save(FiltersVo filter)
        {
            int iRet = 0;
            if(filter.ID == 0)
                iRet = insert(filter);
            else
                iRet = update(filter);
            return iRet;
        }
        #endregion

        #region Insert
        public int insert(FiltersVo filter)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery("use SigaWeb");
            this.addInQuery("INSERT INTO filters (mainId, tabela, campo, filtro, tipofiltro)");
            this.QUERY.Append("VALUES (");
            this.QUERY.Append(""  + filter.MAINID       + ",");
            this.QUERY.Append("'" + filter.TABELA       + "',");
            this.QUERY.Append("'" + filter.CAMPO        + "',");
            this.QUERY.Append("'" + filter.FILTRO       + "',");
            this.QUERY.Append("'" + filter.TIPOFILTRO   + "'");
            this.addInQuery(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(FiltersVo filter)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery("use SigaWeb");
            this.addInQuery("UPDATE filters");
            this.addInQuery("   SET tabela      = '" + filter.TABELA + "'");
            this.addInQuery("      ,campo       = '" + filter.CAMPO + "'");
            this.addInQuery("      ,filtro      = '" + filter.FILTRO + "'");
            this.addInQuery("      ,tipofiltro  = '" + filter.TIPOFILTRO + "'");
            this.addInQuery(" WHERE id = " + filter.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<FiltersVo> filters)
        {
            int cont = 0;
            foreach(FiltersVo filter in filters)
                cont += delete(filter);
            return cont;
        }
        public int delete(FiltersVo filter)
        {
            return delete(filter.MAINID, "id = " + filter.ID);
        }
        public int delete(int mainId)
        {
            return delete(mainId, null);
        }
        public int delete(int mainId, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.addInQuery("DELETE FROM filters");
            this.addInQuery(" WHERE mainId = " + mainId);
            if(filtro != null)
                this.addInQuery("   AND " + filtro);
            return getData().DefaultView.Count;
        }
        #endregion
    }
}
