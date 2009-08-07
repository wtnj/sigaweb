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
using SigaObjects;
#endregion

namespace SigaControls.Report
{
    public partial class Table : UserControl
    {
        #region CONTROLS
        public  REPORT.Report.ReportVo mainReport = null; //new REPORT.Report.ReportVo(); /// RELATORIO DIRETAMENTE LIGADO
        public  Table                  main       = null; //new REPORT.Table.TableVo();   /// OWNER DA TABELA
        public  Fields      FIELDS;  //  = new Fields();      // CAMPOS DA TABELA
        //public  List<Table> CHILDREN;//  = new List<Table>(); // LINKS (tabelas)
        //private GroupBy     GROUPBY; //  = new GroupBy();     // AGRUPAMENTO
        public  Filters     FILTERS; //  = new Filters();     // FILTROS
        private OrderBy     ORDERBY; //  = new OrderBy();     // ORDENACAO
        private Params      PARAMS;  //  = new Params();      // PARAMETROS
        #endregion

        #region ATRIBUTOS
        private bool                   IsRootTable     = false;
        public  REPORT.Table.TableVo   THISTABLE       = new REPORT.Table.TableVo();   /// ESTA TABELA
        private Table                  MAINTABLE;
        private List<string>           relatedTables   = new List<string>();
        private string                 filtroParametro = "";

        private REPORT.Table.TableVo  _relatedtable = new REPORT.Table.TableVo();

        private DataTable dataRelatedTable = new DataTable();
        private DataTable dataRelatedChild = new DataTable();
        #endregion

        #region PROPRIEDADES
        public string FILTROPARAMETRO
        {
            get { return filtroParametro;}
            set
            {
                if (!string.IsNullOrEmpty(value))
                    this.filtroParametro = value;
            }
        }
        
        #region PROPRIEDADES DO THISTABLE
        public string SUFIXO  
        {
            get{ return this.THISTABLE.SUFIXO;  }
            set{ this.THISTABLE.SUFIXO = value; }
        } // SUFIXO DA TABELA
        public int    REPORTID
        {
            get
            {   return (this.MAINREPORT != null) ? this.MAINREPORT.ID : 0;
                //return this.THISTABLE.IDREPORT;
            }
            set
            {
                //this.THISTABLE.IDREPORT = value;
                //REPORT.Report.ReportVo myReport = new REPORT.Report.ReportVo(value);
                //new REPORT.Report.ReportDao().load(myReport);
                //this.MAINREPORT = myReport;
                this.MAINREPORT.ID = value;
            }
        } // ID DO RELATORIO LIGADO
        public int    MAINID  
        {
            get { return (this.MAIN != null) ? this.MAIN.ID : 0; }
        } // ID DA TABELA LIGADA
        public int    ID      
        {
            get { return this.THISTABLE.ID; }
            set { this.THISTABLE.ID = value; }
        } // ID DESTA TABELA
        public REPORT.Table.TableVo   MAIN      
        {
            get { return this.THISTABLE.PARENT;   }
            set { this.THISTABLE.PARENT = value;  }
        }
        public REPORT.Report.ReportVo MAINREPORT
        {
            get { return this.mainReport; }
            set
            {
                this.mainReport  = value;
            }
        } // RELATORIO LIGADO
        public string        TABLE         
        {
            get { return this.THISTABLE.TABELA; }
            set
            {
                if (value != null)
                {
                    this.lblTabela.Text   = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTabela(value)[SXManager.TableDisplayMember].ToString();
                    this.THISTABLE.TABELA = value;
                }
            }
        } // NOME DA TABELA
        public REPORT.Table.TableVo RELATED
        {
            get { return this.THISTABLE.RELATED;  }
            set { this.THISTABLE.RELATED = value; }
        } // TABELA RELACIONADA
        /*
        public string        RELATEDTABLE 
        {
            get { return this.THISTABLE.RELATEDTABLE; }
            set
            {
                if (value != null)
                {
                    this.THISTABLE.RELATEDTABLE = value;
                }
            }
        } // NOME DA TABELA RELACIONADA
        public int           RELATEDINDEX 
        {
            get { return this.THISTABLE.RELATEDINDEX;  }
            set { this.THISTABLE.RELATEDINDEX = value; }
        }
        //*/
        public string        RELATEDIDENT 
        {
            get { return this.THISTABLE.RELATEDIDENT; }
            set
            {
                if (value != null)
                    this.THISTABLE.RELATEDIDENT = value;
            }
        } // TIPO DE RELACIONAMENTO
        public string        RELATEDTYPE  
        {
            get { return this.THISTABLE.RELATEDTYPE; }
            set
            {
                if (value != null)
                {
                    this.THISTABLE.RELATEDTYPE = value;
                }
            }
        } // TIPO DE JOIN (INNER, LEFT, RIGHT, ...)
        public string        JOIN         
        {
            get
            {
                StringBuilder sRet = new StringBuilder();

                if (this.RELATED.TABELA.Length > 0)
                {
                    string tableKey = "@$TABLE$@";
                    string domTable  = tableKey.Replace("$TABLE$", this.TABLE);//(string)new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTabela(this.RELATEDTABLE)["X2_ARQUIVO"];
                    string cdomTable = this.RELATED.TABELA+this._relatedtable.SUFIXO; //tableKey.Replace("$TABLE$", this.RELATEDTABLE);       //(string)new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTabela(this.TABLE       )["X2_ARQUIVO"];
                    sRet.Append( this.RELATEDTYPE );
                    sRet.AppendLine(domTable + " AS " + this.TABLE + this.SUFIXO);
                    sRet.AppendLine("    ON "
                                   + this.TABLE + this.SUFIXO//domTable
                                   + ".D_E_L_E_T_ = "
                                   + cdomTable
                                   + ".D_E_L_E_T_");

                    List<string> clauses = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getRelatedClauses(this.TABLE, this.RELATED.TABELA,"X9_IDENT ='"+this.RELATEDIDENT+"'");
                    if (clauses.Count > 1)
                    {
                        string[] clDom  = clauses[0].ToString().Split('+');
                        string[] clCdom = clauses[1].ToString().Split('+');
                        for (int idx = 0; (idx < clDom.Length && idx < clCdom.Length); idx++)
                            sRet.AppendLine("   AND "
                                           + (((string)clDom.GetValue(idx)).Trim().StartsWith("'") ? "" : this.TABLE+this.SUFIXO + ".")//domTable + ".")
                                           + (string)clDom.GetValue(idx)
                                           + " = "
                                           + (((string)clCdom.GetValue(idx)).Trim().StartsWith("'") ? "" : cdomTable + ".")
                                           + (string)clCdom.GetValue(idx));
                    }
                }
                else
                    MessageBox.Show("É NECESSARIO SELECIONAR A TABELA RELACIONADA!");

                return sRet.ToString();
            }
        } // MONTA RELACIONAMENTO COM CLAUSULAS
        #endregion

