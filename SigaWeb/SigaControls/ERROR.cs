#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SigaControls
{
    public partial class ERROR : UserControl
    {
        private void initializer(Exception error, string HEADER)
        {
            InitializeComponent();
            this.Text = HEADER;
            Carralero.ExceptionControler.getFullException(error);

            lblSource.Text = error.Source;
            txtError.Text  = error.Message;

            this.Dock = DockStyle.Fill;
            //this.Form.StartPosition = FormStartPosition.CenterScreen;
        }
        public ERROR(Exception error)
        {
            this.initializer(error, "ERRO");
        }
        public ERROR(Exception error, string HEADER)
        {
            this.initializer(error, HEADER);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Form.Close();
        }

        public void SHOW()
        {
            Form frm = new Form();
            frm.Controls.Add(this);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}