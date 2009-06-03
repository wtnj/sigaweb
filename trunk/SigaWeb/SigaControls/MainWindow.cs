#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SigaControls
{
    public partial class MainWindow : UserControl
    {
        private Control _caller = new Control();

        public Control oCaller
        {
            get { return _caller; }
            set { _caller = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}