        #region RECURSIVE PROPERTYES
        public  List<Table>   CHILDREN       
        {
            get
            {
                List<Table> tables = new List<Table>();

                foreach (Control c in linksPainel.Controls)
                {
                    if (c.GetType().Equals(typeof(Table)))
                    {
                        tables.Add((Table)c);
                    }
                }

                return tables;
            }
        }
        public  List<Table>   RECURSIVETABLES
        {
            get
            {
                List<Table> tables = new List<Table>();

                // ADD ESTA TABELA, pois esta propriedade retorna todas desse nivel pra baixo.
                //tables.Add(this);

                foreach (Control c in linksPainel.Controls)
                {
                    if (c.GetType().Equals(typeof(Table)))
                    {
                        tables.Add((Table)c);

                        foreach (Table child in (c as Table).RECURSIVETABLES)
                            tables.Add(child);
                    }
                }

                return tables;
            }
        }

        public List<REPORT.Table.TableVo    > RecTABLESvo 
        {
            get
            {
                List<REPORT.Table.TableVo> _tables = new List<REPORT.Table.TableVo>();

                foreach (Control c in linksPainel.Controls)
                {
                    if (c.GetType().Equals(typeof(Table)))
                    {
                        _tables.Add((c as Table).THISTABLE);

                        foreach (REPORT.Table.TableVo child in (c as Table).RecTABLESvo)
                            _tables.Add(child);
                    }
                }

                return _tables;
            }
        }
        public List<REPORT.Fields.FieldsVo  > RecFIELDSvo 
        {
            get
            {
                List<REPORT.Fields.FieldsVo> _fields = new List<REPORT.Fields.FieldsVo>();

                foreach (REPORT.Table.TableVo table in this.RecTABLESvo)
                    foreach (REPORT.Fields.FieldsVo field in table.FIELDS)
                        _fields.Add(field);

                return _fields;
            }
        }
        public List<REPORT.Filters.FiltersVo> RecFILTERSvo
        {
            get
            {
                List<REPORT.Filters.FiltersVo> _filters = new List<REPORT.Filters.FiltersVo>();

                foreach (REPORT.Table.TableVo table in this.RecTABLESvo)
                    foreach (REPORT.Filters.FiltersVo filter in table.FILTERS)
                        _filters.Add(filter);

                return _filters;
            }
        }
        public List<REPORT.OrderBy.OrderByVo> RecORDERBYvo
        {
            get
            {
                List<REPORT.OrderBy.OrderByVo> _orders = new List<REPORT.OrderBy.OrderByVo>();

                foreach (REPORT.Table.TableVo table in this.RecTABLESvo)
                    foreach (REPORT.OrderBy.OrderByVo order in table.ORDERBY)
                        _orders.Add(order);

                return _orders;
            }
        }
        public List<REPORT.Params.ParamsVo  > RecPARAMSvo 
        {
            get
            {
                List<REPORT.Params.ParamsVo> _params = new List<REPORT.Params.ParamsVo>();

                foreach (REPORT.Table.TableVo table in this.RecTABLESvo)
                    foreach (REPORT.Params.ParamsVo parm in table.PARAMS)
                        _params.Add(parm);

                return _params;
            }
        }
        #endregion

