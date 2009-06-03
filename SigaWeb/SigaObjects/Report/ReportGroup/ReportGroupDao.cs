using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.ReportGroup
{
    public class ReportGroupDao : SELECT
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

        #region Save
        public int save(List<ReportGroupVo> reportgroups)
        {
            int cont = 0;
            foreach (ReportGroupVo reportgroup in reportgroups)
                cont += save(reportgroup);
            return cont;
        }
        public int save(ReportGroupVo reportgroup)
        {
            if (reportgroup.ID == 0)
            {
                int i = insert(reportgroup);
                this.load(reportgroup);
                return i;
            }
            else
                return update(reportgroup);
        }
        #endregion

        #region Insert
        public int insert(ReportGroupVo reportgroup)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.Append("INSERT INTO reportgroup");
            this.QUERY.AppendLine("(descricao)");

            this.QUERY.Append("VALUES(");
            this.QUERY.Append("'" + reportgroup.DESCRICAO + "'");
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(ReportGroupVo reportgroup)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("UPDATE reportgroup");
            this.QUERY.AppendLine("   SET");
            this.QUERY.AppendLine("descricao = '" + reportgroup.DESCRICAO + "'");
            this.QUERY.AppendLine(" WHERE id =  " + reportgroup.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<ReportGroupVo> reportgroups)
        {
            int cont = 0;
            foreach (ReportGroupVo reportgroup in reportgroups)
                cont += delete(reportgroup);
            return cont;
        }
        public int delete(ReportGroupVo reportgroup)
        {
            return delete(reportgroup.ID, null);
        }
        /// <summary>
        /// DELETA TUDO !!!!!!!!!!!!!!!!
        /// </summary>
        /// <returns></returns>
        public int delete()
        {
            return delete(0, null);
        }
        public int delete(string filtro)
        {
            return delete(0, filtro);
        }
        public int delete(int id)
        {
            return delete(id, null);
        }
        public int delete(int id, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);
            
            this.QUERY.AppendLine("DELETE FROM reportgroup");
            if(id > 0)
                this.QUERY.AppendLine(" WHERE id = " + id);
            if (filtro != null)
                this.QUERY.AppendLine("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Listas
        public List<string> getCodigoAsList(int id)
        {
            return getColunaAsList(getDescricao(id));
        }
        #endregion

        #region Colunas
        public DataTable getDescricao(int id)
        {
            return getColunas(id, "codigo");
        }
        public DataTable getColunas(int id, string colunas)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
            this.QUERY.AppendLine("  FROM reportgroup");
            this.QUERY.AppendLine(" WHERE id = " + id);

            return getData();
        }
        #endregion

        #region Select
        public DataTable select()
        {
            return select(null, false);
        }
        public DataTable select(string descricao)
        {
            return select(descricao, null, false);
        }
        public DataTable select(string descricao, string filtro)
        {
            return select(descricao, filtro, false);
        }
        public DataTable select(string descricao, bool firstOnly)
        {
            return select(descricao, null, firstOnly);
        }
        public DataTable select(string descricao, string filtro, bool firstOnly)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.Append("SELECT");
            this.QUERY.AppendLine(firstOnly ? "TOP 1 *" : "*");
            this.QUERY.AppendLine("  FROM reportgroup");
            if (descricao != null)
                this.QUERY.AppendLine(" WHERE descricao = '" + descricao+"'");
            if (filtro != null)
                this.QUERY.AppendLine(filtro);

            return getData();
        }
        #endregion

        #region Load
        public void load(ReportGroupVo reportgroup)
        {
            load(reportgroup, null);
        }
        public void load(ReportGroupVo reportgroup, string filtro)
        {
            DataTable table = select(reportgroup.DESCRICAO, filtro, false);
            if (table.DefaultView.Count > 0)
            {
                reportgroup.ID        = (int)   table.DefaultView[0]["id"];
                reportgroup.DESCRICAO = (string)table.DefaultView[0]["descricao"];
            }
        }
        #endregion
    }
}
