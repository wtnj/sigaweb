using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Session.SysUsers
{
    public class SysUserVo
    {
        private int    id = 0, idUserGroup = 0, maildoor = 25;
        private string username   = "", password = "", name       = "", fullname    = "",
                       mailserver = "", mailuser = "", mailpasswd = "", mailaddress = "" ;

        #region Getters & Setters
        public int    ID         
        {
            get { return id; }
            set { this.id = value; }
        }
        public int    IDUSERGROUP
        {
            get { return idUserGroup; }
            set { this.idUserGroup = value; }
        }
        public string USERNAME   
        {
            get { return username; }
            set { this.username = value; }
        }
        public string PASSWORD   
        {
            get { return password; }
            set { this.password = value; }
        }
        public string NAME       
        {
            get { return name; }
            set { this.name = value; }
        }
        public string FULLNAME   
        {
            get { return fullname; }
            set { this.fullname = value; }
        }

        public string MAILSERVER 
        {
            get { return this.mailserver; }
            set { this.mailserver = value; }
        }
        public int    MAILDOOR   
        {
            get { return this.maildoor; }
            set { this.maildoor = value; }
        }
        public string MAILUSER   
        {
            get { return this.mailuser; }
            set { this.mailuser = value; }
        }
        public string MAILPASSWD 
        {
            get { return this.mailpasswd; }
            set { this.mailpasswd = value; }
        }
        public string MAILADDRESS
        {
            get { return this.mailaddress; }
            set { this.mailaddress = value; }
        }
        #endregion

        #region Construtor
        public SysUserVo() { }
        public SysUserVo(int id)
        {
            this.ID = id;
        }
        public SysUserVo(string username, string password)
        {
            this.USERNAME = username;
            this.PASSWORD = password;
        }
        public SysUserVo(int idUserGroup, string username, string password, string name, string fullname)
        {
            this.IDUSERGROUP = idUserGroup;
            this.USERNAME    = username;
            this.PASSWORD    = password;
            this.NAME        = name;
            this.FULLNAME    = fullname;
        }
        public SysUserVo(int id, int idUserGroup, string username, string password, string name, string fullname)
        {
            this.ID          = id;
            this.IDUSERGROUP = idUserGroup;
            this.USERNAME    = username;
            this.PASSWORD    = password;
            this.NAME        = name;
            this.FULLNAME    = fullname;
        }
        #endregion
    }
}