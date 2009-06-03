namespace SigaControls
{
    partial class Permissoes
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
            this.tabControlPermissoes = new Gizmox.WebGUI.Forms.TabControl();
            this.tabRelUsu = new Gizmox.WebGUI.Forms.TabPage();
            this.cmbRelUsu = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbUsuarios = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblRelatorios = new Gizmox.WebGUI.Forms.Label();
            this.lblUsuarios = new Gizmox.WebGUI.Forms.Label();
            this.btnFiltrarUsu = new Gizmox.WebGUI.Forms.Button();
            this.btnDefinirUsu = new Gizmox.WebGUI.Forms.Button();
            this.gridRelUsu = new Gizmox.WebGUI.Forms.DataGridView();
            this.tabRelGrupo = new Gizmox.WebGUI.Forms.TabPage();
            this.gridRelGrupo = new Gizmox.WebGUI.Forms.DataGridView();
            this.btnDefinirGrupo = new Gizmox.WebGUI.Forms.Button();
            this.btnFiltrarGrupo = new Gizmox.WebGUI.Forms.Button();
            this.lblUsuGrupo = new Gizmox.WebGUI.Forms.Label();
            this.lblRelatorio = new Gizmox.WebGUI.Forms.Label();
            this.cmbGrupo = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbRelGrupo = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnSalvar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.lblPermissoes = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelUsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPermissoes
            // 
            this.tabControlPermissoes.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.tabControlPermissoes.Controls.Add(this.tabRelUsu);
            this.tabControlPermissoes.Controls.Add(this.tabRelGrupo);
            this.tabControlPermissoes.Location = new System.Drawing.Point(3, 67);
            this.tabControlPermissoes.Multiline = false;
            this.tabControlPermissoes.Name = "tabControlPermissoes";
            this.tabControlPermissoes.SelectedIndex = 0;
            this.tabControlPermissoes.Size = new System.Drawing.Size(819, 388);
            this.tabControlPermissoes.TabIndex = 0;
            // 
            // tabRelUsu
            // 
            this.tabRelUsu.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.tabRelUsu.Controls.Add(this.cmbRelUsu);
            this.tabRelUsu.Controls.Add(this.cmbUsuarios);
            this.tabRelUsu.Controls.Add(this.lblRelatorios);
            this.tabRelUsu.Controls.Add(this.lblUsuarios);
            this.tabRelUsu.Controls.Add(this.btnFiltrarUsu);
            this.tabRelUsu.Controls.Add(this.btnDefinirUsu);
            this.tabRelUsu.Controls.Add(this.gridRelUsu);
            this.tabRelUsu.Location = new System.Drawing.Point(4, 22);
            this.tabRelUsu.Name = "tabRelUsu";
            this.tabRelUsu.Size = new System.Drawing.Size(811, 362);
            this.tabRelUsu.TabIndex = 0;
            this.tabRelUsu.Text = "Relatório - Usuários";
            // 
            // cmbRelUsu
            // 
            this.cmbRelUsu.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbRelUsu.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbRelUsu.Location = new System.Drawing.Point(133, 35);
            this.cmbRelUsu.Name = "cmbRelUsu";
            this.cmbRelUsu.Size = new System.Drawing.Size(121, 21);
            this.cmbRelUsu.TabIndex = 10;
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbUsuarios.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.Location = new System.Drawing.Point(6, 35);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(121, 21);
            this.cmbUsuarios.TabIndex = 9;
            // 
            // lblRelatorios
            // 
            this.lblRelatorios.Location = new System.Drawing.Point(130, 9);
            this.lblRelatorios.Name = "lblRelatorios";
            this.lblRelatorios.Size = new System.Drawing.Size(100, 23);
            this.lblRelatorios.TabIndex = 8;
            this.lblRelatorios.Text = "Relatórios";
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.Location = new System.Drawing.Point(3, 9);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(100, 23);
            this.lblUsuarios.TabIndex = 7;
            this.lblUsuarios.Text = "Usuários";
            // 
            // btnFiltrarUsu
            // 
            this.btnFiltrarUsu.Location = new System.Drawing.Point(260, 32);
            this.btnFiltrarUsu.Name = "btnFiltrarUsu";
            this.btnFiltrarUsu.Size = new System.Drawing.Size(75, 25);
            this.btnFiltrarUsu.TabIndex = 6;
            this.btnFiltrarUsu.Text = "Filtrar";
            this.btnFiltrarUsu.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnDefinirUsu
            // 
            this.btnDefinirUsu.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnDefinirUsu.Location = new System.Drawing.Point(740, 3);
            this.btnDefinirUsu.Name = "btnDefinirUsu";
            this.btnDefinirUsu.Size = new System.Drawing.Size(68, 25);
            this.btnDefinirUsu.TabIndex = 3;
            this.btnDefinirUsu.Text = "Definir";
            this.btnDefinirUsu.Click += new System.EventHandler(this.btnDefinir_Click);
            // 
            // gridRelUsu
            // 
            this.gridRelUsu.AllowUserToAddRows = false;
            this.gridRelUsu.AllowUserToDeleteRows = false;
            this.gridRelUsu.AllowUserToOrderColumns = true;
            this.gridRelUsu.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.gridRelUsu.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gridRelUsu.Location = new System.Drawing.Point(6, 63);
            this.gridRelUsu.Name = "gridRelUsu";
            this.gridRelUsu.Size = new System.Drawing.Size(802, 296);
            this.gridRelUsu.TabIndex = 0;
            // 
            // tabRelGrupo
            // 
            this.tabRelGrupo.Controls.Add(this.gridRelGrupo);
            this.tabRelGrupo.Controls.Add(this.btnDefinirGrupo);
            this.tabRelGrupo.Controls.Add(this.btnFiltrarGrupo);
            this.tabRelGrupo.Controls.Add(this.lblUsuGrupo);
            this.tabRelGrupo.Controls.Add(this.lblRelatorio);
            this.tabRelGrupo.Controls.Add(this.cmbGrupo);
            this.tabRelGrupo.Controls.Add(this.cmbRelGrupo);
            this.tabRelGrupo.Location = new System.Drawing.Point(4, 22);
            this.tabRelGrupo.Name = "tabRelGrupo";
            this.tabRelGrupo.Size = new System.Drawing.Size(811, 353);
            this.tabRelGrupo.TabIndex = 0;
            this.tabRelGrupo.Text = "Relatório - Grupos";
            // 
            // gridRelGrupo
            // 
            this.gridRelGrupo.AllowUserToAddRows = false;
            this.gridRelGrupo.AllowUserToDeleteRows = false;
            this.gridRelGrupo.AllowUserToOrderColumns = true;
            this.gridRelGrupo.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.gridRelGrupo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gridRelGrupo.Location = new System.Drawing.Point(6, 63);
            this.gridRelGrupo.Name = "gridRelGrupo";
            this.gridRelGrupo.Size = new System.Drawing.Size(802, 287);
            this.gridRelGrupo.TabIndex = 0;
            // 
            // btnDefinirGrupo
            // 
            this.btnDefinirGrupo.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnDefinirGrupo.Location = new System.Drawing.Point(740, 3);
            this.btnDefinirGrupo.Name = "btnDefinirGrupo";
            this.btnDefinirGrupo.Size = new System.Drawing.Size(68, 25);
            this.btnDefinirGrupo.TabIndex = 3;
            this.btnDefinirGrupo.Text = "Definir";
            this.btnDefinirGrupo.Click += new System.EventHandler(this.btnDefinirGrupo_Click);
            // 
            // btnFiltrarGrupo
            // 
            this.btnFiltrarGrupo.Location = new System.Drawing.Point(260, 32);
            this.btnFiltrarGrupo.Name = "btnFiltrarGrupo";
            this.btnFiltrarGrupo.Size = new System.Drawing.Size(75, 25);
            this.btnFiltrarGrupo.TabIndex = 6;
            this.btnFiltrarGrupo.Text = "Filtrar";
            this.btnFiltrarGrupo.Click += new System.EventHandler(this.btnFiltrarGrupo_Click);
            // 
            // lblUsuGrupo
            // 
            this.lblUsuGrupo.Location = new System.Drawing.Point(3, 9);
            this.lblUsuGrupo.Name = "lblUsuGrupo";
            this.lblUsuGrupo.Size = new System.Drawing.Size(100, 23);
            this.lblUsuGrupo.TabIndex = 7;
            this.lblUsuGrupo.Text = "Grupo de Usuários";
            // 
            // lblRelatorio
            // 
            this.lblRelatorio.Location = new System.Drawing.Point(130, 9);
            this.lblRelatorio.Name = "lblRelatorio";
            this.lblRelatorio.Size = new System.Drawing.Size(113, 23);
            this.lblRelatorio.TabIndex = 8;
            this.lblRelatorio.Text = "Relatórios";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbGrupo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupo.Location = new System.Drawing.Point(6, 35);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(121, 21);
            this.cmbGrupo.TabIndex = 9;
            // 
            // cmbRelGrupo
            // 
            this.cmbRelGrupo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbRelGrupo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbRelGrupo.Location = new System.Drawing.Point(133, 35);
            this.cmbRelGrupo.Name = "cmbRelGrupo";
            this.cmbRelGrupo.Size = new System.Drawing.Size(121, 21);
            this.cmbRelGrupo.TabIndex = 10;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(6, 38);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(87, 38);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPermissoes
            // 
            this.lblPermissoes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissoes.Location = new System.Drawing.Point(293, 9);
            this.lblPermissoes.Name = "lblPermissoes";
            this.lblPermissoes.Size = new System.Drawing.Size(268, 23);
            this.lblPermissoes.TabIndex = 2;
            this.lblPermissoes.Text = "Permissões de Acesso";
            this.lblPermissoes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Permissoes
            // 
            this.Controls.Add(this.lblPermissoes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tabControlPermissoes);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(825, 458);
            this.Text = "Permissoes";
            ((System.ComponentModel.ISupportInitialize)(this.gridRelUsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelGrupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl tabControlPermissoes;
        private Gizmox.WebGUI.Forms.TabPage tabRelUsu;
        private Gizmox.WebGUI.Forms.Button btnDefinirUsu;
        private Gizmox.WebGUI.Forms.DataGridView gridRelUsu;
        private Gizmox.WebGUI.Forms.TabPage tabRelGrupo;
        private Gizmox.WebGUI.Forms.Button btnSalvar;
        private Gizmox.WebGUI.Forms.Button btnCancelar;
        private Gizmox.WebGUI.Forms.Label lblPermissoes;
        private Gizmox.WebGUI.Forms.Label lblRelatorios;
        private Gizmox.WebGUI.Forms.Label lblUsuarios;
        private Gizmox.WebGUI.Forms.Button btnFiltrarUsu;
        private Gizmox.WebGUI.Forms.ComboBox cmbRelUsu;
        private Gizmox.WebGUI.Forms.ComboBox cmbUsuarios;
        private Gizmox.WebGUI.Forms.ComboBox cmbRelGrupo;
        private Gizmox.WebGUI.Forms.ComboBox cmbGrupo;
        private Gizmox.WebGUI.Forms.Label lblRelatorio;
        private Gizmox.WebGUI.Forms.Label lblUsuGrupo;
        private Gizmox.WebGUI.Forms.Button btnFiltrarGrupo;
        private Gizmox.WebGUI.Forms.Button btnDefinirGrupo;
        private Gizmox.WebGUI.Forms.DataGridView gridRelGrupo;
    }
}