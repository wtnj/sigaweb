using Gizmox.WebGUI.Common.Resources;
namespace SigaControls.Cadastros
{
    partial class ContasAPagarList
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
            this.dgvDados = new Gizmox.WebGUI.Forms.DataGridView();
            this.menu = new Gizmox.WebGUI.Forms.ToolBar();
            this.tbbAdd = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbVer = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbEdit = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbDel = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.sep1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbExcel = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbPDF = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.sep2 = new Gizmox.WebGUI.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            this.dgvDados.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.dgvDados.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvDados.Location = new System.Drawing.Point(10, 34);
            this.dgvDados.MultiSelect = false;
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.Size = new System.Drawing.Size(513, 262);
            this.dgvDados.TabIndex = 0;
            this.dgvDados.UseInternalPaging = false;
            // 
            // menu
            // 
            this.menu.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.menu.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.menu.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbbAdd,
            this.tbbVer,
            this.tbbEdit,
            this.tbbDel,
            this.sep1,
            this.tbbExcel,
            this.tbbPDF,
            this.sep2});
            this.menu.ButtonSize = new System.Drawing.Size(25, 25);
            this.menu.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.menu.DragHandle = true;
            this.menu.DropDownArrows = false;
            this.menu.ImageList = null;
            this.menu.ImageSize = new System.Drawing.Size(16, 16);
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.MenuHandle = true;
            this.menu.Name = "menu";
            this.menu.RightToLeft = false;
            this.menu.ShowToolTips = true;
            this.menu.TabIndex = 1;
            this.menu.Click += new Gizmox.WebGUI.Forms.ToolBarItemHandler(this.menu_Click);
            // 
            // tbbAdd
            // 
            this.tbbAdd.CustomStyle = "";
            this.tbbAdd.ImageKey = null;
            this.tbbAdd.Name = "tbbAdd";
            this.tbbAdd.Pushed = true;
            this.tbbAdd.Size = 24;
            this.tbbAdd.ToolTipText = "Incluir";
            // 
            // tbbVer
            // 
            this.tbbVer.CustomStyle = "";
            this.tbbVer.ImageKey = null;
            this.tbbVer.Name = "tbbVer";
            this.tbbVer.Pushed = true;
            this.tbbVer.Size = 24;
            this.tbbVer.ToolTipText = "Visualizar";
            // 
            // tbbEdit
            // 
            this.tbbEdit.CustomStyle = "";
            this.tbbEdit.ImageKey = null;
            this.tbbEdit.Name = "tbbEdit";
            this.tbbEdit.Pushed = true;
            this.tbbEdit.Size = 24;
            this.tbbEdit.ToolTipText = "Editar";
            // 
            // tbbDel
            // 
            this.tbbDel.CustomStyle = "";
            this.tbbDel.ImageKey = null;
            this.tbbDel.Name = "tbbDel";
            this.tbbDel.Pushed = true;
            this.tbbDel.Size = 24;
            this.tbbDel.ToolTipText = "Excluir";
            // 
            // sep1
            // 
            this.sep1.CustomStyle = "";
            this.sep1.ImageKey = null;
            this.sep1.Name = "sep1";
            this.sep1.Pushed = true;
            this.sep1.Size = 24;
            this.sep1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.sep1.ToolTipText = "";
            // 
            // tbbExcel
            // 
            this.tbbExcel.CustomStyle = "";
            this.tbbExcel.ImageKey = null;
            this.tbbExcel.Name = "tbbExcel";
            this.tbbExcel.Pushed = true;
            this.tbbExcel.Size = 24;
            this.tbbExcel.ToolTipText = "Gerar Excel";
            // 
            // tbbPDF
            // 
            this.tbbPDF.CustomStyle = "";
            this.tbbPDF.ImageKey = null;
            this.tbbPDF.Name = "tbbPDF";
            this.tbbPDF.Pushed = true;
            this.tbbPDF.Size = 24;
            this.tbbPDF.ToolTipText = "Gerar PDF";
            // 
            // sep2
            // 
            this.sep2.CustomStyle = "";
            this.sep2.ImageKey = null;
            this.sep2.Name = "sep2";
            this.sep2.Pushed = true;
            this.sep2.Size = 24;
            this.sep2.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.sep2.ToolTipText = "";
            // 
            // ContasAPagarList
            // 
            this.Controls.Add(this.menu);
            this.Controls.Add(this.dgvDados);
            this.Size = new System.Drawing.Size(533, 306);
            this.Text = "ContasAPagar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView dgvDados;
        private Gizmox.WebGUI.Forms.ToolBar menu;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbAdd;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbEdit;
        private Gizmox.WebGUI.Forms.ToolBarButton sep1;
        private Gizmox.WebGUI.Forms.ToolBarButton sep2;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbDel;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbExcel;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbPDF;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbVer;


    }
}