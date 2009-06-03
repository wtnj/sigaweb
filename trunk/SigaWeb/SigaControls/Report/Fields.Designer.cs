namespace SigaControls.Report
{
    partial class Fields
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
            this.cbAllNone = new Gizmox.WebGUI.Forms.CheckBox();
            this.dgvFields = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnGrouping = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAllNone
            // 
            this.cbAllNone.Checked = false;
            this.cbAllNone.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.cbAllNone.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.cbAllNone.Location = new System.Drawing.Point(13, 16);
            this.cbAllNone.Name = "cbAllNone";
            this.cbAllNone.Size = new System.Drawing.Size(147, 20);
            this.cbAllNone.TabIndex = 1;
            this.cbAllNone.Text = "Marcar todos";
            this.cbAllNone.ThreeState = false;
            this.cbAllNone.CheckedChanged += new System.EventHandler(this.cbAllNone_CheckedChanged);
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.AllowUserToDeleteRows = false;
            this.dgvFields.AllowUserToOrderColumns = true;
            this.dgvFields.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.dgvFields.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvFields.CellBorderStyle = Gizmox.WebGUI.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvFields.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvFields.Location = new System.Drawing.Point(13, 42);
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.RowHeadersBorderStyle = Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvFields.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFields.Size = new System.Drawing.Size(544, 253);
            this.dgvFields.TabIndex = 2;
            this.dgvFields.UseInternalPaging = false;
            this.dgvFields.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvFields_CellClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewCheckBoxColumn1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.dataGridViewCheckBoxColumn1.HeaderText = "x";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.ToolTipText = "Marcar os Campos para o Exibição no relatório";
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn2.HeaderText = "codCampo";
            this.dataGridViewTextBoxColumn2.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.ToolTipText = "campo interno com o codigo do campo";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn1.HeaderText = "CAMPO";
            this.dataGridViewTextBoxColumn1.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn3.HeaderText = "codGroup";
            this.dataGridViewTextBoxColumn3.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn4.HeaderText = "AGRUPAMENTO";
            this.dataGridViewTextBoxColumn4.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Width = 100;
            // 
            // btnGrouping
            // 
            this.btnGrouping.Location = new System.Drawing.Point(166, 13);
            this.btnGrouping.Name = "btnGrouping";
            this.btnGrouping.Size = new System.Drawing.Size(101, 23);
            this.btnGrouping.TabIndex = 3;
            this.btnGrouping.Text = "Definir Retorno";
            this.btnGrouping.Click += new System.EventHandler(this.btnGrouping_Click);
            // 
            // Fields
            // 
            this.Controls.Add(this.btnGrouping);
            this.Controls.Add(this.dgvFields);
            this.Controls.Add(this.cbAllNone);
            this.Size = new System.Drawing.Size(571, 309);
            this.Text = "Fields";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox cbAllNone;
        private Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Gizmox.WebGUI.Forms.Button btnGrouping;
        public Gizmox.WebGUI.Forms.DataGridView dgvFields;


    }
}