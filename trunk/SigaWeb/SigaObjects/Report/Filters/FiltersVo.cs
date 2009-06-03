using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Filters
{
    public class FiltersVo
    {
        private int id = 0, mainId = 0;

        private string tabela, campo, filtro, tipofiltro;

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
        public int ID
        {
            get { return id; }
            set { this.id = value;  }
        }

        public int MAINID
        {
            get { return mainId; }
            set { this.mainId = value;  }
        }

        public string TABELA
        {
            get { return tabela; }
            set { this.tabela = value;  }
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
        #endregion
    }
}
