using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Params
{
    public class ParamsVo
    {
        private int id = 0, mainId = 0;

        private int tamanho = 0;
        private string tabela = "", campo = "", formato = "", objeto = "";

        #region Getters & Setters
        public int    ID     
        {
            get { return id; }
            set { this.id = value; }
        }
        public int    MAINID 
        {
            get { return mainId; }
            set { this.mainId = value; }
        }
        public int    TAMANHO
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
        public string OBJETO 
        {
            get { return objeto; }
            set { objeto = value;}
        }
        #endregion

        #region Construtor
        public ParamsVo() { }
        public ParamsVo(int mainId)
        {
            this.MAINID = mainId;
        }
        public ParamsVo(int mainId, string tabela, string campo, string formato)
        {
            this.MAINID = mainId;
            this.TABELA = tabela;
            this.CAMPO = campo;
            this.FORMATO = formato;
        }
        public ParamsVo(int id, int mainId)
        {
            this.ID = id;
            this.MAINID = mainId;
        }
        public ParamsVo(int id, int mainId, string tabela, string campo, string formato, string objeto)
        {
            this.ID      = id;
            this.MAINID  = mainId;
            this.TABELA  = tabela;
            this.CAMPO   = campo;
            this.FORMATO = formato;
            this.OBJETO  = objeto;
        }
        #endregion

    }
}
