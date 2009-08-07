using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.OrderBy
{
    public class OrderByVo
    {
        private int id = 0;

        private int           indice    = 0;
        private string        value     = "", display = "";
        private Table.TableVo mainTable = null;

        #region Construtor
        public OrderByVo()
        {
        }
        public OrderByVo(int indice, int mainId)
        {
            this.INDICE     = indice;
            this.MAINID     = mainId;
        }
        public OrderByVo(int indice, Table.TableVo table, string value, string display)
        {
            this.INDICE     = indice;
            this.MAINTABLE  = table;
            this.VALUE      = value;
            this.DISPLAY    = display;
        }
        public OrderByVo(int id, int indice, Table.TableVo table)
        {
            this.ID         = id;
            this.INDICE     = indice;
            this.MAINTABLE  = table;
        }
        public OrderByVo(int id, int indice, Table.TableVo table, string value, string display)
        {
            this.ID         = id;
            this.INDICE     = indice;
            this.MAINTABLE  = table;
            this.VALUE      = value;
            this.DISPLAY    = display;
        }
        #endregion

        #region Getters & Setters
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
        public int    INDICE 
        {
            get { return indice; }
            set { this.indice = value; }
        }
        public string VALUE  
        {
            get { return value; }
            set { this.value = value; }
        }
        public string DISPLAY
        {
            get { return display; }
            set { this.display = value; }
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
    }
}
