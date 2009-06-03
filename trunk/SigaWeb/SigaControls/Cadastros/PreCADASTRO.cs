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

#endregion

namespace SigaControls.Cadastros
{
    public partial class PreCADASTRO : UserControl
    {
        private UserControl toControl = null;
        private EmpresaVo   empresa   = null;

        public PreCADASTRO(UserControl controle, EmpresaVo empresa)
        {
            toControl    = controle;
            this.empresa = empresa;

            InitializeComponent();
            
            cbEMPRESA.DisplayMember = "M0_NOME";
            cbEMPRESA.ValueMember   = "M0_CODIGO";
            cbEMPRESA.DataSource    = new SigaObjects.Session.Empresa.EmpresaDao().getEmpresas().DefaultView;

            cbFILIAL.DisplayMember  = "M0_FILIAL";
            cbFILIAL.ValueMember    = "M0_CODFIL";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbFILIAL.SelectedIndex < 0)
                MessageBox.Show("Selecione uma Empresa/Filial.");
            else
            {
                DataRowView row = cbFILIAL.SelectedItem as DataRowView;
                empresa.CODIGO  = (string)row["M0_CODIGO"];
                empresa.NOME    = (string)row["M0_NOME"];
                empresa.CODIGO_FILIAL = (string)row["M0_CODFIL"];
                empresa.FILIAL  = (string)row["M0_FILIAL"];

                //Form frm = new Form();
                //frm.Controls.Add(toControl);
                //frm.WindowState=FormWindowState.Maximized;
                //frm.ShowDialog(this.Form);
                ControlsConfig.formShow(toControl, this.Form, ControlsConfig.showType.Dialog);
            }
        }

        private void cbEMPRESA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sEmpresa     = (string)cbEMPRESA.SelectedValue;
            cbFILIAL.DataSource = new SigaObjects.Session.Empresa.EmpresaDao().getEmpresas_Filiais("M0_CODIGO = '"+sEmpresa+"'").DefaultView;
        }

        public void ShowWindow(Form form)
        {
            ControlsConfig.formShow(this, form, ControlsConfig.showType.Dialog);
        }
    }
}