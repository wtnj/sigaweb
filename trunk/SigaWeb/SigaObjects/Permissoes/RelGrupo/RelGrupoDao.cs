using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Permissoes.RelGrupo
{
    public class RelGrupoDao : SELECT
    {
        private string table = "permissaoRelGrupo";

        #region Members
        public String ValueMember
        {
            get { return "id"; }
        }
        public String DisplayMember
        {
            get { return "nivel"; }
        }
        #endregion

        #region Commit
        public int commit(List<RelGrupoVo> relGrupos)
        {
            int cont = 0;
            foreach (RelGrupoVo relGrupo in relGrupos)
                cont += commit(relGrupo);
            return cont;
        }
        public int commit(RelGrupoVo relGrupo)
        {
            if (relGrupo.NIVEL == 0)
                return delete(relGrupo);
            else if (relGrupo.ID == 0)
                return insert(relGrupo);
            else
                return update(relGrupo);
        }
        #endregion

        #region Insert
        public int insert(List<RelGrupoVo> relGrupos)
        {
            int cont = 0;
            foreach (RelGrupoVo relGrupo in relGrupos)
                cont += insert(relGrupo);
            return cont;
        }
        public int insert(RelGrupoVo relGrupo)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.Append("INSERT INTO " + table + " ");
            this.QUERY.AppendLine("(idReport, idUserGroup, nivel)");
            this.QUERY.Append("VALUES(");
            this.QUERY.Append("" + relGrupo.IDREPORT    + ",");
            this.QUERY.Append("" + relGrupo.IDUSERGROUP + ",");
            this.QUERY.Append("" + relGrupo.NIVEL       + "");
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(List<RelGrupoVo> relGrupos)
        {
            int cont = 0;
            foreach (RelGrupoVo relGrupo in relGrupos)
                cont += update(relGrupo);
            return cont;
        }
        public int update(RelGrupoVo relGrupo)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("UPDATE " + table);
            this.QUERY.AppendLine("   SET idReport    = " + relGrupo.IDREPORT   );
            this.QUERY.AppendLine("     , idUserGroup = " + relGrupo.IDUSERGROUP);
            this.QUERY.AppendLine("     , nivel       = " + relGrupo.NIVEL      );
            this.QUERY.AppendLine(" WHERE id = " + relGrupo.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<RelGrupoVo> relGrupos)
        {
            int cont = 0;
            foreach (RelGrupoVo relGrupo in relGrupos)
                cont += delete(relGrupo);
            return cont;
        }
        public int delete(RelGrupoVo relGrupo)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM " + table);
            this.QUERY.AppendLine(" WHERE id = " + relGrupo.ID);

            return getData().DefaultView.Count;
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

            this.QUERY.AppendLine(fromDatabase);
            this.QUERY.AppendLine("-- ----- --");
            this.QUERY.AppendLine("SET NOCOUNT ON");
            this.QUERY.AppendLine(" IF Object_Id('perm_temp','U') Is Not Null");
            this.QUERY.AppendLine("   BEGIN");
            this.QUERY.AppendLine("      DROP TABLE perm_temp");
            this.QUERY.AppendLine("   END");
            this.QUERY.AppendLine("CREATE TABLE perm_temp ( idUserGroup   Int,");
            this.QUERY.AppendLine("                         idReport Int,");
            this.QUERY.AppendLine("                         nivel    Int)");
            this.QUERY.AppendLine("DECLARE @idUserGroup   Int");
            this.QUERY.AppendLine("DECLARE @nivel    Int");
            this.QUERY.AppendLine("DECLARE usuario CURSOR FOR");
            this.QUERY.AppendLine("SELECT id,0 nivel");
            this.QUERY.AppendLine("  FROM UsersGroups");
            this.QUERY.AppendLine("  OPEN usuario");
            this.QUERY.AppendLine(" FETCH NEXT FROM usuario INTO @idUserGroup,@nivel");
            this.QUERY.AppendLine(" WHILE @@FETCH_STATUS = 0");
            this.QUERY.AppendLine(" BEGIN");
            this.QUERY.AppendLine("    IF (SELECT COUNT(*) FROM report) > 0");
            this.QUERY.AppendLine("         BEGIN");
            this.QUERY.AppendLine("        INSERT");
            this.QUERY.AppendLine("          INTO perm_temp");
            this.QUERY.AppendLine("        SELECT @idUserGroup,id id_report,@nivel");
            this.QUERY.AppendLine("          FROM report");
            this.QUERY.AppendLine("           END");
            this.QUERY.AppendLine("         FETCH NEXT FROM usuario INTO @idUserGroup,@nivel");
            this.QUERY.AppendLine("   END");
            this.QUERY.AppendLine(" CLOSE usuario");
            this.QUERY.AppendLine("DEALLOCATE usuario");

            this.QUERY.AppendLine("UPDATE perm_temp");
            this.QUERY.AppendLine("   SET nivel = PRG.nivel");
            this.QUERY.AppendLine("  FROM perm_temp temp");
            this.QUERY.AppendLine(" INNER JOIN permissaoRelGrupo PRG");
            this.QUERY.AppendLine("    ON PRG.idUserGroup   = temp.idUserGroup");
            this.QUERY.AppendLine("   AND PRG.idReport = temp.idReport");

            this.QUERY.AppendLine("SELECT isnull(PRG.id,0) id, UG.id idUserGroup, UG.name [Grupo]");
            this.QUERY.AppendLine("     , RR.id idReport    , RR.nome [Relatório]");
            this.QUERY.AppendLine("     , PT.nivel [Nível]  , isnull(PRG.id, 0) id");
            this.QUERY.AppendLine("  FROM perm_temp PT");
            this.QUERY.AppendLine(" INNER JOIN UsersGroups UG");
            this.QUERY.AppendLine("    ON UG.id = PT.idUserGroup");
            this.QUERY.AppendLine(" INNER JOIN report RR");
            this.QUERY.AppendLine("    ON RR.id = PT.idReport");
            this.QUERY.AppendLine("  LEFT JOIN permissaoRelGrupo PRG");
            this.QUERY.AppendLine("    ON PRG.idReport = RR.id");
            this.QUERY.AppendLine("   AND PRG.idUserGroup = UG.id");
            if (filtro != null)
                this.QUERY.AppendLine(" WHERE " + filtro);
            this.QUERY.AppendLine("DROP TABLE perm_temp");

            return getData();

        }
        #endregion
    }
}