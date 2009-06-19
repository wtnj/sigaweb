using System;
using System.Collections.Generic;
using System.Text;

using Gizmox.WebGUI.Forms;
namespace SigaControls
{
    internal static class ControlsConfig
    {
        public enum showType { None, Dialog, PopUp };

        #region formShow
        public static void formShow(Control openForm)
        {
            formShow(openForm, null);
        }
        public static void formShow(Control openForm, Form inForm)
        {
            formShow(openForm, inForm, showType.None);
        }
        public static void formShow(Control openForm, Form inForm, showType type)
        { formShow(openForm, inForm, type, null); }
        public static void formShow(Control openForm, Form inForm, showType type, Control caller)
        { formShow(openForm, inForm, type, caller, false); }
        public static void formShow(Control openForm, Form inForm, showType type, Control caller, bool maxize)
        {
            Form form = new Form();
            form.Size          = openForm.Size;
            form.Text          = openForm.Text;
            form.BorderStyle   = BorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Controls.Add(openForm);

            if (type == showType.PopUp)
                if (inForm != null)
                    form.ShowPopup(inForm);
                else
                    form.ShowPopup();

            if (type == showType.Dialog)
                if (inForm != null)
                    form.ShowDialog(inForm);
                else
                    form.ShowDialog();

            if (type == showType.None)
                form.Show();

            if(maxize)
                form.WindowState = FormWindowState.Maximized;

            //form.Top  = form.Owner.Top  + caller.Top;
            //form.Left = form.Owner.Left + caller.Left;
        }
        #endregion
    }
}
