#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using SigaObjects.Session.SysUsers;
using SigaObjects.Session.UsersGroups;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SigaControls.Session
{
    public partial class Usuarios : UserControl
    {
        SysUserVo    sysUser      = new SysUserVo();
        SysUserDao   dao          = new SysUserDao();
        DataGridView gridUsuarios = new DataGridView();

        public Usuarios() { }
        public Usuarios(DataGridView grid)
        {
            InitializeComponent();

            //Passa o valor do grid recebido para o objeto grid deste controle
            this.gridUsuarios = grid;

            cmbGrupos.ValueMember   = "id";
            cmbGrupos.DisplayMember = "name";
            cmbGrupos.DataSource = new UserGroupDao().select().DefaultView;

            if (grid.SelectedRows.Count == 1)
            {
                txtUsuario.Text        = getValorCampo(gridUsuarios, "Usuário"      );
                txtSenha.Text          = getValorCampo(gridUsuarios, "Senha"        );
                txtConfirmarSenha.Text = getValorCampo(gridUsuarios, "Senha"        );
                txtNome.Text           = getValorCampo(gridUsuarios, "Nome"         );
                txtNomeCompleto.Text   = getValorCampo(gridUsuarios, "Nome Completo");

                int cont = -1;
                foreach (DataRowView drw in cmbGrupos.Items)
                {
                    ++cont;
                    if (drw[2].ToString() == gridUsuarios.SelectedRows[0].Cells["Grupo de Usuários"].Value.ToString())
                        cmbGrupos.SelectedIndex = cont;
                }
                DataTable   dados = new SysUserDao().select(txtUsuario.Text);
                DataRowView row   = dados.DefaultView[0];
                txtMailServer.Text     = (string)row["MailServer"];
                txtMailDoor.Text       = row["MailDoor"].ToString();
                txtMailAddress.Text    = (string)row["MailAddress"];
                txtMailUser.Text       = (string)row["MailUser"];
                txtMailPasswd.Text     = (string)row["MailPasswd"];

                txtNome.Focus();
            }
        }
        /// <summary>
        /// Seta a primeira linha selecionada do DataGridView
        /// </summary>
        /// <param name="grid">  O grid que será atualizado</param>
        /// <param name="campo"> O Nome do campo na tabela</param>
        /// <param name="valor"> O valor que será posto a esse campo</param>
        private void setValorCampo(DataGridView grid, string campo, string valor)
        {
            if (gridUsuarios.SelectedRows.Count > 0)
            {
                if (gridUsuarios.SelectedRows[0].Cells[campo].Value != null)
                {
                    gridUsuarios.SelectedRows[0].Cells[campo].Value = valor;
                }
            }
        }
        private String getValorCampo(DataGridView grid, string campo)
        {
            return grid.SelectedRows[0].Cells[campo].Value == null
            ? ""
            : grid.SelectedRows[0].Cells[campo].Value.ToString();
        }

        private void setValores(DataGridView gridUsuarios)
        {
            //Setando o grid com os valores alterados
            //Isso fará retornar para a tela anterior
            //E Modificar apenas o registro escolhido
            //Não tendo que carregar a tabela toda de novo
            setValorCampo(gridUsuarios, "Usuário"          , txtUsuario.Text);
            setValorCampo(gridUsuarios, "Senha"            , txtSenha.Text);
            setValorCampo(gridUsuarios, "Nome"             , txtNome.Text);
            setValorCampo(gridUsuarios, "Nome Completo"    , txtNomeCompleto.Text);
            setValorCampo(gridUsuarios, "Grupo de Usuários", (cmbGrupos.SelectedItem as DataRowView)["name"].ToString());
            //setValorCampo(gridUsuarios, "Servidor SMTP", txtMailServer.Text );
            //setValorCampo(gridUsuarios, "Porta"        , txtMailDoor.Text   );
            //setValorCampo(gridUsuarios, "e-mail"       , txtMailAddress.Text);
            //setValorCampo(gridUsuarios, "username"     , txtMailUser.Text   );
            //setValorCampo(gridUsuarios, "password"     , txtMailPasswd.Text );
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string senha = txtSenha.Text;
                string confirmarsenha = txtConfirmarSenha.Text;

                if (senha.Equals(confirmarsenha))
                {
                    string nome         = txtNome.Text;
                    string nomecompleto = txtNomeCompleto.Text;
                    string usuario      = txtUsuario.Text;

                    //Carregando dados pelo USERNAME
                    sysUser.USERNAME = usuario;
                    new SysUserDao().load(sysUser, sysUser.USERNAME);

                    //Preenchendo sysUser com os dados da Tela
                    sysUser.NAME        = nome;
                    sysUser.FULLNAME    = nomecompleto;
                    sysUser.PASSWORD    = senha;
                    sysUser.IDUSERGROUP = (int)(cmbGrupos.SelectedItem as DataRowView)["id"];

                    // propriedades de email.
                    sysUser.MAILSERVER  = txtMailServer.Text.Trim();
                    sysUser.MAILDOOR    = int.Parse(txtMailDoor.Text.Trim());
                    sysUser.MAILADDRESS = txtMailAddress.Text.Trim();
                    sysUser.MAILUSER    = txtMailUser.Text.Trim();
                    sysUser.MAILPASSWD  = txtMailPasswd.Text.Trim();

                    //Salvando o Usuário
                    dao.save(sysUser);

                    this.setValores(gridUsuarios);

                    btnVoltar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Senhas diferentes !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao salvar conta");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent.Name == "Painel")
            {
                //Remove o painel este controle
                parent.Controls.Remove(this);
                //Adiciona novamente a tela de Usuario_principal
                //Com o grid modificado
                parent.Controls.Add(new Usuario_principal(gridUsuarios));
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            setValores(gridUsuarios);
            Control parent = this.Parent;
            if (parent.Name == "Painel")
            {
                parent.Controls.Remove(this);
                parent.Controls.Add(new Grupo_usuarios(gridUsuarios));
            }
        }
    }
}