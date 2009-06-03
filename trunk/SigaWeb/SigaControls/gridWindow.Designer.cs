namespace SigaControls
{
    partial class gridWindow
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
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.barra = new Gizmox.WebGUI.Forms.StatusBar();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.BtnPdf = new Gizmox.WebGUI.Forms.Button();
            this.BtnTxt = new Gizmox.WebGUI.Forms.Button();
            this.ABAS = new Gizmox.WebGUI.Forms.TabControl();
            this.tpGrid = new Gizmox.WebGUI.Forms.TabPage();
            this.tpFiltro = new Gizmox.WebGUI.Forms.TabPage();
            this.btnAdd = new Gizmox.WebGUI.Forms.Button();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cbTipo = new Gizmox.WebGUI.Forms.ComboBox();
            this.cbCampos = new Gizmox.WebGUI.Forms.ComboBox();
            this.lbFiltros = new Gizmox.WebGUI.Forms.ListBox();
            this.txtFiltro = new Gizmox.WebGUI.Forms.TextBox();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.cbxPage = new Gizmox.WebGUI.Forms.CheckBox();
            this.nudPaginas = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.cbTotal = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaginas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(834, 414);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UseInternalPaging = false;
            this.dataGridView1.RowsAdded += new Gizmox.WebGUI.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.ColumnAdded += new Gizmox.WebGUI.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnAdded);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.DataBindingComplete += new Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // barra
            // 
            this.barra.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.barra.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.barra.Location = new System.Drawing.Point(0, 495);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(860, 22);
            this.barra.TabIndex = 1;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Location = new System.Drawing.Point(3, 5);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(90, 23);
            this.BtnExcel.TabIndex = 2;
            this.BtnExcel.Text = "Exportar Excel";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnPdf
            // 
            this.BtnPdf.Location = new System.Drawing.Point(99, 5);
            this.BtnPdf.Name = "BtnPdf";
            this.BtnPdf.Size = new System.Drawing.Size(91, 23);
            this.BtnPdf.TabIndex = 3;
            this.BtnPdf.Text = "Exportar Pdf";
            this.BtnPdf.Click += new System.EventHandler(this.BtnPdf_Click);
            // 
            // BtnTxt
            // 
            this.BtnTxt.Location = new System.Drawing.Point(196, 5);
            this.BtnTxt.Name = "BtnTxt";
            this.BtnTxt.Size = new System.Drawing.Size(86, 23);
            this.BtnTxt.TabIndex = 4;
            this.BtnTxt.Text = "Exportar Txt";
            this.BtnTxt.Click += new System.EventHandler(this.BtnTxt_Click);
            // 
            // ABAS
            // 
            this.ABAS.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.ABAS.Controls.Add(this.tpGrid);
            this.ABAS.Controls.Add(this.tpFiltro);
            this.ABAS.Location = new System.Drawing.Point(3, 40);
            this.ABAS.Multiline = false;
            this.ABAS.Name = "ABAS";
            this.ABAS.SelectedIndex = 0;
            this.ABAS.Size = new System.Drawing.Size(854, 449);
            this.ABAS.TabIndex = 5;
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.dataGridView1);
            this.tpGrid.Location = new System.Drawing.Point(4, 22);
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.Size = new System.Drawing.Size(846, 423);
            this.tpGrid.TabIndex = 0;
            this.tpGrid.Text = "Dados";
            // 
            // tpFiltro
            // 
            this.tpFiltro.Controls.Add(this.btnAdd);
            this.tpFiltro.Controls.Add(this.label4);
            this.tpFiltro.Controls.Add(this.label3);
            this.tpFiltro.Controls.Add(this.label2);
            this.tpFiltro.Controls.Add(this.label1);
            this.tpFiltro.Controls.Add(this.cbTipo);
            this.tpFiltro.Controls.Add(this.cbCampos);
            this.tpFiltro.Controls.Add(this.lbFiltros);
            this.tpFiltro.Controls.Add(this.txtFiltro);
            this.tpFiltro.Controls.Add(this.btnFiltrar);
            this.tpFiltro.Location = new System.Drawing.Point(4, 22);
            this.tpFiltro.Name = "tpFiltro";
            this.tpFiltro.Size = new System.Drawing.Size(846, 423);
            this.tpFiltro.TabIndex = 0;
            this.tpFiltro.Text = "Filtro";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(331, 52);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(11, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "FILTROS DEFINIDOS";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(225, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "FILTRO";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(138, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "TIPO";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "CAMPO";
            // 
            // cbTipo
            // 
            this.cbTipo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbTipo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Items.AddRange(new object[] {
            "=",
            "!=",
            ">=",
            "<=",
            "LIKE",
            "IN",
            "NOT IN"});
            this.cbTipo.Location = new System.Drawing.Point(141, 51);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(78, 21);
            this.cbTipo.TabIndex = 4;
            // 
            // cbCampos
            // 
            this.cbCampos.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbCampos.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbCampos.Location = new System.Drawing.Point(14, 51);
            this.cbCampos.Name = "cbCampos";
            this.cbCampos.Size = new System.Drawing.Size(121, 21);
            this.cbCampos.TabIndex = 3;
            // 
            // lbFiltros
            // 
            this.lbFiltros.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.lbFiltros.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.lbFiltros.Location = new System.Drawing.Point(14, 125);
            this.lbFiltros.Name = "lbFiltros";
            this.lbFiltros.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.lbFiltros.Size = new System.Drawing.Size(311, 251);
            this.lbFiltros.TabIndex = 2;
            this.lbFiltros.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.lbFiltros_KeyUp);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(225, 52);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(331, 125);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cbxPage
            // 
            this.cbxPage.Checked = false;
            this.cbxPage.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.cbxPage.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.cbxPage.Location = new System.Drawing.Point(405, 9);
            this.cbxPage.Name = "cbxPage";
            this.cbxPage.Size = new System.Drawing.Size(66, 24);
            this.cbxPage.TabIndex = 6;
            this.cbxPage.Text = "Paginar";
            this.cbxPage.ThreeState = false;
            this.cbxPage.CheckedChanged += new System.EventHandler(this.cbxPage_CheckedChanged);
            // 
            // nudPaginas
            // 
            this.nudPaginas.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPaginas.Location = new System.Drawing.Point(329, 9);
            this.nudPaginas.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPaginas.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPaginas.Name = "nudPaginas";
            this.nudPaginas.Size = new System.Drawing.Size(70, 20);
            this.nudPaginas.TabIndex = 7;
            this.nudPaginas.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.nudPaginas.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Left;
            this.nudPaginas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPaginas.ValueChanged += new System.EventHandler(this.nudPaginas_ValueChanged);
            // 
            // cbTotal
            // 
            this.cbTotal.Checked = false;
            this.cbTotal.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.cbTotal.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.cbTotal.Location = new System.Drawing.Point(502, 10);
            this.cbTotal.Name = "cbTotal";
            this.cbTotal.Size = new System.Drawing.Size(66, 24);
            this.cbTotal.TabIndex = 6;
            this.cbTotal.Text = "Totalizar";
            this.cbTotal.ThreeState = false;
            this.cbTotal.CheckedChanged += new System.EventHandler(this.cbTotal_CheckedChanged);
            // 
            // gridWindow
            // 
            this.Controls.Add(this.cbTotal);
            this.Controls.Add(this.nudPaginas);
            this.Controls.Add(this.cbxPage);
            this.Controls.Add(this.ABAS);
            this.Controls.Add(this.BtnTxt);
            this.Controls.Add(this.BtnPdf);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.barra);
            this.Size = new System.Drawing.Size(860, 517);
            this.Text = "Grid Window";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaginas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView dataGridView1;
        private Gizmox.WebGUI.Forms.StatusBar barra;
        private Gizmox.WebGUI.Forms.Button BtnExcel;
        private Gizmox.WebGUI.Forms.Button BtnPdf;
        private Gizmox.WebGUI.Forms.Button BtnTxt;
        private Gizmox.WebGUI.Forms.TabControl ABAS;
        private Gizmox.WebGUI.Forms.TabPage tpGrid;
        private Gizmox.WebGUI.Forms.TabPage tpFiltro;
        private Gizmox.WebGUI.Forms.Button btnFiltrar;
        private Gizmox.WebGUI.Forms.TextBox txtFiltro;
        private Gizmox.WebGUI.Forms.ComboBox cbTipo;
        private Gizmox.WebGUI.Forms.ComboBox cbCampos;
        private Gizmox.WebGUI.Forms.ListBox lbFiltros;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button btnAdd;
        private Gizmox.WebGUI.Forms.CheckBox cbxPage;
        private Gizmox.WebGUI.Forms.NumericUpDown nudPaginas;
        private Gizmox.WebGUI.Forms.CheckBox cbTotal;


    }
}