        public  List<Table>  RELATEDTABLES  
        {
            /*
            get
            {
                List<string> tabelas = new List<string>();

                if (this.MAIN != null)
                    if (!string.IsNullOrEmpty(this.MAIN.TABELA))
                        tabelas.Add(this.MAIN.TABELA);

                if (this.Parent != null)
                    if (this.Parent.GetType().Equals(typeof(Table)))
                        foreach (Table others in (this.Parent as Table).CHILDREN)
                            tabelas.Add(others.TABLE);

                if (tabelas.Count < 1)
                    tabelas.Add(this.TABLE);

                //return this.relatedTables; }
                return tabelas;
            }//*/
            get
            {
                List<Table> tables = new List<Table>();

                // ADD ESTA TABELA, pois esta propriedade retorna todas desse nivel pra baixo.
                tables.Add(this);

                foreach (Control c in linksPainel.Controls)
                {
                    if (c.GetType().Equals(typeof(Table)))
                    {
                        tables.Add((c as Table));
                    }
                }

                return tables;
            }
            //set { relatedTables = value; }
        } // TABELAS RELACIONADAS
        public  string        SHOWFIELDS     
        {
            get
            {
                return (this.CHILDREN.Count == 0) ? this.FIELDS.FIELDS : "";
            }
        } // MOSTRA CAMPOS CASO NAO SEJA RELACIONADO
        public  StringBuilder QUERY          
        {
            get
            {
                string  QryOrdem = ""; // tmp ordem
                
                //this.THISTABLE.ReSUFIXO();

                #region CREATING GENERIC QUERY.
                string tableKey = "@$TABLE$@";
                string sufixKey = this.TABLE+this.SUFIXO;

                StringBuilder genericQuery = new StringBuilder();

                bool havegroup = this.FIELDS.HAVEGROUP;

                StringBuilder childFields = new StringBuilder();
                StringBuilder childGroups = new StringBuilder();
                
                if(this.getFieldsFromTables(childFields, childGroups, this))
                    havegroup = true;

                string fromTable = tableKey.Replace("$TABLE$" , this.TABLE); //(string)new SXManager(empresa.CODIGO).getTabela(this.TABLE)["X2_ARQUIVO"];

                string agrupa    = "";

                this.FIELDS.generateShowFieldsAndGroupBy();
                string unionFields = this.FIELDS.FIELDSHEADERS;
                string campos      = this.FIELDS.FIELDS;
                agrupa = "";

                campos += childFields;
                if (havegroup) //childGroups.Length > 0 || this.FIELDS.HAVEGROUP)
                    agrupa += this.FIELDS.GROUPBY
                            + ((this.FIELDS.HAVEGROUP
                               && childGroups.Length > 0) ? "" : "")
                            + childGroups;

                genericQuery.AppendLine("SELECT DISTINCT '@EMPRESA@' EMPRESA, @FILIAL@ FILIAL, " + campos);
                genericQuery.AppendLine("  FROM " + fromTable + " AS " + sufixKey);
                genericQuery.AppendLine("@JOIN@");

                /// JOIN
                this.addJoinTables(genericQuery, this);

                genericQuery.AppendLine(" WHERE " + sufixKey + "." + "D_E_L_E_T_ = ' '");
                if (this.FILTERS.FILTERS.Length > 0)
                    genericQuery.AppendLine("   AND " + this.FILTERS.FILTERS);

                /// FILTRO DO PARAMETRO
                if (!string.IsNullOrEmpty(filtroParametro))
                    genericQuery.AppendLine("   AND "+filtroParametro);

                /// GROUP BY
                if (agrupa.Trim().Length > 0)
                {
                    genericQuery.AppendLine(" GROUP BY @FILGROUP@" + agrupa);
                    //genericQuery.AppendLine("  WITH ROLLUP ");
                }

                /// ORDER BY
                if (this.ORDERBY.ORDER.Length > 0)
                    QryOrdem = " ORDER BY " + this.ORDERBY.ORDER.Trim();//genericQuery.AppendLine(" ORDER BY " + this.ORDERBY.ORDER);

                #endregion // END GENERIC QUERY CONSTRUCT

                #region CONSTRUTOR DE QUERY ANTIGA
                /* 
                //int idx = 0;
                StringBuilder mainQuery = new StringBuilder();
                bool havegroup = this.FIELDS.HAVEGROUP;
                foreach(Table tab in this.CHILDREN)
                    if(tab.FIELDS.HAVEGROUP)
                        havegroup = true;

                /// VERIFICAR NECESSIDADE DE UNION
                if (sigaSession.EMPRESAS.Count > 1)
                    mainQuery.AppendLine("SELECT @FIELDS FROM(");

                //string fromTable = "";
                //string campos    = "";
                string agrupa      = "";
                string agrupaunion = "";
                bool   isFirst     = true;

                /// VARRENDO EMPRESAS PRA CRIAR UNION
                foreach (SigaObjects.Session.Empresa.EmpresaVo empresa in sigaSession.EMPRESAS)
                {
                    #region MONTANDO OS UNIONS
                    if (isFirst)
                        isFirst = false;
                    else
                        mainQuery.AppendLine(" UNION ");
                    #endregion FECHANDO O MOUNT DOS UNIONS

                    string        fromTable = (string)new SXManager(empresa.CODIGO).getTabela(this.TABLE)["X2_ARQUIVO"];
                    StringBuilder sQuery    = new StringBuilder();

                    this.FIELDS.generateShowFieldsAndGroupBy(empresa);
                    string unionFields = this.FIELDS.FIELDSHEADERS;
                    string campos      = this.FIELDS.FIELDS;
                    agrupa             = "";

                    //unionFields += 
                    //campos += this.FIELDS.FIELDS;

                    //if (this.FIELDS.HAVEGROUP)
                    //    agrupa = this.FIELDS.GROUPBY;

                    string unionChildFields = "";
                    string childFields      = "";
                    string childGroups      = "";
                    foreach (Table child in this.CHILDREN)
                    {
                        child.FIELDS.generateShowFieldsAndGroupBy(empresa);
                        string unionTempChild = child.FIELDS.FIELDSHEADERS;
                        string fchild = child.SHOWFIELDS;
                        string gchild = havegroup//(this.FIELDS.HAVEGROUP || child.FIELDS.HAVEGROUP)
                                        ? child.FIELDS.GROUPBY
                                        : "";

                        unionChildFields += (unionTempChild.Length > 0) ? ", " + unionTempChild : "";
                        childFields      += (fchild.Length         > 0) ? ", " + fchild         : "";
                        childGroups      += (gchild.Length         > 0) ? ", " + gchild         : "";
                    }
                    unionFields += unionChildFields;
                    campos      += childFields;
                    if (havegroup)//childGroups.Length > 0 || this.FIELDS.HAVEGROUP)
                        agrupa += this.FIELDS.GROUPBY
                                + ((this.FIELDS.HAVEGROUP
                                   && childGroups.Length > 0) ? "" : "")
                                + childGroups;
                    
                    agrupaunion = unionFields;
                    mainQuery   = mainQuery.Replace("@FIELDS", unionFields);
                    sQuery.AppendLine("SELECT " + campos   );
                    sQuery.AppendLine("  FROM " + fromTable);

                    foreach (Table child in this.CHILDREN)
                        if (child.SHOWFIELDS.Length > 0)
                            sQuery.AppendLine(child.JOIN);

                    sQuery.AppendLine(" WHERE " + fromTable + "." + "D_E_L_E_T_ = ' '");
                    if (this.FILTERS.FILTERS.Length > 0)
                        sQuery.AppendLine("   AND " + this.FILTERS.FILTERS);

                    mainQuery.AppendLine(sQuery.ToString());
                }

                /// VERIFICAR NECESSIDADE DE UNION
                if (sigaSession.EMPRESAS.Count > 1)
                {
                    mainQuery.AppendLine(") X");

                    if (agrupa.Trim().Length > 0)
                    {
                        mainQuery.AppendLine(" GROUP BY " + agrupaunion);
                        mainQuery.AppendLine("  WITH ROLLUP ");
                    }

                    if (this.ORDERBY.ORDER.Length > 0)
                        mainQuery.AppendLine(" ORDER BY " + this.ORDERBY.ORDER);
                }
                else /// CASO NAO TENHA UNION
                {
                    if (agrupa.Trim().Length > 0)
                    {
                        mainQuery.AppendLine(" GROUP BY " + agrupa);
                        mainQuery.AppendLine("  WITH ROLLUP ");
                    }

                    if (this.ORDERBY.ORDER.Length > 0)
                        mainQuery.AppendLine(" ORDER BY " + this.ORDERBY.ORDER);
                }
                */
                #endregion

                #region REPLACE NAS CHAVES PRA PEGAR OS NOMES DAS TABELAS DE ACORDO COM AS EMPRESAS.
                bool          isFirst = true;
                StringBuilder sQuery  = new StringBuilder();
                foreach (SigaObjects.Session.Empresa.EmpresaVo empresa in sigaSession.EMPRESAS)
                {
                    StringBuilder tempQuery = new StringBuilder(genericQuery.ToString()
                                                                .Replace("@EMPRESA@",empresa.NOME  ));

                    bool haveFil = new SXManager(empresa.CODIGO).getTabela(this.TABLE)["X2_MODO"].ToString() == "E";
                    if (haveFil)
                    {
                        tempQuery = tempQuery.Replace("@FILIAL@", "M0_FILIAL");
                        tempQuery = tempQuery.Replace("@JOIN@"  , "  LEFT JOIN SigaWeb..SIGAMAT \r\n" +
                                                                  "    ON M0_CODIGO = '" + empresa.CODIGO + "'      \r\n" +
                                                                  "   AND M0_CODFIL = " + this.TABLE + this.SUFIXO + "."
                                                                  + new SXManager(empresa.CODIGO).getFields(this.TABLE, "X3_CAMPO LIKE '%_FILIAL'", null).DefaultView[0]["X3_CAMPO"]);
                        tempQuery = tempQuery.Replace("@FILGROUP@", "M0_FILIAL, ");
                    }
                    else
                    {
                        tempQuery = tempQuery.Replace("@FILIAL@"  , "''");
                        tempQuery = tempQuery.Replace("@JOIN@"    , "");
                        tempQuery = tempQuery.Replace("@FILGROUP@", "");
                    }

                    replaceTableEmpresa(tempQuery, this.TABLE, empresa);

                    #region VERIFICA NECESSIDADE DE UNION
                    if (isFirst)
                        isFirst = false;
                    else
                        sQuery.AppendLine(" UNION");
                    #endregion

                    /// INICIA LOOP NAS TABELAS PRA SUBSTITUICAO.
                    replaceRecursiveTables(tempQuery, this, empresa);

                    sQuery.AppendLine(tempQuery.ToString().Trim());
                }
                #endregion
                
                sQuery.AppendLine(QryOrdem);
                
                return sQuery;
            }
        } // MONTA A QUERY A PARTIR DOS CONTROLES NA TELA.
        
