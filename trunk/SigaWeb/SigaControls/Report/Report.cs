#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SigaObjects;
using REPORT = SigaObjects.Reports;
#endregion

namespace SigaControls.Report
{
    public partial class Report : UserControl
    {
        #region CONTROLS
        public  REPORT.Table.TableVo   FROMTABLE = new REPORT.Table.TableVo();
        private Table                  table;//     = new Table();
        #endregion

        #region ATRIBUTOS
        public  REPORT.ReportGroup.ReportGroupVo REPORTGROUP = new REPORT.ReportGroup.ReportGroupVo();
        public  REPORT.Report.ReportVo           THISREPORT  = new REPORT.Report.ReportVo();
        //private REPORT.Table.TableVo            tablevo     = new REPORT.Table.TableVo();
        #endregion

        #region PROPRIEDADES
        public string REPORTNAME   
        {
            get { return this.THISREPORT.NOME; }
            set
            {
                if (value != null && this.Parent != null)
                {
                    this.THISREPORT.NOME = value;
                    this.Parent.Text     = value;
                }
            }
        }
        public int    ID           
        {
            get { return this.THISREPORT.ID; }
            set { this.THISREPORT.ID = value; }
        }
        public int    IDREPORTGROUP
        {
            get { return this.THISREPORT.IDREPORTGROUP; }
            set { this.THISREPORT.IDREPORTGROUP = value; }
        }
        public string EMPRESA      
        {
            get { return this.THISREPORT.EMPRESA; }
            set
            {
                if (value != null)
                    this.THISREPORT.EMPRESA = value;
            }
        }
        public string FILIAL       
        {
            get { return this.THISREPORT.FILIAL; }
            set
            {
                if (value != null)
                    this.THISREPORT.FILIAL = value;
            }
        }
        public string USERNAME     
        {
            get { return this.THISREPORT.USERNAME; }
            set
            {
                if (value != null)
                    this.THISREPORT.USERNAME = value;
            }
        }
        public Table  TABLE        
        {
            get { return this.table; }
            private set { table = value; }
        }
        public REPORT.Table.TableVo TABLEVO
        {
            get { return this.THISREPORT.TABLE;  }
            set { this.THISREPORT.TABLE = value; }
        }
        #endregion

        #region CONSTRUTOR
        private void initializer(string reportName)
        {
            InitializeComponent();
            this.REPORTNAME = reportName;
            this.TABLE = new Table(this.THISREPORT);
            this.Dock = DockStyle.Fill;
        }
        public Report()
        { initializer(null); }
        public Report(string reportName)
        { initializer(reportName); }
        #endregion

