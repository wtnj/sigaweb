using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Resources;

namespace SigaControls.Resources.Icons
{
    public class status
    {
        #region NOME DOS ARQUIVOS
        private static List<object> _aprovado, _aguardando, _recusado, _bloqueado;
        #endregion

        #region PROPRIEDADE
        public static List<object> Aprovado     
        {
            get
            {
                _aprovado = new List<object>();
                _aprovado.Add(new IconResourceHandle("status.aprovado.png"));
                _aprovado.Add("Aprovado!");
                return _aprovado;
            }
        }
        public static List<object> Aguardando   
        {
            get
            {
                _aguardando = new List<object>();
                _aguardando.Add(new IconResourceHandle("status.aguardando.png"));
                _aguardando.Add("Aguardando...!");
                return _aguardando;
            }
        }
        public static List<object> Recusado     
        {
            get
            {
                _recusado = new List<object>();
                _recusado.Add(new IconResourceHandle("status.recusado.png"));
                _recusado.Add("Recusado!");
                return _recusado;
            }
        }
        public static List<object> Bloqueado    
        {
            get
            {
                _bloqueado = new List<object>();
                _bloqueado.Add(new IconResourceHandle("status.bloqueado.png"));
                _bloqueado.Add("Bloqueado!");
                return _bloqueado;
            }
        }
        #endregion

        public List<object> this[int idx]
        {
            get
            {
                List<object> oRet = null;

                switch (idx)
                {
                    case 1: oRet = Aprovado;   break;
                    case 2: oRet = Aguardando; break;
                    case 3: oRet = Recusado;   break;
                    case 4: oRet = Bloqueado;  break;
                }

                return oRet;
            }
        }

        #region STATIC METHODS
        public static ResourceHandle getResourceHandler(int idx)
        {
            List<object> oRet = new List<object>();

            switch (idx)
            {
                case 1: oRet = Aprovado;   break;
                case 2: oRet = Aguardando; break;
                case 3: oRet = Recusado;   break;
                case 4: oRet = Bloqueado;  break;
            }
            
            ResourceHandle rrRet = null;
            if(oRet.Count>0)
                rrRet = (ResourceHandle)oRet[0];
            
            return rrRet;
        }
        #endregion
    }
}