        private void replaceRecursiveTables(StringBuilder inQuery, Table mainTB, SigaObjects.Session.Empresa.EmpresaVo empresa)
        {
            foreach (Table childTB in mainTB.CHILDREN)
            {
                replaceTableEmpresa(   inQuery, childTB.TABLE, empresa);
                replaceRecursiveTables(inQuery, childTB      , empresa);
            }
        }
        private void replaceTableEmpresa(   StringBuilder inQuery, string table, SigaObjects.Session.Empresa.EmpresaVo empresa)
        {
            inQuery = inQuery.Replace( "@"+table+"@"
                                     , new SXManager(empresa.CODIGO).getTabela(table)["X2_ARQUIVO"].ToString());
        }
        private void addJoinTables(         StringBuilder inQuery, Table mainTable)
        {
            foreach (Table child in mainTable.CHILDREN)
            {
                //if (child.SHOWFIELDS.Length > 0)
                inQuery.AppendLine(child.JOIN.Trim());
                this.addJoinTables(inQuery, child);
            }
        }
        private bool getFieldsFromTables(   StringBuilder childFields, StringBuilder childGroups, Table mainTable)
        {
            bool bHave = false;

            foreach (Table child in mainTable.CHILDREN)
            {
                child.FIELDS.generateShowFieldsAndGroupBy();
                if (child.FIELDS.HAVEGROUP)
                    bHave = true;

                string fchild = child.FIELDS.FIELDS;
                string gchild = bHave //(this.FIELDS.HAVEGROUP || child.FIELDS.HAVEGROUP)
                                ? child.FIELDS.GROUPBY
                                : "";

                childFields.AppendLine( (fchild.Length > 0) ? ", " + fchild : "" );
                childGroups.AppendLine( (gchild.Length > 0) ? ", " + gchild : "" );

                bool _bHave = this.getFieldsFromTables(childFields, childGroups, child);
                
                if(_bHave)
                    bHave = _bHave;
            }

            return bHave;
        }
        #endregion

