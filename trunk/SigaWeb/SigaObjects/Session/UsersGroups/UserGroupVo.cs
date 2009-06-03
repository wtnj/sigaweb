using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Session.UsersGroups
{
    public class UserGroupVo
    {
        private int id;
        private string descricao, name;

        #region Getters & Setters
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }
        public string DESCRICAO
        {
            get { return descricao; }
            set { this.descricao = value; }
        }
        public string NAME
        {
            get { return name; }
            set { this.name = value; }
        }
        #endregion

        #region Construtor
        public UserGroupVo() { }
        public UserGroupVo(string descricao, string name)
        {
            this.DESCRICAO = descricao;
            this.NAME = name;
        }
        public UserGroupVo(int id, string descricao, string name)
        {
            this.ID = id;
            this.DESCRICAO = descricao;
            this.NAME = name;
        }
        #endregion
    }
}