#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using SigaObjects.Session.SysUsers;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SigaControls.Session
{
    public partial class Usuario_principal : UserControl
    {
        public void ajustaGrid()
        {
            this.gridUsuarios.Columns["Senha"].Visible = false;
        }
        public Usuario_principal()
        {
            InitializeComponent();
            //this.gridUsuarios.DataSource = new SigaObjects.Reports.ReportGroup.ReportGroupDao().select().DefaultView;
            this.gridUsuarios.DataSource = new SysUserDao().selectGrid().DefaultView;
            ajustaGrid();
        }
        public Usuario_principal(DataGridView gridUsuarios)
        {
            InitializeComponent();
            if (gridUsuarios.SelectedRows.Count > 0)
                this.gridUsuarios.DataSource = gridUsuarios.DataSource;
            else
                this.gridUsuarios.DataSource = new SysUserDao().selectGrid().DefaultView;
            ajustaGrid();
        }

        private void addPainel(Control controle)
        {
            Control parent = this.Parent;
            parent.Controls.Remove(this);
            parent.Controls.Add(controle);
        }

        private void Comandos_Click(object objSource, ToolBarItemEventArgs objArgs)
        {
            if (objArgs.ToolBarButton.Name == "btnAdicionar")
            {
                gridUsuarios.ClearSelection();
                addPainel(new Usuarios(gridUsuarios));
            }
            if (objArgs.ToolBarButton.Name == "btnEditar")
            {
                if (gridUsuarios.SelectedRows.Count > 0)
                    addPainel(new Usuarios(gridUsuarios));
            }
            if (objArgs.ToolBarButton.Name == "btnRemover")
            {
                if (gridUsuarios.SelectedRows.Count == 1)
                {
                    if (gridUsuarios
                        .SelectedRows[0]
                        .Cells["Usuário"].Value != "admin")
                    {
                        new SysUserDao().delete(
                            gridUsuarios
                            .SelectedRows[0]
                            .Cells["Usuário"].Value == null
                        ? ""
                        : gridUsuarios
                        .SelectedRows[0]
                        .Cells["Usuário"].Value.ToString());
                    }
                }
                gridUsuarios.DataSource = new SigaObjects.Session.SysUsers.SysUserDao().selectGrid().DefaultView;
            }
        }

        private void ValidarDelete(object sender, EventArgs e)
        {
            return;
        }
    }
}