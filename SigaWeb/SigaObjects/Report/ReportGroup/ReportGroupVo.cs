using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.ReportGroup
{
    public class ReportGroupVo
    {
        private int id;
        private string descricao;

        #region Getters & Setters
        public int ID
        {
            get { return id;}
            set { this.id = value; }
        }
        public string DESCRICAO
        {
            get { return descricao;}
            set { this.descricao = value; }
        }
        #endregion

        #region Construtor
        public ReportGroupVo(){}
        public ReportGroupVo(int id)
        {
            this.ID = id;
        }
        public ReportGroupVo(string descricao)
        {
            this.DESCRICAO = descricao;
        }
        public ReportGroupVo(int id, string descricao)
        {
            this.ID = id;
            this.DESCRICAO = descricao;
        }
        #endregion
    }
}
