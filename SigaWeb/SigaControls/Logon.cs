//using System;
//using System.Collections.Generic;
//using System.Text;

//using SigaObjects.Session.Empresa;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

using SigaObjects.Session.Empresa;

namespace SigaControls
{
    public class Logon
    {
        /// <summary>
        ///     Unico acesso externo, pois todo o trafego de informaçoes eh monitorado
        /// pelo conjunto de userControls, SigaControle com o objeto SigaSession.
        /// </summary>
        /// <param name="username">usuario de sistema</param>
        /// <param name="password">senha do usuario setado</param>
        /// <param name="inForm"  >webguiForm onde o Main(menu e janela principal) será carregado, caso seja autenticado</param>
        public Logon(string username, string password, List<string> nomes, Gizmox.WebGUI.Forms.Form inForm)
        {

            try
            {
                if (nomes.Count > 0)
                {
                    if (username.Equals("") || password.Equals(""))
                    {
                        MessageBox.Show("Favor preencher Login e/ou Senha !");
                    }
                    else
                    {
                        sigaSession.Logon(username, password);
                        //new EmpresaDao().Load(sigaSession.EMPRESAS, nomes);
                        inForm.Controls.Clear();
                        FormatScreen.AddControl(inForm, new MainMenu(), true);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione alguma empresa !");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}