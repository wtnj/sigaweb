using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace SigaObjects.Cadastros.ContasAPagar
{
    
    public class ContasAPagarDAO : SELECT
    {
        #region ATRIBUTOS
        private string formato    = "################.##";
        private string showFields = "  STATUS    , EMPRESA, FILIAL , PREFIXO   , NUMTITULO, PARCELA, NATUREZA\n"
                                  + ", FORNECEDOR, LOJA   , EMISSAO, VENCIMENTO, HISTORICO, USERID \n"
                                  + ", Cast(VALOR  as decimal(17,2)) VALOR , Cast(ISS      as decimal(17,2)) ISS      \n"
                                  + ", Cast(IRRF   as decimal(17,2)) IRRF  , Cast(INSS     as decimal(17,2)) INSS     \n"
                                  + ", Cast(COFINS as decimal(17,2)) COFINS, Cast(PISPASEP as decimal(17,2)) PISPASEP \n"
                                  + ", Cast(CSLL   as decimal(17,2)) CSLL  , OBS_SOL, OBS_APR, id \n";

        private string showObs    = "OBS_SOL, OBS_APR";
        #endregion

        #region PROPRIEDADES
        public string ShowFields
        {
            get { return showFields;  }
            set { showFields = value; }
        }
        public string ShowObs
        {
            get { return showObs; }
        }
        #endregion

        #region CONSTRUTOR
        public ContasAPagarDAO()
        { }
        public ContasAPagarDAO(ContasAPagarVO conta)
        {
            throw new Exception("método não implementado.");
        }
        #endregion

        #region save
        public int save(List<ContasAPagarVO> contas)
        {
            int cont = 0;
            foreach (ContasAPagarVO conta in contas)
                cont += save(conta);
            return cont;
        }
        public int save(ContasAPagarVO       conta )
        {
            if (conta.ID == 0)
                return insert(conta);
            else
                return update(conta);
        }
        #endregion

        #region insert
        private int insert(ContasAPagarVO conta)
        {
            this.QUERY = new StringBuilder();
            
            this.QUERY.AppendLine("INSERT INTO CONTASPG");
            this.QUERY.AppendLine("( EMPRESA, FILIAL , PREFIXO   , NUMTITULO, PARCELA, NATUREZA, FORNECEDOR ");
            this.QUERY.AppendLine(", LOJA   , EMISSAO, VENCIMENTO, VALOR    , ISS    , IRRF    , HISTORICO  ");
            this.QUERY.AppendLine(", INSS   , COFINS , PISPASEP  , CSLL     , OBS_SOL, OBS_APR  , STATUS    , USERID)");

            this.QUERY.AppendLine("VALUES(");
            this.QUERY.Append(    "'"  + conta.EMPRESA       + "', ");
            this.QUERY.Append(    "'"  + conta.FILIAL        + "', ");
            this.QUERY.Append(    "'"  + conta.PREFIXO       + "', ");
            this.QUERY.Append(    "'"  + conta.NUMTITULO     + "', ");
            this.QUERY.Append(    "'"  + conta.PARCELA       + "', ");
            this.QUERY.Append(    "'"  + conta.NATUREZA      + "', ");
            this.QUERY.Append(    "'"  + conta.FORNECEDOR    + "', ");
            this.QUERY.AppendLine("'"  + conta.LOJA          + "', ");
            this.QUERY.Append(    "'"  + conta.EMISSAOstr    + "', ");
            this.QUERY.Append(    "'"  + conta.VENCIMENTOstr + "', ");
            this.QUERY.Append(    "'"  + conta.VALOR.ToString(   "0.00", CultureInfo.InvariantCulture) + "', ");
            this.QUERY.Append(    "'"  + conta.ISS.ToString(     "0.00", CultureInfo.InvariantCulture) + "', ");
            this.QUERY.Append(    "'"  + conta.IRRF.ToString(    "0.00", CultureInfo.InvariantCulture) + "', ");
            this.QUERY.Append(    "'"  + conta.HISTORICO     + "', ");
            this.QUERY.AppendLine("'"  + conta.INSS.ToString(    "0.00", CultureInfo.InvariantCulture) + "', ");
            this.QUERY.Append(    "'"  + conta.COFINS.ToString(  "0.00", CultureInfo.InvariantCulture) + "', ");
            this.QUERY.Append(    "'"  + conta.PISPASEP.ToString("0.00", CultureInfo.InvariantCulture) + "', ");
            this.QUERY.Append(    "'"  + conta.CSLL.ToString(    "0.00", CultureInfo.InvariantCulture) + "', ");
            this.QUERY.Append(    "'"  + conta.ObsSolicitante+ "', ");
            this.QUERY.Append(    "'"  + conta.ObsAprovador  + "', ");
            this.QUERY.Append(    "'"  + conta.STATUS        + "', ");
            this.QUERY.Append(    "'"  + conta.USERID        + "'  ");
            this.QUERY.Append(    ")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region update
        private int update(ContasAPagarVO conta)
        {
            this.QUERY = new StringBuilder();
            
            this.QUERY.AppendLine("UPDATE CONTASPG ");
            this.QUERY.AppendLine("   SET EMPRESA    = '" + conta.EMPRESA        + "'");
            this.QUERY.AppendLine("     , FILIAL     = '" + conta.FILIAL         + "'");
            this.QUERY.AppendLine("     , PREFIXO    = '" + conta.PREFIXO        + "'");
            this.QUERY.AppendLine("     , NUMTITULO  = '" + conta.NUMTITULO      + "'");
            this.QUERY.AppendLine("     , PARCELA    = '" + conta.PARCELA        + "'");
            this.QUERY.AppendLine("     , NATUREZA   = '" + conta.NATUREZA       + "'");
            this.QUERY.AppendLine("     , FORNECEDOR = '" + conta.FORNECEDOR     + "'");
            this.QUERY.AppendLine("     , LOJA       = '" + conta.LOJA           + "'");
            this.QUERY.AppendLine("     , EMISSAO    = '" + conta.EMISSAOstr     + "'");
            this.QUERY.AppendLine("     , VENCIMENTO = '" + conta.VENCIMENTOstr  + "'");
            this.QUERY.AppendLine("     , VALOR      = '" + conta.VALOR.ToString(   "0.00", CultureInfo.InvariantCulture) + "'");
            this.QUERY.AppendLine("     , ISS        = '" + conta.ISS.ToString(     "0.00", CultureInfo.InvariantCulture) + "'");
            this.QUERY.AppendLine("     , IRRF       = '" + conta.IRRF.ToString(    "0.00", CultureInfo.InvariantCulture) + "'");
            this.QUERY.AppendLine("     , HISTORICO  = '" + conta.HISTORICO      + "'");
            this.QUERY.AppendLine("     , INSS       = '" + conta.INSS.ToString(    "0.00", CultureInfo.InvariantCulture) + "'");
            this.QUERY.AppendLine("     , COFINS     = '" + conta.COFINS.ToString(  "0.00", CultureInfo.InvariantCulture) + "'");
            this.QUERY.AppendLine("     , PISPASEP   = '" + conta.PISPASEP.ToString("0.00", CultureInfo.InvariantCulture) + "'");
            this.QUERY.AppendLine("     , CSLL       = '" + conta.CSLL.ToString(    "0.00", CultureInfo.InvariantCulture) + "'");
            this.QUERY.AppendLine("     , OBS_SOL    = '" + conta.ObsSolicitante + "'");
            this.QUERY.AppendLine("     , OBS_APR    = '" + conta.ObsAprovador   + "'");
            this.QUERY.AppendLine("     , STATUS     =  " + conta.STATUS         + " ");
            this.QUERY.AppendLine(" WHERE id = " + conta.ID);
            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<ContasAPagarVO> contas)
        {
            int cont = 0;
            foreach (ContasAPagarVO conta in contas)
                cont += delete(conta);
            return cont;
        }
        public int delete(ContasAPagarVO conta)
        {
            return delete(conta.EMPRESA, null, "id = " + conta.ID);
        }
        public int delete(string empresa)
        {
            return delete(empresa, null);
        }
        public int delete(string empresa, string filial)
        {
            return delete(empresa, filial, null);
        }
        public int delete(string empresa, string filial, string filtro)
        {
            this.QUERY = new StringBuilder();
            
            this.QUERY.AppendLine("DELETE");
            this.QUERY.AppendLine("  FROM CONTASPG");
            this.QUERY.AppendLine(" WHERE EMPRESA = " + empresa);

            if(filial != null)
                this.QUERY.AppendLine("   AND FILIAL = " + filial);
            if(filtro != null)
                this.QUERY.AppendLine("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion

        #region SELECT
        public DataTable select(int userid)
        {
            return select(userid, null);
        }
        public DataTable select(int userid, string filtro)
        {
            return select(null, null, userid, null);
        }
        public DataTable select(string empresa)
        {
            return select(empresa, null);
        }
        public DataTable select(string empresa, string filial)
        {
            return select(empresa, filial, 0);
        }
        public DataTable select(string empresa, string filial, int userid)
        {
            return select(empresa, filial, userid, null);
        }
        public DataTable select(string empresa, string filial, int userid, string filtro)
        {
            StringBuilder filtros = new StringBuilder();

            if(empresa!=null)
                filtros.AppendLine((filtros.Length>0?" AND ":"")+" EMPRESA = '" + empresa + "'");
            if(filial != null)
                filtros.AppendLine((filtros.Length>0?" AND ":"")+" FILIAL  = '" + filial  + "'");
            if(userid>0)
                filtros.AppendLine((filtros.Length>0?" AND ":"")+" USERID  = " + userid);
            if(filtro != null)
                filtros.AppendLine((filtros.Length>0?" AND ":"")+filtro);

            return select(filtros.ToString(), null, false);
        }
        public DataTable select(string filtro, string orderby, bool firstOnly)
        {
            this.QUERY = new StringBuilder();
            
            this.QUERY.AppendLine("SELECT " + (firstOnly ? "TOP 1 " + showFields : showFields));
            this.QUERY.AppendLine("  FROM CONTASPG");

            if(filtro != null)
                this.QUERY.AppendLine(" WHERE " + filtro);
            if(orderby != null)
                this.QUERY.AppendLine(" ORDER BY " + orderby);

            return getData();
        }
        #endregion

        #region Load
        public void load(ContasAPagarVO conta, string empresa, string filial, string numtitulo)
        {
            StringBuilder filtro = new StringBuilder();
            filtro.AppendLine("       EMPRESA   = '" + empresa   + "'");
            filtro.AppendLine("   AND FILIAL    = '" + filial    + "'");
            filtro.AppendLine("   AND NUMTITULO = '" + numtitulo + "'");

            load(conta, filtro.ToString());
        }
        public void load(ContasAPagarVO conta, string filtro)
        {
            DataTable table = select(filtro, null, true);
            if (table.DefaultView.Count > 0)
                populaConta(conta, table, 0);
        }

        public void load(List<ContasAPagarVO> contas, string empresa)
        {
            load(contas, empresa, null);
        }
        public void load(List<ContasAPagarVO> contas, string empresa, string filial)
        {
            load(contas, empresa, filial, null);
        }
        public void load(List<ContasAPagarVO> contas, string empresa, string filial, string filtro) 
        {
            StringBuilder filtros = new StringBuilder();
            
            filtros.AppendLine(" EMPRESA = '" + empresa + "'");

            if(filial != null)
                filtros.AppendLine("   AND FILIAL = '" + filtro + "'");
            if(filtro != null)
                filtros.AppendLine("   AND " + filtro);

            load(contas, filtros.ToString(), null, false);
        }
        public void load(List<ContasAPagarVO> contas, string filtro, string orderby, bool firstOnly)
        {
            contas = new List<ContasAPagarVO>();

            DataTable table = select(filtro, orderby, firstOnly);
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                ContasAPagarVO conta = new ContasAPagarVO();
                populaConta(conta, table, i);
                contas.Add(conta);
            }
        }
        private void populaConta(ContasAPagarVO conta, DataTable table, int i)
        {
            conta.ID            = (int)    table.DefaultView[i]["id"];
            conta.EMPRESA       = (string) table.DefaultView[i]["EMPRESA"];
            conta.FILIAL        = (string) table.DefaultView[i]["FILIAL"];
            conta.PREFIXO       = (string) table.DefaultView[i]["PREFIXO"];
            conta.NUMTITULO     = (string) table.DefaultView[i]["NUMTITULO"];
            conta.PARCELA       = (string) table.DefaultView[i]["PARCELA"];
            conta.NATUREZA      = (string) table.DefaultView[i]["NATUREZA"];
            conta.FORNECEDOR    = (string) table.DefaultView[i]["FORNECEDOR"];
            conta.LOJA          = (string) table.DefaultView[i]["LOJA"];
            conta.EMISSAOstr    = (string) table.DefaultView[i]["EMISSAO"];
            conta.VENCIMENTOstr = (string) table.DefaultView[i]["VENCIMENTO"];
            conta.VALOR         = (decimal)table.DefaultView[i]["VALOR"];
            conta.ISS           = (decimal)table.DefaultView[i]["ISS"];
            conta.IRRF          = (decimal)table.DefaultView[i]["IRRF"];
            conta.HISTORICO     = (string) table.DefaultView[i]["HISTORICO"];
            conta.INSS          = (decimal)table.DefaultView[i]["INSS"];
            conta.COFINS        = (decimal)table.DefaultView[i]["COFINS"];
            conta.PISPASEP      = (decimal)table.DefaultView[i]["PISPASEP"];
            conta.CSLL          = (decimal)table.DefaultView[i]["CSLL"];
            conta.ObsSolicitante = (string)table.DefaultView[i]["OBS_SOL"];
            conta.ObsAprovador  = (string) table.DefaultView[i]["OBS_APR"];
            conta.STATUS        = (int)    table.DefaultView[i]["STATUS"];
            conta.USERID        = (int)    table.DefaultView[i]["USERID"];
        }
        #endregion
    }
}
