#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using SigaObjects.Permissoes;
using SigaObjects.Permissoes.RelGrupo;
using SigaObjects.Permissoes.RelUsu;

#endregion

namespace SigaControls
{
    public partial class DefinirPermissoes : UserControl
    {
        private DataGridView grid = null;

        public DefinirPermissoes(DataGridView grid)
        {
            this.grid = grid;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Nivel nivelSelecionado = Nivel.NaoDefinido;

            if (rdbAdicionar.Checked)
                nivelSelecionado = Nivel.Adicionar;
            else if (rdbNenhuma.Checked)
                nivelSelecionado = Nivel.Nenhuma;
            else if (rdbVisualizar.Checked)
                nivelSelecionado = Nivel.Visualizar;
            else if (rdbEditar.Checked)
                nivelSelecionado = Nivel.Editar;
            else if (rdbDeletar.Checked)
                nivelSelecionado = Nivel.Deletar;

            if (nivelSelecionado != Nivel.NaoDefinido)
                foreach (DataGridViewRow row in grid.SelectedRows)
                    row.Cells["Nível"].Value = nivelSelecionado;

            new Permissoes().updatePermissoesSelectedRows(grid.SelectedRows);

            Voltar();
        }

        private void Voltar()
        {
            this.Form.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Voltar();
        }
    }
}