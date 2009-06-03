#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SigaControls;

#endregion

namespace SigaWeb
{
    public partial class FormTeste : Form
    {
        public FormTeste()
        {
            InitializeComponent();
            this.Form.Controls.Add(new Permissoes());
        }
    }
}