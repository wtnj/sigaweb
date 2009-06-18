#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using REPORT = SigaObjects.Reports;
#endregion

namespace SigaControls.Report
{
    public partial class ViewReport : UserControl
    {
        private REPORT.Report.ReportVo _report = new REPORT.Report.ReportVo();
        public  REPORT.Report.ReportVo REPORT
        {
            get { return _report;  }
            set { _report = value; }
        }

        private void initializer(Type tipo)
        {
            InitializeComponent();

            switch (tipo.ToString())
            {
                case "System.string":
                    break;
                case "System.int":
                    break;
                case "SigaObjects.Reports.Report.ReportVo":
                    break;
                default:
                    break;
            }
        }

        public ViewReport()
        {
            initializer(null);
        }
        public ViewReport(int reportId)
        {
            initializer(reportId.GetType());
        }
        public ViewReport(string reportname)
        {
            initializer(reportname.GetType());
        }
        public ViewReport(REPORT.Report.ReportVo report)
        {
            initializer(report.GetType());
        }

        private void generateContols()
        {
            panelParams.Controls.Clear();
            // TODO varrer lista de parametros, instanciar controles respectivos usando as tags pra criar o filtro.
            // Ex.: TABLE[@EMPRESA@]0.FIELD <= (ou >= ou ...) '@?@' -- ESTE @?@ é a chave pra substituição na hora de varrer os controles e gerar o filtro.
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            // TODO varrer lista de controles, usar as TAGs pra fazer os filtros.
        }
    }
}