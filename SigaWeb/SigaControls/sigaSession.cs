using System;
using System.Collections.Generic;
using System.Text;

using Gizmox.WebGUI.Forms;

using SESSION = SigaObjects.Session;

namespace SigaControls
{
    internal static class sigaSession
    {
        private static SESSION.SysUsers.SysUserVo      usuario  =
                       new SigaObjects.Session.SysUsers.SysUserVo();
        private static List<SESSION.Empresa.EmpresaVo> empresas =
                       new List<SigaObjects.Session.Empresa.EmpresaVo>();
        private static List<SESSION.Empresa.EmpresaVo> filiais  = 
                       new List<SigaObjects.Session.Empresa.EmpresaVo>();

        public static SESSION.SysUsers.SysUserVo      LoggedUser
        {
            get { return usuario; }
            private set { usuario = value; }
        }
        public static List<SESSION.Empresa.EmpresaVo> EMPRESAS  
        {
            get { return empresas;  }
            set { empresas = value; }
        }
        public static List<SESSION.Empresa.EmpresaVo> FILIAIS   
        {
            get { return filiais;  }
            set { filiais = value; }
        }

        public static void Logon(string username, string password)
        {
            new SESSION.SysUsers.SysUserDao().load(LoggedUser, username, password);
            if (LoggedUser.ID == 0)
                throw new Exception("Acesso negado.\n Usuário ou Senha inválidos.");
        }
    }
}
