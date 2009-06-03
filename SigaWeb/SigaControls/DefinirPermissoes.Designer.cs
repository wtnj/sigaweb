namespace SigaControls
{
    partial class DefinirPermissoes
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
            this.lblDefinir = new Gizmox.WebGUI.Forms.Label();
            this.rdbNenhuma = new Gizmox.WebGUI.Forms.RadioButton();
            this.rdbEditar = new Gizmox.WebGUI.Forms.RadioButton();
            this.rdbVisualizar = new Gizmox.WebGUI.Forms.RadioButton();
            this.rdbAdicionar = new Gizmox.WebGUI.Forms.RadioButton();
            this.rdbDeletar = new Gizmox.WebGUI.Forms.RadioButton();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDefinir
            // 
            this.lblDefinir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefinir.Location = new System.Drawing.Point(31, 14);
            this.lblDefinir.Name = "lblDefinir";
            this.lblDefinir.Size = new System.Drawing.Size(164, 23);
            this.lblDefinir.TabIndex = 0;
            this.lblDefinir.Text = "Definindo Permissões ...";
            // 
            // rdbNenhuma
            // 
            this.rdbNenhuma.Location = new System.Drawing.Point(15, 59);
            this.rdbNenhuma.Name = "rdbNenhuma";
            this.rdbNenhuma.Size = new System.Drawing.Size(104, 24);
            this.rdbNenhuma.TabIndex = 1;
            this.rdbNenhuma.Text = "Nenhuma";
            // 
            // rdbEditar
            // 
            this.rdbEditar.Location = new System.Drawing.Point(15, 149);
            this.rdbEditar.Name = "rdbEditar";
            this.rdbEditar.Size = new System.Drawing.Size(104, 24);
            this.rdbEditar.TabIndex = 4;
            this.rdbEditar.Text = "Editar";
            // 
            // rdbVisualizar
            // 
            this.rdbVisualizar.Location = new System.Drawing.Point(15, 89);
            this.rdbVisualizar.Name = "rdbVisualizar";
            this.rdbVisualizar.Size = new System.Drawing.Size(104, 24);
            this.rdbVisualizar.TabIndex = 2;
            this.rdbVisualizar.Text = "Visualizar";
            // 
            // rdbAdicionar
            // 
            this.rdbAdicionar.Location = new System.Drawing.Point(15, 119);
            this.rdbAdicionar.Name = "rdbAdicionar";
            this.rdbAdicionar.Size = new System.Drawing.Size(104, 24);
            this.rdbAdicionar.TabIndex = 3;
            this.rdbAdicionar.Text = "Adicionar";
            // 
            // rdbDeletar
            // 
            this.rdbDeletar.Location = new System.Drawing.Point(15, 179);
            this.rdbDeletar.Name = "rdbDeletar";
            this.rdbDeletar.Size = new System.Drawing.Size(104, 24);
            this.rdbDeletar.TabIndex = 5;
            this.rdbDeletar.Text = "Deletar";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(39, 221);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(120, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // DefinirPermissoes
            // 
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rdbDeletar);
            this.Controls.Add(this.rdbAdicionar);
            this.Controls.Add(this.rdbVisualizar);
            this.Controls.Add(this.rdbEditar);
            this.Controls.Add(this.rdbNenhuma);
            this.Controls.Add(this.lblDefinir);
            this.Size = new System.Drawing.Size(229, 262);
            this.Text = "DefinirPermissoes";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblDefinir;
        private Gizmox.WebGUI.Forms.RadioButton rdbNenhuma;
        private Gizmox.WebGUI.Forms.RadioButton rdbEditar;
        private Gizmox.WebGUI.Forms.RadioButton rdbVisualizar;
        private Gizmox.WebGUI.Forms.RadioButton rdbAdicionar;
        private Gizmox.WebGUI.Forms.RadioButton rdbDeletar;
        private Gizmox.WebGUI.Forms.Button btnOk;
        private Gizmox.WebGUI.Forms.Button btnCancelar;


    }
}