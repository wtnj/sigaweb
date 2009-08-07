using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Fields
{
    public class FieldsVo
    {
        private int id = 0;

        private string codigo = "", grouping = "";
        private Table.TableVo mainTable = null;

        #region Getters and Setters
        public int    ID      
        {
            get { return id; }
            set { this.id = value; }
        }
        public int    MAINID  
        {
            get { return this.MAINTABLE.ID;  }
            set { this.MAINTABLE.ID = value; }
        }
        public string GROUPING
        {
            get { return grouping; }
            set { this.grouping = value; }
        }
        public string CODIGO  
        {
            get { return codigo; }
            set { this.codigo = value; }
        }

        public Table.TableVo MAINTABLE
        {
            get
            {
                if( this.mainTable != null )
                    return this.mainTable;
                else
                    return new Table.TableVo();
            }
            set { this.mainTable = value; }
        }
        #endregion

        #region Construtor
        public FieldsVo()
        {
        }
        public FieldsVo(int id)
        {
            this.ID = id;
        }
        public FieldsVo(Table.TableVo table, string grouping)
        {
            this.MAINTABLE = table;
            this.GROUPING = grouping;
        }
        public FieldsVo(Table.TableVo table, string grouping, string codigo)
        {
            this.MAINTABLE = table;
            this.GROUPING  = grouping;
            this.CODIGO    = codigo;
        }
        public FieldsVo(Table.TableVo table, string grouping, string codigo, int id)
        {
            this.MAINTABLE = table;
            this.GROUPING  = grouping;
            this.CODIGO    = codigo;
            this.ID        = id;
        }
        #endregion
    }
}