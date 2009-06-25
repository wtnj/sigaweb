#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Globalization;

#endregion

namespace SigaControls
{
    public partial class gridWindow : MainWindow
    {
        // MUDANÇAS
        private List<Control> toControl    = null;
        private List<object>  oColRet      = null;

        // REFERENCIA DE COLUNAS
        private string displaymember = "display";
        private string valuemember   = "value";

        DataTable gridHeader = new DataTable();
        DataTable filterType = new DataTable();
        DataTable filter     = new DataTable();

        private object    columnReturn = null;
        private DataTable table;

        private string    root         = "C:\\SigaWeb\\";
        private string    caminho;

        private List<object> tRow = new List<object>();

        #region CONSTRUTOR
        private void initialize(string    sQuery)
        {
            //this.Dock = DockStyle.Fill;
            //InitializeComponent();
            DataTable dtGrid = new SigaObjects.DataMaster().SelectDataTable(sQuery);
            //dataGridView1.DataSource = dtGrid.DefaultView;

            //barra.Text = string.Format(">> {0} Registros", dtGrid.DefaultView.Count);

            //table = dtGrid;
            //this.calcTotalRow();
            initialize(dtGrid);
        }
        private void initialize(DataTable dados )
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            this.initializeDataTables();

            dataGridView1.DataSource = dados.DefaultView;
            //dataGridView1.UseInternalPaging=false;

            barra.Text = string.Format(">> {0} Registros", dados.DefaultView.Count);
            
            table = dados;
            this.calcTotalRow();

            if (this.toControl != null && this.oColRet != null)
            {
                btnSelecionar.Visible = true;
            }
        }
        private void initializeDataTables()
        {
            /// INICIANDO TABELAS
            gridHeader = new DataTable();
            filterType = new DataTable();
            filter     = new DataTable();

            /// INICIANDO headers
            gridHeader.Columns.Add(valuemember  );
            gridHeader.Columns.Add(displaymember);
            cbCampos.ValueMember   = valuemember;
            cbCampos.DisplayMember = displaymember;

            /// INICIANDO tipos de filtro
            filterType.Columns.Add(valuemember  );
            filterType.Columns.Add(displaymember);
            filterType.Rows.Add("  =     '?'"    ,"igual"         );
            filterType.Rows.Add(" <>     '?'"    ,"diferente"     );
            filterType.Rows.Add(" >      '?'"    ,"maior"         );
            filterType.Rows.Add(" >=     '?'"    ,"maior ou igual");
            filterType.Rows.Add(" <      '?'"    ,"menor"         );
            filterType.Rows.Add(" <=     '?'"    ,"menor ou igual");
            filterType.Rows.Add(" LIKE   ('%?%')","contém"        );
            filterType.Rows.Add(" IN     (?)"    ,"contido"       );
            filterType.Rows.Add(" NOT IN (?)"    ,"não contido"   );
            cbTipo.ValueMember   = valuemember;
            cbTipo.DisplayMember = displaymember;
            
            /// INICIANDO filtros
            filter.Columns.Add(valuemember  );
            filter.Columns.Add(displaymember);
            lbFiltros.ValueMember   = valuemember;
            lbFiltros.DisplayMember = displaymember;

            cbCampos.DataSource  = gridHeader.DefaultView;
            cbTipo.DataSource    = filterType.DefaultView;
            lbFiltros.DataSource = filter.DefaultView;
        }

        public gridWindow(DataTable dados , Control caller)
        {
            this.oCaller = caller;

            initialize(dados);
        }
        public gridWindow(DataTable dados , Control caller, string strCollumnReturn)
        {
            this.oCaller = caller;
            columnReturn = strCollumnReturn;
            this.initialize(dados);
        }
        public gridWindow(DataTable dados , Control caller, int    idxCollumnReturn)
        {
            this.oCaller = caller;
            columnReturn = idxCollumnReturn;
            initialize(dados);
        }

        public gridWindow(string    sQuery, Control caller)
        {
            this.oCaller = caller;
            
            initialize(sQuery);
        }
        public gridWindow(string    sQuery, Control caller, string strCollumnReturn)
        {
            this.oCaller = caller;
            columnReturn = strCollumnReturn;
            initialize(sQuery);
        }
        public gridWindow(string    sQuery, Control caller, int    idxCollumnReturn)
        {
            this.oCaller = caller;
            columnReturn = idxCollumnReturn;
            initialize(sQuery);
        }