        #region CONSTRUTOR
        private void initializer(REPORT.Report.ReportVo report, Table main, string table)
        {
            InitializeComponent();
            
            this.MAINREPORT = report;
            //if(this.MAINREPORT!=null)
            //    this.REPORTID   = this.MAINREPORT.ID;

            this.main       = main;
            this.TABLE      = table;

            /// LIMPANDO AS ABAS
            this.tpFieldsReturn.Controls.Clear();
            this.linksPainel.Controls.Clear();
            this.tpGourp.Controls.Clear();
            this.tpFilter.Controls.Clear();
            this.tpOrder.Controls.Clear();
            this.tpParms.Controls.Clear();

            /// INICIALIZANDO OBJETOS
            //this.CHILDREN = new List<Table>();
            this.FIELDS   = new Fields( this);
            this.FILTERS  = new Filters(this);
            this.ORDERBY  = new OrderBy(this);
            this.PARAMS   = new Params( this);

            /// ADCIONANDO OBJETOS NAS ABAS
            FormatScreen.AddControl(tpFieldsReturn, this.FIELDS);
            //FormatScreen.AddControl(tpGourp       , this.GROUPBY);
            FormatScreen.AddControl(tpFilter, this.FILTERS);
            FormatScreen.AddControl(tpOrder , this.ORDERBY);
            FormatScreen.AddControl(tpParms , this.PARAMS);

            DataTable dtRelType = new DataTable();
            string typeDisplay  = "display";
            string typeValue    = "value"  ;
            cbRelatedType.DisplayMember = typeDisplay;
            cbRelatedType.ValueMember   = typeValue  ;
            dtRelType.Columns.Add(typeDisplay);
            dtRelType.Columns.Add(typeValue  );
            dtRelType.Rows.Add("AMBAS AS TABELAS      ", " INNER JOIN ");
            dtRelType.Rows.Add("SOMENTE NA RELACIONADA", "  LEFT JOIN ");
            dtRelType.Rows.Add("SOMENTE NESTA         ", " RIGHT JOIN ");
            cbRelatedType.DataSource = dtRelType.DefaultView;

            /*
            cbRelatedTable.DisplayMember = SXManager.TableDisplayMember;
            cbRelatedTable.ValueMember   = SXManager.TableValueMember;
            //*/

            // -------------------------------
            dataRelatedTable = new DataTable();
            dataRelatedTable.Columns.Add("display");
            dataRelatedTable.Columns.Add("value");
            cbRelatedTable.DisplayMember = "display";
            cbRelatedTable.ValueMember   = "value";
            cbRelatedTable.DataSource = dataRelatedTable.DefaultView;
        }
        
        public Table(REPORT.Report.ReportVo report)              
        {
            this.initializer(report, null, null);
        }
        public Table(REPORT.Report.ReportVo report, string table)
        {
            this.initializer(report, null, table);
        }
        public Table(Table   main)                
        {
            this.initializer(new REPORT.Report.ReportVo(), main, null);
        }
        public Table(Table   main  , string table)
        {
            this.initializer(new REPORT.Report.ReportVo(), main, table);
        }
        public Table(REPORT.Report.ReportVo report, Table main)              
        {
            this.initializer(report, main, null);
        }
        public Table(REPORT.Report.ReportVo report, Table main, string table)
        {
            this.initializer(report, main, table);
        }
        #endregion

