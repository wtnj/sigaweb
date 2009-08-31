#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SigaControls.Report;
using SigaControls.Session;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace SigaControls
{
    public class STATUS
    {
        private static string valor = "";
        
        public static string VALOR
        {
            get{ return valor;   }
            set
            {
                valor += value;
                SetInStatus();
            }
        }

        public static void Clear()
        {
            valor = "";
            SetInStatus();
        }

        public static void SetInStatus()
        { MainMenu.txtSTATUS.Text = valor; }
    }

    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.carraleroLOGO.BackgroundImage = (ResourceHandle)Resources.Images.basic.LOGO[0];
            this.carraleroLOGO.Text            = (string)Resources.Images.basic.LOGO[1];
            this.carraleroLOGO.BackgroundImageLayout = ImageLayout.Zoom;
        }
        public MainMenu(DataGridView gridUsuarios)
        {
            this.Painel.Controls.Clear();
            FormatScreen.AddControl(Painel, new Usuario_principal(gridUsuarios), true, 1, true, false);
        }

        private void AdicionaControle(Control controle)
        {
            this.Painel.Controls.Clear();
            this.Painel.Controls.Add(controle);
        }

        private void CadUsuario_Click(object sender, EventArgs e)
        {
            this.Painel.Controls.Clear();
            FormatScreen.AddControl(Painel, new Usuario_principal(), true, 1, true, false);
        }

        private void CriarRelatorio_Click(object sender, EventArgs e)
        {
            this.Painel.Controls.Clear();

            SxMakeRelatory rel = new SxMakeRelatory();
            rel.Dock = DockStyle.Fill;

            this.AdicionaControle(rel);
        }

        private void ConsultarRelatorio_Click(object sender, EventArgs e)
        {
            this.Painel.Controls.Clear();
            
            FormatScreen.AddControl(Painel, new Report.ReportList(), true, 1, true, false);
        }

        private void PermissaoUsuRel_Click(object sender, EventArgs e)
        {
            this.Painel.Controls.Clear();
            FormatScreen.AddControl(Painel, new Permissoes(), true, 1, true, false);
            //FormatScreen.AddControl(Painel, new Label("Controle ainda não implementado"), true, 1, true, false);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Control pai = this.Parent;
            this.Form.Controls.Remove(this);
            pai.Controls.Add(new Login());
        }

        private void btnCadCompPg_Click(object sender, EventArgs e)
        {
            this.Painel.Controls.Clear();
            FormatScreen.AddControl(Painel, new Cadastros.ContasAPagarList(), true, 1, true, false);
        }

        private void txtSTATUS_DoubleClick(object sender, EventArgs e)
        {
            new ERROR(new Exception(txtSTATUS.Text),"LOG DO SISTEMA").SHOW();
        }
    }
}