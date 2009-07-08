#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

using REPORT = SigaObjects.Reports.Report;
#endregion

namespace SigaControls.Report
{
    public partial class ReportList : UserControl
    {
        private DataTable dados = new DataTable();

        public  ReportList()            
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            initializeToolBar();
            initializeData();
        }
        private void initializeToolBar()
        {
            this.tbbAdd.Image   = (ResourceHandle)Resources.Icons.basic.PageAdd[   0];
            this.tbbVer.Image   = (ResourceHandle)Resources.Icons.basic.PageView[  0];
            this.tbbEdit.Image  = (ResourceHandle)Resources.Icons.basic.PageEdit[  0];
            this.tbbDel.Image   = (ResourceHandle)Resources.Icons.basic.PageDelete[0];
            this.tbbExcel.Image = (ResourceHandle)Resources.Icons.basic.PageExcel[ 0];
            this.tbbPDF.Image   = (ResourceHandle)Resources.Icons.basic.PagePDF[   0];
        }
        private void initializeData()             
        {
            this.initializeData(null);
        }
        private void initializeData(string filtro)
        {
            dados.Columns.Add("idReportGroup");
            dados.Columns.Add("descricao"    );
            dados.Columns.Add("id"           );
            dados.Columns.Add("nome"         );

            dgvReports.DataSource = dados.DefaultView;
            
            dgvReports.Columns["idReportGroup"].HeaderText = "id Grupo";
            dgvReports.Columns["descricao"    ].HeaderText = "Grupo";
            dgvReports.Columns["id"           ].HeaderText = "id Relatório";
            dgvReports.Columns["nome"         ].HeaderText = "Nome do Relatório";

            DataTable _dados = new REPORT.ReportDao().SelectForDisplay(filtro, false);
            //TODO CONCERTAR ISSO >>
            foreach(DataRow row in _dados.Rows)
                dados.Rows.Add(row.ItemArray);
        }

        private void menu_Click(object objSource, ToolBarItemEventArgs objArgs)
        {
            Control inControl = this.Parent;
            SxMakeRelatory  rel;
            REPORT.ReportVo report;
            string relname  = "";

            switch (objArgs.ToolBarButton.Name.ToLower())
            {
                case "tbbadd":
                    #region ADD
                    this.Parent.Controls.Clear();
                    rel = new SxMakeRelatory();
                    rel.Dock = DockStyle.Fill;
                    FormatScreen.AddControl(inControl, rel, true, 1, true, false);
                    rel.btnAddNew_Click(null, null);
                    #endregion

                    break;
                case "tbbver":
                    #region VER
                    if (dgvReports.SelectedRows.Count > 0)
                    {
                        DataRow row = (DataRow)(dgvReports.DataSource as DataView).Table.Rows[dgvReports.SelectedRows[0].Index];
                        
                        /*
                        Report cReport = new Report();
                        cReport.LOAD((string)row["nome"], false);

                        gridWindow grid = new gridWindow(cReport.TABLE.QUERY.ToString(), null);
                        grid.SetGridHeader(cReport.TABLE.FIELDS.TOGRID);
                        grid.showWindow();
                        //*/

                        ControlsConfig.formShow(new ViewReport(int.Parse(row["id"].ToString())), this.Form, ControlsConfig.showType.Dialog, null, true);
                    }
                    #endregion

                    break;
                case "tbbedit":
                    #region EDIT
                    if (dgvReports.SelectedRows.Count > 0)
                    {
                        this.Parent.Controls.Clear();
                        
                        DataRow row = (DataRow)(dgvReports.DataSource as DataView).Table.Rows[dgvReports.SelectedRows[0].Index];
                        
                        rel = new SxMakeRelatory();
                        rel.Dock = DockStyle.Fill;
                        FormatScreen.AddControl(inControl, rel, true, 1, true, false);
                        relname = (string)row["nome"];
                        rel.btnAbrir_Click(new Label(relname), null);
                    }
                    #endregion

                    break;
                case "tbbdel":
                    #region DEL
                    if (dgvReports.SelectedRows.Count > 0)
                    {
                        DataRow row = (DataRow)(dgvReports.DataSource as DataView).Table.Rows[dgvReports.SelectedRows[0].Index];
                        
                        report = new REPORT.ReportVo();

                        report.ID            = int.Parse(row["id"           ].ToString());
                        report.IDREPORTGROUP = int.Parse(row["idreportgroup"].ToString());

                        SigaObjects.Reports.Table.TableVo maintable = new SigaObjects.Reports.Table.TableVo();
                        new SigaObjects.Reports.Table.TableDao().load(maintable, report.ID, 0);

                        new SigaObjects.Reports.Report.ReportDao().DeleteRecursiveTables(maintable.ID);
                        new SigaObjects.Reports.Report.ReportDao().delete(report);
                    }
                    #endregion

                    break;
                case "tbbexcel":
                    #region EXCEL
                    FormatScreen.showNotImplemented();
                    #endregion

                    break;
                case "tbbpdf":
                    #region PDF
                    FormatScreen.showNotImplemented();
                    #endregion
                    
                    break;
                default:
                    break;
            }
        }
    }
}