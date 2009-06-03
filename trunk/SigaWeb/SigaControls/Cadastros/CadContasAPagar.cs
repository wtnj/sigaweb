#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using SigaObjects.Session.Empresa;
using SigaObjects.Cadastros.ContasAPagar;
using System.Globalization;

#endregion

namespace SigaControls.Cadastros
{
    public partial class CadContasAPagar : UserControl
    {
        private EmpresaVo      empresa  = new EmpresaVo();
        private ContasAPagarVO conta    = new ContasAPagarVO();
        private bool           readOnly = false;

        private void initializer(EmpresaVo _empresa, int id, bool readOnly)
        {
            InitializeComponent();
            this.Dock    = DockStyle.Fill;
            this.empresa = _empresa;
            new ContasAPagarDAO().load(this.conta, "id = " + id);
            this.readOnly = readOnly;
        }
        public CadContasAPagar(  EmpresaVo _empresa)
        { initializer(_empresa, 0, false); }
        public CadContasAPagar(  EmpresaVo _empresa, int id)
        { initializer(_empresa, id, false); }
        public CadContasAPagar(  EmpresaVo _empresa, int id, bool readOnly)
        { initializer(_empresa, id, readOnly); }

        private void popScreen()
        {
            lblEmpresaFilial.Text     = empresa.CODIGO + "-" + empresa.NOME + " / " + empresa.CODIGO_FILIAL + "-" + empresa.FILIAL;
            
            List<object> pic = new Resources.Icons.status()[conta.STATUS];
            picSTATUS.BackgroundImage = (Gizmox.WebGUI.Common.Resources.ResourceHandle)pic[0];
            picSTATUS.Text            = (string)pic[1];

            lblOBS_APR.Text     = conta.ObsAprovador;
            txtOBS_SOL.Text     = conta.ObsSolicitante;

            txtPREFIXO.Text     = conta.PREFIXO;
            txtNUMTITULO.Text   = conta.NUMTITULO;
            txtPARCELA.Text     = conta.PARCELA;
            txtNATUREZA.Text    = conta.NATUREZA;
            txtFORNECEDOR.Text  = conta.FORNECEDOR;
            txtLOJA.Text        = conta.LOJA;
            dtpEMISSAO.Value    = conta.EMISSAO;
            dtpVENCIMENTO.Value = conta.VENCIMENTO;
            txtVALOR.Text       = conta.VALOR.ToString(   "0.00", CultureInfo.InvariantCulture);
            txtISS.Text         = conta.ISS.ToString(     "0.00", CultureInfo.InvariantCulture);
            txtIRRF.Text        = conta.IRRF.ToString(    "0.00", CultureInfo.InvariantCulture);
            txtHISTORICO.Text   = conta.HISTORICO;
            txtINSS.Text        = conta.INSS.ToString(    "0.00", CultureInfo.InvariantCulture);
            txtCOFINS.Text      = conta.COFINS.ToString(  "0.00", CultureInfo.InvariantCulture);
            txtPISPASEP.Text    = conta.PISPASEP.ToString("0.00", CultureInfo.InvariantCulture);
            txtCSLL.Text        = conta.CSLL.ToString(    "0.00", CultureInfo.InvariantCulture);
        }

        #region EVENTOS
        private void CadContasAPagar_VisibleChanged(object sender, EventArgs e)
        {
            FormatScreen.setIcon(this);
            popScreen();

            if ( this.readOnly
              || conta.STATUS == 1
              || conta.STATUS == 4 )
                FormatScreen.lockControls(this, typeof(TextBox), typeof(Button), typeof(DateTimePicker), typeof(NumericUpDown));

            FormatScreen.addEventTag(this, "*");
            FormatScreen.addEventTag(this, FormatScreen.TIPOS.MOEDA, "$");
        }

        private void dtpVENCIMENTO_ValueChanged(object sender, EventArgs e)
        {
            if (dtpVENCIMENTO.Value < dtpEMISSAO.Value)
            {
                MessageBox.Show("Vencimento não pode ser inferior a Emissão!");
                dtpVENCIMENTO.Value = dtpEMISSAO.Value;
            }
        }
        private void dtpEMISSAO_ValueChanged(   object sender, EventArgs e)
        {
            if (dtpEMISSAO.Value > dtpVENCIMENTO.Value)
                dtpVENCIMENTO.Value = dtpEMISSAO.Value;
        }

