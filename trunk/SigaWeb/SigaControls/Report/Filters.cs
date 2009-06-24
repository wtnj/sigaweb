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
    public partial class Filters : UserControl
    {
        private Table     main;//  = new Table();
        private DataTable dados     = new DataTable();
        private Control   txtFilter = new TextBox();

        public Table MAIN    
        {
            get { return main; }
            set { this.main = value; }
        }
        public string FILTERS
        {
            get
            {
                StringBuilder strFilter = new StringBuilder();

                int i = 0;
                foreach (DataGridViewRow drw in DGFilters.Rows)
                {
                    strFilter.AppendLine( ((i++ == 0) ? "" : "\r\n   AND ")
                                        + "@"   + this.MAIN.TABLE + "@"
                                        + "."   + drw.Cells["codCampos" ].Value.ToString()
                                        + " "   + drw.Cells["tipoFiltro"].Value.ToString() + " "
                                        + " ('" + drw.Cells["Filtro"    ].Value.ToString() + "') ");
                }

                StringBuilder childFilter = new StringBuilder();
                foreach (Table child in this.MAIN.CHILDREN)
                {
                    if (child.FILTERS.FILTERS.Trim().Length > 0)
                        childFilter.AppendLine((childFilter.ToString().Trim().Length > 0)
                                          ? "   AND " + child.FILTERS.FILTERS
                                          : child.FILTERS.FILTERS);
                }
                if (childFilter.ToString().Trim().Length > 0)
                    strFilter.AppendLine((strFilter.ToString().Trim().Length > 0)
                                        ? "   AND " + childFilter.ToString()
                                        : childFilter.ToString());

                return strFilter.ToString();
            }
        }

        private void initialize(Table main)
        {
            InitializeComponent();
            
            txtFilter.Top  = 39 ;
            txtFilter.Left = 337;
            panel1.Controls.Add(txtFilter);

            cbTables.DisplayMember = SXManager.TableDisplayMember;
            cbTables.ValueMember   = SXManager.TableValueMember  ;
            cbFields.DisplayMember = SXManager.FieldDisplayMember;
            cbFields.ValueMember   = SXManager.FieldValueMember  ;

            dados.Columns.Add("mainId"    );
            dados.Columns.Add("Tabela"    );
            dados.Columns.Add("Campos"    );
            dados.Columns.Add("tipoFiltro");
            dados.Columns.Add("Filtro"    );
            dados.Columns.Add("codTabela" );
            dados.Columns.Add("codCampos" );

            this.MAIN = main;
            this.Dock = DockStyle.Fill;
        }
        public Filters()          
        {
            initialize(null);
        }
        public Filters(Table main)
        {
            initialize(main);
        }

        #region SAVE LOAD E DELETE
        public void LOAD()  
        {
            if (this.MAIN != null)
            {
                //cbTables.DataSource = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTables("X2_CHAVE IN (" + SXManager.getStringArr(this.MAIN.RELATEDTABLES) + ")").DefaultView;
                cbTables.DataSource = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTables("X2_CHAVE = '" + this.MAIN.TABLE + "'").DefaultView;

                REPORT.Filters.FiltersDao filters = new REPORT.Filters.FiltersDao();

                dados = filters.select(this.MAIN.ID);

                dados.Columns.Add("CodTabela");
                dados.Columns.Add("CodCampos");

                foreach (DataRow linha in dados.Rows)
                {
                    DataTable dt;
                    string    tabela = "";
                    dt = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTables("X2_CHAVE = '" + linha["Tabela"].ToString() + "'");
                    if (dt.DefaultView.Count > 0)
                    {
                        linha["Tabela"]     = dt.DefaultView[0][SXManager.TableDisplayMember];
                        linha["CodTabela"]  = dt.DefaultView[0][SXManager.TableValueMember];
                        tabela = dt.DefaultView[0][SXManager.TableValueMember].ToString();
                    }
                    if (tabela != "")
                    {
                        dt = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getFields(tabela, "X3_CAMPO = '" + linha["campo"] + "'", "X3_CAMPO");
                        if (dt.DefaultView.Count > 0)
                        {
                            linha["campo"]      = dt.DefaultView[0][SXManager.FieldDisplayMember];
                            linha["CodCampos"]  = dt.DefaultView[0][SXManager.FieldValueMember];
                        }

                    }
                }
                DGFilters.DataSource = dados.DefaultView;
                DGFilters.Columns["Id"].Visible        = false;
                DGFilters.Columns["mainId"].Visible    = false;
                DGFilters.Columns["CodTabela"].Visible = false;
                DGFilters.Columns["CodCampos"].Visible = false;
                DGFilters.AllowUserToDeleteRows        = true;
            }
        }
        public void SAVE()  
        {
            List<REPORT.Filters.FiltersVo> filters = new List<REPORT.Filters.FiltersVo>();

            //for (int i = 0; i < dados.Rows.Count; i++)
            for (int i = 0; i < DGFilters.Rows.Count; i++)
            {
                REPORT.Filters.FiltersVo filter = new REPORT.Filters.FiltersVo();
                filter.MAINID       = this.MAIN.ID;
                filter.TABELA       = DGFilters.Rows[i].Cells["codTabela"].Value.ToString();
                filter.CAMPO        = DGFilters.Rows[i].Cells["codCampos"].Value.ToString();
                filter.FILTRO       = DGFilters.Rows[i].Cells["Filtro"].Value.ToString();
                filter.TIPOFILTRO   = DGFilters.Rows[i].Cells["TipoFiltro"].Value.ToString();

                filters.Add(filter);
            }

            new REPORT.Filters.FiltersDao().save(filters);
        }
        public void DELETE()
        {
            new REPORT.Filters.FiltersDao().delete(this.MAIN.ID);
        }
        #endregion

        private void Filters_Load(object sender, EventArgs e)
        {
        }

        private void cbTables_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            cbFields.DataSource = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getFields(Convert.ToString(cbTables.SelectedValue)).DefaultView;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DataRowView table  = (cbTables.SelectedItem as DataRowView);
            DataRowView fields = (cbFields.SelectedItem as DataRowView);

            string dTable = (string)table[ SXManager.TableDisplayMember];
            string vTable = (string)table[ SXManager.TableValueMember  ];

            string dField = (string)fields[SXManager.FieldDisplayMember];
            string vField = (string)fields[SXManager.FieldValueMember  ];
            int    codMainId = this.MAIN.ID;

            string vTipoFiltro;
            string vFiltro = "";
            if (cbClausula.SelectedItem == null)
            {
                MessageBox.Show("Escolha o filtro.");
                return;
            }
            else
            {
                vTipoFiltro = cbClausula.SelectedItem.ToString();
            }

            vFiltro = (txtFilter.GetType()==typeof(DateTimePicker))?(txtFilter as DateTimePicker).Value.ToString("yyyyMMdd"): txtFilter.Text;
            dados.Rows.Add(0, codMainId, dTable, dField, vTipoFiltro, vFiltro, vTable, vField);

            DGFilters.DataSource = dados.DefaultView;
            DGFilters.Columns["mainId"   ].Visible = false;
            DGFilters.Columns["codTabela"].Visible = false;
            DGFilters.Columns["codCampos"].Visible = false;
        }

        private void cbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFields.SelectedIndex >= 0)
            {
                DataRow row = (cbFields.DataSource as DataView).Table.Rows[cbFields.SelectedIndex];
                int left = txtFilter.Left;
                int top  = txtFilter.Top;

                panel1.Controls.Remove(txtFilter);
                txtFilter = FormatScreen.getObjectFromSigaType((string)row["X3_TIPO"]);
                txtFilter.Update();
                txtFilter.Left = left;
                txtFilter.Top  = top;
                panel1.Controls.Add(txtFilter);
            }
        }
    }
}