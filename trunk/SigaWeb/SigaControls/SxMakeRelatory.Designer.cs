namespace SigaControls
{
    partial class SxMakeRelatory
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
            this.btnAddNew = new Gizmox.WebGUI.Forms.Button();
            this.btnAbrir = new Gizmox.WebGUI.Forms.Button();
            this.ABAS = new Gizmox.WebGUI.Forms.TabControl();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(3, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(48, 23);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "Novo";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(57, 3);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(56, 23);
            this.btnAbrir.TabIndex = 5;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // ABAS
            // 
            this.ABAS.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.ABAS.Location = new System.Drawing.Point(3, 32);
            this.ABAS.Multiline = false;
            this.ABAS.Name = "ABAS";
            this.ABAS.Size = new System.Drawing.Size(552, 200);
            this.ABAS.TabIndex = 6;
            // 
            // SxMakeRelatory
            // 
            this.Controls.Add(this.ABAS);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnAddNew);
            this.Size = new System.Drawing.Size(558, 235);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnAddNew;
        private Gizmox.WebGUI.Forms.Button btnAbrir;
        private Gizmox.WebGUI.Forms.TabControl ABAS;


    }
}