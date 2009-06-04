namespace SigaWeb
{
    partial class mainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // mainForm
            // 
            this.FormStyle = Gizmox.WebGUI.Forms.FormStyle.Application;
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(808, 435);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARALERO Consultoria e Desenvolvimento LTDA";
            this.DragDrop += new Gizmox.WebGUI.Forms.DragEventHandler(this.mainForm_DragDrop);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ControlAdded += new Gizmox.WebGUI.Forms.ControlEventHandler(this.mainForm_ControlAdded);
            this.ResumeLayout(false);

        }

        #endregion











    }
}