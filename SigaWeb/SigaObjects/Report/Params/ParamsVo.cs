using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Params
{
    public class ParamsVo
    {
        private int id = 0, mainId = 0;
        
        private int tamanho;
        private string tabela, campo, formato;

        #region Getters & Setters
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }

        public int MAINID
        {
            get { return mainId; }
            set { this.mainId = value; }
        }

        public int TAMANHO
        {
            get { return tamanho; }
            set { this.tamanho = value; }
        }

        public string TABELA
        {
            get { return tabela; }
            set { this.tabela = value; }
        }

        public string CAMPO
        {
            get { return campo; }
            set { this.campo = value; }
        }

        public string FORMATO
        {
            get { return formato; }
            set { this.formato = value; }
        }
        #endregion

        #region Construtor
        public ParamsVo() { }
        public ParamsVo(int mainId)
        {
            this.MAINID     = mainId;
        }
        public ParamsVo(int mainId, string tabela, string campo, string formato)
        {
            this.MAINID     = mainId;
            this.TABELA     = tabela;
            this.CAMPO      = campo;
            this.FORMATO    = formato;
        }
        public ParamsVo(int id, int mainId)
        {
            this.ID         = id;
            this.MAINID     = mainId;
        }
        public ParamsVo(int id, int mainId, string tabela, string campo, string formato)
        {
            this.ID         = id;
            this.MAINID     = mainId;
            this.TABELA     = tabela;
            this.CAMPO      = campo;
            this.FORMATO    = formato;
        }
        #endregion

    }
}
