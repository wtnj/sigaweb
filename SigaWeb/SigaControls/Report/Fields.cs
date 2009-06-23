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
    public partial class Fields : UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private List<string> showFields    = new List<string>();
        private List<string> fieldsheaders = new List<string>();
        private List<string> fieldsname    = new List<string>();
        private List<string> fieldsunion   = new List<string>();
        private List<string> groupFields   = new List<string>();
        private bool         haveGroup     = false;
        private DataTable    comboGrouping = new DataTable();
        private Table  main;
        public  Table  MAIN         
        {
            get { return main; }
            set { this.main = value; }
        }
        public  bool   HAVEGROUP    
        {
            get
            {
                /*
                bool childGroup = false;
                foreach(Table child in this.MAIN.CHILDREN)
                    if(child.FIELDS.haveGroup)
                        childGroup=true;
                */
                return this.haveGroup;// && childGroup;
            }
        }
        public  string FIELDS       
        {
            get
            {
                StringBuilder sRet = new StringBuilder();

                foreach(string str in this.showFields)
                    sRet.Append(", " + str);
                
                if(sRet.ToString().Length>0)
                    sRet = new StringBuilder(sRet.ToString().Substring(1).Trim());

                return sRet.ToString();
            }
        }
        public  string FIELDSNAME   
        {
            get
            {
                StringBuilder sRet = new StringBuilder();

                foreach (string str in this.fieldsname)
                    sRet.Append(", " + str);

                if (sRet.Length > 0)
                    sRet = new StringBuilder(sRet.ToString().Substring(1).ToString().Trim());

                return sRet.ToString();
            }
        }
        public  string FIELDSHEADERS
        {
            get
            {
                StringBuilder sRet = new StringBuilder();

                foreach (string str in this.fieldsheaders)
                    sRet.Append(", " + str);

                if (sRet.Length > 0)
                    sRet = new StringBuilder(sRet.ToString().Substring(1).ToString().Trim());

                return sRet.ToString();
            }
        }
        public  string FIELDSUNION  
        {
            get
            {
                StringBuilder sRet = new StringBuilder();

                foreach (string str in this.fieldsunion)
                    sRet.Append(", " + str);

                if (sRet.Length > 0)
                    sRet = new StringBuilder(sRet.ToString().Substring(1).ToString().Trim());

                return sRet.ToString();
            }
        }
        public  string GROUPBY      
        {
            get
            {
                StringBuilder sRet = new StringBuilder();
                foreach(string str in groupFields)
                    sRet.Append(", "+str);
                
                if(sRet.ToString().Length>0)
                    sRet = new StringBuilder(sRet.ToString().Substring(1).Trim());

                return sRet.ToString();
            }
        }
        private string getDisplayCombo(string value) 
        {
            string sRet = "";
            
            foreach(DataRow dr in comboGrouping.Rows)
                if(dr["functCode"].ToString() == value)
                    sRet = dr["functName"].ToString();

            return sRet;
        }
        private string getValueCombo(string display) 
        {
            string sRet = "";
            
            foreach(DataRow dr in comboGrouping.Rows)
                if(dr["functName"].ToString() == display)
                    sRet = dr["functCode"].ToString();

            return sRet;
        }
        public  void   generateShowFieldsAndGroupBy()
        {
            this.generateShowFieldsAndGroupBy(sigaSession.EMPRESAS[0]);
            /*
            this.showFields    = new List<string>();
            this.fieldsname    = new List<string>();
            this.fieldsheaders = new List<string>();
            this.fieldsunion   = new List<string>(); // AGRUPAMENTO DO UNION
            this.groupFields   = new List<string>();

            foreach (DataGridViewRow drw in dgvFields.Rows)
                if ((drw.Cells[0] as DataGridViewCheckBoxCell).Value.ToString() == true.ToString())
                {
                    string show     = "*";
                    string tableKey = "@$TABLE$@";
                    
                    show = drw.Cells[3].Value.ToString();
                    
                    string field = tableKey.Replace("$TABLE$",this.MAIN.TABLE) //new SXManager(empresa.CODIGO).getTabela(this.MAIN.TABLE)["X2_ARQUIVO"].ToString()
                                 + "."
                                 + (string)drw.Cells[1].Value;

                    if (show == "*" || show == null || show == "")
                    {
                        this.groupFields.Add(field);
                        this.fieldsunion.Add((string)drw.Cells[2].Value);
                        show = "*";
                    }
                    else
                        this.haveGroup = true;

                    this.fieldsname.Add(field);
                    this.fieldsheaders.Add((string)drw.Cells[2].Value);

                    string filtro   = SXManager.FieldValueMember
                                + " = '" + (string)drw.Cells[1].Value + "'";
                    
                    if (new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                                   .getFields( this.MAIN.TABLE
                                   , filtro
                                   , SXManager.FieldDisplayMember).DefaultView[0]["X3_TIPO"].ToString() == "D")
                    {
                        showFields.Add( "CASE WHEN "+field+" = '' THEN '' ELSE CONVERT(NVARCHAR(10),CAST("+field+" AS SMALLDATETIME),103) END"
                                      + " [ "
                                      + (string)drw.Cells[2].Value
                                      + " ] ");
                    }
                    else
                        showFields.Add( show.Replace("*", field)
                                  + " [ "
                                  + (string)drw.Cells[4].Value
                                  + " "
                                  + (string)drw.Cells[2].Value
                                  + " ]");
                }//*/
        }
        public  void   generateShowFieldsAndGroupBy(SigaObjects.Session.Empresa.EmpresaVo empresa)
        {
            this.showFields    = new List<string>();
            this.fieldsname    = new List<string>();
            this.fieldsheaders = new List<string>();
            this.fieldsunion   = new List<string>(); // AGRUPAMENTO DO UNION
            this.groupFields   = new List<string>();

            foreach (DataGridViewRow drw in dgvFields.Rows)
                if ((drw.Cells[0] as DataGridViewCheckBoxCell).Value.ToString() == true.ToString())
                {
                    string show  = "*";
                    
                    show = drw.Cells[3].Value.ToString();
                    
                    string field = new SXManager(empresa.CODIGO).getTabela(this.MAIN.TABLE)["X2_ARQUIVO"].ToString()
                                 + "."
                                 + (string)drw.Cells[1].Value;

                    if (show == "*" || show == null || show == "")
                    {
                        this.groupFields.Add(field);
                        this.fieldsunion.Add((string)drw.Cells[2].Value);
                        show = "*";
                    }
                    else
                        this.haveGroup = true;

                    this.fieldsname.Add(field);
                    this.fieldsheaders.Add((string)drw.Cells[2].Value);

                    string filtro   = SXManager.FieldValueMember
                                + " = '" + (string)drw.Cells[1].Value + "'";
                    
                    if (new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                                   .getFields( this.MAIN.TABLE
                                   , filtro
                                   , SXManager.FieldDisplayMember).DefaultView[0]["X3_TIPO"].ToString() == "D")
                    {
                        showFields.Add( "CONVERT(VARCHAR(12),CONVERT(DATETIME,"+field+",103),103)"
                                      + " [ "
                                      + (string)drw.Cells[2].Value
                                      + " ] ");
                    }
                    else
                        showFields.Add(show.Replace("*", field)
                                      + " [ "
                                      + (string)drw.Cells[4].Value
                                      + " "
                                      + (string)drw.Cells[2].Value
                                      + " ]");
                }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private void initialize(Table main)
        {
            InitializeComponent();

            this.MAIN = main;
            this.Dock = DockStyle.Fill;

            comboGrouping.Columns.Add("functCode");
            comboGrouping.Columns.Add("functName");
            comboGrouping.Rows.Add("*"       ,""     );
            comboGrouping.Rows.Add("SUM(*)"  ,"SOMAR");
            comboGrouping.Rows.Add("AVG(*)"  ,"MEDIA");
            comboGrouping.Rows.Add("MAX(*)"  ,"MAXIMO");
            comboGrouping.Rows.Add("MIN(*)"  ,"MINIMO");
            comboGrouping.Rows.Add("COUNT(*)","CONTAR");
            //(dgvFields.Columns[1] as DataGridViewTextBoxColumn)//.DisplayMember = SXManager.FieldDisplayMember;
            //cblFIELDS.ValueMember   = SXManager.FieldValueMember;
        }
        public Fields()          
        {
            initialize(null);
        }
        public Fields(Table main)
        {
            initialize(main);
        }
        
        #region SAVE E LOAD
        private REPORT.Fields.FieldsVo existInFields(List<REPORT.Fields.FieldsVo> fields, string findField)
        {
            foreach(REPORT.Fields.FieldsVo field in fields)
                if(field.CODIGO == findField)
                    return field;

            return null;
        }
        public void LOAD()
        {
            try
            {
                if (this.MAIN.TABLE != null)
                {
                    /// Verifica os campos selecionados na consulta anterior.
                    List<SigaObjects.Reports.Fields.FieldsVo> fields = new List<SigaObjects.Reports.Fields.FieldsVo>();
                    new REPORT.Fields.FieldsDao().load(fields, this.MAIN.ID);

                    // POPULA CAMPOS DA TABELA SELECIONADA
                    DataTable dtFields = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getFields(this.MAIN.TABLE);
                    foreach (DataRow drv in dtFields.Rows)
                    {
                        dgvFields.Rows.Add();
                        REPORT.Fields.FieldsVo field = this.existInFields(fields, drv[SXManager.FieldValueMember].ToString());
                        int  indice = dgvFields.Rows.Count - 1;
                        bool isMark = field != null;

                        dgvFields.Rows[indice].Cells[0].Value = isMark;
                        dgvFields.Rows[indice].Cells[1].Value = (string)drv[SXManager.FieldValueMember];
                        dgvFields.Rows[indice].Cells[2].Value = (string)drv[SXManager.FieldDisplayMember];
                        dgvFields.Rows[indice].Cells[3].Value = (isMark) ? field.GROUPING                  : "";
                        dgvFields.Rows[indice].Cells[4].Value = (isMark) ? getDisplayCombo(field.GROUPING) : "";
                    }
                }
            }
            catch (Exception e)
            {
                new ERROR(Carralero.ExceptionControler.getFullException(e)).SHOW();
            }
        }
        public void SAVE()
        {
            this.DELETE();

            List<REPORT.Fields.FieldsVo> fields = new List<REPORT.Fields.FieldsVo>();

            foreach (DataGridViewRow drv in dgvFields.Rows)
            {
                if (drv.Cells[0].Value.ToString() == true.ToString())
                {
                    REPORT.Fields.FieldsVo field = new REPORT.Fields.FieldsVo();

                    field.MAINID   = this.MAIN.ID;
                    field.CODIGO   = (string)drv.Cells[1].Value;
                    field.GROUPING = (string)drv.Cells[3].Value;

                    fields.Add(field);
                }
            }
            
            new REPORT.Fields.FieldsDao().save(fields);
        }
        public void DELETE()
        {
            new REPORT.Fields.FieldsDao().delete(this.MAIN.ID);
        }
        #endregion

        private void cbAllNone_CheckedChanged(object sender, EventArgs e)
        {
            this.checkField(cbAllNone.Checked);
        }
        public  void checkField(bool isCheck)
        { this.checkField(isCheck, null); }
        public  void checkField(bool isCheck, string field)
        {
            this.Enabled = false;
            try
            {
                foreach (DataGridViewRow drv in dgvFields.Rows)
                {
                    if (field != null)
                    {
                        if (drv.Cells[1].Value.ToString() == field)
                            drv.Cells[0].Value = isCheck;
                    }
                    else
                        drv.Cells[0].Value = isCheck;
                }
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }

        private void btnGrouping_Click(object sender, EventArgs e)
        {
            Control cRet = new Control();
            cRet.TextChanged += new EventHandler(cRet_TextChanged);
            new gridWindow(comboGrouping, cRet, "functCode").showWindow();
        }

        void cRet_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvFields.SelectedRows)
            {
                string strValue = (sender as Control).Text;
                string filtro   = SXManager.FieldValueMember
                                + " = '" + dr.Cells[1].Value + "'";
                DataTable dados = new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                         .getFields( this.MAIN.TABLE
                                   , filtro
                                   , SXManager.FieldDisplayMember);
                if ( dados.DefaultView[0]["X3_TIPO"].ToString() == "N" )
                {
                    dgvFields.Rows[dr.Index].Cells[3].Value = strValue;
                    dgvFields.Rows[dr.Index].Cells[4].Value = getDisplayCombo(strValue);
                }
                /*if (dados.DefaultView[0]["X3_TIPO"].ToString() == "D")
                {
                    dgvFields.Rows[dr.Index].Cells[3].Value = "CONVERT(VARCHAR(12),CONVERT(DATETIME,*,103),103)";
                    dgvFields.Rows[dr.Index].Cells[4].Value = "DATA";
                }
                //*/

                dgvFields.Rows[dr.Index].Cells[0].Value = true;
                // comboGrouping.Rows[0].RowState=DataRowState.Modified;
            }
        }

        private void marcarCampo(int row, int col)
        {
            if (dgvFields.Rows[row].Cells[0].Value.ToString() == "True")
            {
                /// Verifica se existe grupo
                /// se existir verifica o select do campo.
                string query = this.main.QUERY.ToString();
                int haveOrder = query.IndexOf("ORDER BY");

                string tab_camp = new SXManager(sigaSession.EMPRESAS[0].CODIGO).getTabela(this.main.TABLE)["X2_ARQUIVO"].ToString()
                                   + "."
                                   + dgvFields.Rows[row].Cells[1].Value.ToString();

                if (haveOrder > 0)
                {
                    int haveField = query.IndexOf(tab_camp, haveOrder);

                    if (haveField > 0)
                    {
                        this.main.SAVE();

                        REPORT.OrderBy.OrderByDao orders = new SigaObjects.Reports.OrderBy.OrderByDao();

                        tab_camp = " valuemember = '" + tab_camp + "'";
                        orders.delete(this.main.ID, tab_camp);

                        this.main.LOAD(this.main.TABLE);

                        MessageBox.Show("A Ordenação com este campo foi excluída. ");

                    }
                }
            }
        }
        private void dgvFields_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                marcarCampo(e.RowIndex, e.ColumnIndex);

            //marcarCampo(e.RowIndex, e.ColumnIndex);
            //dgvFields.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "erro...";

            /*
            int row = dgvFields.CurrentCell.RowIndex;
            Boolean isChecked = Convert.ToBoolean(dgvFields.Rows[row].Cells[0].Value);
            if (e.ColumnIndex == 0)
            {
                if (dgvFields.Rows[row].Cells[0].Value.ToString() == "True")
                {
                    /// Verifica se existe grupo
                    /// se existir verifica o select do campo.
                    string query = this.main.QUERY.ToString();
                    int haveOrder = query.IndexOf("ORDER BY");

                    string tab_camp = dgvFields.Rows[row].Cells[1].Value.ToString();

                    if (haveOrder > 0)
                    {
                        int haveField = query.IndexOf(tab_camp, haveOrder);

                        if (haveField > 0)
                        {
                            dgvFields.Rows[row].Cells[0].Selected = true;
                            isChecked = true;
                            //   dgvFields.Rows[row].Cells[0].Value = true;
                            MessageBox.Show("Existe Ordenação com este campo. ");

                        }
                        else
                        {
                            isChecked = false;
                            dgvFields.Rows[row].Cells[0].Selected = true;
                        }
                    }

                }
            }

            dgvFields.Rows[row].Cells[0].Value = isChecked;
        */
        }

        private void dgvFields_GotFocus(object sender, EventArgs e)
        {
            return;
        }      

     
    }
}