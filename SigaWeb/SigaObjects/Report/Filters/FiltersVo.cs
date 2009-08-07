using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Filters
{
    public class FiltersVo
    {
        private int id = 0;

        private string campo = "", filtro = "", tipofiltro = "";
        private Table.TableVo mainTable = null;

        #region Construtor
        public FiltersVo() { }
        public FiltersVo(int mainId)
        {
            this.MAINID     = mainId;
        }
        public FiltersVo(int mainId, string tabela, string campo, string filtro, string tipofiltro)
        {
            this.MAINID     = mainId;
            this.TABELA     = tabela;
            this.CAMPO      = campo;
            this.FILTRO     = filtro;
            this.TIPOFILTRO = tipofiltro;
        }
        public FiltersVo(int id, int mainId)
        {
            this.ID         = id;
            this.MAINID     = mainId;
        }
        public FiltersVo(int id, int mainId, string tabela, string campo, string filtro, string tipofiltro)
        {
            this.ID         = id;
            this.MAINID     = mainId;
            this.TABELA     = tabela;
            this.CAMPO      = campo;
            this.FILTRO     = filtro;
            this.TIPOFILTRO = tipofiltro;
        }
        #endregion

        #region Getters & Setters
        public int    ID        
        {
            get { return id; }
            set { this.id = value;  }
        }
        public int    MAINID    
        {
            get { return this.MAINTABLE.ID;  }
            set { this.MAINTABLE.ID = value; }
        }
        public string TABELA    
        {
            get { return this.MAINTABLE.TABELA;  }
            set { this.MAINTABLE.TABELA = value; }
        }
        public string CAMPO     
        {
            get { return campo; }
            set { this.campo = value;  }
        }
        public string FILTRO    
        {
            get { return filtro; }
            set { this.filtro = value;  }
        }
        public string TIPOFILTRO
        {
            get { return tipofiltro; }
            set { this.tipofiltro = value;  }
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