        #region SAVE E LOAD
        public void SAVE()
        {
            try
            {
                if (txtReportName.Text.Trim().Length == 0)
                    throw new Exception("Insira um nome no relatório, não é possivel gravar um relatório sem nome.");
                
                REPORT.ReportGroup.ReportGroupDao rgDAO = new REPORT.ReportGroup.ReportGroupDao();
                rgDAO.load(this.REPORTGROUP);
                if (this.REPORTGROUP.ID == 0)
                    rgDAO.save(this.REPORTGROUP);
                
                this.THISREPORT.IDREPORTGROUP = this.REPORTGROUP.ID;
                this.THISREPORT.NOME          = txtReportName.Text.Trim();
                this.THISREPORT.USERNAME      = ""; //sigaSession.LoggedUser.USERNAME;
                this.THISREPORT.EMPRESA       = ""; //Empresa.CODIGO;
                this.THISREPORT.FILIAL        = ""; //Empresa.CODIGO_FILIAL;
                
                new REPORT.Report.ReportDao().save(this.THISREPORT);

                //if (this.TABLE != null)
                //    foreach(Table table in this.TABLE.RECURSIVETABLES)
                //        table.REPORTID = this.ID;

                //this.TABLE.SAVE();
                //this.TABLE.RECURSIVETABLES;
                new REPORT.Table.TableDao().delete(this.ID, 0);

                #region RESET IDs
                foreach (Table _table in this.TABLE.RECURSIVETABLES)
                {
                    _table.THISTABLE.ID = 0; // ZERANDO TABELAS FILHO (recursivamente)

                    foreach (REPORT.Fields.FieldsVo _field in _table.THISTABLE.FIELDS)
                        _field.ID = 0;  // ZERANDO SEUS CAMPOS
                    
                    foreach (REPORT.Filters.FiltersVo _filter in _table.THISTABLE.FILTERS)
                        _filter.ID = 0; // ZERANDO SEUS FILTROS
                    
                    foreach (REPORT.OrderBy.OrderByVo _order in _table.THISTABLE.ORDERBY)
                        _order.ID = 0;  // ZERANDO SUAS ORDENS
                    
                    foreach (REPORT.Params.ParamsVo _parm in _table.THISTABLE.PARAMS)
                        _parm.ID = 0;   // ZERANDO SEUS PARAMETROS
                }
                #endregion

                this.TABLE.THISTABLE.ID       = 0;
                this.TABLE.THISTABLE.IDREPORT = this.ID;
                new REPORT.Table.TableDao().save(this.TABLE.THISTABLE);

                MessageBox.Show("Relatorio Salvo com sucesso!", "SALVANDO...");
            }
            catch (Exception e)
            {
                new ERROR(Carralero.ExceptionControler.getFullException(e)).SHOW();
                //MessageBox.Show(Carralero.ExceptionControler.getFullException(e).Message);
            }
        }
        public void LOAD(string reportName, bool isFirst)
        {
            try
            {
                this.cbReportGroup.DisplayMember = "descricao";
                this.cbReportGroup.ValueMember   = "id";
                this.cbReportGroup.DataSource    = new REPORT.ReportGroup.ReportGroupDao().select();
                this.cbReportGroup.SelectedIndex = -1;

                if (reportName != null && !isFirst)
                {
                    this.txtReportName.Text = reportName;

                    //SigaObjects.Reports.Report.ReportVo report = new SigaObjects.Reports.Report.ReportVo();
                    //report.NOME = this.REPORTNAME;
                    new SigaObjects.Reports.Report.ReportDao().load(this.THISREPORT, reportName, null);
                    //this.ID     = report.ID;
                    this.cbReportGroup.SelectedValue = this.THISREPORT.IDREPORTGROUP;

                    if (this.TABLEVO != null)
                        this.TABLEVO.INDEX = 0;

                    if (this.ID > 0)
                    {
                        this.cbReportGroup.SelectedValue = this.REPORTGROUP.ID;

                        //List<REPORT.Table.TableVo> tabelas = new List<REPORT.Table.TableVo>();
                        new SigaObjects.Reports.Table.TableDao().load(this.TABLEVO, this.ID, 0);
                        //if (tabelas.Count > 0)
                        if (this.TABLEVO.ID != 0)
                        {
                            Table mainTable = new Table(this.THISREPORT, this.TABLEVO);
                            mainTable.LOAD(TABLEVO);
                            if (mainTable.ID > 0)
                                this.AddTable(mainTable);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                new ERROR(Carralero.ExceptionControler.getFullException(e)).SHOW();
                //MessageBox.Show(Carralero.ExceptionControler.getFullException(e).Message);
            }
        }
        public void DELETE()
        {
            this.TABLE.DELETE();            
        }
        #endregion

        #region EVENTOS
        private void btnRemove_Click(object sender, EventArgs e)
        {
            TabControl tc     = (this.Parent.Parent as TabControl);
            TabPage    tp     = (this.Parent as TabPage);
            int        indice = tc.SelectedIndex;
            tc.TabPages.Remove(tp);
            tc.SelectedIndex  = indice - 1;
        }
        
        private void txtReportName_TextChanged(object sender, EventArgs e)
        {
            string texto = txtReportName.Text.ToString();
            if (texto.Length > 0)
                this.REPORTNAME = texto;
        }
        #endregion

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            Label strTable = new Label();
            
            DataTable dados = new DataTable();
            string filtro = txtFiltro.Text.Trim();

            filtro = (filtro == "filtro") ? "" : filtro;

            dados  = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTables("X2_NOME LIKE '%" + filtro + "%'");

            Form frm = new Form();
            frm.Text = "TODAS AS TABELAS";
            frm.Controls.Add(new gridWindow(dados, strTable, "X2_CHAVE"));
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            strTable.TextChanged += new EventHandler(strTable_TextChanged);
        }

        void strTable_TextChanged(object sender, EventArgs e)
        {
            this.TABLEVO = new REPORT.Table.TableVo((sender as Control).Text,"","","");
            Table child  = new Table(this.THISREPORT);
            child.LOAD(this.TABLEVO);

            this.AddTable(child);
        }
        private void AddTable(Table table)
        {
            this.TABLE             = table;

            reportPanel.Controls.Clear();
            reportPanel.Controls.Add(this.TABLE);
        }

        private void cbReportGroup_TextChanged(object sender, EventArgs e)
        {
            this.REPORTGROUP.DESCRICAO = (sender as ComboBox).Text.Trim();
            new REPORT.ReportGroup.ReportGroupDao().load(this.REPORTGROUP);
        }

        private void txtSalvar_Click(object sender, EventArgs e)
        {
            // LIMPANDO TABELAS E DADOS RELACIONADOS
            new REPORT.Report.ReportDao().DeleteRecursiveTables(this.TABLE.ID);

            this.SAVE();
        }

        private void btnShowQuery_Click(object sender, EventArgs e)
        {
            try
            {
                new ERROR(new Exception(this.TABLE.QUERY.ToString()), "CONSULTA SQL").SHOW();
            }
            catch (Exception EX)
            {
                new ERROR(Carralero.ExceptionControler.getFullException(EX)).SHOW();
            }
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            try
            {
                gridWindow grid = new gridWindow(this.TABLE.QUERY.ToString(), null);
                grid.SetGridHeader(this.TABLE.FIELDS.TOGRID);
                grid.showWindow(this.Form);
            }
            catch (Exception EX)
            {
                new ERROR(Carralero.ExceptionControler.getFullException(EX)).SHOW();
            }
        }

        private void reportPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            (e.Control as Table).ChangeRootTable(true);
            (e.Control as Table).THISTABLE.INDEX = 0;
        }
    }
}