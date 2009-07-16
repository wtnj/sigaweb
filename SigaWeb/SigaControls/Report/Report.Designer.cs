namespace SigaControls.Report
{
    partial class Report
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
            this.btnAddTable = new Gizmox.WebGUI.Forms.Button();
            this.txtFiltro = new Gizmox.WebGUI.Forms.TextBox();
            this.reportPanel = new Gizmox.WebGUI.Forms.Panel();
            this.txtSalvar = new Gizmox.WebGUI.Forms.Button();
            this.btnShowQuery = new Gizmox.WebGUI.Forms.Button();
            this.btnShowData = new Gizmox.WebGUI.Forms.Button();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.txtReportName = new Gizmox.WebGUI.Forms.TextBox();
            this.cbReportGroup = new Gizmox.WebGUI.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(3, 3);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(25, 23);
            this.btnAddTable.TabIndex = 0;
            this.btnAddTable.Text = "+";
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(34, 5);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(128, 20);
            this.txtFiltro.TabIndex = 1;
            // 
            // reportPanel
            // 
            this.reportPanel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.reportPanel.Location = new System.Drawing.Point(3, 32);
            this.reportPanel.Name = "reportPanel";
            this.reportPanel.Size = new System.Drawing.Size(599, 236);
            this.reportPanel.TabIndex = 2;
            this.reportPanel.ControlAdded += new Gizmox.WebGUI.Forms.ControlEventHandler(this.reportPanel_ControlAdded);
            // 
            // txtSalvar
            // 
            this.txtSalvar.Location = new System.Drawing.Point(168, 3);
            this.txtSalvar.Name = "txtSalvar";
            this.txtSalvar.Size = new System.Drawing.Size(55, 23);
            this.txtSalvar.TabIndex = 0;
            this.txtSalvar.Text = "SALVAR";
            this.txtSalvar.Click += new System.EventHandler(this.txtSalvar_Click);
            // 
            // btnShowQuery
            // 
            this.btnShowQuery.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnShowQuery.Location = new System.Drawing.Point(456, 3);
            this.btnShowQuery.Name = "btnShowQuery";
            this.btnShowQuery.Size = new System.Drawing.Size(55, 23);
            this.btnShowQuery.TabIndex = 0;
            this.btnShowQuery.Text = "QUERY";
            this.btnShowQuery.Click += new System.EventHandler(this.btnShowQuery_Click);
            // 
            // btnShowData
            // 
            this.btnShowData.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnShowData.Location = new System.Drawing.Point(517, 3);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(55, 23);
            this.btnShowData.TabIndex = 0;
            this.btnShowData.Text = "DADOS";
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(577, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(25, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "X";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtReportName
            // 
            this.txtReportName.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.txtReportName.Location = new System.Drawing.Point(229, 5);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(104, 20);
            this.txtReportName.TabIndex = 1;
            this.txtReportName.TextChanged += new System.EventHandler(this.txtReportName_TextChanged);
            // 
            // cbReportGroup
            // 
            this.cbReportGroup.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.cbReportGroup.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbReportGroup.Location = new System.Drawing.Point(339, 5);
            this.cbReportGroup.Name = "cbReportGroup";
            this.cbReportGroup.Size = new System.Drawing.Size(111, 21);
            this.cbReportGroup.TabIndex = 3;
            this.cbReportGroup.TextChanged += new System.EventHandler(this.cbReportGroup_TextChanged);
            // 
            // Report
            // 
            this.Controls.Add(this.cbReportGroup);
            this.Controls.Add(this.txtReportName);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnShowQuery);
            this.Controls.Add(this.btnShowData);
            this.Controls.Add(this.txtSalvar);
            this.Controls.Add(this.reportPanel);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnAddTable);
            this.Size = new System.Drawing.Size(605, 271);
            this.Text = "Report";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnAddTable;
        private Gizmox.WebGUI.Forms.TextBox txtFiltro;
        private Gizmox.WebGUI.Forms.Panel reportPanel;
        private Gizmox.WebGUI.Forms.Button txtSalvar;
        private Gizmox.WebGUI.Forms.Button btnShowQuery;
        private Gizmox.WebGUI.Forms.Button btnShowData;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.TextBox txtReportName;
        private Gizmox.WebGUI.Forms.ComboBox cbReportGroup;


    }
}