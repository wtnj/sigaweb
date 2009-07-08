namespace SigaControls.Report
{
    partial class ViewReport
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
            this.panelParams = new Gizmox.WebGUI.Forms.Panel();
            this.btnExec = new Gizmox.WebGUI.Forms.Button();
            this.lblREPORT = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // panelParams
            // 
            this.panelParams.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.panelParams.AutoScroll = true;
            this.panelParams.Location = new System.Drawing.Point(3, 32);
            this.panelParams.Name = "panelParams";
            this.panelParams.Size = new System.Drawing.Size(309, 349);
            this.panelParams.TabIndex = 0;
            // 
            // btnExec
            // 
            this.btnExec.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnExec.Location = new System.Drawing.Point(237, 3);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 1;
            this.btnExec.Text = "Executar";
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // lblREPORT
            // 
            this.lblREPORT.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lblREPORT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblREPORT.Location = new System.Drawing.Point(16, 3);
            this.lblREPORT.Name = "lblREPORT";
            this.lblREPORT.Size = new System.Drawing.Size(215, 23);
            this.lblREPORT.TabIndex = 2;
            this.lblREPORT.Text = "Parametros do Relatório {0}";
            this.lblREPORT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewReport
            // 
            this.Controls.Add(this.lblREPORT);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.panelParams);
            this.Size = new System.Drawing.Size(315, 384);
            this.Text = "ViewReport";
            this.VisibleChanged += new System.EventHandler(this.ViewReport_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel panelParams;
        private Gizmox.WebGUI.Forms.Button btnExec;
        private Gizmox.WebGUI.Forms.Label lblREPORT;


    }
}