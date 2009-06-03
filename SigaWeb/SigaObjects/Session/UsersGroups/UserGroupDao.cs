using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Session.UsersGroups
{
    public class UserGroupDao : SELECT
    {
        #region Members
        public static String ValueMember
        {
            get { return "id"; }
        }
        public static String DisplayMember
        {
            get { return "name"; }
        }
        #endregion

        #region Save
        public int save(List<UserGroupVo> userGroups)
        {
            int cont = 0;
            foreach (UserGroupVo userGroup in userGroups)
                cont += save(userGroup);
            return cont;
        }
        public int save(UserGroupVo userGroup)
        {
            load(userGroup, userGroup.NAME);

            if (userGroup.ID == 0)
                return insert(userGroup);
            else
                return update(userGroup);
        }
        #endregion

        #region Insert
        public int insert(UserGroupVo userGroup)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.QUERY.Append("INSERT INTO UsersGroups");
                this.QUERY.AppendLine("([name], descricao)");

                this.QUERY.Append("VALUES(");
                this.QUERY.Append("'" + userGroup.NAME + "',");
                this.QUERY.Append("'" + userGroup.DESCRICAO + "'");
                this.QUERY.AppendLine(")");

                return getData().DefaultView.Count;
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Update
        public int update(UserGroupVo userGroup)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.QUERY.AppendLine("UPDATE UsersGroups");
                this.QUERY.AppendLine("   SET ");
                this.QUERY.AppendLine("       [name]    = '" + userGroup.NAME + "'");
                this.QUERY.AppendLine("      ,descricao = '" + userGroup + "'");
                this.QUERY.AppendLine(" WHERE id        = " + userGroup.ID);

                return getData().DefaultView.Count;
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Delete
        public int delete(List<UserGroupVo> userGroups)
        {
            int cont = 0;
            foreach (UserGroupVo userGroup in userGroups)
                cont += delete(userGroup);
            return cont;
        }
        public int delete(UserGroupVo userGroup)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.QUERY.AppendLine("DELETE FROM UsersGroups");
                this.QUERY.AppendLine(" WHERE id = " + userGroup.ID);

                return getData().DefaultView.Count;
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Listas
        public List<string> getNamesAsList()
        {
            return getColunaAsList(getNames());
        }
        public List<string> getDescricoesAsList()
        {
            return getColunaAsList(getDescricoes());
        }
        #endregion

        #region Colunas
        public DataTable getNames()
        {
            return getColunas("[name]");
        }
        public DataTable getDescricoes()
        {
            return getColunas("descricao");
        }
        public DataTable getColunas(string colunas)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
                this.QUERY.AppendLine("  FROM UsersGroups");
                this.QUERY.AppendLine(" ORDER BY [name]");

                return getData();
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Select
        public DataTable select()
        {
            return select(null, false);
        }
        public DataTable select(string filtro)
        {
            return select(filtro, false);
        }
        public DataTable select(bool firstOnly)
        {
            return select(null, firstOnly);
        }
        public DataTable select(string filtro, bool firstOnly)
        {
            try
            {
                new SELECT(firstOnly ? "TOP 1 *" : "*")
                .From("UsersGroups")
                .Where(filtro);

                return getData();
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Load
        public void load(List<UserGroupVo> userGroups)
        {
            DataTable table = select();
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                UserGroupVo userGroup = new UserGroupVo();

                userGroup.ID = (int)table.DefaultView[i]["id"];
                userGroup.NAME = (string)table.DefaultView[i]["[name]"];
                userGroup.DESCRICAO = (string)table.DefaultView[i]["descricao"];

                userGroups.Add(userGroup);
            }
        }
        public void load(UserGroupVo userGroup, string name)
        {
            DataTable table = select("name = '" + name + "'");
            if (table.DefaultView.Count > 0)
            {
                userGroup.ID = (int)table.DefaultView[0]["id"];
                userGroup.NAME = (string)table.DefaultView[0]["name"];
                userGroup.DESCRICAO = (string)table.DefaultView[0]["descricao"];
            }
        }
        #endregion
    }
}