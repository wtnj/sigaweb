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
    public partial class sxManager : UserControl
    {
        public sxManager()
        {
            InitializeComponent();
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                SigaObjects.SXManager sxm = new SigaObjects.SXManager(sigaSession.EMPRESAS[0].CODIGO);

                sxm.ToDatabase = txtToDatabase.Text.Trim();
                sxm.ToFields = txtToFields.Text.Trim();
                sxm.ToTable = txtToTable.Text.Trim();
                sxm.UseProvider = txtProvider.Text.Trim();
                sxm.UseDriver = txtDriver.Text.Trim();
                sxm.InDirectory = txtDirectory.Text.Trim();
                sxm.SourceType = txtSourceType.Text.Trim();
                sxm.FromFields = txtFromFields.Text.Trim();
                sxm.FromFile = txtFromFile.Text.Trim();

                DataTable dtSxm = (DataTable)sxm.Import();
                string strError = "";

                for (int i = 0; i < dtSxm.GetErrors().Length; i++)
                    strError += dtSxm.GetErrors().GetValue(i).ToString();

                if (strError.Length > 0)
                    MessageBox.Show(strError);
                else
                    MessageBox.Show(sxm.ToTable + " add com sucesso!");
            }
            catch (Exception err)
            {
                StringBuilder sError = new StringBuilder();
                sError.AppendLine("< ERRO >");
                sError.AppendLine("Message: " + err.Message);
                sError.AppendLine("Source : " + err.Source);
                sError.AppendLine("Target : " + err.TargetSite);
                sError.AppendLine("StackTrace:\n" + err.StackTrace);
                
                //MessageBox.Show(sError.ToString(), "ERRO");
                MessageBox.Show(Carralero.ExceptionControler.getStrException(err), "ERROR");
            }
        }
    }
}