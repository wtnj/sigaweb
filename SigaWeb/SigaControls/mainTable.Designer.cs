namespace SigaControls
{
    partial class mainTable
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
            this.tcMainTable = new Gizmox.WebGUI.Forms.TabControl();
            this.tpJoin = new Gizmox.WebGUI.Forms.TabPage();
            this.tpFieldsReturn = new Gizmox.WebGUI.Forms.TabPage();
            this.tpGourp = new Gizmox.WebGUI.Forms.TabPage();
            this.tpFilter = new Gizmox.WebGUI.Forms.TabPage();
            this.tpOrder = new Gizmox.WebGUI.Forms.TabPage();
            this.tpParms = new Gizmox.WebGUI.Forms.TabPage();
            this.btnShowDados = new Gizmox.WebGUI.Forms.Button();
            this.btnShowQuery = new Gizmox.WebGUI.Forms.Button();
            this.btnShowTables = new Gizmox.WebGUI.Forms.Button();
            this.txtFilterTables = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNomeRelatorio = new Gizmox.WebGUI.Forms.TextBox();
            this.btnSalve = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // tcMainTable
            // 
            this.tcMainTable.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.tcMainTable.Controls.Add(this.tpJoin);
            this.tcMainTable.Controls.Add(this.tpFieldsReturn);
            this.tcMainTable.Controls.Add(this.tpGourp);
            this.tcMainTable.Controls.Add(this.tpFilter);
            this.tcMainTable.Controls.Add(this.tpOrder);
            this.tcMainTable.Controls.Add(this.tpParms);
            this.tcMainTable.Location = new System.Drawing.Point(0, 32);
            this.tcMainTable.Multiline = false;
            this.tcMainTable.Name = "tcMainTable";
            this.tcMainTable.SelectedIndex = 0;
            this.tcMainTable.Size = new System.Drawing.Size(467, 207);
            this.tcMainTable.TabIndex = 0;
            // 
            // tpJoin
            // 
            this.tpJoin.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tpJoin.AutoScroll = true;
            this.tpJoin.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpJoin.Location = new System.Drawing.Point(4, 22);
            this.tpJoin.Name = "tpJoin";
            this.tpJoin.Size = new System.Drawing.Size(459, 181);
            this.tpJoin.TabIndex = 0;
            this.tpJoin.Text = "[TABLES]";
            this.tpJoin.ControlAdded += new Gizmox.WebGUI.Forms.ControlEventHandler(this.tpJoin_ControlAdded);
            this.tpJoin.Resize += new System.EventHandler(this.tpJoin_Resize);
            this.tpJoin.ControlRemoved += new Gizmox.WebGUI.Forms.ControlEventHandler(this.tpJoin_ControlRemoved);
            // 
            // tpFieldsReturn
            // 
            this.tpFieldsReturn.Location = new System.Drawing.Point(4, 22);
            this.tpFieldsReturn.Name = "tpFieldsReturn";
            this.tpFieldsReturn.Size = new System.Drawing.Size(459, 181);
            this.tpFieldsReturn.TabIndex = 0;
            this.tpFieldsReturn.Text = "Campos";
            // 
            // tpGourp
            // 
            this.tpGourp.Location = new System.Drawing.Point(4, 22);
            this.tpGourp.Name = "tpGourp";
            this.tpGourp.Size = new System.Drawing.Size(459, 181);
            this.tpGourp.TabIndex = 0;
            this.tpGourp.Text = "Agrupamentos";
            // 
            // tpFilter
            // 
            this.tpFilter.Location = new System.Drawing.Point(4, 22);
            this.tpFilter.Name = "tpFilter";
            this.tpFilter.Size = new System.Drawing.Size(459, 181);
            this.tpFilter.TabIndex = 0;
            this.tpFilter.Text = "Filtros";
            // 
            // tpOrder
            // 
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(459, 181);
            this.tpOrder.TabIndex = 0;
            this.tpOrder.Text = "Ordem";
            // 
            // tpParms
            // 
            this.tpParms.Location = new System.Drawing.Point(4, 22);
            this.tpParms.Name = "tpParms";
            this.tpParms.Size = new System.Drawing.Size(459, 181);
            this.tpParms.TabIndex = 0;
            this.tpParms.Text = "Parametros";
            // 
            // btnShowDados
            // 
            this.btnShowDados.Location = new System.Drawing.Point(4, 3);
            this.btnShowDados.Name = "btnShowDados";
            this.btnShowDados.Size = new System.Drawing.Size(50, 23);
            this.btnShowDados.TabIndex = 1;
            this.btnShowDados.Text = "Dados";
            this.btnShowDados.Click += new System.EventHandler(this.btnShowDados_Click);
            // 
            // btnShowQuery
            // 
            this.btnShowQuery.Location = new System.Drawing.Point(60, 3);
            this.btnShowQuery.Name = "btnShowQuery";
            this.btnShowQuery.Size = new System.Drawing.Size(50, 23);
            this.btnShowQuery.TabIndex = 1;
            this.btnShowQuery.Text = "Query";
            this.btnShowQuery.Click += new System.EventHandler(this.btnShowQuery_Click);
            // 
            // btnShowTables
            // 
            this.btnShowTables.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnShowTables.Location = new System.Drawing.Point(437, 3);
            this.btnShowTables.Name = "btnShowTables";
            this.btnShowTables.Size = new System.Drawing.Size(26, 23);
            this.btnShowTables.TabIndex = 2;
            this.btnShowTables.Text = "+";
            this.btnShowTables.Click += new System.EventHandler(this.btnShowTables_Click);
            // 
            // txtFilterTables
            // 
            this.txtFilterTables.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.txtFilterTables.Location = new System.Drawing.Point(298, 5);
            this.txtFilterTables.Name = "txtFilterTables";
            this.txtFilterTables.Size = new System.Drawing.Size(133, 20);
            this.txtFilterTables.TabIndex = 3;
            this.txtFilterTables.Text = "filtro";
            // 
            // txtNomeRelatorio
            // 
            this.txtNomeRelatorio.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.txtNomeRelatorio.Location = new System.Drawing.Point(172, 5);
            this.txtNomeRelatorio.Name = "txtNomeRelatorio";
            this.txtNomeRelatorio.Size = new System.Drawing.Size(120, 20);
            this.txtNomeRelatorio.TabIndex = 3;
            this.txtNomeRelatorio.GotFocus += new System.EventHandler(this.txtNomeRelatorio_GotFocus);
            this.txtNomeRelatorio.TextChanged += new System.EventHandler(this.txtNomeRelatorio_TextChanged);
            // 
            // btnSalve
            // 
            this.btnSalve.Location = new System.Drawing.Point(116, 3);
            this.btnSalve.Name = "btnSalve";
            this.btnSalve.Size = new System.Drawing.Size(50, 23);
            this.btnSalve.TabIndex = 4;
            this.btnSalve.Text = "Salvar";
            this.btnSalve.Click += new System.EventHandler(this.btnSalve_Click);
            // 
            // mainTable
            // 
            this.Controls.Add(this.btnSalve);
            this.Controls.Add(this.txtNomeRelatorio);
            this.Controls.Add(this.txtFilterTables);
            this.Controls.Add(this.btnShowTables);
            this.Controls.Add(this.btnShowQuery);
            this.Controls.Add(this.btnShowDados);
            this.Controls.Add(this.tcMainTable);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(467, 239);
            this.Text = "MainTable";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl tcMainTable;
        private Gizmox.WebGUI.Forms.TabPage tpJoin;
        private Gizmox.WebGUI.Forms.TabPage tpGourp;
        private Gizmox.WebGUI.Forms.TabPage tpFilter;
        private Gizmox.WebGUI.Forms.TabPage tpOrder;
        private Gizmox.WebGUI.Forms.TabPage tpParms;
        private Gizmox.WebGUI.Forms.TabPage tpFieldsReturn;
        private Gizmox.WebGUI.Forms.Button btnShowDados;
        private Gizmox.WebGUI.Forms.Button btnShowQuery;
        private Gizmox.WebGUI.Forms.Button btnShowTables;
        private Gizmox.WebGUI.Forms.TextBox txtFilterTables;
        private Gizmox.WebGUI.Forms.TextBox txtNomeRelatorio;
        private Gizmox.WebGUI.Forms.Button btnSalve;
    }
}