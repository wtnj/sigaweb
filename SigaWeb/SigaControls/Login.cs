#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

using SigaObjects.Session.Empresa;

#endregion

namespace SigaControls
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            pictureLogo.BackgroundImage       = (ResourceHandle)Resources.Images.basic.LOGO[0];
            pictureLogo.Text                  = (string)Resources.Images.basic.LOGO[1];
            pictureLogo.BackgroundImageLayout = ImageLayout.Zoom;

            /// Empresa.fillControls(cmbEmpresas);
            checkListEmpresas.DataSource = new EmpresaDao().getEmpresas();

            txtLogin.Focus();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            List<string> nomes = new List<string>();
            sigaSession.EMPRESAS.Clear();
            foreach (object item in checkListEmpresas.CheckedItems)
            {
                nomes.Add((item as DataRowView)["M0_NOME"].ToString());
                DataRowView dr      = (item as DataRowView);
                EmpresaVo   empresa = new EmpresaVo();
                empresa.CODIGO        = dr["M0_CODIGO"].ToString();
                empresa.NOME          = dr["M0_NOME"  ].ToString();
                //empresa.CODIGO_FILIAL = dr["M0_CODFIL"].ToString();
                //empresa.FILIAL        = dr["M0_FILIA" ].ToString();
                sigaSession.EMPRESAS.Add(empresa);
            }

            new Logon(login, senha, nomes, this.Form);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0: pictureLogo.BackgroundImageLayout = ImageLayout.None;    break;
                case 1: pictureLogo.BackgroundImageLayout = ImageLayout.Tile;    break;
                case 2: pictureLogo.BackgroundImageLayout = ImageLayout.Center;  break;
                case 3: pictureLogo.BackgroundImageLayout = ImageLayout.Stretch; break;
                case 4: pictureLogo.BackgroundImageLayout = ImageLayout.Zoom;    break;
                default:break;
            }
        }

        private void cbEmpresas_CheckedChanged(object sender, EventArgs e)
        {
            for(int idx =0; idx<checkListEmpresas.Items.Count; idx++)
                checkListEmpresas.SetItemChecked(idx, (sender as CheckBox).Checked);
        }
    }
}