        public gridWindow(DataTable dados , List<Control> setControls, List<object> oCollumnsReturn)
        {
            this.toControl = setControls;
            this.oColRet   = oCollumnsReturn;
            initialize(dados);
        }
        public gridWindow(string    sQuery, List<Control> setControls, List<object> oCollumnsReturn)
        {
            this.toControl = setControls;
            this.oColRet   = oCollumnsReturn;
            initialize(sQuery);
        }

        public void SetGridHeader(List<string[]> TOGRID)
        { this.SetGridHeader(TOGRID, false); }
        public void SetGridHeader(List<string[]> TOGRID, bool showError)
        {
            foreach (string[] header in TOGRID)
            {
                try
                {
                    string value   = header.GetValue(0).ToString();
                    string display = header.GetValue(1).ToString();
                    dataGridView1.Columns[value].HeaderText = display;
                    
                    for(int idx=0; idx<gridHeader.Rows.Count; idx++)
                        if( gridHeader.Rows[idx]["value"].ToString() == value)
                            gridHeader.Rows[idx]["display"] = display;
                }
                catch(Exception err)
                {
                    if(showError)
                        throw err;
                }
            }
        }
        #endregion

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (columnReturn != null)
            {
                object valueCell = new object();

                if (columnReturn.GetType() == typeof(string))
                    valueCell = dataGridView1.SelectedRows[0].Cells[columnReturn.ToString()].Value;
                if (columnReturn.GetType() == typeof(int))
                    valueCell = dataGridView1.SelectedRows[0].Cells[int.Parse(columnReturn.ToString())].Value;
             
                oCaller.Text = valueCell.ToString();
                this.Form.Close();
            }
        }
        private void dataGridView1_DoubleClick(     object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public void showWindow()
        { this.showWindow(null); }
        public void showWindow(Form modal)
        { showWindow(modal, true); }
        public void showWindow(Form modal, bool paging)
        { showWindow(modal, paging, 25); }
        public void showWindow(Form modal, bool paging, int pages)
        { showWindow(modal, paging, pages, 250, 500); }
        public void showWindow(Form modal, bool paging, int pages, int height, int width)
        {
            cbxPage.Checked  = paging;
            nudPaginas.Value = pages;

            dataGridView1.UseInternalPaging = paging;
            dataGridView1.ItemsPerPage      = pages;
            Form frm = new Form();
            frm.WindowState = FormWindowState.Maximized;
            frm.Height      = height;
            frm.Width       = width;
            frm.Controls.Add(this);
            if (modal != null)
                frm.ShowDialog(modal);
            else
                frm.ShowDialog();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e) 
        {
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            gridHeader.Rows.Add( e.Column.Name
                               , e.Column.Name );
            //cbCampos.Items.Add(e.Column.Name);
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //return;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(root) == false)
            {
                MessageBox.Show("Diretório " + root + " não existe no servidor.");
                return;
            }
            root = System.Web.HttpContext.Current.Server.MapPath("");
            int rootIdx = root.IndexOf("Route\\");
            root = root.Substring(0, rootIdx) + @"arquivos\";
            caminho = root + "Report_" + DateTime.Today.ToString("dd_MM_yyyy-hhmmss") + ".xls";
            Carralero.ExportExcel excel = new Carralero.ExportExcel(caminho);

            if (table.Rows.Count > 0)
            {
                try
                {
                    excel.setDataTable(1, 1, table, true);
                    excel.Close();
                    MessageBox.Show("Relatório Criado: " + caminho);

                    new FormatScreen().DownloadFile(root, caminho.Replace(root,""), FormatScreen.ContextType.Excel);
                }
                catch (Exception ERR) { MessageBox.Show(ERR.Message, "ERRO"); }
            }
            caminho = null;
        }
        private void BtnPdf_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(root) == false)
            {
                MessageBox.Show("Diretório " + root + " não existe no servidor.");
                return;
            }

            root = System.Web.HttpContext.Current.Server.MapPath("");
            int rootIdx = root.IndexOf("Route\\");
            root = root.Substring(0, rootIdx) + @"arquivos\";

            caminho = root + "Report_" + DateTime.Today.ToString("dd_MM_yyyy-hhmmss") + ".pdf";
            Carralero.ExportPdf pdf = new Carralero.ExportPdf(caminho);
            if (table.Rows.Count > 0)
            {
                pdf.setDataTable(table, true);
                MessageBox.Show("Relatório Criado: " + caminho);
                new FormatScreen().DownloadFile(root, caminho.Replace(root, ""), FormatScreen.ContextType.PDF);
            }
            caminho = null;
        }
        private void BtnTxt_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(root) == false)
            {
                MessageBox.Show("Diretório " + root + " não existe no servidor.");
                return;
            }

            root = System.Web.HttpContext.Current.Server.MapPath("");
            int rootIdx = root.IndexOf("Route\\");
            root = root.Substring(0, rootIdx) + @"arquivos\";

            caminho = root + "Report_" + DateTime.Today.ToString("dd_MM_yyyy-hhmmss")+ ".txt";
            Carralero.ExportTxt txt = new Carralero.ExportTxt(caminho);
            if (table.Rows.Count > 0)
            {
                txt.setDataTable(table, true);
                MessageBox.Show("Relatório Criado: " + caminho);
                new FormatScreen().DownloadFile(root, caminho.Replace(root,""), FormatScreen.ContextType.txt);
            }
            caminho = null;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            StringBuilder sFiltro = new StringBuilder();
            bool isFirst = true;
            foreach (DataRow filtro in filter.Rows)//lbFiltros.Items)
            {
                sFiltro.AppendLine((isFirst ? "" : " AND ") + filtro[valuemember].ToString());
                isFirst = false;
            }

            (dataGridView1.DataSource as DataView).RowFilter = sFiltro.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbCampos.SelectedIndex >= 0 && cbTipo.SelectedIndex >= 0)
            {
                /// VALUE DO FILTRO
                string vCampo  = gridHeader.Rows[cbCampos.SelectedIndex][valuemember].ToString();
                string vTipo   = filterType.Rows[cbTipo.SelectedIndex  ][valuemember].ToString();
                string vFiltro = "";
                vFiltro += vCampo;
                vFiltro += vTipo.Replace("?", txtFiltro.Text);

                /// DISPLAY DO FILTRO
                string dCampo  = gridHeader.Rows[cbCampos.SelectedIndex][displaymember].ToString();
                string dTipo   = filterType.Rows[cbTipo.SelectedIndex  ][displaymember].ToString();
                string dFiltro = "";
                dFiltro += dCampo;
                dFiltro += " "  +dTipo;
                dFiltro += " ( "+txtFiltro.Text+" )";

                filter.Rows.Add(vFiltro, dFiltro);
            }
        }
        private void lbFiltros_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            if ( lbFiltros.SelectedIndex >= 0
              && Keys.Delete == objArgs.KeyCode )
                filter.Rows.RemoveAt(lbFiltros.SelectedIndex);
        }

        private void cbxPage_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.UseInternalPaging = (sender as CheckBox).Checked;
        }

        private void nudPaginas_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ItemsPerPage = int.Parse((sender as NumericUpDown).Value.ToString());
        }

        private void calcTotalRow()
        {
            tRow = new List<object>();

            for (int idx = 0; idx < dataGridView1.Columns.Count; idx++)
                tRow.Add(0);

            foreach (DataGridViewRow row in dataGridView1.Rows)
                for (int idx = 0; idx < row.Cells.Count; idx++)
                    try
                    {
                        tRow[idx] = decimal.Parse(tRow[idx].ToString())
                                  + decimal.Parse(row.Cells[idx].Value.ToString());
                    }
                    catch
                    {
                        tRow[idx] = "TOTAL";
                    }
        }
        private void cbTotal_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                //for (int idx = 0; idx < dataGridView1.Columns.Count; idx++)
                    

                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //    for (int idx = 0; idx < row.Cells.Count; idx++)
                //        try
                //        {
                //            tRow[idx] = decimal.Parse(tRow[idx].ToString())
                //                      + decimal.Parse(row.Cells[idx].Value.ToString());
                //        }
                //        catch
                //        { }

                //DataRow dr = new DataTable().Rows.Add(tRow.ToArray());
                //table.PrimaryKey = table.Columns[0].ToString();

                table.Rows.Add(tRow.ToArray());
                //dataGridView1.Rows.Add(tRow.ToArray());
            }
            else
            {
                //dataGridView1.DataSource = table.DefaultView;
                table.Rows.RemoveAt(table.Rows.Count - 1);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //this.calcTotalRow();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            for (int idx = 0; idx < toControl.Count && idx < oColRet.Count; idx++)
            {
                object valueCell = new object();
                object oCol      = oColRet[idx];

                if (oCol.GetType() == typeof(string))
                    valueCell = dataGridView1.SelectedRows[0].Cells[oCol.ToString()].Value;
                if (oCol.GetType() == typeof(int)   )
                    valueCell = dataGridView1.SelectedRows[0].Cells[int.Parse(oCol.ToString())].Value;

                toControl[idx].Text = valueCell.ToString();
            }
            this.Form.Close();
        }
    }
}