namespace SigaControls.Cadastros
{
    partial class PreCADASTRO
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
            this.cbEMPRESA = new Gizmox.WebGUI.Forms.ComboBox();
            this.cbFILIAL = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // cbEMPRESA
            // 
            this.cbEMPRESA.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbEMPRESA.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbEMPRESA.Location = new System.Drawing.Point(85, 15);
            this.cbEMPRESA.Name = "cbEMPRESA";
            this.cbEMPRESA.Size = new System.Drawing.Size(121, 21);
            this.cbEMPRESA.TabIndex = 0;
            this.cbEMPRESA.SelectedIndexChanged += new System.EventHandler(this.cbEMPRESA_SelectedIndexChanged);
            // 
            // cbFILIAL
            // 
            this.cbFILIAL.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cbFILIAL.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbFILIAL.Location = new System.Drawing.Point(85, 42);
            this.cbFILIAL.Name = "cbFILIAL";
            this.cbFILIAL.Size = new System.Drawing.Size(121, 21);
            this.cbFILIAL.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(85, 80);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "EMPRESA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "FILIAL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PreCADASTRO
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbFILIAL);
            this.Controls.Add(this.cbEMPRESA);
            this.Size = new System.Drawing.Size(247, 127);
            this.Text = "PreCADASTRO";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox cbEMPRESA;
        private Gizmox.WebGUI.Forms.ComboBox cbFILIAL;
        private Gizmox.WebGUI.Forms.Button btnOk;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;


    }
}