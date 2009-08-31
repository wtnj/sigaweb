namespace SigaControls
{
    partial class Login
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
            this.btnLogar = new Gizmox.WebGUI.Forms.Button();
            this.lblLogin = new Gizmox.WebGUI.Forms.Label();
            this.lblSenha = new Gizmox.WebGUI.Forms.Label();
            this.txtLogin = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSenha = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInforme = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.pictureLogo = new Gizmox.WebGUI.Forms.PictureBox();
            this.checkListEmpresas = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.cbEmpresas = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLogar
            // 
            this.btnLogar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogar.Location = new System.Drawing.Point(112, 339);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(75, 25);
            this.btnLogar.TabIndex = 3;
            this.btnLogar.Text = "Logar";
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(19, 159);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(87, 23);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login";
            // 
            // lblSenha
            // 
            this.lblSenha.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(19, 182);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(87, 23);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Text = "Senha";
            // 
            // txtLogin
            // 
            this.txtLogin.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Location = new System.Drawing.Point(112, 156);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(155, 20);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtKeyPress);
            // 
            // txtSenha
            // 
            this.txtSenha.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Location = new System.Drawing.Point(112, 182);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(155, 20);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtKeyPress);
            // 
            // lblInforme
            // 
            this.lblInforme.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInforme.Location = new System.Drawing.Point(3, 0);
            this.lblInforme.Name = "lblInforme";
            this.lblInforme.Size = new System.Drawing.Size(307, 23);
            this.lblInforme.TabIndex = 5;
            this.lblInforme.Text = "Informe o seu login";
            this.lblInforme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Empresa(s)";
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = null;
            this.pictureLogo.Location = new System.Drawing.Point(97, 26);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(124, 124);
            this.pictureLogo.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureLogo.TabIndex = 8;
            this.pictureLogo.Text = "TESTE...";
            // 
            // checkListEmpresas
            // 
            this.checkListEmpresas.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.checkListEmpresas.DisplayMember = "M0_NOME";
            this.checkListEmpresas.Location = new System.Drawing.Point(112, 238);
            this.checkListEmpresas.Name = "checkListEmpresas";
            this.checkListEmpresas.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.checkListEmpresas.Size = new System.Drawing.Size(155, 95);
            this.checkListEmpresas.TabIndex = 2;
            this.checkListEmpresas.ValueMember = "M0_CODIGO";
            this.checkListEmpresas.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtKeyPress);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbEmpresas);
            this.panel1.Controls.Add(this.lblInforme);
            this.panel1.Controls.Add(this.checkListEmpresas);
            this.panel1.Controls.Add(this.btnLogar);
            this.panel1.Controls.Add(this.pictureLogo);
            this.panel1.Controls.Add(this.lblLogin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSenha);
            this.panel1.Controls.Add(this.txtLogin);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Location = new System.Drawing.Point(6, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 392);
            this.panel1.TabIndex = 10;
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbEmpresas.Checked = false;
            this.cbEmpresas.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.cbEmpresas.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.cbEmpresas.Location = new System.Drawing.Point(112, 208);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(155, 24);
            this.cbEmpresas.TabIndex = 4;
            this.cbEmpresas.Text = "Marcar Todos";
            this.cbEmpresas.ThreeState = false;
            this.cbEmpresas.CheckedChanged += new System.EventHandler(this.cbEmpresas_CheckedChanged);
            // 
            // Login
            // 
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(336, 416);
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnLogar;
        private Gizmox.WebGUI.Forms.Label lblLogin;
        private Gizmox.WebGUI.Forms.Label lblSenha;
        private Gizmox.WebGUI.Forms.TextBox txtLogin;
        private Gizmox.WebGUI.Forms.TextBox txtSenha;
        private Gizmox.WebGUI.Forms.Label lblInforme;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.PictureBox pictureLogo;
        private Gizmox.WebGUI.Forms.CheckedListBox checkListEmpresas;
        private Gizmox.WebGUI.Forms.Panel panel1;
        private Gizmox.WebGUI.Forms.CheckBox cbEmpresas;


    }
}