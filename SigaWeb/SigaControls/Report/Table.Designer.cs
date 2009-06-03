namespace SigaControls.Report
{
    partial class Table
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
            this.tcJoins = new Gizmox.WebGUI.Forms.TabControl();
            this.tpFieldsReturn = new Gizmox.WebGUI.Forms.TabPage();
            this.tpLINKIN = new Gizmox.WebGUI.Forms.TabPage();
            this.cbRelatedType = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cbRelatedTable = new Gizmox.WebGUI.Forms.ComboBox();
            this.tpJoin = new Gizmox.WebGUI.Forms.TabPage();
            this.btnAddTable = new Gizmox.WebGUI.Forms.Button();
            this.txtFilterTables = new Gizmox.WebGUI.Forms.TextBox();
            this.linksPainel = new Gizmox.WebGUI.Forms.Panel();
            this.tpGourp = new Gizmox.WebGUI.Forms.TabPage();
            this.tpFilter = new Gizmox.WebGUI.Forms.TabPage();
            this.tpOrder = new Gizmox.WebGUI.Forms.TabPage();
            this.tpParms = new Gizmox.WebGUI.Forms.TabPage();
            this.lblTabela = new Gizmox.WebGUI.Forms.Label();
            this.btnCloseThis = new Gizmox.WebGUI.Forms.Button();
            this.TOTALIZAR = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tcJoins
            // 
            this.tcJoins.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.tcJoins.Controls.Add(this.tpFieldsReturn);
            this.tcJoins.Controls.Add(this.tpLINKIN);
            this.tcJoins.Controls.Add(this.tpJoin);
            this.tcJoins.Controls.Add(this.tpGourp);
            this.tcJoins.Controls.Add(this.tpFilter);
            this.tcJoins.Controls.Add(this.tpOrder);
            this.tcJoins.Controls.Add(this.tpParms);
            this.tcJoins.Location = new System.Drawing.Point(3, 32);
            this.tcJoins.Multiline = false;
            this.tcJoins.Name = "tcJoins";
            this.tcJoins.SelectedIndex = 0;
            this.tcJoins.Size = new System.Drawing.Size(463, 334);
            this.tcJoins.TabIndex = 0;
            // 
            // tpFieldsReturn
            // 
            this.tpFieldsReturn.Location = new System.Drawing.Point(4, 22);
            this.tpFieldsReturn.Name = "tpFieldsReturn";
            this.tpFieldsReturn.Size = new System.Drawing.Size(455, 308);
            this.tpFieldsReturn.TabIndex = 0;
            this.tpFieldsReturn.Text = "Campos";
            // 
            // tpLINKIN
            // 
            this.tpLINKIN.AutoScroll = true;
            this.tpLINKIN.Controls.Add(this.cbRelatedType);
            this.tpLINKIN.Controls.Add(this.label2);
            this.tpLINKIN.Controls.Add(this.label1);
            this.tpLINKIN.Controls.Add(this.cbRelatedTable);
            this.tpLINKIN.Location = new System.Drawing.Point(4, 22);
            this.tpLINKIN.Name = "tpLINKIN";
            this.tpLINKIN.Size = new System.Drawing.Size(455, 308);
            this.tpLINKIN.TabIndex = 0;
            this.tpLINKIN.Text = "Relação";
            // 
            // cbRelatedType
            // 
            this.cbRelatedType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbRelatedType.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbRelatedType.Location = new System.Drawing.Point(14, 90);
            this.cbRelatedType.Name = "cbRelatedType";
            this.cbRelatedType.Size = new System.Drawing.Size(183, 21);
            this.cbRelatedType.TabIndex = 0;
            this.cbRelatedType.SelectedIndexChanged += new System.EventHandler(this.cbRelatedType_SelectedIndexChanged);
            this.cbRelatedType.TextChanged += new System.EventHandler(this.cbRelatedType_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "RELAÇÃO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "RELACIONADA A";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbRelatedTable
            // 
            this.cbRelatedTable.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbRelatedTable.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbRelatedTable.Location = new System.Drawing.Point(14, 40);
            this.cbRelatedTable.Name = "cbRelatedTable";
            this.cbRelatedTable.Size = new System.Drawing.Size(183, 21);
            this.cbRelatedTable.TabIndex = 0;
            this.cbRelatedTable.SelectedIndexChanged += new System.EventHandler(this.cbRelatedTable_SelectedIndexChanged);
            this.cbRelatedTable.TextChanged += new System.EventHandler(this.cbRelatedTable_TextChanged);
            // 
            // tpJoin
            // 
            this.tpJoin.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tpJoin.Controls.Add(this.btnAddTable);
            this.tpJoin.Controls.Add(this.txtFilterTables);
            this.tpJoin.Controls.Add(this.linksPainel);
            this.tpJoin.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpJoin.Location = new System.Drawing.Point(4, 22);
            this.tpJoin.Name = "tpJoin";
            this.tpJoin.Size = new System.Drawing.Size(455, 308);
            this.tpJoin.TabIndex = 0;
            this.tpJoin.Text = "Links";
            this.tpJoin.ControlAdded += new Gizmox.WebGUI.Forms.ControlEventHandler(this.tpJoin_ControlAdded);
            this.tpJoin.Resize += new System.EventHandler(this.tpJoin_Resize);
            this.tpJoin.ControlRemoved += new Gizmox.WebGUI.Forms.ControlEventHandler(this.tpJoin_ControlRemoved);
            // 
            // btnAddTable
            // 
            this.btnAddTable.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.btnAddTable.Location = new System.Drawing.Point(3, 5);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(23, 23);
            this.btnAddTable.TabIndex = 2;
            this.btnAddTable.Text = "+";
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // txtFilterTables
            // 
            this.txtFilterTables.Location = new System.Drawing.Point(32, 8);
            this.txtFilterTables.Name = "txtFilterTables";
            this.txtFilterTables.Size = new System.Drawing.Size(317, 20);
            this.txtFilterTables.TabIndex = 1;
            // 
            // linksPainel
            // 
            this.linksPainel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.linksPainel.AutoScroll = true;
            this.linksPainel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.linksPainel.Location = new System.Drawing.Point(3, 34);
            this.linksPainel.Name = "linksPainel";
            this.linksPainel.Size = new System.Drawing.Size(449, 271);
            this.linksPainel.TabIndex = 0;
            this.linksPainel.ControlAdded += new Gizmox.WebGUI.Forms.ControlEventHandler(this.linksPainel_ControlAdded);
            this.linksPainel.Resize += new System.EventHandler(this.linksPainel_Resize);
            this.linksPainel.ControlRemoved += new Gizmox.WebGUI.Forms.ControlEventHandler(this.linksPainel_ControlRemoved);
            // 
            // tpGourp
            // 
            this.tpGourp.Location = new System.Drawing.Point(4, 22);
            this.tpGourp.Name = "tpGourp";
            this.tpGourp.Size = new System.Drawing.Size(455, 308);
            this.tpGourp.TabIndex = 0;
            this.tpGourp.Text = "Agrupamentos";
            this.tpGourp.Visible = false;
            // 
            // tpFilter
            // 
            this.tpFilter.Location = new System.Drawing.Point(4, 22);
            this.tpFilter.Name = "tpFilter";
            this.tpFilter.Size = new System.Drawing.Size(455, 308);
            this.tpFilter.TabIndex = 0;
            this.tpFilter.Text = "Filtros";
            // 
            // tpOrder
            // 
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(455, 308);
            this.tpOrder.TabIndex = 0;
            this.tpOrder.Text = "Ordem";
            // 
            // tpParms
            // 
            this.tpParms.Location = new System.Drawing.Point(4, 22);
            this.tpParms.Name = "tpParms";
            this.tpParms.Size = new System.Drawing.Size(455, 308);
            this.tpParms.TabIndex = 0;
            this.tpParms.Text = "Parametros";
            // 
            // lblTabela
            // 
            this.lblTabela.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lblTabela.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTabela.Location = new System.Drawing.Point(3, 3);
            this.lblTabela.Name = "lblTabela";
            this.lblTabela.Size = new System.Drawing.Size(342, 23);
            this.lblTabela.TabIndex = 3;
            this.lblTabela.Text = "tabela";
            this.lblTabela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCloseThis
            // 
            this.btnCloseThis.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnCloseThis.BackColor = System.Drawing.Color.Red;
            this.btnCloseThis.BorderColor = System.Drawing.Color.Empty;
            this.btnCloseThis.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.btnCloseThis.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseThis.ForeColor = System.Drawing.Color.White;
            this.btnCloseThis.Location = new System.Drawing.Point(443, 3);
            this.btnCloseThis.Name = "btnCloseThis";
            this.btnCloseThis.Size = new System.Drawing.Size(23, 23);
            this.btnCloseThis.TabIndex = 2;
            this.btnCloseThis.Text = "x";
            this.btnCloseThis.Click += new System.EventHandler(this.btnCloseThis_Click);
            // 
            // TOTALIZAR
            // 
            this.TOTALIZAR.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.TOTALIZAR.Checked = false;
            this.TOTALIZAR.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.TOTALIZAR.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.TOTALIZAR.Location = new System.Drawing.Point(369, 3);
            this.TOTALIZAR.Name = "TOTALIZAR";
            this.TOTALIZAR.Size = new System.Drawing.Size(68, 24);
            this.TOTALIZAR.TabIndex = 4;
            this.TOTALIZAR.Text = "Totalizar";
            this.TOTALIZAR.ThreeState = false;
            this.TOTALIZAR.Visible = false;
            // 
            // Table
            // 
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.TOTALIZAR);
            this.Controls.Add(this.btnCloseThis);
            this.Controls.Add(this.lblTabela);
            this.Controls.Add(this.tcJoins);
            this.Size = new System.Drawing.Size(469, 369);
            this.Text = "Table";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl tcJoins;
        private Gizmox.WebGUI.Forms.TabPage tpJoin;
        private Gizmox.WebGUI.Forms.TabPage tpFieldsReturn;
        private Gizmox.WebGUI.Forms.TabPage tpGourp;
        private Gizmox.WebGUI.Forms.TabPage tpFilter;
        private Gizmox.WebGUI.Forms.TabPage tpOrder;
        private Gizmox.WebGUI.Forms.TabPage tpParms;
        private Gizmox.WebGUI.Forms.Panel linksPainel;
        private Gizmox.WebGUI.Forms.Button btnAddTable;
        private Gizmox.WebGUI.Forms.TextBox txtFilterTables;
        private Gizmox.WebGUI.Forms.Label lblTabela;
        private Gizmox.WebGUI.Forms.Button btnCloseThis;
        private Gizmox.WebGUI.Forms.TabPage tpLINKIN;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.ComboBox cbRelatedTable;
        private Gizmox.WebGUI.Forms.ComboBox cbRelatedType;
        private Gizmox.WebGUI.Forms.Label label2;
        public Gizmox.WebGUI.Forms.CheckBox TOTALIZAR;


    }
}