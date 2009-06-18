using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using System.Text;
using System.IO;
using Gizmox.WebGUI.Common.Gateways;
using System.Net;
using System.Globalization;
namespace SigaControls
{
    public class FormatScreen
    {
        private static int _margem = 5;
        public  static int Margem
        { get { return _margem; } set { _margem = value; } }

        #region AddTab
        public static void AddTab(TabControl inTab, string tabName, Control ctrl)
        {
            TabPage tpNew = new TabPage(tabName);
            tpNew.Controls.Add(ctrl);

            AddTab(inTab, tpNew);
        }
        public static void AddTab(TabControl inTab, TabPage addTab)
        {
            AddTab(inTab, addTab, true);
        }
        public static void AddTab(TabControl inTab, TabPage addTab, bool focusNewTab)
        {
            bool bOk = true;

            for(int i=0; i<inTab.TabPages.Count;i++)
                if (addTab.Text == inTab.TabPages[i].Text)
                {
                    if (focusNewTab)
                        inTab.SelectedIndex = i;
                    bOk = false;
                }

            if (bOk)
            {
                inTab.TabPages.Add(addTab);
                if (focusNewTab)
                    inTab.SelectedIndex = inTab.TabPages.Count - 1;
            }
        }
        #endregion

        #region AddControl
        public static void AddControl(Control inControl, Control addCtrl)
        { AddControl(inControl, addCtrl, false); }
        public static void AddControl(Control inControl, Control addCtrl, bool inLeft)
        { AddControl(inControl, addCtrl, inLeft, 0, true, false); }
        public static void AddControl(Control inControl, Control addCtrl, bool inLeft, int maxInCol, bool ajustWidth, bool focusNewControl)
        {
            Control lastControl = new Control();
            
            if(inControl.Controls.Count>0)
                lastControl = inControl.Controls[inControl.Controls.Count-1];

            addCtrl.Top = (lastControl.Top >= Margem) ? lastControl.Top : Margem;
            inControl.Controls.Add(addCtrl);

            ArrayList arr = new ArrayList();
            foreach (Control c in inControl.Controls)
                if (c.Top == addCtrl.Top
                 && c.Top == lastControl.Top)
                    arr.Add(c);

            if (inLeft
             && arr.Count <= maxInCol)
            {
                if (arr.Count > 0)
                    Ajust2EqualsWidthControls(arr.ToArray(), inControl.Width, ajustWidth);
            }
            else
            {
                addCtrl.Left = Margem;
                addCtrl.Top  = lastControl.Top + lastControl.Height + Margem;
            }
        }
        #endregion

        public static void setDragTarget(Control inControl, ArrayList controls)
        { setDragTarget(inControl, controls.ToArray()); }
        public static void setDragTarget(Control inControl, Array controls)
        {
            inControl.DragTargets = (controls as Gizmox.WebGUI.Forms.Component[]);
        }

        #region Ajust2EqualsWidthControls
        public static void Ajust2EqualsWidthControls(Array controls, int maxWidth)
        { Ajust2EqualsWidthControls(controls, maxWidth, true); }
        public static void Ajust2EqualsWidthControls(Array controls, int maxWidth, bool ajustWidth)
        {
            if (controls.Length > 0)
            {
                int width = (maxWidth - Margem * (controls.Length + 1)) / controls.Length;
                int iLeft = Margem;

                foreach (Control c in controls)
                {
                    if (ajustWidth)
                        c.Width = width;
                    c.Left = iLeft;
                    iLeft = c.Left + c.Width + Margem;
                }
            }
        }
        #endregion
        
        public static void organizerControls(Control inControl)
        {
            Control lastControl = new Control();
            lastControl.Top     = 0;
            lastControl.Left    = 0;
            lastControl.Width   = 0;
            lastControl.Height  = 0;

            foreach (Control c in inControl.Controls)
            {
                int sumAll = lastControl.Left + lastControl.Width + Margem * 2;
                if (sumAll + c.Width > inControl.Width)
                {
                    c.Top = lastControl.Top + lastControl.Height + Margem;
                    c.Left = Margem;
                }
                else
                {
                    c.Top = (lastControl.Top >= Margem) ? lastControl.Top : Margem;
                    c.Left = sumAll-Margem;
                }
                lastControl = c;
            }
        }

