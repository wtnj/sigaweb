using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Session.SysUsers
{
    public class SysUserDao : SELECT
    {
        public SysUserDao()
        {
        }

        #region Members
        public static String ValueMember
        {
            get { return "id"; }
        }
        public static String DisplayMember
        {
            get { return "username"; }
        }
        #endregion

        #region Load
        public void load(List<SysUserVo> users, int idUserGroup)
        {
            DataTable table = select(idUserGroup);
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                SysUserVo user = new SysUserVo();
                user.USERNAME = (string)table.DefaultView[i]["username"];
                
                load(user, user.USERNAME);

                users.Add(user);
            }
        }
        public void load(SysUserVo user, string username)
        {
            string filtro = " username = '" + username + "'";
            load(user, 0, filtro);
        }
        public void load(SysUserVo user, string username, string password)
        {
            string filter = "username = '" + username + "' AND [password] = '" + password + "'";
            load(user, 0, filter);
        }
        public void load(SysUserVo user, int idUserGroup, string filtro)
        {
            DataTable table = select(idUserGroup, filtro, true);
            
            if (table.DefaultView.Count > 0)
            {
                user.ID          = (int)   table.DefaultView[0]["id"         ];
                user.IDUSERGROUP = (int)   table.DefaultView[0]["idUserGroup"];
                user.NAME        = (string)table.DefaultView[0]["name"       ];
                user.FULLNAME    = (string)table.DefaultView[0]["fullname"   ];
                user.PASSWORD    = (string)table.DefaultView[0]["password"   ];
                user.USERNAME    = (string)table.DefaultView[0]["username"   ];
                user.MAILSERVER  = (string)table.DefaultView[0]["MailServer" ];
                user.MAILUSER    = (string)table.DefaultView[0]["MailUser"   ];
                user.MAILPASSWD  = (string)table.DefaultView[0]["MailPasswd" ];
                user.MAILADDRESS = table.DefaultView[0]["MailAddress"].ToString();
                user.MAILDOOR    = (int)   table.DefaultView[0]["MailDoor"   ];
            }
        }
        #endregion

        #region Select
        public DataTable select()
        {
            return select(0, null, false);
        }
        public DataTable select(string username)
        {
            return select(0, "username = '" + username + "'", true);
        }
        public DataTable select(int idUserGroup)
        {
            return select(idUserGroup, null, false);
        }
        public DataTable select(int idUserGroup, string filtro   )
        {
            return select(idUserGroup, filtro, false);
        }
        public DataTable select(int idUserGroup, bool   firstOnly)
        {
            return select(idUserGroup, null, firstOnly);
        }
        public DataTable select(int idUserGroup, string filtro   , bool firstOnly)
        {
            try
            {
                new SELECT(firstOnly ? "TOP 1 *" : "*")
                .From("SigaUsers")
                .Where(idUserGroup == 0
                    ? "idUserGroup != 0"
                    : "idUserGroup  = " + idUserGroup)
                .And(filtro);

                return getData();
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        public DataTable selectGrid()
        {
            try
            {
                this.QUERY = new StringBuilder();

                this.QUERY.AppendLine("use SigaWeb");
                this.QUERY.AppendLine("SELECT ug.[name] [Grupo de Usuários], su.username [Usuário],");
                this.QUERY.AppendLine("       su.[name] [Nome], su.fullname [Nome Completo], su.[password] [Senha]");
                this.QUERY.AppendLine("  FROM SigaUsers su");
                this.QUERY.AppendLine(" INNER JOIN [UsersGroups] ug");
                this.QUERY.AppendLine("    ON ug.id = su.idUserGroup");
                this.QUERY.AppendLine(" ORDER BY ug.[name] ASC, su.username ASC");

                return getData();
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Listas
        public List<string> getPasswordsAsList(int idUserGroup)
        {
            return this.getColunaAsList(getPasswords(idUserGroup));
        }
        public List<string> getUserNamesAsList(int idUserGroup)
        {
            return this.getColunaAsList(getUserNames(idUserGroup));
        }
        public List<string> getNamesAsList(int idUserGroup)
        {
            return this.getColunaAsList(getNames(idUserGroup));
        }
        public List<string> getFullNamesAsList(int idUserGroup)
        {
            return this.getColunaAsList(getFullNames(idUserGroup));
        }
        #endregion

        #region Colunas
        public DataTable getPasswords(int idUserGroup)
        {
            return getColunas(idUserGroup, "[password]");
        }
        public DataTable getUserNames(int idUserGroup)
        {
            return getColunas(idUserGroup, "username");
        }
        public DataTable getNames(int idUserGroup)
        {
            return getColunas(idUserGroup, "[name]");
        }
        public DataTable getFullNames(int idUserGroup)
        {
            return getColunas(idUserGroup, "fullname");
        }
        public DataTable getColunas(int idUserGroup, string colunas)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
                this.QUERY.AppendLine("  FROM SigaUsers");
                this.QUERY.AppendLine(" WHERE idUserGroup = " + idUserGroup);

                return getData();
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Save
        public int save(List<SysUserVo> sysUsers)
        {
            int cont = 0;
            foreach (SysUserVo sysUser in sysUsers)
                cont += save(sysUser);
            return cont;
        }
        public int save(SysUserVo sysUser)
        {
            int iRet = 0;
            if (sysUser.ID == 0)
            {
                iRet = insert(sysUser);
                load(sysUser, sysUser.USERNAME);
            }
            else
                iRet = update(sysUser);
            return iRet;
        }
        #endregion

        #region Insert
        public int insert(SysUserVo sysUser)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.addInQuery("INSERT INTO SigaUsers (idUserGroup, [name], fullname, username, [password], MailServer, MailDoor, MailUser, MailPasswd, MailAddress)");
                this.QUERY.Append("VALUES (");
                this.QUERY.Append("" + sysUser.IDUSERGROUP  + ",");
                this.QUERY.Append("'" + sysUser.NAME        + "',");
                this.QUERY.Append("'" + sysUser.FULLNAME    + "',");
                this.QUERY.Append("'" + sysUser.USERNAME    + "',");
                this.QUERY.Append("'" + sysUser.PASSWORD    + "',");
                this.QUERY.Append("'" + sysUser.MAILSERVER  + "',");
                this.QUERY.Append("'" + sysUser.MAILDOOR    + "',");
                this.QUERY.Append("'" + sysUser.MAILUSER    + "',");
                this.QUERY.Append("'" + sysUser.MAILPASSWD  + "',");
                this.QUERY.Append("'" + sysUser.MAILADDRESS + "'");

                this.addInQuery(")");

                return getData().DefaultView.Count;
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Update
        public int update(SysUserVo sysUser)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.addInQuery("UPDATE SigaUsers");
                this.addInQuery("   SET idUserGroup = " + sysUser.IDUSERGROUP  + "");
                this.addInQuery("     , username    = '" + sysUser.USERNAME    + "'");
                this.addInQuery("     , [password]  = '" + sysUser.PASSWORD    + "'");
                this.addInQuery("     , [name]      = '" + sysUser.NAME        + "'");
                this.addInQuery("     , fullname    = '" + sysUser.FULLNAME    + "'");
                this.addInQuery("     , MailServer  = '" + sysUser.MAILSERVER  + "'");
                this.addInQuery("     , MailDoor    = '" + sysUser.MAILDOOR    + "'");
                this.addInQuery("     , MailUser    = '" + sysUser.MAILUSER    + "'");
                this.addInQuery("     , MailPasswd  = '" + sysUser.MAILPASSWD  + "'");
                this.addInQuery("     , MailAddress = '" + sysUser.MAILADDRESS + "'");
                this.addInQuery(" WHERE id = " + sysUser.ID );

                return getData().DefaultView.Count;
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        #endregion

        #region Delete
        public int delete(List<SysUserVo> sysUsers)
        {
            int cont = 0;
            foreach (SysUserVo sysUser in sysUsers)
                cont += delete(sysUser);
            return cont;
        }
        public int delete(SysUserVo sysUser)
        {
            return delete(sysUser.IDUSERGROUP, "username = '" + sysUser.USERNAME + "'");
        }
        public int delete(int idUserGroup)
        {
            return delete(idUserGroup, null);
        }
        public int delete(int idUserGroup, string filtro)
        {
            try
            {
                this.QUERY = new StringBuilder(fromDatabase);

                this.QUERY.AppendLine("DELETE FROM SigaUsers");
                this.QUERY.AppendLine(" WHERE idUserGroup = " + idUserGroup);
                if (filtro != null)
                    this.QUERY.AppendLine("   AND " + filtro);

                return getData().DefaultView.Count;
            }
            catch (Exception e)
            {
                throw new Exception(Carralero.ExceptionControler.getFullException(e).ToString());
            }
        }
        public int delete(string username)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM SigaUsers");
            this.QUERY.AppendLine(" WHERE username = '" + username + "'");

            return getData().DefaultView.Count;
        }
        #endregion
    }
}