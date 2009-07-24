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
    public partial class Params : UserControl
    {
        private DataTable dados;
        private Table main;// = new Table();
        public  Table MAIN
        {
            get { return main; }
            set { main = value; }
        }

        #region CONSTRUTORES e initialize
        public  Params() : this(null)
        {
            //this.initialize(null);
        }
        public  Params(Table main)
        {
            this.initialize(main);
        }

        private void initialize(Table main)
        {
            InitializeComponent();

            cmbCampos.DisplayMember = SXManager.FieldDisplayMember;
            cmbCampos.ValueMember   = SXManager.FieldValueMember;

            cmbTabela.DisplayMember = SXManager.TableDisplayMember;
            cmbTabela.ValueMember   = SXManager.TableValueMember;

            lbCampos.DisplayMember  = REPORT.Params.ParamsDao.DisplayMember;
            lbCampos.ValueMember    = REPORT.Params.ParamsDao.ValueMember;

            this.MAIN = main;
            this.Dock = DockStyle.Fill;
        }
        #endregion

        #region SAVE LOAD E DELETE
        public void LOAD()  
        {
             if (this.MAIN != null)
            {
                /// CARREGAR TABELAS RELACIONADAS.
                cmbTabela.DataSource = 
                    new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                    .getTables("X2_CHAVE IN (" + SXManager.getStringArr(this.MAIN.getTables()) + ")")
                    .DefaultView;

                 cmbCampos.DataSource = 
                     new SXManager(sigaSession.EMPRESAS[0].CODIGO)
                     .getFields(this.MAIN.TABLE).DefaultView;

                /// CARREGAR CONFIGURACAO DE FILDS DO BANCO
                dados = new REPORT.Params.ParamsDao().select(this.MAIN.ID);
                lbCampos.DataSource = dados.DefaultView;
            }
        }
        public void SAVE()  
        {
            /*
            this.DELETE();

            List<REPORT.Params.ParamsVo> paramets = new List<REPORT.Params.ParamsVo>();

            for (int i = 0; i < lbCampos.Items.Count; i++)
            {
                REPORT.Params.ParamsVo param = new REPORT.Params.ParamsVo();

                param.MAINID  = this.MAIN.ID;
                param.TABELA  = this.main.TABLE;

                DataRowView valor = (lbCampos.Items[i] as DataRowView);

                param.FORMATO = valor[REPORT.Params.ParamsDao.ValueMember  ].ToString();
                param.CAMPO   = valor[REPORT.Params.ParamsDao.DisplayMember].ToString();
                param.OBJETO  = valor["objeto" ].ToString();
                //param.TAMANHO = int.Parse(valor["tamanho"].ToString());
                
                paramets.Add(param);
            }
            //*/
            new REPORT.Params.ParamsDao().save(this.MAIN.THISTABLE.PARAMS);
        }
        public void DELETE()
        {
            new REPORT.Params.ParamsDao().delete(this.MAIN.ID);
        }
        #endregion

        private void btnAdd_Click(  object sender   , EventArgs e         )
        {
            if (cmbCampos.SelectedIndex >= 0)
            {
                DataRowView row  = (DataRowView)cmbCampos.SelectedItem;

                string      tipo = row["X3_TIPO"   ].ToString().ToUpper();
                string      len  = row["X3_TAMANHO"].ToString();
                string      obj  = FormatScreen.getObjectFromSigaType(tipo).GetType().ToString();

                REPORT.Params.ParamsVo parm = new REPORT.Params.ParamsVo();
                parm.MAINID  = this.MAIN.ID;
                parm.TAMANHO = int.Parse(len);
                parm.TABELA  = this.MAIN.TABLE;
                parm.CAMPO   = this.cmbCampos.SelectedValue.ToString();
                parm.FORMATO = tipo;
                parm.OBJETO  = obj;
                this.MAIN.THISTABLE.PARAMS.Add(parm);

                dados.Rows.Add( 0               //id
                              , this.MAIN.ID    //id da ligação
                              , len             //tamanho de digitação
                              , this.MAIN.TABLE //nome da tabela
                              , this.cmbCampos.SelectedValue.ToString() //campo
                              , tipo            //formato
                              , obj             //objeto
                              );
            }
        }

        private void lbCampos_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Delete)
            {
                ListBox     list = (ListBox    )objSender;
                DataRowView row  = (DataRowView)list.SelectedItem;

                //int idx = find((string)row[""]);
                //if (idx >= 0)
                //    this.MAIN.THISTABLE.PARAMS.RemoveAt(idx);
                this.MAIN.THISTABLE.PARAMS.RemoveAt((objSender as ListBox).SelectedIndex);
                
                row.Delete();
            }
        }

        private int find(string campo)
        {
            int idx = 0;
            foreach (REPORT.Params.ParamsVo parms in this.MAIN.THISTABLE.PARAMS)
            {
                if (parms.CAMPO == campo)
                    return idx;
                idx++;
            }

            return -1;
        }
    }
}