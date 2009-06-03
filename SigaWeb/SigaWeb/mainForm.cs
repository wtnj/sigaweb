#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections;

#endregion

namespace SigaWeb
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        private AnchorStyles allSides = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
        private int iMargem = 5;

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Comentado 14:31 01-04-09
                this.Controls.Add(new SigaControls.Login());
                //this.Controls.Add(new SigaControls.Session.Grupo_usuarios(new DataGridView()));
                //this.Controls.Add(new SigaControls.Permissoes());
            } //new SigaControls.Logon(null, null, this); }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
            
            /*
            FormatScreen.Margem = iMargem;
            this.WindowState    = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            
            Panel p  = new Panel();
            p.Top    = iMargem;
            p.Left   = iMargem;
            p.Height = this.Height - 2 * iMargem;
            p.Width  = this.Width  - 2 * iMargem;
            p.Anchor = allSides;
            p.AutoSizeMode = AutoSizeMode.GrowOnly;
            
            p.BorderStyle  = BorderStyle.FixedSingle;
            FormatScreen.AddControl(this, p, true);

            int[] arrTBox = new int[20] { 010, 010, 040, 070, 070
                                        , 070, 070, 100, 100, 130
                                        , 160, 160, 160, 190, 190
                                        , 220, 220, 220, 220, 220 };

            ArrayList comp = new ArrayList();
            
            foreach(int iTop in arrTBox)
            {
                TextBox tbox   = new TextBox();
                tbox.Top       = iTop;
                tbox.AllowDrop = true;

                comp.Add(tbox);
                
                FormatScreen.AddControl(p, tbox, true);
            }

            Button btn = new Button();
            btn.Top    = 190;
            btn.Text   = "cilck";
            btn.AllowDrop = true;
            comp.Add(btn);
            FormatScreen.setDragTarget(p, comp);
            
            p.DragDrop += new DragEventHandler(dragDrop);
            btn.Click  += new EventHandler(btn_Click);
            
            FormatScreen.AddControl(p, btn);
            
            */
        }

        protected void addTab()
        { }

        protected void gerarExel()
        {
            /*Carralero.MSExcel excel = new Carralero.MSExcel(@"c:\teste.xls", "Planilha de Teste");

            excel.setCell(1, 1, "VALORES");
            excel.mergeRange("A1","B1");

            excel.setCell(1, 3, "TOTAL", true, true);
            excel.setCell(2, 1, 3 );
            excel.setCell(2, 2, 10);
            excel.setCell(2, 3, "=A2+B2", true, true);

            excel.Close();
             */
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            int lastTop = 0;
            StringBuilder sMsg = new StringBuilder();
            foreach (Control c in this.Controls[0].Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    string rn = "";
                    if (c.Top > lastTop)
                        rn = "\r\n";
                    sMsg.Append(rn + c.Text + " ");
                }
                lastTop = c.Top;
            }

            MessageBox.Show("MSG: " + sMsg.ToString());
        }

        protected void dragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.ToString());
            MessageBox.Show(sender.ToString());
            (sender as Control).Top = e.Y;
            (sender as Control).Left = e.X;
        }
    }
}