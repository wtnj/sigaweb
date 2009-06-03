using System;
using System.Collections.Generic;
using System.Text;

using Gizmox.WebGUI.Common.Resources;

namespace SigaControls.Resources.Images
{
    public class basic
    {
        #region NOME DOS ARQUIVOS
        private static List<object> _logo;
        #endregion

        #region PROPRIEDADE
        public static List<object> LOGO
        {
            get
            {
                _logo = new List<object>();
                _logo.Add(new ImageResourceHandle("logo.png"));
                _logo.Add("Carralero Consultoria e Desenvolvimento LTDA");
                return _logo;
            }
        }
        #endregion
    }
}
