#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SigaObjects.Session.UsersGroups;

#endregion

namespace SigaControls.Session
{
    public partial class Grupo_usuarios : UserControl
    {
        private DataGridView grid;
        
        public Grupo_usuarios(DataGridView grid)
        {
            InitializeComponent();

            this.grid = grid;

            gridGrupos.DataSource = new
                UserGroupDao().select().DefaultView;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;

            new UserGroupDao().save(new UserGroupVo(descricao, nome));

            btnVoltar_Click(sender, e);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent.Name == "Painel")
            {
                parent.Controls.Remove(this);
                parent.Controls.Add(new Usuarios(grid));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnVoltar.Visible = true;
            btnCancelar.Visible = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = true;
            btnVoltar.Visible = false;
        }
    }
}