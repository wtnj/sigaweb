namespace SigaControls
{
    partial class ERROR
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
            this.lblSource = new Gizmox.WebGUI.Forms.Label();
            this.txtError = new Gizmox.WebGUI.Forms.TextBox();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lblSource.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblSource.Location = new System.Drawing.Point(3, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(385, 23);
            this.lblSource.TabIndex = 0;
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtError
            // 
            this.txtError.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.txtError.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtError.Location = new System.Drawing.Point(3, 26);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(385, 248);
            this.txtError.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(313, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ERROR
            // 
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.lblSource);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ERROR";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblSource;
        private Gizmox.WebGUI.Forms.TextBox txtError;
        private Gizmox.WebGUI.Forms.Button btnOk;


    }
}