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
    internal partial class OrderBy : UserControl
    {
        private DataTable dados = new DataTable();
        private Table     main;

        /// <summary>Retorna um [controle]</summary>
        public Table  MAIN {
            get { return main; }
            set { main = value; }
        }
        /// <summary>Retorna a String de ordenação</summary>
        public String ORDER
        {
            get
            {
                StringBuilder strOrder = new StringBuilder();

                foreach (DataRowView dr in lbCampos.Items)
                {
                    strOrder.Append(", " + dr[REPORT.OrderBy.OrderByDao.ValueMember].ToString());
                }

                if(strOrder.ToString().Length>0)
                    strOrder = new StringBuilder(strOrder.ToString().Substring(1).Trim());

                return strOrder.ToString();
            }
        }

        #region Construtor
        /// <summary>Chama o método initialize, Inicializa os controles e seus respectivos Members (Display & Value)</summary>
        public OrderBy()
        {
            initialize(null);
        }
        /// <summary>Chama o método initialize, Inicializa os controles e seus respectivos Members (Display & Value)</summary>
        /// <param name="main">Um [controle] mainTable</param>
        public OrderBy(Table main)
        {
            initialize(main);
        }
        #endregion

        #region Aqui é onde ficará todo o código de inicialização do controle orderBy
        /// <summary>Inicializa os controles e seus respectivos Members (Display & Value)</summary>
        /// <param name="main">Um [controle] Table</param>
        private void initialize(Table main)
        {
            InitializeComponent();

            cmbTabela.SelectedIndexChanged += new EventHandler(cmbTabela_SelectedIndexChanged);

            cmbCampos.DisplayMember = SXManager.FieldDisplayMember;
            cmbCampos.ValueMember   = SXManager.FieldValueMember;

            cmbTabela.DisplayMember = SXManager.TableDisplayMember;
            cmbTabela.ValueMember   = SXManager.TableValueMember;

            lbCampos.DisplayMember  = REPORT.OrderBy.OrderByDao.DisplayMember;
            lbCampos.ValueMember    = REPORT.OrderBy.OrderByDao.ValueMember;

            dados.Columns.Add("id");
            dados.Columns.Add("indice");
            dados.Columns.Add("mainId");
            dados.Columns.Add(REPORT.OrderBy.OrderByDao.DisplayMember);
            dados.Columns.Add(REPORT.OrderBy.OrderByDao.ValueMember);
            
            this.MAIN = main;
            this.Dock = DockStyle.Fill;
        }
        #endregion

        #region SAVE LOAD E DELETE
        /// <summary> Montando a lista para salvar no banco de dados</summary>
        public void SAVE()
        {
            List<REPORT.OrderBy.OrderByVo> orders = new List<REPORT.OrderBy.OrderByVo>();

            for (int i = 0; i < lbCampos.Items.Count; i++)
            {
                REPORT.OrderBy.OrderByVo order = new REPORT.OrderBy.OrderByVo();

                order.MAINID = this.MAIN.ID;
                order.INDICE = i;

                DataRowView valor = (lbCampos.Items[i] as DataRowView);

                order.VALUE   = valor[REPORT.OrderBy.OrderByDao.ValueMember].ToString();
                order.DISPLAY = valor[REPORT.OrderBy.OrderByDao.DisplayMember].ToString();

                orders.Add(order);
            }

            new REPORT.OrderBy.OrderByDao().save(orders);
        }
        public void LOAD()
        {
            if (this.MAIN != null)
            {
                /// CARREGAR TABELAS RELACIONADAS.
                cmbTabela.DataSource = 
                    new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                    .getTables("X2_CHAVE IN (" + SXManager.getStringArr(this.MAIN.RELATEDTABLES) + ")")
                    .DefaultView;

                /// CARREGAR CONFIGURACAO DE FILDS DO BANCO
                dados = new REPORT.OrderBy.OrderByDao().select(this.MAIN.ID);
                lbCampos.DataSource = dados.DefaultView;
            }
        }
        public void DELETE()
        {
            new REPORT.OrderBy.OrderByDao().delete(this.MAIN.ID);
        }
        #endregion

        #region Remover Item
        /// <summary>Remove um item da lista [lbCampos] e remove também do seu respectivo DataTable</summary>
        /// <param name="sender">Objeto que mandou</param>
        /// <param name="e">Argumentos de eventos</param>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lbCampos.SelectedIndex != -1)
            {
                dados.Rows[lbCampos.SelectedIndex].Delete();
                lbCampos.DataSource = dados.DefaultView;
            }
        }
        #endregion

        #region Adicionar Item
        /// <summary>Adiciona um item da lista [lbCampos] e remove também do seu respectivo DataTable</summary>
        /// <param name="sender">Objeto que mandou</param>
        /// <param name="e">Argumentos de eventos</param>
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DataRowView tabela = (cmbTabela.SelectedItem as DataRowView);
            DataRowView campos = (cmbCampos.SelectedItem as DataRowView);    
          
            string display = tabela["X2_NOME"].ToString() + " ( "
                           + campos["X3_TITULO"].ToString() + " )"
                           + ( (cbDesc.Checked)?" <DESC>":"" );
            string value = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTabela(tabela["X2_CHAVE"].ToString())["X2_ARQUIVO"].ToString()
                         + "." + campos["X3_CAMPO"].ToString()
                         + ( (cbDesc.Checked)?" DESC":"" );

            /// Verifica se existe grupo
            /// se existir verifica o select do campo.
            string query = this.main.QUERY.ToString();
            int haveGroup = query.IndexOf("GROUP BY");

            string tab_camp = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTabela(tabela["X2_CHAVE"].ToString())["X2_ARQUIVO"].ToString()
                              + "."
                              + campos["X3_CAMPO"].ToString();

            int haveField = query.IndexOf(tab_camp);

            if (haveGroup < 0)
            {
                if (haveField < 0)
                {
                    MessageBox.Show("selecione o campo na aba Campos.");
                    return;
                }
            }
                       
            dados.Rows.Add(new Object[] 
                {
                    0                         , //Id
                    (lbCampos.Items.Count - 1), //Indice o mesmo do controle
                    this.MAIN.ID              , //Id do controle pai
                    display                   , //O valor que é mostrado para o cliente
                    value                       //O valor que para a formação da cláusula orderBy
                });
            lbCampos.DataSource = dados.DefaultView;
            lbCampos.SelectedIndex = lbCampos.Items.Count - 1;
        }
        void cmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCampos.DataSource =
                new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                .getFields(cmbTabela.SelectedValue.ToString())
                .DefaultView;
        }
        #endregion

        #region Move Controles
        #region Auxílio
        private void preencheSwapComDados(DataTable swap)
        {
            swap.Columns.Add("id");
            swap.Columns.Add("indice");
            swap.Columns.Add("mainId");
            swap.Columns.Add(REPORT.OrderBy.OrderByDao.DisplayMember);
            swap.Columns.Add(REPORT.OrderBy.OrderByDao.ValueMember);

            //Passa todos os registros de [dados] para o [swap]
            for (int i = 0; i < dados.DefaultView.Count; i++)
            {
                swap.Rows.Add(
                    new object[]
                    {
                        dados.DefaultView[i]["id"],
                        dados.DefaultView[i]["indice"],
                        dados.DefaultView[i]["mainId"],
                        dados.DefaultView[i][REPORT.OrderBy.OrderByDao.DisplayMember],
                        dados.DefaultView[i][REPORT.OrderBy.OrderByDao.ValueMember]
                    }
                );
            }
        }
        private void adicionaIndiceEmDados(int indice, DataTable swap)
        {
            dados.Rows.Add(
                        new object[]
                    {
                        swap.DefaultView[indice]["id"],
                        swap.DefaultView[indice]["indice"],
                        swap.DefaultView[indice]["mainId"],
                        swap.DefaultView[indice][REPORT.OrderBy.OrderByDao.DisplayMember],
                        swap.DefaultView[indice][REPORT.OrderBy.OrderByDao.ValueMember]
                    }
                    );
        }
        private void limpaEmDados()
        {
            dados.Rows.Clear();
        }
        private void preencheDadosComSwap(DataTable swap)
        {
            for (int i = 0; i < swap.DefaultView.Count; i++)
            {
                dados.Rows.Add(
                    new object[]
                    {
                        swap.DefaultView[i]["id"],
                        swap.DefaultView[i]["indice"],
                        swap.DefaultView[i]["mainId"],
                        swap.DefaultView[i][REPORT.OrderBy.OrderByDao.DisplayMember],
                        swap.DefaultView[i][REPORT.OrderBy.OrderByDao.ValueMember]
                    }
                );
            }
        }
        #endregion

        #region Passa a seleção do lbCampos para a primeira posição
        private void btnPrimeiro_click(object sender, EventArgs e)
        {
            if (lbCampos.SelectedIndex != -1)
            {
                DataTable swap = new DataTable();
                int indice = lbCampos.SelectedIndex;

                //Preenche todo o [swap]
                preencheSwapComDados(swap);

                //Limpa todas as linhas de [dados] (Porém o Backup está em [swap])
                limpaEmDados();
                //Adiciona na primeira linha o valor do indice do [swap] (Passa a ser o primeiro)
                adicionaIndiceEmDados(indice, swap);

                //Deleta aquele indice do [swap], mas [dados] contém aquele registro na primeira linha
                swap.Rows[indice].Delete();
                //Preenche [dados] com o restante dos dados de [swap]
                preencheDadosComSwap(swap);

                //Passa [dados] como referência
                lbCampos.DataSource = dados.DefaultView;

                //Mantém o cursor no primeiro índice
                lbCampos.SelectedIndex = 0;
            }
        }
        #endregion

        #region Passa a seleção do lbCampos para a posição de cima
        private void btnCima_Click(object sender, EventArgs e)
        {
            if (lbCampos.SelectedIndex > 0)
            {
                DataTable swap = new DataTable();
                int indice = lbCampos.SelectedIndex;

                preencheSwapComDados(swap);

                //Limpa a tabela de [dados]
                limpaEmDados();

                object[] anterior =
                    new object[]
                    {
                        swap.Rows[indice - 1]["id"],
                        swap.Rows[indice - 1]["indice"],
                        swap.Rows[indice - 1]["mainId"],
                        swap.Rows[indice - 1][REPORT.OrderBy.OrderByDao.DisplayMember],
                        swap.Rows[indice - 1][REPORT.OrderBy.OrderByDao.ValueMember]
                    };
                object[] eu =
                    new object[]
                    {
                        swap.Rows[indice]["id"],
                        swap.Rows[indice]["indice"],
                        swap.Rows[indice]["mainId"],
                        swap.Rows[indice][REPORT.OrderBy.OrderByDao.DisplayMember],
                        swap.Rows[indice][REPORT.OrderBy.OrderByDao.ValueMember]
                    };
                for (int i = 0; i < swap.DefaultView.Count; i++)
                {
                    dados.Rows.Add(
                        i == (indice - 1)
                    ? eu
                    : (i == (indice)
                        ? anterior
                        : new object[]
                        {
                            swap.Rows[i]["id"],
                            swap.Rows[i]["indice"],
                            swap.Rows[i]["mainId"],
                            swap.Rows[i][REPORT.OrderBy.OrderByDao.DisplayMember],
                            swap.Rows[i][REPORT.OrderBy.OrderByDao.ValueMember]
                        }
                       )
                    );
                }

                //Mantém o cursor 1 índice acima
                lbCampos.SelectedIndex = indice - 1;
            }
        }
        #endregion

        #region Passa a seleção do lbCampos para a posição de baixo
        private void btnBaixo_Click(object sender, EventArgs e)
        {
            if (lbCampos.SelectedIndex < lbCampos.Items.Count - 1)
            {
                DataTable swap = new DataTable();
                int indice = lbCampos.SelectedIndex;

                preencheSwapComDados(swap);

                //Limpa a tabela de [dados]
                limpaEmDados();

                object[] anterior =
                    new object[]
                    {
                        swap.Rows[indice]["id"],
                        swap.Rows[indice]["indice"],
                        swap.Rows[indice]["mainId"],
                        swap.Rows[indice][REPORT.OrderBy.OrderByDao.DisplayMember],
                        swap.Rows[indice][REPORT.OrderBy.OrderByDao.ValueMember]
                    };
                object[] proximo =
                    new object[]
                    {
                        swap.Rows[indice + 1]["id"],
                        swap.Rows[indice + 1]["indice"],
                        swap.Rows[indice + 1]["mainId"],
                        swap.Rows[indice + 1][REPORT.OrderBy.OrderByDao.DisplayMember],
                        swap.Rows[indice + 1][REPORT.OrderBy.OrderByDao.ValueMember]
                    };
                for (int i = 0; i < swap.DefaultView.Count; i++)
                {
                    dados.Rows.Add(
                        i == indice
                    ? proximo
                    : (i == (indice + 1)
                        ? anterior
                        : new object[]
                        {
                            swap.Rows[i]["id"],
                            swap.Rows[i]["indice"],
                            swap.Rows[i]["mainId"],
                            swap.Rows[i][REPORT.OrderBy.OrderByDao.DisplayMember],
                            swap.Rows[i][REPORT.OrderBy.OrderByDao.ValueMember]
                        }
                       )
                    );
                }

                //Mantém o cursor 1 índice abaixo
                lbCampos.SelectedIndex = indice + 1;
            }
        }
        #endregion

        #region Passa a seleção do lbCampos para a última posição
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            DataTable swap = new DataTable();
            int indice = lbCampos.SelectedIndex;

            //Passa todos os registros de [dados] para o [swap]
            preencheSwapComDados(swap);

            //Limpa todas as linhas de [dados] (Porém o Backup está em [swap])
            limpaEmDados();

            //Guarda o que será o último índice
            object[] ultimo =
                new object[]
                    {
                        swap.DefaultView[indice]["id"],
                        swap.DefaultView[indice]["indice"],
                        swap.DefaultView[indice]["mainId"],
                        swap.DefaultView[indice][REPORT.OrderBy.OrderByDao.DisplayMember],
                        swap.DefaultView[indice][REPORT.OrderBy.OrderByDao.ValueMember]
                    };

            //Deleta aquele indice do [swap], mas dados contém aquele registro na primeira linha
            swap.Rows[indice].Delete();

            //Preenche [dados] com o restante dos dados de [swap]
            preencheDadosComSwap(swap);

            //Adiciona o último registro
            dados.Rows.Add(ultimo);

            //Passa dados como referência para o conjunto de dados
            //de lbCampos, Recebendo os registros de [dados],
            //lbCampos poderá mostrar esses registros para o usuário
            //sendo assim o usuário poderá manipular o DataSource
            //através de um controle visual
            lbCampos.DataSource = dados.DefaultView;

            //Mantém o cursor no último índice
            lbCampos.SelectedIndex = lbCampos.Items.Count - 1;
        }
        #endregion
        #endregion

        internal static object ControlCollection()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}