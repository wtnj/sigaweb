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
        public  REPORT.Report.ReportVo RELATORIO
        {
            get { return _report;  }
            set { _report = value; }
        }

        private void initializer()
        {
            InitializeComponent();
            
            this.Dock = DockStyle.Fill;
            this.popScreenFromRecursiveTables();
        }
        private void popScreenFromRecursiveTables()
        {
            panelParams.Controls.Clear();

            REPORT.Table.TableVo tabela = new REPORT.Table.TableVo();
            new REPORT.Table.TableDao().load(tabela, this.RELATORIO.ID, 0);

            DataTable tabelas = new REPORT.Params.ParamsDao().getRecursiveTables(tabela);
            
            foreach (DataRow row in tabelas.Rows)
            {
                string tagFormat = "@$TAB$@.$CAMPO$ ?? '@?@'";
                string  controle = (string)row["formato"];
                
                //
                // CONTROLE DE
                Control cDE      = FormatScreen.getObjectFromSigaType(controle);
                string lblDE     = (string)row["campo"] + " de  : ";
                cDE.Tag = tagFormat
                          .Replace("$TAB$"  ,(string)row["tabela"])
                          .Replace("$CAMPO$",(string)row["campo" ])
                          .Replace("??"     , ">="                );

                FormatScreen.AddControl(panelParams, new Label(lblDE) ,true, 4, false, false);
                FormatScreen.AddControl(panelParams, cDE              ,true, 4, false, false);
                
                //
                // CONTROLE ATE
                Control cATE     = FormatScreen.getObjectFromSigaType(controle);
                string lblATE    = (string)row["campo"] + " ate : ";
                cATE.Tag = tagFormat
                          .Replace("$TAB$"  ,(string)row["tabela"])
                          .Replace("$CAMPO$",(string)row["campo" ])
                          .Replace("??"     , "<="                );

                FormatScreen.AddControl(panelParams, new Label(lblATE),true, 4, false, false);
                FormatScreen.AddControl(panelParams, cATE             ,true, 4, false, false);
            }
        }

        public ViewReport()
        {
            initializer();
        }
        public ViewReport(int reportId)
        {
            new REPORT.Report.ReportDao().load(this.RELATORIO, 0, "id = "+reportId);
            initializer();
            
        }
        public ViewReport(string reportname)
        {
            new REPORT.Report.ReportDao().load(this.RELATORIO, 0, "nome = '"+reportname+"'");
            initializer();
            
        }
        public ViewReport(REPORT.Report.ReportVo report)
        {
            this.RELATORIO = report;
            initializer();
        }

        private void generateContols()
        {
            // TODO varrer lista de parametros, instanciar controles respectivos usando as tags pra criar o filtro.
            // Ex.: TABLE[@EMPRESA@]0.FIELD <= (ou >= ou ...) '@?@' -- ESTE @?@ é a chave pra substituição na hora de varrer os controles e gerar o filtro.
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            // TODO varrer lista de controles, usar as TAGs pra fazer os filtros.
            StringBuilder filtro = new StringBuilder();
            foreach (Control c in panelParams.Controls)
            {
                string _and = string.IsNullOrEmpty(filtro.ToString()) ? "" : "   AND ";

                if (c.GetType() == typeof(TextBox))
                {
                    TextBox texto = c as TextBox;
                    filtro.AppendLine(_and + texto.Tag.ToString().Replace("@?@", texto.Text));
                }
                if (c.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker data = c as DateTimePicker;
                    filtro.AppendLine(_and + data.Tag.ToString().Replace("@?@", data.Value.ToString("yyyyMMdd")));
                }
            }

            Report cReport = new Report();
            cReport.LOAD(this.RELATORIO.NOME, false);
            cReport.TABLE.FILTROPARAMETRO = filtro.ToString();

            new gridWindow(cReport.TABLE.QUERY.ToString(), null).showWindow();
        }
    }
}