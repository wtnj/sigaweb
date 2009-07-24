using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SigaObjects.Reports.Report
{
    public class ReportDao : SELECT
    {
        #region Members
        public static String ValueMember
        {
            get { return "id"; }
        }
        public static String DisplayMember
        {
            get { return "nome"; }
        }
        #endregion

        public ReportDao()
        { }

        #region Save
        public int save(List<ReportVo> reports)
        {
            int cont = 0;
            foreach (ReportVo report in reports)
                cont += save(report);
            return cont;
        }
        public int save(ReportVo report)
        {
            if (report.ID == 0)
            {
                int i = insert(report);
                
                this.load(report);

                report.TABLE.IDREPORT = report.ID;
                new Table.TableDao().save(report.TABLE);

                return i;
            }
            else
                return update(report);
        }
        #endregion

        #region Insert
        public int insert(ReportVo report)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.Append("INSERT INTO report");
            this.QUERY.AppendLine("(idReportGroup, nome, username, filial, empresa)");

            this.QUERY.Append("VALUES(");
            this.QUERY.Append(""  + report.IDREPORTGROUP    + ",");
            this.QUERY.Append("'" + report.NOME             + "',");
            this.QUERY.Append("'" + report.USERNAME         + "',");
            this.QUERY.Append("'" + report.FILIAL           + "',");
            this.QUERY.Append("'" + report.EMPRESA          + "'");
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(ReportVo report)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("UPDATE report");
            this.QUERY.AppendLine("   SET idReportGroup    = "  + report.IDREPORTGROUP );
            this.QUERY.AppendLine("     , nome             = '" + report.NOME         + "'");
            this.QUERY.AppendLine("     , username         = '" + report.USERNAME     + "'");
            this.QUERY.AppendLine("     , filial           = '" + report.FILIAL       + "'");
            this.QUERY.AppendLine("     , empresa          = '" + report.EMPRESA      + "'");
            this.QUERY.AppendLine(" WHERE id = " + report.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<ReportVo> reports      )
        {
            int cont = 0;
            foreach (ReportVo report in reports)
                cont += delete(report);
            return cont;
        }
        public int delete(ReportVo       report       )
        { return delete(report.IDREPORTGROUP, "id = " + report.ID); }
        public int delete(int            idreportgroup)
        { return delete(idreportgroup, null); }
        public int delete(int            idreportgroup, string filtro)
        {
            //this.DeleteRecursiveTables(

            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM report");
            this.QUERY.AppendLine(" WHERE idReportGroup = " + idreportgroup);
            if (filtro != null)
                this.QUERY.AppendLine("   AND " + filtro);

            return getData().DefaultView.Count;
        }

        #region DELETE RECURSIVE {Tables, Fields, Filters, ...}
        public int DeleteRecursiveTables(List<Report.ReportVo> reports)
        {
            int i = 0;
            foreach(Report.ReportVo report in reports)
                i = this.DeleteRecursiveTables(report);

            return i;
        }
        public int DeleteRecursiveTables(Report.ReportVo       report )
        {
            int i = 0;
            Table.TableVo mainTable = new Table.TableVo();
            new Table.TableDao().load(mainTable, report.ID, 0);

            if(mainTable.ID>0)
                i = this.DeleteRecursiveTables(mainTable.ID);

            return i;
        }
        public int DeleteRecursiveTables(List<int>             mainIds)
        {
            int i = 0;
            foreach(int mainId in mainIds)
                i = this.DeleteRecursiveTables(mainId);

            return i;
        }
        public int DeleteRecursiveTables(int                   mainId )
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.addInQuery("-- INICIA A RECURSIVA");
            this.addInQuery("IF OBJECT_ID('TABELAS','U') IS NOT NULL");
            this.addInQuery("BEGIN");
            this.addInQuery("    DROP TABLE TABELAS");
            this.addInQuery("END");

            this.addInQuery("");
            
            this.addInQuery("EXECUTE SPR_ParametrosRecursivos "+mainId+", 0, TABELAS");

            this.addInQuery("");
            
            this.addInQuery("-- INICIA PROCESSO DE DELETE A PARTIR DO @TABELAS");
            this.addInQuery("DELETE FROM RTable");
            this.addInQuery(" WHERE id in (SELECT id FROM TABELAS)");

            this.addInQuery("DELETE FROM fields");
            this.addInQuery(" WHERE id in (SELECT id FROM TABELAS)");
            
            this.addInQuery("DELETE FROM filters");
            this.addInQuery(" WHERE id in (SELECT id FROM TABELAS)");
            
            this.addInQuery("DELETE FROM groupBy");
            this.addInQuery(" WHERE id in (SELECT id FROM TABELAS)");
            
            this.addInQuery("DELETE FROM orderBy");
            this.addInQuery(" WHERE id in (SELECT id FROM TABELAS)");
            
            this.addInQuery("DELETE FROM params");
            this.addInQuery(" WHERE id in (SELECT id FROM TABELAS)");
            
            this.addInQuery("");
            
            this.addInQuery("-- DROP NA TABELA");
            this.addInQuery("DROP TABLE TABELAS");

            return this.getData().Rows.Count;
        }
        #endregion
        #endregion

        #region Listas
        public List<string> getCodigoAsList(int idreportgroup)
        {
            return getColunaAsList(getDescription(idreportgroup));
        }
        #endregion

        #region Colunas
        public DataTable getDescription(int idreportgroup)
        {
            return getColunas(idreportgroup, "description");
        }
        public DataTable getColunas(int idreportgroup, string colunas)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
            this.QUERY.AppendLine("  FROM report");
            this.QUERY.AppendLine(" WHERE idReportGroup = " + idreportgroup);

            return getData();
        }
        #endregion

        #region Select
        public DataTable select()
        {
            return select(0, null, false);
        }
        public DataTable select(int idreportgroup)
        {
            return select(idreportgroup, null, false);
        }
        public DataTable select(int idreportgroup, ReportVo report)
        {
            return this.select(idreportgroup, " nome = '" + report.NOME + "'");
        }
        public DataTable select(int idreportgroup, string filtro)
        {
            return select(idreportgroup, filtro, false);
        }
        public DataTable select(int idreportgroup, bool firstOnly)
        {
            return select(idreportgroup, null, false);
        }
        public DataTable select(int idreportgroup, string filtro, bool firstOnly)
        {
            string strFilter = "";
            strFilter += (idreportgroup > 0) ? "idReportGroup = " + idreportgroup : "idReportGroup != 0";
            strFilter += (filtro != null) ? "\r\n   AND " + filtro : "";

            return select(strFilter, firstOnly);
        }
        public DataTable select(string filtro, bool firstOnly)
        {
            new SELECT(firstOnly ? "TOP 1 *" : "*")
                .From("report")
                .Where(filtro);

            return getData();
        }

        public DataTable SelectForDisplay(string filtro, bool firstOnly)
        {
            string fields = "R.idReportGroup, G.descricao, R.id, R.nome";
            return this.SelectForDisplay(filtro, firstOnly, fields);
        }
        public DataTable SelectForDisplay(string filtro, bool firstOnly, string fields)
        {
            new SELECT(firstOnly ? "TOP 1 " + fields : fields)
                .From("report", "R")
                .InnerJoin("reportgroup", "G")
                .On("G.id = R.idReportGroup")
                .Where(filtro);

            return getData();
        }
        #endregion

        #region Load
        public void load(ReportVo report)
        {
            load(report, report.IDREPORTGROUP);
        }
        public void load(ReportVo report, int idreportgroup)
        {
            load(report, idreportgroup, " nome = '" + report.NOME + "'");
        }
        public void load(ReportVo report, int idreportgroup, string filtro)
        {
            string strFiltro = "";
            strFiltro += (idreportgroup > 0) ? " idReportGroup = " + idreportgroup : " idReportGroup != 0";
            strFiltro += (filtro != null) ? "   AND " + filtro : filtro;

            load(report, strFiltro);
        }
        public void load(ReportVo report, string reportName, string filtro)
        {
            string strFiltro = "";
            strFiltro += (reportName != null) ? " nome = '" + reportName + "'" : "";
            strFiltro += (filtro     != null) ? "   AND "   + filtro           : filtro;

            load(report, strFiltro);
        }
        public void load(ReportVo report, string filtro)
        {
            DataTable table = select(filtro, false);
            if (table.DefaultView.Count > 0)
            {
                report.IDREPORTGROUP = (int)   table.DefaultView[0]["idReportGroup"];
                report.ID            = (int)   table.DefaultView[0]["id"];
                report.EMPRESA       = (string)table.DefaultView[0]["empresa"];
                report.NOME          = (string)table.DefaultView[0]["nome"];
                report.USERNAME      = (string)table.DefaultView[0]["username"];
                report.FILIAL        = (string)table.DefaultView[0]["filial"];
            }
        }
        public void load(List<ReportVo> reports, int idreportgroup)
        {
            load(reports, idreportgroup, null);
        }
        public void load(List<ReportVo> reports, int idreportgroup, string filtro)
        {
            DataTable table = select(idreportgroup, filtro, false);
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                ReportVo report      = new ReportVo();
                report.IDREPORTGROUP = idreportgroup;

                report.ID       = (int)   table.DefaultView[i]["id"];
                report.EMPRESA  = (string)table.DefaultView[i]["empresa"];
                report.NOME     = (string)table.DefaultView[i]["nome"];
                report.USERNAME = (string)table.DefaultView[i]["username"];
                report.FILIAL   = (string)table.DefaultView[i]["filial"];

                reports.Add(report);
            }
        }
        #endregion
    }
}
