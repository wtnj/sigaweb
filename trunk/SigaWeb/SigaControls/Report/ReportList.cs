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
            DataTable dados = new REPORT.ReportDao().select(0, filtro);
            //TODO CONCERTAR ISSO >> 
            //dgvReports.DataSource = dados.DefaultView;
        }

        private void menu_Click(object objSource, ToolBarItemEventArgs objArgs)
        {
            Control inControl = this.Parent;
            SxMakeRelatory  rel;
            REPORT.ReportVo report;
            string relname    = "";

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

                        Report cReport = new Report();
                        cReport.LOAD((string)row["nome"], false);

                        new gridWindow(cReport.TABLE.QUERY.ToString(), null).showWindow();
                        //ControlsConfig.formShow(new ViewReport((int)row["id"]), this.Form, ControlsConfig.showType.Dialog, null, true);
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

                        report.ID            = (int)row["id"];
                        report.IDREPORTGROUP = (int)row["idreportgroup"];

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