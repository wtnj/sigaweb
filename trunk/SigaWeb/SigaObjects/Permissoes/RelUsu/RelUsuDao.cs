using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Carralero;

namespace SigaObjects.Permissoes.RelUsu
{
    public class RelUsuDao : SELECT
    {
        private string table = "permissaoRelUsu";

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

        #region Select
        public DataTable select()
        {
            return select(null);
        }
        public DataTable select(string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("SET NOCOUNT ON");
            this.QUERY.AppendLine(" IF Object_Id('perm_temp','U') Is Not Null");
            this.QUERY.AppendLine("   BEGIN");
            this.QUERY.AppendLine("      DROP TABLE perm_temp");
            this.QUERY.AppendLine("   END");
            this.QUERY.AppendLine("CREATE TABLE perm_temp ( idUser   Int,");
            this.QUERY.AppendLine("                         idReport Int,");
            this.QUERY.AppendLine("                         nivel    Int)");

            this.QUERY.AppendLine("DECLARE @idUser   Int");
            this.QUERY.AppendLine("DECLARE @nivel    Int");

            this.QUERY.AppendLine("DECLARE usuario CURSOR FOR");
            this.QUERY.AppendLine("SELECT id,0 nivel");
            this.QUERY.AppendLine("  FROM SigaUsers");
            this.QUERY.AppendLine("  OPEN usuario");
            this.QUERY.AppendLine(" FETCH NEXT FROM usuario INTO @idUser,@nivel");
            this.QUERY.AppendLine(" WHILE @@FETCH_STATUS = 0");
            this.QUERY.AppendLine(" BEGIN");
            this.QUERY.AppendLine("    IF (SELECT COUNT(*) FROM report) > 0");
            this.QUERY.AppendLine("         BEGIN");
            this.QUERY.AppendLine("        INSERT");
            this.QUERY.AppendLine("          INTO perm_temp");
            this.QUERY.AppendLine("        SELECT @idUser,id id_report,@nivel");
            this.QUERY.AppendLine("          FROM report");
            this.QUERY.AppendLine("           END");
            this.QUERY.AppendLine("         FETCH NEXT FROM usuario INTO @idUser,@nivel");
            this.QUERY.AppendLine("   END");
            this.QUERY.AppendLine(" CLOSE usuario");
            this.QUERY.AppendLine("DEALLOCATE usuario");
            
            this.QUERY.AppendLine("UPDATE perm_temp");
            this.QUERY.AppendLine("   SET nivel = PRU.nivel");
            this.QUERY.AppendLine("  FROM perm_temp temp");
            this.QUERY.AppendLine(" INNER JOIN permissaoRelUsu PRU");
            this.QUERY.AppendLine("    ON PRU.idUser   = temp.idUser");
            this.QUERY.AppendLine("   AND PRU.idReport = temp.idReport");
            
            this.QUERY.AppendLine("SELECT isnull(PRU.id,0) id, SU.id idUser, SU.username [Usuário]");
            this.QUERY.AppendLine("     , RR.id idReport , RR.nome [Relatório]");
            this.QUERY.AppendLine("     , PT.nivel [Nível]");
            this.QUERY.AppendLine("  FROM perm_temp PT");
            this.QUERY.AppendLine(" INNER JOIN SigaUsers SU");
            this.QUERY.AppendLine("    ON SU.id = PT.idUser");
            this.QUERY.AppendLine(" INNER JOIN report RR");
            this.QUERY.AppendLine("    ON RR.id = PT.idReport");
            this.QUERY.AppendLine(" LEFT JOIN permissaoRelUsu PRU");
            this.QUERY.AppendLine("    ON PRU.idUser = SU.id");
            this.QUERY.AppendLine("   AND PRU.idReport = RR.id");
            if(filtro != null)
                this.QUERY.AppendLine(" WHERE " + filtro);
            this.QUERY.AppendLine("DROP TABLE perm_temp");

            return getData();
        }
        #endregion

        #region Delete
        public int delete(List<RelUsuVo> relUsus)
        {
            int cont = 0;
            foreach (RelUsuVo vo in relUsus)
                cont += delete(relUsus);
            return cont;
        }

        public int delete(RelUsuVo relUsu)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM " + table);
            this.QUERY.AppendLine(" WHERE id = " + relUsu.ID);

            return getData().DefaultView.Count;
        }

        // DELETE ANTIGO
        //public int delete(int id)
        //{
        //    return delete(id.ToString());
        //}
        //public int delete(List<string> ids)
        //{
        //    return delete(Funcoes.getStringArr(ids));
        //}
        //public int delete(string ids)
        //{
        //    this.QUERY = new StringBuilder(fromDatabase);

        //    this.QUERY.AppendLine("DELETE FROM " + table);
        //    this.QUERY.AppendLine(" WHERE id IN (" + ids + ")");

        //    return getData().DefaultView.Count;
        //}
        // DELETE ANTIGO
        #endregion

        #region Commit
        public int commit(List<RelUsuVo> relUsus)
        {
            int cont = 0;
            foreach (RelUsuVo relUsu in relUsus)
                cont += commit(relUsu);
            return cont;
        }
        public int commit(RelUsuVo relUsu)
        {
            if (relUsu.NIVEL == 0)
                return delete(relUsu);
            else if (relUsu.ID == 0)
                return insert(relUsu);
            else
                return update(relUsu);
            
        }
        #endregion

        #region Insert
        public int insert(List<RelUsuVo> relUsus)
        {
            int cont = 0;
            foreach (RelUsuVo relUsu in relUsus)
                cont += insert(relUsu);
            return cont;
        }
        public int insert(RelUsuVo relUsu)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.Append("INSERT INTO " + table);
            this.QUERY.AppendLine("(idUser, idReport, nivel)");

            this.QUERY.Append("VALUES");
            this.QUERY.Append("(");
            this.QUERY.Append("" + relUsu.IDUSER + ",");
            this.QUERY.Append("" + relUsu.IDREPORT + ",");
            this.QUERY.Append("" + relUsu.NIVEL + "");
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(List<RelUsuVo> relUsus)
        {
            int cont = 0;
            foreach (RelUsuVo relUsu in relUsus)
                cont += update(relUsu);
            return cont;
        }
        public int update(RelUsuVo relUsu)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("UPDATE " + table);
            this.QUERY.AppendLine("   SET ");
            this.QUERY.AppendLine("     idReport    = " + relUsu.IDREPORT + ",");
            this.QUERY.AppendLine("     idUser      = " + relUsu.IDUSER + ",");
            this.QUERY.AppendLine("     nivel       = " + relUsu.NIVEL);
            this.QUERY.AppendLine(" WHERE id = " + relUsu.ID);

            return getData().DefaultView.Count;
        }
        #endregion
    }
}