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

        private object    columnReturn = null;
        private DataTable table;

        private string    root         = "C:\\SigaWeb\\";
        private string    caminho;

        private List<object> tRow = new List<object>();

        #region CONSTRUTOR
        private void initialize(string sQuery  )
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
        private void initialize(DataTable dados)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            dataGridView1.DataSource = dados.DefaultView;
            dataGridView1.UseInternalPaging=false;

            barra.Text = string.Format(">> {0} Registros", dados.DefaultView.Count);
            
            table = dados;
            this.calcTotalRow();

            if (this.toControl != null && this.oColRet != null)
            {
                btnSelecionar.Visible = true;
            }
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
        public gridWindow(DataTable dados , Control caller, int idxCollumnReturn)
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
        { showWindow(modal, paging, 20); }
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

            cbCampos.Items.Add(e.Column.Name);
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
            foreach (string filtro in lbFiltros.Items)
            { sFiltro.AppendLine((isFirst ? "" : " AND ") + filtro); isFirst = false; }

            (dataGridView1.DataSource as DataView).RowFilter = sFiltro.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbCampos.SelectedIndex >= 0 && cbTipo.SelectedIndex >= 0)
            {
                string campo = cbCampos.Items[cbCampos.SelectedIndex].ToString();
                string tipo  = cbTipo.Items[cbTipo.SelectedIndex].ToString();
                string like = tipo == "LIKE" ? "%" : "";

                string filtro = "";
                filtro += campo + " ";
                filtro += tipo  + " ";
                filtro += "('" +like+ txtFiltro.Text +like+ "')";

                lbFiltros.Items.Add(filtro);
            }
        }

        private void lbFiltros_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            if(lbFiltros.SelectedIndex>=0)
                lbFiltros.Items.RemoveAt(lbFiltros.SelectedIndex);
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
            object valueCell = new object();

            if (columnReturn.GetType() == typeof(string))
                valueCell = dataGridView1.SelectedRows[0].Cells[columnReturn.ToString()].Value;
            if (columnReturn.GetType() == typeof(int))
                valueCell = dataGridView1.SelectedRows[0].Cells[int.Parse(columnReturn.ToString())].Value;

            oCaller.Text = valueCell.ToString();
            this.Form.Close();
        }
    }
}