        private void btnBuscaNatureza_Click(object sender, EventArgs e)
        {
            DataRowView   table  = new SigaObjects.SXManager(empresa.CODIGO).getTabela("SED");
            StringBuilder sQuery = new StringBuilder();
            if (table != null)
            {
                sQuery.AppendLine("SELECT ED_CODIGO , ED_DESCRIC, ED_CALCIRF, ED_CALCISS");
                sQuery.AppendLine("     , ED_CALCINS, ED_CALCCSL, ED_CALCCOF, ED_CALCPIS");
                sQuery.AppendLine("  FROM " + table["X2_ARQUIVO"].ToString());
                
                if (table["X2_MODO"].ToString() == "E")
                    sQuery.AppendLine(" WHERE ED_FILIAL = '" + empresa.CODIGO_FILIAL + "'");
                
                sQuery.AppendLine(" ORDER BY ED_DESCRIC");
            }

            if (sQuery.Length>0)
            {
                DataTable fornece = new SigaObjects.DataMaster().SelectDataTable(sQuery);
                new gridWindow(fornece, txtNATUREZA,"ED_CODIGO").showWindow(this.Form,true,50);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string erro = FormatScreen.ValidateTextControls(this, typeof(TextBox));

            if (erro.Length > 0)
                MessageBox.Show(erro, "ERRO DE PREENCHIMENTO");
            else
            {
                conta.EMPRESA = empresa.CODIGO;
                conta.FILIAL  = empresa.CODIGO_FILIAL;

                conta.PREFIXO    = txtPREFIXO.Text;
                conta.NUMTITULO  = txtNUMTITULO.Text;
                conta.PARCELA    = txtPARCELA.Text;
                conta.NATUREZA   = txtNATUREZA.Text;
                conta.FORNECEDOR = txtFORNECEDOR.Text;
                conta.LOJA       = txtLOJA.Text;
                conta.EMISSAO    = dtpEMISSAO.Value;
                conta.VENCIMENTO = dtpVENCIMENTO.Value;
                conta.VALOR      = decimal.Parse(txtVALOR.Text   , CultureInfo.InvariantCulture);
                conta.ISS        = decimal.Parse(txtISS.Text     , CultureInfo.InvariantCulture);
                conta.IRRF       = decimal.Parse(txtIRRF.Text    , CultureInfo.InvariantCulture);
                conta.HISTORICO  = txtHISTORICO.Text.Trim();
                conta.INSS       = decimal.Parse(txtINSS.Text    , CultureInfo.InvariantCulture);
                conta.COFINS     = decimal.Parse(txtCOFINS.Text  , CultureInfo.InvariantCulture);
                conta.PISPASEP   = decimal.Parse(txtPISPASEP.Text, CultureInfo.InvariantCulture);
                conta.CSLL       = decimal.Parse(txtCSLL.Text    , CultureInfo.InvariantCulture);
                
                conta.STATUS     = 2;
                conta.ObsSolicitante = txtOBS_SOL.Text.Trim();

                conta.USERID     = sigaSession.LoggedUser.ID;

                try
                {
                    new ContasAPagarDAO().save(conta);
                    MessageBox.Show("Cadastro feito com sucesso.");
                }
                catch (Exception EX)
                { MessageBox.Show(EX.Message); return; }

                string subject = "CONTAS A PAGAR / "+lblEmpresaFilial.Text+" / "+DateTime.Now.ToString("dddd dd/MM/yyyy hh:mm:ss");
                
                StringBuilder bodyMail = new StringBuilder(subject);
                bodyMail.AppendLine();
                bodyMail.AppendLine("EMPRESA / FILIAL\t\t: " + lblEmpresaFilial.Text);
                bodyMail.AppendLine("Prefixo - Numero do Titulo\t\t: " + conta.PREFIXO + " - "+conta.NUMTITULO);
                bodyMail.AppendLine("Parcela / Natureza\t\t: " + conta.PARCELA +" - "+conta.NATUREZA);
                bodyMail.AppendLine("Fornecedor / Loja : " + conta.FORNECEDOR +" - "+txtNOMEFORNECEDOR.Text+" / "+conta.LOJA);
                bodyMail.AppendLine(String.Format("{0,-11} : {1,-10}", "Emissao"   , conta.EMISSAO.ToString(   "dd/MM/yyyy")));
                bodyMail.AppendLine(String.Format("{0,-11} : {1,-10}", "Vencimento", conta.VENCIMENTO.ToString("dd/MM/yyyy")));
                bodyMail.AppendLine(String.Format("{0,-11} : {1, 10}", "Valor"     , conta.VALOR.ToString(   "C",new CultureInfo("pt-BR"))));
                bodyMail.AppendLine(String.Format("{0,-11} : {1,-10}", "Historico" , conta.HISTORICO));
                bodyMail.AppendLine(String.Format("{0,-11} : {1, 10}", "ISS"       , conta.ISS.ToString(     "C",new CultureInfo("pt-BR"))));
                bodyMail.AppendLine(String.Format("{0,-11} : {1, 10}", "IRFF"      , conta.IRRF.ToString(    "C",new CultureInfo("pt-BR"))));
                bodyMail.AppendLine(String.Format("{0,-11} : {1, 10}", "INSS"      , conta.INSS.ToString(    "C",new CultureInfo("pt-BR"))));
                bodyMail.AppendLine(String.Format("{0,-11} : {1, 10}", "COFINS"    , conta.COFINS.ToString(  "C",new CultureInfo("pt-BR"))));
                bodyMail.AppendLine(String.Format("{0,-11} : {1, 10}", "PIS/PASEP" , conta.PISPASEP.ToString("C",new CultureInfo("pt-BR"))));
                bodyMail.AppendLine(String.Format("{0,-11} : {1, 10}", "CSLL"      , conta.CSLL.ToString(    "C",new CultureInfo("pt-BR"))));
                bodyMail.AppendLine();
                bodyMail.AppendLine("------------------------------");
                bodyMail.AppendLine("Obs Solicitante : "+ sigaSession.LoggedUser.NAME);
                bodyMail.AppendLine(conta.ObsSolicitante);
                bodyMail.AppendLine("------------------------------");
                bodyMail.AppendLine();
                bodyMail.AppendLine("Obs Aprovador:");
                bodyMail.AppendLine(conta.ObsAprovador);

                SigaObjects.Session.SysUsers.SysUserVo mailSender = new SigaObjects.Session.SysUsers.SysUserVo();
                new SigaObjects.Session.SysUsers.SysUserDao().load(mailSender, "admin");

                try
                {
                    new Carralero.Net.Email( mailSender.MAILADDRESS
                                           , subject
                                           , bodyMail
                                           , mailSender.MAILADDRESS
                                           , mailSender.MAILUSER
                                           , mailSender.MAILPASSWD
                                           , mailSender.MAILSERVER
                                           , mailSender.MAILDOOR).Enviar();

                    MessageBox.Show("Email Enviado com sucesso!");
                    this.Form.Close();
                }
                catch (Exception EX)
                { MessageBox.Show(Carralero.ExceptionControler.getStrException(EX)); }

                //this.Form.Close();
            }
        }
        #endregion

        #region FORNECEDOR
        private void txtFORNECEDOR_TextChanged(object sender, EventArgs e)
        {
            DataRowView   table  = new SigaObjects.SXManager(empresa.CODIGO).getTabela("SA2");
            StringBuilder sQuery = new StringBuilder();
            if (table != null)
            {
                sQuery.AppendLine("SELECT A2_COD, A2_LOJA, A2_NOME");
                sQuery.AppendLine("  FROM " + table["X2_ARQUIVO"].ToString());
                
                sQuery.AppendLine(" WHERE A2_COD = '"+txtFORNECEDOR.Text.Trim()+"'");
                if (table["X2_MODO"].ToString() == "E")
                    sQuery.AppendLine("   AND A2_FILIAL = '" + empresa.CODIGO_FILIAL + "'");
            }
            if (sQuery.Length > 0)
            {
                DataTable fornece = new SigaObjects.DataMaster().SelectDataTable(sQuery);
                if (fornece.DefaultView.Count > 0)
                {
                    txtNOMEFORNECEDOR.Text = fornece.DefaultView[0]["A2_NOME"].ToString().Trim();
                    txtLOJA.Text           = fornece.DefaultView[0]["A2_LOJA"].ToString().Trim();
                }
                else
                    MessageBox.Show("Fornecedor inexistente. cod:" + txtFORNECEDOR.Text.Trim());
            }
        }
        private void btnBuscaFornece_Click(    object sender, EventArgs e)
        {
            DataRowView   table  = new SigaObjects.SXManager(empresa.CODIGO).getTabela("SA2");
            StringBuilder sQuery = new StringBuilder();
            if (table != null)
            {
                sQuery.AppendLine("SELECT A2_COD, A2_LOJA, A2_NOME");
                sQuery.AppendLine("  FROM " + table["X2_ARQUIVO"].ToString());
                
                if (table["X2_MODO"].ToString() == "E")
                    sQuery.AppendLine(" WHERE A2_FILIAL = '" + empresa.CODIGO_FILIAL + "'");
                
                sQuery.AppendLine(" ORDER BY A2_NOME");
            }

            if (sQuery.Length>0)
            {
                DataTable fornece = new SigaObjects.DataMaster().SelectDataTable(sQuery);
                new gridWindow(fornece, txtFORNECEDOR,"A2_COD").showWindow(this.Form,true,50);
            }
        }
        #endregion
    }
}