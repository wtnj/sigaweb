using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Cadastros.ContasAPagar
{
    public class ContasAPagarVO
    {
        #region ATRIBUTOS
        private int    id = 0, status = 2, userid = 0;
        private string empresa   = "", filial     = "", prefixo    = "", numtitulo = ""
                     , parcela   = "", natureza   = "", fornecedor = "", loja      = ""
                     , emissao   = DateTime.Now.ToString("yyyyMMdd"), vencimento = DateTime.Now.ToString("yyyyMMdd")
                     , historico = "", obs_sol    = "", obs_apr    = "";
        private decimal valor, iss, irrf, inss, cofins, pispasep, csll;
        #endregion

        #region PROPRIEDADES
        public int      ID              
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string   EMPRESA         
        {
            get { return this.empresa; }
            set { this.empresa = value; }
        }  
        public string   FILIAL          
        {
            get { return this.filial; }
            set { this.filial = value; }
        }
        public string   PREFIXO         
        {
            get { return this.prefixo; }
            set { this.prefixo = value; }
        }
        public string   NUMTITULO       
        {
            get { return this.numtitulo; }
            set { this.numtitulo = value; }
        }
        public string   PARCELA         
        {
            get { return this.parcela; }
            set { this.parcela = value; }
        }
        public string   NATUREZA        
        {
            get { return this.natureza; }
            set { this.natureza = value; }
        }
        public string   FORNECEDOR      
        {
            get { return this.fornecedor; }
            set { this.fornecedor = value; }
        }
        public string   LOJA            
        {
            get { return this.loja; }
            set { this.loja = value; }
        }
        public DateTime EMISSAO         
        {
            get { return Carralero.Funcoes.getDateTime(this.emissao); }
            set { this.emissao = value.ToString("yyyyMMdd"); }
        }
        public DateTime VENCIMENTO      
        {
            get { return Carralero.Funcoes.getDateTime(this.vencimento); }
            set { this.vencimento = value.ToString("yyyyMMdd"); }
        }
        public decimal  VALOR           
        {
            get { return this.valor; }
            set { this.valor = value; }
        }
        public decimal  ISS             
        {
            get { return this.iss; }
            set { this.iss = value; }
        }
        public decimal  IRRF            
        {
            get { return this.irrf; }
            set { this.irrf = value; }
        }
        public string   HISTORICO       
        {
            get { return this.historico; }
            set { this.historico = value; }
        }
        public decimal  INSS            
        {
            get { return this.inss; }
            set { this.inss = value; }
        }
        public decimal  COFINS          
        {
            get { return this.cofins; }
            set { this.cofins = value; }
        }
        public decimal  PISPASEP        
        {
            get { return this.pispasep; }
            set { this.pispasep = value; }
        }
        public decimal  CSLL            
        {
            get { return this.csll; }
            set { this.csll = value; }
        }
        public string   ObsSolicitante  
        {
            get { return this.obs_sol; }
            set { this.obs_sol = value; }
        }
        public string   ObsAprovador    
        {
            get { return this.obs_apr; }
            set { this.obs_apr = value; }
        }
        public int      STATUS          
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public int      USERID          
        {
            get { return userid;  }
            set { userid = value; }
        }

        public string   EMISSAOstr      
        {
            get { return this.emissao; }
            set { this.emissao = value; }
        }
        public string   VENCIMENTOstr   
        {
            get { return this.vencimento; }
            set { this.vencimento = value; }
        }
        #endregion

        public ContasAPagarVO()
        { }
        public ContasAPagarVO(string empresa, string filial, int userid)
        {
            this.EMPRESA = emissao;
            this.FILIAL  = filial;
            this.USERID  = userid;
        }
    }
}