        public static void setIcon(Control control)
        {
            foreach (Control cCur in control.Controls)
            {
                if (cCur.GetType() == typeof(Button))
                {
                    Button btn = (cCur as Button);

                    switch ((cCur.Tag as string).Trim().ToLower())
                    {
                        case "busca":
                            btn.Image = (ResourceHandle)Resources.Icons.basic.Search[0];
                            break;
                        case "ok":
                            btn.Image = (ResourceHandle)Resources.Icons.status.Aprovado[0];
                            break;
                        default: break;
                    }
                    if (btn.Text.Trim().Length > 0
                      && btn.Image != null)
                        btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                }

                if (cCur.Controls.Count > 0)
                    setIcon(cCur);
            }
        }

        public static void lockControls(Control control, params Type[] lockTypes)
        {
            foreach (Control cCur in control.Controls)
            {
                bool bLock = false;
                foreach (Type t in lockTypes)
                    if (cCur.GetType() == t)
                    { bLock = true; break; }

                if (bLock)
                {
                    cCur.Enabled = false;
                }

                if (cCur.Controls.Count > 0)
                    lockControls(cCur, lockTypes);
            }
        }

        public static void showNotImplemented()
        {
            MessageBox.Show("Controle não implementado!");
        }
        #region AddEVENTS
        public enum TIPOS
        {
            TEXTO  ,
            NUMERO ,
            MOEDA  ,
            DECIMAL,
            DATA   ,
            HORA
        }
        public static void addEventType(Control controls, params Type[] setTypes)
        { addEventType(controls, TIPOS.TEXTO, setTypes); }
        public static void addEventType(Control controls, TIPOS tipo, params Type[] setTypes)
        {
            foreach (Control cCur in controls.Controls)
            {
                bool bSet = false;
                foreach (Type t in setTypes)
                    if (cCur.GetType() == t)
                    { bSet = true; break; }

                if (bSet)
                    switch (tipo)
                    {
                        case TIPOS.TEXTO:
                            cCur.TextChanged += new EventHandler(cCur_CheckText);
                            break;
                        case TIPOS.DECIMAL:
                            cCur.TextChanged += new EventHandler(cCur_CheckNumber);
                            break;
                        default:
                            cCur.TextChanged +=new EventHandler(cCur_CheckText);
                            break;
                    }
            }
        }

        public static void addEventTag(Control controls, string tag)
        { addEventTag(controls, TIPOS.TEXTO, tag); }
        public static void addEventTag(Control controls, TIPOS tipo, string tag)
        {
            foreach (Control cCur in controls.Controls)
            {
                if (cCur.Tag != null)
                    if (cCur.Tag.ToString().Trim().ToLower() == tag.Trim().ToLower())
                        switch (tipo)
                        {
                            case TIPOS.TEXTO:
                                cCur.TextChanged += new EventHandler(cCur_CheckText);
                                break;
                            case TIPOS.DECIMAL:
                                cCur.TextChanged += new EventHandler(cCur_CheckNumber);
                                break;
                            case TIPOS.MOEDA:
                                TextBox tbox = cCur as TextBox;
                                tbox.Validator    = new TextBoxValidation("","","0-9\\.");
                                cCur.TextChanged += new EventHandler(cCur_CheckCurrency);
                                //cCur.KeyPress    += new KeyPressEventHandler(cCur_KeyPressCurrency);
                                // cCur.KeyUp       += new KeyEventHandler(cCur_KeyUp);
                                break;
                            default:
                                cCur.TextChanged += new EventHandler(cCur_CheckText);
                                break;
                        }
            }
        }

