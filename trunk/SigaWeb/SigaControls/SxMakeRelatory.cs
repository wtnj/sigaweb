#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections;

using Carralero;
using SigaObjects;
#endregion

namespace SigaControls
{
    public partial class SxMakeRelatory : MainWindow
    {
        private DataTable allTables = new SigaObjects.SXManager(sigaSession.EMPRESAS[0].CODIGO).getTables();

        public SxMakeRelatory()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            //this.Text = string.Format("SIGA REPORTS - EMPRESA [ {0} / {1} ]", Empresa.NOME, Empresa.FILIAL);
        }

        #region ABRINDO RELATORIO
        public void btnAbrir_Click(   object sender, EventArgs e)
        {
            Label label = new Label();
            label.TextChanged += new EventHandler(label_TextChanged);
            
            if (sender.GetType() == typeof(Label))
            {
                label.Text = (sender as Label).Text;
            }
            else
            {
                new gridWindow(new SigaObjects.Reports.Report.ReportDao().select(0), label, "nome").showWindow();
            }
        }
        private void label_TextChanged(object sender, EventArgs e)
        {
            string relatorio = (sender as Control).Text;
            Report.Report report = new SigaControls.Report.Report(relatorio);
            FormatScreen.AddTab(ABAS, relatorio, report);
            report.LOAD(relatorio, false);
        }
        #endregion

        public void btnAddNew_Click(object sender, EventArgs e)
        {
            string novo  = "novo relatorio";
            int    count = 1;
            for (int i = 0; i < ABAS.TabPages.Count; i++)
                if (ABAS.TabPages[i].Text.StartsWith(novo))
                    count++;
            
            novo = novo + count.ToString();

            Report.Report report = new Report.Report();
            
            FormatScreen.AddTab(ABAS, novo, report);

            report.LOAD(novo, true);
        }
    }
}