#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using Carralero;
using SigaObjects;
#endregion

namespace SigaControls
{
    public partial class mainTable : UserControl
    {
        //private SigaObjects.MainTable main;

        private int          id             = 0;
        private bool         mainType       = true;
        private string       nomeOriginal   = "";
        private List<string> relatedTables  = new List<string>();
        private List<string> selectedFields = new List<string>();
        private List<string> displayFields  = new List<string>();
        private Label        lblTABLE       = new Label();
        /// subcontroles
        //private abas.orderBy ORDERBY = new abas.orderBy();
        //private abas.groupBy GROUPBY = new abas.groupBy();
        //private abas.Fields  FIELDS  = new abas.Fields();
        //private abas.Filters FILTERS = new abas.Filters();
        
        public  int          ID           
        {
            get { return id; }
            set { id = value; }
        }
        public  bool         MAINTYPE     
        {
            get { return mainType; }
            set { mainType = value; }
        }
        public  string       NOMEORIGINAL 
        {
            get { return nomeOriginal; }
            set { nomeOriginal = value; }
        }
        public  string       TABLE        
        {
            get { return lblTABLE.Text; }
            set { lblTABLE.Text = value; }
        }
        public  List<string> RELATEDTABLES
        {
            get { return relatedTables; }
            set { relatedTables = value; }
        }
        public  List<string> DISPLAYFIELDS
        { get { return displayFields; } }
        /// gerar Query
        public  string       QUERY        
        {
            get
            {
                StringBuilder sQuery = new StringBuilder();
                //string fields = this.FIELDS.FIELDS;
                List<string> joinTypes  = new List<string>();
                List<string> joinTables = new List<string>();
                List<string> allClauses = new List<string>();

                //foreach (Control win in tpJoin.Controls)
                    //if((win as winTable).getFIELDS.Trim()!="")
                    //    fields += ", " + sQuery.AppendLine((win as winTable).getFIELDS);

                /*if (fields.Length > 0)
                    fields = (fields.Length > 0) ? fields.Substring(1) : fields;
                else
                    fields = "*";

                if (fields.Trim().StartsWith(","))
                    fields = fields.Trim().Substring(1);

                sQuery = new StringBuilder("SELECT " + fields);*/
                sQuery.AppendLine("  FROM @SIGAMAT ");
                // TODO <> loop das Clausulas. JOINS
                /// foreach (Control win in tpJoin.Controls)
                    /// sQuery.AppendLine((win as winTable).JOIN);
                //sQuery.AppendLine(
                //sQuery.AppendLine(" WHERE @SIGAMAT." + this.TABLE.Substring(1) + "_FILIAL \t= '" + Empresa.CODIGO_FILIAL + "'");

                return sQuery.ToString().Replace("@SIGAMAT", new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTabela(this.TABLE)["X2_ARQUIVO"].ToString()); //MakeQuery.createQuery(this);
            }
        }

        public mainTable()
        {
            InitializeComponent();

            this.Dock             = DockStyle.Fill;
            lblTABLE.TextChanged += new EventHandler(lblTABLE_TextChanged);

            // ADICIONANDO SubControles
            /*
            tpFieldsReturn.Controls.Add(this.FIELDS );
            tpGourp.Controls.Add(       this.GROUPBY);
            tpOrder.Controls.Add(       this.ORDERBY);
            tpFilter.Controls.Add(      this.FILTERS);
             * */
        }
        public void LOAD(string name, bool isFirst)
        {
            relatedTables = new List<string>();
            
            /// Inicializando o MAIN.
            //main = new SigaObjects.MainTable();
            //main.NOME    = name;
            //main.EMPRESA = Empresa.CODIGO;
            //main.USUARIO = Usuario.USERNAME;
            // CARREGANDO MainTable
            //main.load();

            //this.ID = main.ID;
            if (this.ID > 0 && !isFirst)
            {
                // preenche o nome da tabela.
             //   this.TABLE = main.TABELA;

             //   relatedTables.Add(main.TABELA);

                /// PRENCHE OS CAMPOS SELECIONADOS
                /*
                this.FIELDS.MAIN = this;
                this.FIELDS.LOAD();
                 */
                this.RELATEDTABLES.Clear();
                this.RELATEDTABLES.Add(this.TABLE);
                // Preenche lista de tabelas filho.
           //     foreach (ChildTable child in main.getChildTables())
           //     {
           //         this.RELATEDTABLES.Add(child.TABELA);
           //         winTable win = new winTable(child, this);
                    //win.LOAD(child);
           //         this.addRelatedTable(win.TABLE);
           //     }
            }

            /// Controles de tela.
          //  txtNomeRelatorio.Text = main.NOME;
        }

        public void addRelatedTable(string  strTable)
        {
            //ChildTable child = new ChildTable();
            //child.MAINID       = this.ID;
            //child.TABELA       = strTable;
            
            //addRelatedTable(new winTable(child, this));
        }
        public void addRelatedTable(Control wintable)
        {
            //if (wintable.GetType() == typeof(winTable))
           // {
                //winTable win = (wintable as winTable);
                //this.RELATEDTABLES.Add(win.TABLE);
                //tpJoin.Controls.Add(win);
           // }
        }

        private void setRelations()
        {
            /*
            foreach (Control c in tpJoin.Controls)
                if (c.GetType() == typeof(winTable))
                {
                    winTable win = (c as winTable);
                    win.RELATEDTABLES = this.RELATEDTABLES;
                }
            */
        }

        //private void 