        #region SAVE E LOAD
        /// <summary>
        /// NEW SAVE METHOD
        /// </summary>
        public  void SAVE()
        {
            //this.DELETE();
            this.THISTABLE.ID = 0;
            this.THISTABLE.IDREPORT     = this.REPORTID;
            this.THISTABLE.MAINID       = this.MAINID;

            if (tpLINKIN.Visible)
            {
                this.THISTABLE.RELATEDTABLE = (string)cbRelatedTable.SelectedValue;
                this.THISTABLE.RELATEDTYPE  = (string)cbRelatedType.SelectedValue;
            }
            else
            {
                this.THISTABLE.RELATEDTABLE = "";
                this.THISTABLE.RELATEDTYPE  = "";
            }

            new REPORT.Table.TableDao().save(this.THISTABLE);
            
            this.FIELDS.SAVE();
            //this.ORDERBY.SAVE();
            this.FILTERS.SAVE();
            this.ORDERBY.SAVE();
            this.PARAMS.SAVE();

            foreach(Table child in this.CHILDREN)
                child.SAVE();
        }
        /// <summary>
        /// NEW LOAD METHOD
        /// </summary>
        /// <param name="tablevo"></param>
        public void LOAD(REPORT.Table.TableVo tablevo)
        {
            //if(this.MAIN!=null)
            //    this.MAIN.CHILDREN.Add(tablevo);

            this.THISTABLE = tablevo;
            this.TABLE     = tablevo.TABELA;

            //*
            new REPORT.Fields.FieldsDao().load(  this.THISTABLE.FIELDS , this.ID);
            //new REPORT.GroupBy.GroupByDao().load(this.THISTABLE.GROUPBY, this.ID);
            new REPORT.Filters.FiltersDao().Load(this.THISTABLE.FILTERS, this.ID);
            new REPORT.OrderBy.OrderByDao().load(this.THISTABLE.ORDERBY, this.ID);
            new REPORT.Params.ParamsDao().Load(  this.THISTABLE.PARAMS , this.ID);
            //*/

            //*
            this.FIELDS.LOAD(this.THISTABLE.FIELDS);
            //this.GROUPBY.LOAD();
            this.FILTERS.LOAD();
            this.ORDERBY.LOAD();
            this.PARAMS.LOAD( );
            //*/
            if (this.ID != 0)
            {
                this.TABLE = this.THISTABLE.TABELA;
                //this.RELATEDTABLES.Clear();
                //this.RELATEDTABLES.Add(this.TABLE);

                #region TABELAS FILHO
                //*
                //List<REPORT.Table.TableVo> childrenTable = new List<REPORT.Table.TableVo>();
                new REPORT.Table.TableDao().load(this.THISTABLE.CHILDREN, this.REPORTID, this.ID);
                //*/
                this.AddChildrenTable(this.THISTABLE.CHILDREN);
                #endregion
            }

            this.TOTALIZAR.Visible = this.MAIN != null;
            //this.ReloadRelatedTables();

            for(int idx=0; idx<this.THISTABLE.CHILDREN.Count; idx++)
            {
                this.CHILDREN[idx].LOAD(this.THISTABLE.CHILDREN[idx]);
            }
            //this.RELOAD();
        }
        #region SAVE E LOAD antigo (comantado)
        /*
        public  void SAVE()
        {
            //this.DELETE();
            this.THISTABLE.ID = 0;
            this.THISTABLE.IDREPORT     = this.REPORTID;
            this.THISTABLE.MAINID       = this.MAINID;

            if (tpLINKIN.Visible)
            {
                this.THISTABLE.RELATEDTABLE = (string)cbRelatedTable.SelectedValue;
                this.THISTABLE.RELATEDTYPE  = (string)cbRelatedType.SelectedValue;
            }
            else
            {
                this.THISTABLE.RELATEDTABLE = "";
                this.THISTABLE.RELATEDTYPE  = "";
            }

            new REPORT.Table.TableDao().save(this.THISTABLE);
            
            this.FIELDS.SAVE();
            this.FILTERS.SAVE();
            this.ORDERBY.SAVE();
            this.PARAMS.SAVE();

            foreach(Table child in this.CHILDREN)
                child.SAVE();
        }
        public  void LOAD(REPORT.Table.TableVo tablevo)
        {
            this.THISTABLE = tablevo;
            //this.TABLE              = tableName;
            //this.RELATEDTABLES      = new List<string>();
            //this.RELATEDTABLES.Add(this.TABLE);
            
            //new REPORT.Table.TableDao().load(this.THISTABLE, this.REPORTID, this.MAINID);
            //this.THISTABLE.ID = this.THISTABLE.ID;
            
            this.FIELDS.LOAD();
            this.FILTERS.LOAD();
            //this.GROUPBY.LOAD();
            this.ORDERBY.LOAD();
            this.PARAMS.LOAD();

            if (this.ID != 0)
            {
                this.TABLE = this.THISTABLE.TABELA;
                this.RELATEDTABLES.Clear();
                this.RELATEDTABLES.Add(this.TABLE);

                #region TABELAS FILHO
                List<REPORT.Table.TableVo> childrenTable = new List<REPORT.Table.TableVo>();
                new REPORT.Table.TableDao().load( childrenTable, this.REPORTID, this.ID);
                this.AddChildrenTable(childrenTable);
                #endregion
            }

            this.TOTALIZAR.Visible = this.MAIN != null;
            //this.ReloadRelatedTables();

            this.RELOAD();
        }
        //*/
        #endregion
        public List<string> getTables()
        {
            List<string> strTables = new List<string>();

            if( this.MAIN != null)
                foreach(REPORT.Table.TableVo tab in this.MAIN.getTables())//this.RELATEDTABLES)
                    strTables.Add(tab.TABELA);

            return strTables;
        }
        public void RELOAD()
        {
            this.ReLoadVO();
            foreach ( Table child in this.linksPainel.Controls)
            {
                child.RELOAD(); //.ReLoadVO();
            }
        }
        public  void ReLoadVO()
        {
            new REPORT.Table.TableDao().load(this.THISTABLE,this.THISTABLE.IDREPORT,this.THISTABLE.MAINID);

            string ident      = this.RELATEDIDENT;
            
            if(this.RELATED != null)
                this.cbRelatedTable.SelectedValue = this.RELATED.INDEX+"|"+this.RELATEDIDENT; //this.RELATEDTABLE;
            
            this.RELATEDIDENT = ident;
        }
        public  void LOADJOINS(List<string> relatedtables)
        {
            DataTable dtRelTable = new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                                       //.getParentTables(relatedtables, "SX9.X9_CDOM = '" + this.TABLE + "'");
                                       //.getChildTables( relatedtables, "SX9.X9_CDOM = '" + this.TABLE + "'");
                                       .getComboChildTables(relatedtables, "SX9.X9_DOM = '" + this.TABLE + "'");
                                       //.getRelatedTables(relatedtables, "SX9.X9_CDOM = '" + this.TABLE + "'");

            object oIdx = cbRelatedTable.SelectedItem;
            
            this.popRelatedtables(dtRelTable);
            
            //cbRelatedTable.DataSource = dtRelTable.DefaultView;
            if (cbRelatedTable.Items.Contains(oIdx))
                cbRelatedTable.SelectedItem = oIdx;
        }
        public  void ReloadRelatedTables()
        {
            foreach (Table child in this.CHILDREN)
                child.LOADJOINS(child.getTables());
        }
        public  void DELETE()  
        {
            this.FIELDS.DELETE();
            this.FILTERS.DELETE();
            this.ORDERBY.DELETE();
            this.PARAMS.DELETE();
            foreach(Table child in this.CHILDREN)
                child.DELETE();

            new REPORT.Table.TableDao().delete(this.REPORTID, this.MAINID);
            this.ID = 0;
        }
        public  void ChangeRootTable(bool isRootTable)
        {
            this.IsRootTable = isRootTable;

            if (this.IsRootTable)
            {
                tpLINKIN.Visible = false;
                this.Dock = DockStyle.Fill;
            }
        }
        #endregion
        
