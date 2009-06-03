using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Table
{
    public class TableVo
    {
        private int id, idReport, mainId;
        private string tabela       = "";
        private string relatedtype  = "";
        private string relatedtable = "";
        private string relatedident = "";

        #region Getters & Setters
        public int    ID          
        {
            get { return id; }
            set { this.id = value; }
        }
        public int    IDREPORT    
        {
            get { return idReport; }
            set { this.idReport = value; }
        }
        public int    MAINID      
        {
            get { return mainId; }
            set { this.mainId = value; }
        }
        public string TABELA      
        {
            get { return tabela; }
            set { this.tabela = value; }
        }
        public string RELATEDTYPE 
        {
            get { return relatedtype; }
            set { this.relatedtype = value; }
        }
        public string RELATEDTABLE
        {
            get { return relatedtable; }
            set { this.relatedtable = value; }
        }
        public string RELATEDIDENT
        {
            get { return this.relatedident; }
            set { this.relatedident = value; }
        }
        #endregion

        #region Construtor
        public TableVo()
        {
        }
        public TableVo(int id)
        {
            this.ID = id;
        }
        public TableVo(int id, int idReport)
        {
            this.ID       = id;
            this.IDREPORT = idReport;
        }
        public TableVo(string table, string relatedtype, string relatedtable, string relatedident)
        {
            this.TABELA       = table;
            this.RELATEDTYPE  = relatedtype;
            this.RELATEDTABLE = relatedtable;
            this.RELATEDIDENT = relatedident;
        }
        public TableVo(int idReport, string table, string relatedtype, string relatedtable, string relatedident)
        {
            this.IDREPORT     = idReport;
            this.TABELA       = table;
            this.RELATEDTYPE  = relatedtype;
            this.RELATEDTABLE = relatedtable;
            this.RELATEDIDENT = relatedident;
        }
        public TableVo(int id, int idReport, string table, string relatedtype, string relatedtable, string relatedident)
        {
            this.ID           = id;
            this.IDREPORT     = idReport;
            this.TABELA       = table;
            this.RELATEDTYPE  = relatedtype;
            this.RELATEDTABLE = relatedtable;
            this.RELATEDIDENT = relatedident;
        }
        #endregion
    }
}