        #region EVENTOS DE CONTROLES
        private void lblTABLE_TextChanged(object sender, EventArgs e)
        {
            string filtro;
            SigaObjects.SXManager manager = new SigaObjects.SXManager(sigaSession.EMPRESAS[0].CODIGO);

            /// POPULA COM DADOS DA TABELA SELECONADA
            filtro = "X2_CHAVE = '@TABLE'";
            filtro = filtro.Replace("@TABLE", TABLE);
            tpJoin.Text = (string)manager.getTables(filtro).DefaultView[0]["X2_NOME"];
            tpJoin.Controls.Clear();

            this.relatedTables.Clear();
            this.relatedTables.Add(this.TABLE);

            /// RECARREGANDO SUBCONTROLES
            //this.ORDERBY.MAIN = this;
            //this.FIELDS.MAIN  = this;
            //this.FILTERS.MAIN = this;
            //this.GROUPBY.MAIN = this;
            /*
            this.ORDERBY.LOAD();
            this.FIELDS.LOAD();
            this.FILTERS.LOAD();
            this.GROUPBY.LOAD();
            */
        }

        private void tpJoin_Resize(        object sender , EventArgs e)
        { FormatScreen.organizerControls(tpJoin); }

        private void tpJoin_ControlAdded(  object sender , ControlEventArgs e)
        {
            /*
            FormatScreen.organizerControls(tpJoin);
            if (e.Control.GetType() == typeof(winTable))
            {
                this.relatedTables.Add((e.Control as winTable).TABLE);
                foreach (Control win in this.tpJoin.Controls)
                    (win as winTable).MAIN = this;
            }
            */
            setRelations();
        }

        private void tpJoin_ControlRemoved(object sender, ControlEventArgs e)
        {
            /*
            FormatScreen.organizerControls(tpJoin);
            if (e.Control.GetType() == typeof(winTable))
            {
                this.relatedTables.Remove((e.Control as winTable).TABLE);
                foreach(Control win in this.tpJoin.Controls)
                    (win as winTable).MAIN=this;
            }
            */
            setRelations();
        }
        #endregion

        private void btnShowDados_Click( object sender, EventArgs e)
        {
            new gridWindow(this.QUERY, new Control()).showWindow(this.Form,true, 50);
        }

        private void btnShowQuery_Click( object sender, EventArgs e)
        {
            Exception msg = new Exception(this.QUERY);
            ERROR erro = new ERROR(msg);
            ControlsConfig.formShow(erro, this.Form);
        }

        private void btnShowTables_Click(object sender, EventArgs e)
        {
            Label strTable = new Label();
            
            //StringBuilder sQuery;
            DataTable dados = new DataTable();
            bool   isRelatedTable = this.relatedTables.Count > 0;
            string filtro = txtFilterTables.Text.Trim();

            filtro = (filtro == "filtro") ? "" : filtro;

            if (isRelatedTable)
                dados = new SigaObjects.SXManager(sigaSession.EMPRESAS[0].CODIGO).getRelatedTables(this.RELATEDTABLES, "X2_NOME LIKE '%" + filtro + "%'");
            else
                dados = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTables("X2_NOME LIKE '%" + filtro + "%'");

            Form frm = new Form();
            frm.Text = (this.relatedTables.Count>0) ? "TABELAS RELACIONADAS" : "TODAS AS TABELAS";
            frm.Controls.Add(new gridWindow(dados, strTable, "X2_CHAVE"));
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            strTable.TextChanged += new EventHandler(strTable_TextChanged);
        }
        void strTable_TextChanged(       object sender, EventArgs e)
        {
            bool isRelatedTable = this.relatedTables.Count > 0;

            if (!isRelatedTable)
                this.TABLE = (sender as Control).Text;
            else
                this.addRelatedTable((sender as Control).Text);
        }

        private void btnSalve_Click(     object sender, EventArgs e)
        {
            /*
            MainTable main = new MainTable();
            main.EMPRESA = Empresa.CODIGO;
            main.USUARIO = Usuario.USERNAME;
            main.NOME    = this.NOMEORIGINAL;
            main.TABELA  = this.TABLE;
            main.ID      = this.ID;
            bool bOk     = true;

            try
            {
                if (this.ID == 0)
                {
                    main.NOME = txtNomeRelatorio.Text.Trim();
                    main.insert();
                    main.load();
                    this.ID = main.ID;
                }
                else
                { main.update(txtNomeRelatorio.Text.Trim()); }
            }
            catch { bOk = false; }

            if (this.ID > 0)
            {
                /// SALVANDO OS CAMPOS INSERIDOS, ATUALIZADOS e DELETADOS.
                this.FIELDS.SAVE();
                this.ORDERBY.SAVE();
                this.FILTERS.SAVE();
                this.GROUPBY.SAVE();

                /// DELETANDO TODAS AS TABELAS FILHO
                /// PARA GARANTIR O SAVE E CANCEL DO USUARIO
                foreach (ChildTable child in main.getChildTables())
                    child.delete(); // DELETANDO OS FIELDS EM CASCATE (também)

                /// VARRENDO OS CONTROLES E SALVANDO AS TABELAS CONFORME O USUARIO CONFIGUROU.
                foreach (Control control in tpJoin.Controls)
                    if (control.GetType() == typeof(winTable))
                        (control as winTable).SAVE();
            }

            /// SALVO COM SUCESSO?
            string message = bOk ? "Salvo com Sucesso!"
                                 : "Algum problema ao salvar o relatório.";
            MessageBox.Show(message, "Operação SALVAR.");
            */
        }

        private void txtNomeRelatorio_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeRelatorio.Text.Trim().Length > 0)
                this.Parent.Text = txtNomeRelatorio.Text.Trim();
        }

        private void txtNomeRelatorio_GotFocus(object sender, EventArgs e)
        {
            txtNomeRelatorio.SelectionLength = txtNomeRelatorio.Text.Length;
        }
    }
}