        #region METHODS
        public void AddChildrenTable(List<REPORT.Table.TableVo> childrenTable)
        {
            foreach (REPORT.Table.TableVo childTable in childrenTable)
            {
                /*
                Table child = new Table(this.MAINREPORT, this.THISTABLE);
                //child.MAIN  = childTable;
                child.LOAD(childTable);
                this.AddChildTable(child);//*/
                this.AddChildTable(childTable);
            }
        }
        public void AddChildTable(REPORT.Table.TableVo childvo)
        {
            Table child = new Table(this.MAINREPORT, this);
            child.LOAD(childvo);
            this.AddChildTable(child);
        }
        public void AddChildTable(Table child)
        {
            this.CHILDREN.Add(child);
            //this.RELATEDTABLES.Add(child.TABLE);
            FormatScreen.AddControl(linksPainel, child, true, 3, false, false);
            //foreach(Table tab in this.CHILDREN)
            //    tab.popRelatedtables(dataRelatedChild);
        }

        public void popRelatedtables(DataTable dados)
        {
            dataRelatedTable.Rows.Clear();

            foreach(REPORT.Table.TableVo tab in this.MAIN.getTables())
                foreach(DataRow row in dados.Rows)
                {
                    string tabnome = row["X2_CHAVE"].ToString(); 
                    if(tab.TABELA == tabnome)
                    {
                        int idx = this.MAIN.getTables().IndexOf(tab); //.main.RELATEDTABLES.IndexOf(tab);
                        dataRelatedTable.Rows.Add( idx+" - "+(string)row["X2_NOME"] +" - "+(string)row["X9_IDENT"]
                                                 , idx+"|"/*+(string)row["X2_CHAVE"]+"|"//*/  +(string)row["X9_IDENT"]);
                        // TODO: incluir validação e informação na relação de tabelas.
                    }
                }
        }
        #endregion

        #region EVENTOS
        private void tpJoin_ControlAdded(  object sender, ControlEventArgs e)
        {
        }
        private void tpJoin_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.CHILDREN.Remove((sender as Table));
        }

        private void tpJoin_Resize(object sender, EventArgs e)
        {
        }

