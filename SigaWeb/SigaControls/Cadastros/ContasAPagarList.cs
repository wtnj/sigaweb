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

using SigaObjects.Session.Empresa;
using SigaObjects.Cadastros.ContasAPagar;
#endregion

namespace SigaControls.Cadastros
{
    public partial class ContasAPagarList : UserControl
    {
        private Random rnd  = new Random();
        
        public ContasAPagarList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            initializeGrid();
            initializeToolBar();

            DataTable dados =
                    new SigaObjects
                       .Cadastros
                       .ContasAPagar
                       .ContasAPagarDAO()
                       .select( sigaSession.LoggedUser.ID);

            dgvDados.DataSource = dados;
            
            this.setGridToView(this.dgvDados);
        }

        private void initializeGrid()
        {
            dgvDados.AutoGenerateColumns = false;

            /// STATUS
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn(true);
            imgCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            imgCol.Name         = "_aprv";
            imgCol.HeaderText   = "Aprovação";
            imgCol.SortMode     = DataGridViewColumnSortMode.Automatic;

            DataGridViewAutoSizeColumnMode defAutoCol = DataGridViewAutoSizeColumnMode.AllCells;

            /// EMPRESA (descrição) > pegar dados a partir da coluna EMPRESA do datasource
            DataGridViewTextBoxColumn colEmpresa = new DataGridViewTextBoxColumn();
            colEmpresa.AutoSizeMode = defAutoCol;
            colEmpresa.Name         = "_empresa";
            colEmpresa.HeaderText   = "Empresa";

            /// FILIAL  (descrição) > pegar dados a partir da coluna FILIAL do datasource
            DataGridViewTextBoxColumn colFilial = new DataGridViewTextBoxColumn();
            colFilial.AutoSizeMode = defAutoCol;
            colFilial.Name         = "_filial";
            colFilial.HeaderText   = "Filial";

            /// PREFIXO
            DataGridViewTextBoxColumn colPrefixo = new DataGridViewTextBoxColumn();
            colPrefixo.AutoSizeMode = defAutoCol;
            colPrefixo.Name         = "PREFIXO";
            colPrefixo.HeaderText   = "Prefixo";
            colPrefixo.DataPropertyName = "PREFIXO";

            /// NUMTITULO
            DataGridViewTextBoxColumn colNumtitulo = new DataGridViewTextBoxColumn();
            colNumtitulo.AutoSizeMode = defAutoCol;
            colNumtitulo.Name         = "NUMTITULO";
            colNumtitulo.HeaderText   = "Numero";
            colNumtitulo.DataPropertyName = "NUMTITULO";

            /// PARCELA
            DataGridViewTextBoxColumn colParcela = new DataGridViewTextBoxColumn();
            colParcela.AutoSizeMode = defAutoCol;
            colParcela.Name         = "PARCELA";
            colParcela.HeaderText   = "Parcela";
            colParcela.DataPropertyName = "PARCELA";

            /// NATUREZA
            DataGridViewTextBoxColumn colNatureza = new DataGridViewTextBoxColumn();
            colNatureza.AutoSizeMode = defAutoCol;
            colNatureza.Name         = "NATUREZA";
            colNatureza.HeaderText   = "Natureza";
            colNatureza.DataPropertyName = "NATUREZA";
            
            /// FORNECEDOR (descrição) > pegar dados a partir da coluna FORNECE do datasource
            DataGridViewTextBoxColumn colFornecedor = new DataGridViewTextBoxColumn();
            colFornecedor.AutoSizeMode = defAutoCol;
            colFornecedor.Name         = "_fornece";
            colFornecedor.HeaderText   = "Forncedor";
            colFornecedor.DataPropertyName = "FORNECEDOR";
            
            /// LOJA
            DataGridViewTextBoxColumn colLoja = new DataGridViewTextBoxColumn();
            colLoja.AutoSizeMode = defAutoCol;
            colLoja.Name         = "LOJA";
            colLoja.HeaderText   = "Loja";
            colLoja.DataPropertyName = "LOJA";
            
            /// EMISSAO    (formatar data)
            DataGridViewTextBoxColumn colEmissao = new DataGridViewTextBoxColumn();
            colEmissao.AutoSizeMode = defAutoCol;
            colEmissao.Name         = "_emissao";
            colEmissao.HeaderText   = "Emissao";
            colEmissao.DefaultCellStyle.Format = "dd/MM/yyyy";
            
            /// VENCIMENTO (formatar data)
            DataGridViewTextBoxColumn colVencimento = new DataGridViewTextBoxColumn();
            colVencimento.AutoSizeMode = defAutoCol;
            colVencimento.Name         = "_vencimento";
            colVencimento.HeaderText   = "Vencimento";
            colVencimento.DefaultCellStyle.Format = "dd/MM/yyyy";
            
            /// VALOR     - decimal(17,2)
            DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn();
            colValor.AutoSizeMode = defAutoCol;
            colValor.Name         = "VALOR";
            colValor.HeaderText   = "Valor";
            colValor.DataPropertyName = "VALOR";
            
            /// ISS       - decimal
            DataGridViewTextBoxColumn colISS = new DataGridViewTextBoxColumn();
            colISS.AutoSizeMode = defAutoCol;
            colISS.Name         = "ISS";
            colISS.HeaderText   = "ISS";
            colISS.DataPropertyName = "ISS";
            
            /// IRFF      - decimal
            DataGridViewTextBoxColumn colIRFF = new DataGridViewTextBoxColumn();
            colIRFF.AutoSizeMode = defAutoCol;
            colIRFF.Name         = "IRRF";
            colIRFF.HeaderText   = "IRRF";
            colIRFF.DataPropertyName = "IRRF";
            
            /// HISTORICO
            DataGridViewTextBoxColumn colHistorico = new DataGridViewTextBoxColumn();
            colHistorico.AutoSizeMode = defAutoCol;
            colHistorico.Name         = "HISTORICO";
            colHistorico.HeaderText   = "Historico";
            colHistorico.DataPropertyName = "HISTORICO";
            
            /// INSS      - decimal
            DataGridViewTextBoxColumn colINSS = new DataGridViewTextBoxColumn();
            colINSS.AutoSizeMode = defAutoCol;
            colINSS.Name         = "INSS";
            colINSS.HeaderText   = "INSS";
            colINSS.DataPropertyName = "INSS";
            
            /// COFINS    - decimal
            DataGridViewTextBoxColumn colCOFINS = new DataGridViewTextBoxColumn();
            colCOFINS.AutoSizeMode = defAutoCol;
            colCOFINS.Name         = "COFINS";
            colCOFINS.HeaderText   = "COFINS";
            colCOFINS.DataPropertyName = "COFINS";
            
            /// PISPASEP  - decimal
            DataGridViewTextBoxColumn colPISPASEP = new DataGridViewTextBoxColumn();
            colPISPASEP.AutoSizeMode = defAutoCol;
            colPISPASEP.Name         = "PISPASEP";
            colPISPASEP.HeaderText   = "PIS/PASEP";
            colPISPASEP.DataPropertyName = "PISPASEP";
            
            /// CSLL      - decimal
            DataGridViewTextBoxColumn colCSLL = new DataGridViewTextBoxColumn();
            colCSLL.AutoSizeMode = defAutoCol;
            colCSLL.Name         = "CSLL";
            colCSLL.HeaderText   = "CSLL";
            colCSLL.DataPropertyName = "CSLL";
            
            /// ADD COLUNAS
            dgvDados.Columns.Add(imgCol       );
            dgvDados.Columns.Add(colEmpresa   );
            dgvDados.Columns.Add(colFilial    );
            dgvDados.Columns.Add(colPrefixo   );
            dgvDados.Columns.Add(colNumtitulo );
            dgvDados.Columns.Add(colParcela   );
            dgvDados.Columns.Add(colNatureza  );
            dgvDados.Columns.Add(colFornecedor);
            dgvDados.Columns.Add(colLoja      );
            dgvDados.Columns.Add(colEmissao   );
            dgvDados.Columns.Add(colVencimento);
            dgvDados.Columns.Add(colValor     );
            dgvDados.Columns.Add(colISS       );
            dgvDados.Columns.Add(colIRFF      );
            dgvDados.Columns.Add(colHistorico );
            dgvDados.Columns.Add(colINSS      );
            dgvDados.Columns.Add(colCOFINS    );
            dgvDados.Columns.Add(colPISPASEP  );
            dgvDados.Columns.Add(colCSLL      );
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

        private void menu_Click(object objSource, ToolBarItemEventArgs objArgs)
        {
            EmpresaVo empresa  = new EmpresaVo();
            string    root     = System.Web.HttpContext.Current.Server.MapPath("");
            int       rootIdx  = root.IndexOf("Route\\");
            root               = root.Substring(0, rootIdx) + "arquivos\\";
            string    filename = "Report_"+DateTime.Now.ToString("dd_MM_yyyy")+".[?]";

            switch (objArgs.ToolBarButton.Name.ToLower())
            {
                case "tbbadd":
                    #region ADD
                    new PreCADASTRO(new CadContasAPagar(empresa), empresa).ShowWindow(this.Form);
                    #endregion
                    
                    break;
                case "tbbver":
                    #region VER
                    if (dgvDados.SelectedRows.Count > 0)
                    {
                        openRow(empresa, true);
                    }
                    #endregion
                    
                    break;
                case "tbbedit":
                    #region EDIT
                    if (dgvDados.SelectedRows.Count > 0)
                    {
                        openRow(empresa, false);
                    }
                    else
                        MessageBox.Show("Selecione uma linha pra edição.");
                    #endregion

                    break;
                case "tbbdel":
                    #region DEL
                    if (dgvDados.SelectedRows.Count > 0)
                    {
                        int status = (int)(dgvDados.DataSource as DataTable)
                                         .DefaultView[dgvDados.SelectedRows[0].Index]["STATUS"];

                        if ( status != 1
                          && status != 4)
                        {
                            MessageBox.Show("Tem certeza que deseja deletar o registro?"
                                           , ""
                                           , MessageBoxButtons.YesNo
                                           , new EventHandler(rowDelete));
                        }
                        else
                        {
                            MessageBox.Show( "Não é possivel remover o registro com status " +
                                              new Resources.Icons.status()[status][1].ToString()
                                           , "Negado!");
                        }
                    }
                    #endregion

                    break;
                case "tbbexcel":
                    #region EXCEL
                    filename = filename.Replace("[?]","xls");
                    Carralero.ExportExcel excel = new Carralero.ExportExcel(root + filename);
                    excel.setDataTable(1, 1, (DataTable)dgvDados.DataSource, true);
                    excel.Close();
                    
                    new FormatScreen().DownloadFile("arquivos", filename, FormatScreen.ContextType.PDF);
                    #endregion

                    break;
                case "tbbpdf":
                    #region PDF
                    filename = filename.Replace("[?]","pdf");
                    Carralero.ExportPdf pdf = new Carralero.ExportPdf("arquivos\\"+filename);
                    pdf.setDataTable((DataTable)dgvDados.DataSource, true);
                    
                    new FormatScreen().DownloadFile("arquivos", filename, FormatScreen.ContextType.PDF);
                    #endregion
                    
                    break;
                default: break;
            }
            return;
        }

        private void openRow(EmpresaVo empresa, bool readOnly)
        {
            int         idx = dgvDados.SelectedRows[0].Index;
            DataRowView row = (dgvDados.DataSource as DataTable).DefaultView[idx];
            int         id  = (int)row["id"];
            empresa.CODIGO        = (string)row["EMPRESA"];
            empresa.CODIGO_FILIAL = (string)row["FILIAl"];
            new EmpresaDao().Load(empresa, null);
            ControlsConfig.formShow(new CadContasAPagar(empresa, id, readOnly), this.Form, ControlsConfig.showType.Dialog);
        }
        private void rowDelete(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(MessageBoxWindow)))
            {
                if ((sender as MessageBoxWindow).DialogResult.Equals(DialogResult.Yes))
                {
                    int         idx = dgvDados.SelectedRows[0].Index;
                    DataRowView row = (dgvDados.DataSource as DataTable).DefaultView[idx];

                    ContasAPagarVO conta = new ContasAPagarVO();
                    conta.ID      = (int)   row["id"];
                    conta.EMPRESA = (string)row["EMPRESA"];
                    conta.FILIAL  = (string)row["FILIAl"];

                    new ContasAPagarDAO().delete(conta);
                }
            }
        }

        private void setGridToView(DataGridView grid)
        {
            /// SET STATUS
            //DataGridView    grid  = sender as DataGridView;
            
            // DataRowView     dtrow = (grid.DataSource as DataTable).DefaultView[idx];//e.RowIndex];
            
            int idx = 0;
            foreach (DataRowView dtrow in (grid.DataSource as DataTable).DefaultView)
            {
                DataGridViewRow row = grid.Rows[idx];//e.RowIndex];
                this.setStatusColumn(grid.Rows[idx], (int)dtrow["STATUS"]);

                /// SET DATAS
                row.Cells["_emissao"   ].Value = Carralero.Funcoes.getDateTime((string)dtrow["EMISSAO"   ]);
                row.Cells["_vencimento"].Value = Carralero.Funcoes.getDateTime((string)dtrow["VENCIMENTO"]);

                /// SET EMPRESA e FILIAL (DESCRICAO)
                string sCodEmp  = (string)dtrow["EMPRESA"];
                string sEmpresa = "";
                DataTable dtEmp = new SigaObjects.Session.Empresa.EmpresaDao().getEmpresas("M0_CODIGO = '" + sCodEmp + "'");
                if (dtEmp.DefaultView.Count > 0)
                    sEmpresa = (string)dtEmp.DefaultView[0]["M0_NOME"];

                string    sCodFil = (string)dtrow["FILIAl"];
                string    sFilial = "";
                DataTable dtFil   = new SigaObjects.Session.Empresa.EmpresaDao().getEmpresas_Filiais("M0_CODIGO = '" + sCodEmp + "' AND M0_CODFIL = '" + sCodFil + "'");
                if (dtFil.DefaultView.Count > 0)
                    sFilial = sCodFil + " - " + (string)dtFil.DefaultView[0]["M0_FILIAL"];

                row.Cells["_empresa"].Value = sEmpresa;
                row.Cells["_filial" ].Value = sFilial;
                
                idx++;
            }
        }
        private void setStatusColumn(DataGridViewRow row, int iStatus)
        {
            DataGridViewImageCell status = new DataGridViewImageCell();
            List<object> estado = new Resources.Icons.status()[iStatus];
            if (estado != null && estado.Count > 0)
            {
                status.Value       = estado[0];
                status.ToolTipText = (string)estado[1];
            }

            row.Cells["_aprv"] = status;
        }
    }
}