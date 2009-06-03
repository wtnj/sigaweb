namespace SigaControls.Session
{
    partial class Usuario_principal
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
            this.gridUsuarios = new Gizmox.WebGUI.Forms.DataGridView();
            this.Comandos = new Gizmox.WebGUI.Forms.ToolBar();
            this.btnAdicionar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.btnEditar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.btnRemover = new Gizmox.WebGUI.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUsuarios
            // 
            this.gridUsuarios.AllowUserToAddRows = false;
            this.gridUsuarios.AllowUserToDeleteRows = false;
            this.gridUsuarios.AllowUserToOrderColumns = true;
            this.gridUsuarios.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.gridUsuarios.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gridUsuarios.Location = new System.Drawing.Point(3, 34);
            this.gridUsuarios.Name = "gridUsuarios";
            this.gridUsuarios.Size = new System.Drawing.Size(622, 193);
            this.gridUsuarios.TabIndex = 0;
            // 
            // Comandos
            // 
            this.Comandos.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Comandos.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.Comandos.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.btnAdicionar,
            this.btnEditar,
            this.btnRemover});
            this.Comandos.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.Comandos.DragHandle = true;
            this.Comandos.DropDownArrows = false;
            this.Comandos.ImageList = null;
            this.Comandos.Location = new System.Drawing.Point(0, 0);
            this.Comandos.MenuHandle = true;
            this.Comandos.Name = "Comandos";
            this.Comandos.RightToLeft = false;
            this.Comandos.ShowToolTips = true;
            this.Comandos.TabIndex = 1;
            this.Comandos.Click += new Gizmox.WebGUI.Forms.ToolBarItemHandler(this.Comandos_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.CustomStyle = "";
            this.btnAdicionar.ImageKey = null;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Pushed = true;
            this.btnAdicionar.Size = 24;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.ToolTipText = "Adiciona um novo usuário";
            // 
            // btnEditar
            // 
            this.btnEditar.CustomStyle = "";
            this.btnEditar.ImageKey = null;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Pushed = true;
            this.btnEditar.Size = 24;
            this.btnEditar.Text = "Editar";
            this.btnEditar.ToolTipText = "Edita as proriedades do usuário selecionado";
            // 
            // btnRemover
            // 
            this.btnRemover.CustomStyle = "";
            this.btnRemover.ImageKey = null;
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Pushed = true;
            this.btnRemover.Size = 24;
            this.btnRemover.Text = "Remover";
            this.btnRemover.ToolTipText = "Remove o usuário selecionado";
            // 
            // Usuario_principal
            // 
            this.Controls.Add(this.Comandos);
            this.Controls.Add(this.gridUsuarios);
            this.Size = new System.Drawing.Size(628, 230);
            this.Text = "Usuario_principal";
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView gridUsuarios;
        private Gizmox.WebGUI.Forms.ToolBar Comandos;
        private Gizmox.WebGUI.Forms.ToolBarButton btnAdicionar;
        private Gizmox.WebGUI.Forms.ToolBarButton btnEditar;
        private Gizmox.WebGUI.Forms.ToolBarButton btnRemover;


    }
}