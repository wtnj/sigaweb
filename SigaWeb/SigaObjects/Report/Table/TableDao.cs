using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.Table
{
    public class TableDao : SELECT
    {
        #region Members
        public static String ValueMember  
        {
            get { return "id"; }
        }
        public static String DisplayMember
        {
            get { return "tabela"; }
        }
        #endregion

        #region Save
        public int save(List<TableVo> tables)
        {
            int cont = 0;
            foreach (TableVo table in tables)
                cont += save(table);
            return cont;
        }
        public int save(TableVo table)
        {
            if (table.ID == 0)
            {
                int i = insert(table);
                this.load(table, table.IDREPORT, table.MAINID);
                return i;
            }
            else
                return update(table);
        }
        #endregion

        #region Insert
        public int insert(TableVo table)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.Append("INSERT INTO [RTable]");
            this.QUERY.AppendLine("(idReport, mainId, relatedtable, relatedident, relatedtype, tabela)");

            this.QUERY.Append("VALUES( ");
            this.QUERY.Append("        "  + table.IDREPORT         );
            this.QUERY.Append("      , "  + table.MAINID           );
            this.QUERY.Append("      ,'" + table.RELATEDTABLE + "'");
            this.QUERY.Append("      ,'" + table.RELATEDIDENT + "'");
            this.QUERY.Append("      ,'" + table.RELATEDTYPE  + "'");
            this.QUERY.Append("      ,'" + table.TABELA       + "'");
            this.QUERY.AppendLine("      )");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(TableVo table)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("UPDATE [RTable]");
            this.QUERY.AppendLine("   SET idReport     =  " + table.IDREPORT     );
            this.QUERY.AppendLine("     , mainId       =  " + table.MAINID       );
            this.QUERY.AppendLine("     , relatedtable = '" + table.RELATEDTABLE + "'");
            this.QUERY.AppendLine("     , relatedident = '" + table.RELATEDIDENT + "'");
            this.QUERY.AppendLine("     , relatedtype  = '" + table.RELATEDTYPE  + "'");
            this.QUERY.AppendLine("     , tabela       = '" + table.TABELA       + "'");
            this.QUERY.AppendLine(" WHERE id    = " + table.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<TableVo> tables)
        {
            int cont = 0;
            foreach (TableVo table in tables)
                cont += delete(table);
            return cont;
        }
        public int delete(TableVo table)
        {
            return delete(table.IDREPORT, table.MAINID, "id = " + table.ID);
        }
        public int delete(int idReport, int mainId)
        {
            return delete(idReport, mainId, null);
        }
        public int delete(int idReport, int mainId, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM [RTable]");
            this.QUERY.AppendLine(" WHERE idReport = " + idReport);
            this.QUERY.AppendLine("   AND mainId = " + mainId);
            if (filtro != null)
                this.QUERY.AppendLine("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Listas
        //public List<string> getCodigoAsList(int idReport)
        //{
        //    return getColunaAsList(getCodigo(idReport));
        //}
        #endregion

        #region Colunas
        //public DataTable getTabela(int idReport)
        //{
        //    return getColunas(idReport, "codigo");
        //}

        //public DataTable getColunas(int idReport, string colunas)
        //{
        //    this.QUERY = new StringBuilder(fromDatabase);

        //    this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
        //    this.QUERY.AppendLine("  FROM [table]");
        //    this.QUERY.AppendLine(" WHERE idReport = " + idReport);

        //    return getData();
        //}
        #endregion

        #region Select
        public DataTable select(int idReport, int mainId)
        {
            return select(idReport, mainId, null, false);
        }
        public DataTable select(int idReport, int mainId, string filtro)
        {
            return select(idReport, mainId, filtro, false);
        }
        public DataTable select(int idReport, int mainId, bool firstOnly)
        {
            return select(idReport, mainId, null, false);
        }
        public DataTable select(int idReport, int mainId, string filtro, bool firstOnly)
        {
            new SELECT(firstOnly ? "TOP 1 *" : "*")
            .From("[RTable]")
            .Where("idReport = " + idReport)
            .And("mainId = " + mainId)
            .And(filtro);

            return getData();
        }
        #endregion

        #region Load
        public void load(TableVo table, int idReport, int mainId)
        {
            load(table, idReport, mainId, null);
        }
        public void load(TableVo table, int idReport, int mainId, bool filterTable)
        {
            load(table, idReport, mainId, "tabela = '" + table.TABELA + "'");
        }
        public void load(TableVo table, int idReport, int mainId, string filtro)
        {
            DataTable dtTable = select(idReport, mainId, filtro);
            if(dtTable.DefaultView.Count > 0)
            {
                table.IDREPORT = idReport;
                table.MAINID   = mainId;

                table.ID           = (int)   dtTable.DefaultView[0]["id"];
                table.RELATEDTABLE = (string)dtTable.DefaultView[0]["relatedtable"];
                table.RELATEDIDENT = (string)dtTable.DefaultView[0]["relatedident"];
                table.RELATEDTYPE  = (string)dtTable.DefaultView[0]["relatedtype"];
                table.TABELA       = (string)dtTable.DefaultView[0]["tabela"];
            }
        }
        public void load(List<TableVo> tables, int idReport, int mainId)
        {
            load(tables, idReport, mainId, null);
        }
        public void load(List<TableVo> tables, int idReport, int mainId, string filtro)
        {
            DataTable table = select(idReport, mainId, filtro, false);
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                TableVo tableVo  = new TableVo();
                tableVo.IDREPORT = idReport;
                tableVo.MAINID   = mainId;

                tableVo.ID           = (int)   table.DefaultView[i]["id"];
                tableVo.RELATEDTABLE = (string)table.DefaultView[i]["relatedtable"];
                tableVo.RELATEDIDENT = (string)table.DefaultView[i]["relatedident"];
                tableVo.RELATEDTYPE  = (string)table.DefaultView[i]["relatedtype"];
                tableVo.TABELA       = (string)table.DefaultView[i]["tabela"];

                tables.Add(tableVo);
            }
        }
        #endregion
    }
}