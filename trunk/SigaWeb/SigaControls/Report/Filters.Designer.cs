namespace SigaControls.Report
{
    partial class Filters
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
            this.DGFilters = new Gizmox.WebGUI.Forms.DataGridView();
            this.cbTables = new Gizmox.WebGUI.Forms.ComboBox();
            this.cbFields = new Gizmox.WebGUI.Forms.ComboBox();
            this.cbClausula = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtFilter = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.BtnOk = new Gizmox.WebGUI.Forms.Button();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGFilters)).BeginInit();
            this.SuspendLayout();
            // 
            // DGFilters
            // 
            this.DGFilters.AllowUserToAddRows = false;
            this.DGFilters.AllowUserToOrderColumns = true;
            this.DGFilters.AllowUserToResizeRows = false;
            this.DGFilters.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.DGFilters.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.DGFilters.Location = new System.Drawing.Point(3, 114);
            this.DGFilters.MultiSelect = false;
            this.DGFilters.Name = "DGFilters";
            this.DGFilters.RowTemplate.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.DGFilters.Size = new System.Drawing.Size(490, 211);
            this.DGFilters.TabIndex = 0;
            // 
            // cbTables
            // 
            this.cbTables.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbTables.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.DropDownWidth = 121;
            this.cbTables.Location = new System.Drawing.Point(3, 38);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(121, 21);
            this.cbTables.TabIndex = 1;
            this.cbTables.SelectedIndexChangedQueued += new System.EventHandler(this.cbTables_SelectedIndexChangedQueued);
            // 
            // cbFields
            // 
            this.cbFields.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbFields.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbFields.DropDownWidth = 121;
            this.cbFields.Location = new System.Drawing.Point(130, 38);
            this.cbFields.Name = "cbFields";
            this.cbFields.Size = new System.Drawing.Size(121, 21);
            this.cbFields.TabIndex = 2;
            // 
            // cbClausula
            // 
            this.cbClausula.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbClausula.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbClausula.DropDownWidth = 121;
            this.cbClausula.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">=",
            "!=",
            "In",
            "Not In"});
            this.cbClausula.Location = new System.Drawing.Point(257, 38);
            this.cbClausula.Name = "cbClausula";
            this.cbClausula.Size = new System.Drawing.Size(60, 21);
            this.cbClausula.TabIndex = 3;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(337, 39);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 20);
            this.txtFilter.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tabela:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(130, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Campo:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(257, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo Filtro:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(337, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Filtro:";
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(443, 36);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(35, 23);
            this.BtnOk.TabIndex = 9;
            this.BtnOk.Text = "Ok";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Filtros:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbTables);
            this.panel1.Controls.Add(this.BtnOk);
            this.panel1.Controls.Add(this.cbFields);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbClausula);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 83);
            this.panel1.TabIndex = 12;
            // 
            // Filters
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DGFilters);
            this.Size = new System.Drawing.Size(498, 335);
            this.Text = "Filters";
            ((System.ComponentModel.ISupportInitialize)(this.DGFilters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView DGFilters;
        private Gizmox.WebGUI.Forms.ComboBox cbTables;
        private Gizmox.WebGUI.Forms.ComboBox cbFields;
        private Gizmox.WebGUI.Forms.ComboBox cbClausula;
        private Gizmox.WebGUI.Forms.TextBox txtFilter;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Button BtnOk;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Panel panel1;


    }
}