        private void btnCloseThis_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnAddTable_Click( object sender, EventArgs e)
        {
            // listas de controles e objetos para o grid.
            List<Control> toControls      = new List<Control>();
            List<object>  oCollumnsReturn = new List<object>();

            Label     strTable = new Label();
            Label     strIdent = new Label();
            DataTable dados    = new DataTable();

            string    filtro   = txtFilterTables.Text.Trim();

            filtro = (filtro == "filtro") ? "" : filtro;

            dados = new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                //.getChildTables(this.RELATEDTABLES, "SX9.X9_DOM = '" + this.TABLE + "' AND X2_NOME LIKE '%"+filtro+"%'");
                        .getParentTables(getTables(), "X2_NOME LIKE '%" + filtro + "%'");
            //.getRelatedTables(this.RELATEDTABLES, "X2_NOME LIKE '%" + filtro + "%'");

            // inicializar com dados desejados as listas.
            toControls.Add(     strTable  );
            oCollumnsReturn.Add("X2_CHAVE");

            toControls.Add(     strIdent  );
            oCollumnsReturn.Add("X9_IDENT");

            Form frm = new Form();
            frm.Text = (this.relatedTables.Count > 0) ? "TABELAS RELACIONADAS" : "TODAS AS TABELAS";
            frm.Controls.Add(new gridWindow( dados
                                           , toControls
                                           , oCollumnsReturn ));
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            strTable.TextChanged += new EventHandler(strTable_TextChanged);
            strIdent.TextChanged += new EventHandler(strIdent_TextChanged);
        }
        protected void strTable_TextChanged(object sender, EventArgs e)
        {
            //Table child = new Table(this.THISTABLE);
            //child.REPORTID = this.REPORTID;
            REPORT.Table.TableVo cTable = new REPORT.Table.TableVo();
            new REPORT.Table.TableDao().load(cTable, this.REPORTID, this.ID);
            cTable.MAINID   = this.THISTABLE.ID;
            cTable.IDREPORT = this.REPORTID;
            cTable.TABELA   = (sender as Control).Text;

            // child.LOAD(cTable);
            
            this.AddChildTable(cTable);
        }
        protected void strIdent_TextChanged(object sender, EventArgs e)
        {
            //this.RELATEDIDENT = (sender as Control).Text;
            CHILDREN[CHILDREN.Count-1].RELATEDIDENT = (sender as Control).Text;
            MessageBox.Show(this.RELATEDIDENT);
        }
        #endregion

        private void linksPainel_AjustControls()
        {
            List<Control> controls = new List<Control>();
            foreach (Control c in linksPainel.Controls)
            {
                controls.Add(c);
                //(c as Table).THISTABLE.INDEX = linksPainel.Controls.IndexOf(c);
            }

            FormatScreen.Ajust2EqualsWidthControls(controls.ToArray(), linksPainel.Width, false);
        }
        private void linksPainel_ControlAdded(  object sender, ControlEventArgs e)
        {
            if ((e.Control as Table).THISTABLE.INDEX < 0)
                this.THISTABLE.CHILDREN.Add((e.Control as Table).THISTABLE);

            this.linksPainel_AjustControls();
            this.ReloadRelatedTables();
        }

        private void linksPainel_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.THISTABLE.CHILDREN.Remove((e.Control as Table).THISTABLE);

            this.linksPainel_AjustControls();
            this.ReloadRelatedTables();
        }

        private void linksPainel_Resize(        object sender, EventArgs e)
        {
            this.linksPainel_AjustControls();
        }

        private void cbRelatedTable_TextChanged(object sender, EventArgs e)
        {
            if ( cbRelatedTable.SelectedIndex>=0
              && cbRelatedTable.SelectedValue != null
              && this.MAINREPORT.LOADED )
            {
                /// TODO: corrigir relacionamento.
                //this.RELATED.TABELA = cbRelatedTable.SelectedValue.ToString();
                string[] strValue = cbRelatedTable.SelectedValue.ToString().Split('|');
                int      idx      = int.Parse((string)strValue.GetValue(0));
                this.RELATED      = this.main.RELATEDTABLES[idx].THISTABLE;
                this.RELATEDIDENT = (string)strValue.GetValue(1);
            }
        }

        private void cbRelatedType_TextChanged( object sender, EventArgs e)
        {
            if(this.MAINREPORT.LOADED)
                this.RELATEDTYPE = (string)cbRelatedType.SelectedValue;
        }

        private void cbRelatedTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != null && this.MAINREPORT.LOADED)
            {
                ComboBox cb = (sender as ComboBox);
                if (cb.SelectedIndex >= 0 && cb != null)
                {
                    /*
                    DataRowView row = (DataRowView)cb.SelectedItem;
                    
                    this.RELATEDTABLE = (string)row["X2_CHAVE"]; //cb.SelectedValue.ToString();
                    this.RELATEDIDENT = (string)row["X9_IDENT"];
                    //*/
                    string[] values = cb.SelectedValue.ToString().Split('|');

                    int idx = int.Parse((string)values.GetValue(0));

                    this.RELATED = this.main.RELATEDTABLES[idx].THISTABLE;

                    //this.RELATED.TABELA = table.TABELA;
                    this.RELATEDIDENT = (string)values.GetValue(1);
                }
            }
        }
        private void cbRelatedType_SelectedIndexChanged( object sender, EventArgs e)
        {
            if (sender != null && this.MAINREPORT.LOADED)
            {
                ComboBox cb = (sender as ComboBox);
                if (cb.SelectedIndex >= 0)
                {
                    this.RELATEDTYPE = cb.SelectedValue.ToString();
                }
            }
        }
    }
}