        static void cCur_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            
        }
        
        #region EVENTOS
        static void cCur_CheckText(    object sender, EventArgs e)
        {
        }
        static void cCur_CheckNumber(  object sender, EventArgs e)
        {
        }
        static void cCur_CheckCurrency(object sender, EventArgs e)
        {
            Control cCur = sender as Control;
            string sCurr = cCur.Text.Trim();
            while(sCurr.LastIndexOf('.') != sCurr.IndexOf('.'))
                sCurr = sCurr.Remove(cCur.Text.IndexOf('.'),1);

            double dbCurr = double.Parse(   sCurr , CultureInfo.InvariantCulture);
            cCur.Text     = dbCurr.ToString("0.00", CultureInfo.InvariantCulture); //String.Format("{0:0,00}", dbCurr);
        }
        static void cCur_KeyPressCurrency(object sender, KeyPressEventArgs e)
        {
            Control cCur = sender as Control;

            if (cCur.Text.Contains("."))
                cCur.Text = cCur.Text.Replace(".", "");
        }
        #endregion
        #endregion

        #region VALIDACAO
        public static string ValidateTextControls(Control control, params Type[] valTypes)
        {
            StringBuilder strMsg = new StringBuilder();

            foreach (Control cCur in control.Controls)
            {
                bool bVal = false;
                foreach(Type t in valTypes)
                    if (cCur.GetType() == t && cCur.Tag != null)
                        if ((cCur.Tag as string).StartsWith("*:"))
                        { bVal = true; break; }

                if (bVal)
                {
                    if (cCur.Text.Trim().Length==0)
                        strMsg.AppendLine("* : "+(cCur.Tag as string).Trim().Substring(2));
                }

                if (cCur.Controls.Count > 0)
                {
                    string sResult = ValidateTextControls(cCur, valTypes);
                    if (sResult.Trim().Length > 0)
                        strMsg.AppendLine(sResult);
                }
            }

            return strMsg.ToString();
        }
        #endregion

        public struct ContextType
        {
            public static string HTML  = "text/HTML";
            public static string PDF   = "application/pdf";
            public static string Excel = "application/x-msexcel";
            public static string Word  = "application/msword";
            public static string txt   = "text/plain";
            public static string other = "application/octet-stream";
        }
        public void   DownloadFile(string rootPath, string filename, string contexto)
        { DownloadFile(rootPath, filename, contexto, new HtmlBox());}
        public void   DownloadFile(string rootPath, string filename, string contexto, HtmlBox html)
        {
            
                HttpResponse response = HttpContext.Current.Response;
                
                response.Clear();
                response.AddHeader("Content-Type"       , ContextType.HTML);//"binary/octet-stream");
                response.ContentType = ContextType.HTML; //contexto;//"application/octet-stream";
                response.Write("Arquivo gerado com sucesso : ");
                response.Write("<a href='arquivos\\"+filename+"'>download</a>.");
                
                response.End();
        }

        public Control getObject(string objeto)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(Form));//.GetAssembly(typeof(Gizmox.WebGUI.Forms.Control));
            Type tipo = assembly.GetType(objeto);
            return getObject(tipo);
        }
        public Control getObject(Type   tipo  )
        {
            return (Control)Activator.CreateInstance(tipo);
        }

        public static Control getObjectFromSigaType(string strType)
        {
            Control control = null;

            switch (strType.ToUpper().Trim())
            {
                case "N":
                    control = new TextBox();
                    (control as TextBox).Validator = new TextBoxValidation("", "", "0-9\\.");
                    control.TextChanged += new EventHandler(cCur_CheckCurrency);
                    break;
                case "D":
                    control = new DateTimePicker();
                    (control as DateTimePicker).CustomFormat = "dd/MM/yyyy";
                    (control as DateTimePicker).Format       = DateTimePickerFormat.Custom;
                    break;
                default:
                    control = new TextBox();
                    break;
            }

            return control;
        }
    }
}
