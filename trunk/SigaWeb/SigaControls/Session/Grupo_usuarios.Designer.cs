namespace SigaControls.Session
{
    partial class Grupo_usuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNome = new Gizmox.WebGUI.Forms.Label();
            this.lblDescricao = new Gizmox.WebGUI.Forms.Label();
            this.txtNome = new Gizmox.WebGUI.Forms.TextBox();
            this.txtDescricao = new Gizmox.WebGUI.Forms.TextBox();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.lblGrupo = new Gizmox.WebGUI.Forms.Label();
            this.btnVoltar = new Gizmox.WebGUI.Forms.Button();
            this.gridGrupos = new Gizmox.WebGUI.Forms.DataGridView();
            this.btnRemover = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.btnNovo = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblNome.Location = new System.Drawing.Point(16, 251);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(100, 23);
            this.lblNome.TabIndex = 7;
            this.lblNome.Text = "Nome";
            // 
            // lblDescricao
            // 
            this.lblDescricao.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblDescricao.Location = new System.Drawing.Point(16, 315);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(100, 25);
            this.lblDescricao.TabIndex = 6;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(16, 277);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(226, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(16, 343);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(271, 78);
            this.txtDescricao.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(332, 180);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblGrupo.Location = new System.Drawing.Point(209, 0);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(145, 23);
            this.lblGrupo.TabIndex = 5;
            this.lblGrupo.Text = "Grupo de Usuários";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(332, 209);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // gridGrupos
            // 
            this.gridGrupos.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gridGrupos.Location = new System.Drawing.Point(16, 62);
            this.gridGrupos.Name = "gridGrupos";
            this.gridGrupos.Size = new System.Drawing.Size(310, 170);
            this.gridGrupos.TabIndex = 8;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(332, 151);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 9;
            this.btnRemover.Text = "Remover";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(332, 209);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(332, 238);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 11;
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // Grupo_usuarios
            // 
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.gridGrupos);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblNome);
            this.Size = new System.Drawing.Size(593, 524);
            this.Text = "Grupo_usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblNome;
        private Gizmox.WebGUI.Forms.Label lblDescricao;
        private Gizmox.WebGUI.Forms.TextBox txtNome;
        private Gizmox.WebGUI.Forms.TextBox txtDescricao;
        private Gizmox.WebGUI.Forms.Button btnOk;
        private Gizmox.WebGUI.Forms.Label lblGrupo;
        private Gizmox.WebGUI.Forms.Button btnVoltar;
        private Gizmox.WebGUI.Forms.DataGridView gridGrupos;
        private Gizmox.WebGUI.Forms.Button btnRemover;
        private Gizmox.WebGUI.Forms.Button btnCancelar;
        private Gizmox.WebGUI.Forms.Button btnNovo;


    }
}