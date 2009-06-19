namespace SigaControls.Report
{
    partial class ReportList
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
            this.menu = new Gizmox.WebGUI.Forms.ToolBar();
            this.tbbAdd = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbVer = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbEdit = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbDel = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.sep1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbExcel = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbPDF = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.sep2 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.dgvReports = new Gizmox.WebGUI.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
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
            this.menu.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.menu.DragHandle = true;
            this.menu.DropDownArrows = false;
            this.menu.ImageList = null;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.MenuHandle = true;
            this.menu.Name = "menu";
            this.menu.RightToLeft = false;
            this.menu.ShowToolTips = true;
            this.menu.TabIndex = 0;
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
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AllowUserToOrderColumns = true;
            this.dgvReports.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.dgvReports.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvReports.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvReports.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvReports.Location = new System.Drawing.Point(0, 28);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.Size = new System.Drawing.Size(814, 399);
            this.dgvReports.TabIndex = 1;
            // 
            // ReportList
            // 
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.menu);
            this.Size = new System.Drawing.Size(814, 427);
            this.Text = "ReportList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar menu;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbAdd;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbVer;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbEdit;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbDel;
        private Gizmox.WebGUI.Forms.ToolBarButton sep1;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbExcel;
        private Gizmox.WebGUI.Forms.ToolBarButton tbbPDF;
        private Gizmox.WebGUI.Forms.ToolBarButton sep2;
        private Gizmox.WebGUI.Forms.DataGridView dgvReports;


    }
}