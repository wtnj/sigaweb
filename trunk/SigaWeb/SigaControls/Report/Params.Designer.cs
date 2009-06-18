namespace SigaControls.Report
{
    partial class Params
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
            this.cmbCampos = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbTabela = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lbCampos = new Gizmox.WebGUI.Forms.ListBox();
            this.btnAdd = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCampos
            // 
            this.cmbCampos.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbCampos.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbCampos.DropDownWidth = 228;
            this.cmbCampos.Location = new System.Drawing.Point(116, 44);
            this.cmbCampos.Name = "cmbCampos";
            this.cmbCampos.Size = new System.Drawing.Size(100, 21);
            this.cmbCampos.TabIndex = 1;
            // 
            // cmbTabela
            // 
            this.cmbTabela.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbTabela.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabela.DropDownWidth = 121;
            this.cmbTabela.Location = new System.Drawing.Point(10, 44);
            this.cmbTabela.Name = "cmbTabela";
            this.cmbTabela.Size = new System.Drawing.Size(100, 21);
            this.cmbTabela.TabIndex = 0;
            this.cmbTabela.Text = "-- selecione --";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(113, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Campos :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tabela :";
            // 
            // lbCampos
            // 
            this.lbCampos.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lbCampos.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.lbCampos.Location = new System.Drawing.Point(10, 71);
            this.lbCampos.Name = "lbCampos";
            this.lbCampos.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.lbCampos.Size = new System.Drawing.Size(286, 342);
            this.lbCampos.TabIndex = 4;
            this.lbCampos.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.lbCampos_KeyUp);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(223, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Params
            // 
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbCampos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTabela);
            this.Controls.Add(this.cmbCampos);
            this.Size = new System.Drawing.Size(310, 425);
            this.Text = "Params";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox cmbCampos;
        private Gizmox.WebGUI.Forms.ComboBox cmbTabela;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.ListBox lbCampos;
        private Gizmox.WebGUI.Forms.Button btnAdd;




    }
}