using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Table
{
    public class TableVo
    {
        private int    id       = 0;
        private int    idReport = 0;
        private int    mainId   = 0;
        private int    indice   = 0;
        private int    relatedindex = 0;
        private string tabela       = "";
        private string relatedtype  = "";
        private string relatedtable = "";
        private string relatedident = "";

        #region [Private Lists]
        private List<TableVo>           children   = new List<TableVo>();
        private List<Fields.FieldsVo  > fields     = new List<Fields.FieldsVo  >();
        private List<GroupBy.GroupByVo> groupby    = new List<GroupBy.GroupByVo>();
        private List<Filters.FiltersVo> filters    = new List<Filters.FiltersVo>();
        private List<OrderBy.OrderByVo> orderby    = new List<OrderBy.OrderByVo>();
        private List<Params.ParamsVo  > parameters = new List<Params.ParamsVo  >();
        #endregion

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
        public int    INDEX       
        {
            get { return indice; }
            set { indice = value;}
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
        public int    RELATEDINDEX
        {
            get { return relatedindex;  }
            set { relatedindex = value; }
        }
        public string RELATEDIDENT
        {
            get { return this.relatedident; }
            set { this.relatedident = value; }
        }

        #region [Public Lists]
        public List<TableVo>           CHILDREN
        {
            get { return children;  }
            set { children = value; }
        }
        public List<Fields.FieldsVo  > FIELDS  
        {
            get { return fields;  }
            set { fields = value; }
        }
        public List<GroupBy.GroupByVo> GROUPBY 
        {
            get { return groupby;  }
            set { groupby = value; }
        }
        public List<Filters.FiltersVo> FILTERS 
        {
            get { return filters;  }
            set { filters = value; }
        }
        public List<OrderBy.OrderByVo> ORDERBY 
        {
            get { return orderby;  }
            set { orderby = value; }
        }
        public List<Params.ParamsVo  > PARAMS  
        {
            get { return parameters;  }
            set { parameters = value; }
        }
        #endregion
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