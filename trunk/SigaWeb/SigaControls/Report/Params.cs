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
#endregion

namespace SigaControls.Report
{
    public partial class Params : UserControl
    {
        private Table main;// = new Table();
        public  Table MAIN
        {
            get { return main; }
            set { main = value; }
        }

        public Params(Table main)
        {
            InitializeComponent();
            this.MAIN = main;
        }

        #region SAVE LOAD E DELETE
        public void LOAD()
        {
             // TODO <FAZER O LOAD DESTE CONTROLE>
        }
        public void SAVE()
        {
            // TODO <FAZER O SAVE DESTE CONTROLE>
        }
        public void DELETE()
        {
            new REPORT.Params.ParamsDao().delete(this.MAIN.ID);
        }
        #endregion
    }
}