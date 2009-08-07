using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Table
{
    public class TableVo
    {
        private int    id       =  0;
        private int    relatedindex = 0;
        private string tabela       = "";
        private string relatedtype  = "";
        private string relatedident = "";
        private string sufixo       = "";
        
        private Report.ReportVo mainReport = null;
        private TableVo         parent     = null;
        private TableVo         related    = null;

        #region [Private Lists]
        private List<TableVo>           children   = new List<TableVo>();
        private List<Fields.FieldsVo  > fields     = new List<Fields.FieldsVo  >();
        private List<GroupBy.GroupByVo> groupby    = new List<GroupBy.GroupByVo>();
        private List<Filters.FiltersVo> filters    = new List<Filters.FiltersVo>();
        private List<OrderBy.OrderByVo> orderby    = new List<OrderBy.OrderByVo>();
        private List<Params.ParamsVo  > parameters = new List<Params.ParamsVo  >();
        #endregion

        #region [Getters & Setters]
        public int    ID          
        {
            get { return id; }
            set { this.id = value; }
        }
        public int    IDREPORT    
        {
            get
            {
                if( this.REPORT != null )
                    return this.REPORT.ID;

                return 0;
            }
            set
            {
                if( this.REPORT != null )
                    this.REPORT.ID = value;
            }
        }
        public int    MAINID      
        {
            get
            {
                if( parent != null )
                    return this.PARENT.ID;
                
                return 0;
            }
            set
            {
                if( parent != null )
                    this.PARENT.ID = value;
            }
        }
        public int    INDEX       
        {
            get
            {
                if( this.parent != null )
                    return parent.CHILDREN.IndexOf(this);
                
                return 0;
            }
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
            get
            {
                if (this.RELATED != null)
                    return this.RELATED.TABELA;
                else
                    return "";
            }
            set
            {
                if( this.RELATED != null )
                    this.RELATED.TABELA = value;
            }
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
        public string SUFIXO      
        {
            get
            {
                return this.PARENT.SUFIXO+"_"+this.INDEX;
            }
            set{ sufixo = value; }
        }
        
        public Report.ReportVo REPORT 
        {
            get
            {
                //if ( this.mainReport != null )
                    return this.mainReport;
            }
            set { this.mainReport = value; }
        }
        public TableVo         PARENT 
        {
            get
            {
                //if( this.parent != null )
                    return parent;
            }
            set
            {
                this.parent = value;
            }
        }
        public TableVo         RELATED
        {
            get
            {
                //if( this.related != null )
                    return related;
            }
            set { related = value; }
        }

        #region Public Lists
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

        #region [CONSTRUCTOR]
        public TableVo() : this(0)
        {
        }
        public TableVo(int id) : this(id, 0)
        {
            this.ID = id;
        }
        public TableVo(int id, int idReport) : this(id, idReport, "", "", "", "")
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

        #region [METHODS]
        
        #region FINDS
        public int FindField(    string strField )
        {
            foreach(Fields.FieldsVo field in this.FIELDS)
                if(field.CODIGO == strField)
                    return this.FIELDS.IndexOf(field);

            return -1;
        }
        public int FindFilter(   string strFilter)
        {
            foreach(Filters.FiltersVo filter in this.FILTERS)
                return -1; // TODO: implementar metodo de pesquisa para este objeto, de forma a trazer unico.
            
            return -1;
        }
        public int FindOrderBy(  string strFilter)
        {
            foreach(OrderBy.OrderByVo order in this.ORDERBY)
                return -1; // TODO: implementar metodo de pesquisa para este objeto, de forma a trazer unico.

            return -1;
        }
        public int FindParameter(string strParam )
        {
            foreach(Params.ParamsVo parm in this.PARAMS)
                return -1; // TODO: implementar metodo de pesquisa para este objeto, de forma a trazer unico.

            return -1;
        }
        public int FindTable(    Table.TableVo child)
        {
            return this.CHILDREN.IndexOf(child);
        }
        #endregion

        #region ADDs
        public void AddField(  Fields.FieldsVo   field )
        {
            if(this.FindField(field.CODIGO)<0)
            {
                field.MAINTABLE = this;
                this.FIELDS.Add(field);
            }
        }
        public void AddFilter( Filters.FiltersVo filter)
        {
            filter.MAINTABLE = this;
            this.FILTERS.Add(filter);
        }
        public void AddOrderBy(OrderBy.OrderByVo order )
        {
            order.MAINTABLE = this;
            this.ORDERBY.Add(order);
        }
        public void AddParam(  Params.ParamsVo   parm  )
        {
            parm.MAINTABLE = this;
            this.PARAMS.Add(parm);
        }
        public void AddChild(  Table.TableVo     child )
        {
            child.MAINID = this.ID;
            //child.INDEX  = this.CHILDREN.Count;
            //child.SUFIXO = this.SUFIXO+"_"+child.INDEX;

            child.PARENT = this;
            child.REPORT = this.REPORT;

            this.CHILDREN.Add(child);
        }
        #endregion

        #region REMOVEs
        public void RemoveField(    Fields.FieldsVo   field )
        {
            int idx = this.FindField(field.CODIGO);
            if (idx >=0)
                this.FIELDS.RemoveAt(idx);
        }
        public void RemoveFilter(   Filters.FiltersVo filter)
        {
            this.FILTERS.Remove(filter);
        }
        public void RemoveOrderBy(  OrderBy.OrderByVo order )
        {
            this.ORDERBY.Remove(order);
        }
        public void RemoveParameter(Params.ParamsVo   parm  )
        {
            this.PARAMS.Remove(parm);
        }
        public void RemoveTable(    Table.TableVo     child )
        {
            this.CHILDREN.Remove(child);

            /*
            foreach(Table.TableVo _child in this.CHILDREN)
            {
                _child.INDEX  = this.CHILDREN.IndexOf(_child);
                _child.SUFIXO = this.SUFIXO+"_"+_child.INDEX;
            }
            //*/
        }
        #endregion

        /*
        public void ReSUFIXO()
        {
            foreach(Table.TableVo _child in this.CHILDREN)
            {
                _child.INDEX  = this.CHILDREN.IndexOf(_child);
                _child.SUFIXO = this.SUFIXO+"_"+_child.INDEX;

                _child.ReSUFIXO();
            }
        }//*/

        public List<TableVo> getTables()
        {
            List<TableVo> tabRelations = new List<TableVo>();
            tabRelations.Add(this);

            foreach(TableVo tabChild in this.CHILDREN)
            {
                tabRelations.Add(tabChild);
            }

            return tabRelations;
        }

        public void RealocRelations()
        {
            foreach(TableVo tabChild in this.CHILDREN)
            {
                tabChild.RELATED = this.getTables()[tabChild.RELATEDINDEX];

                tabChild.RealocRelations();
            }
        }
        #endregion
    }
}