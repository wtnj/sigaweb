using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms;
using System.Data;

namespace SigaControls
{
    public class Empresa
    {
        private static SigaObjects.Empresa empresa = new SigaObjects.Empresa();

        public static string CODIGO
        {
            get { return empresa.CODIGO; }
            set { empresa.CODIGO = value; }
        }

        public static string CODIGO_FILIAL
        {
            get { return empresa.CODIGO_FILIAL; }
            set { empresa.CODIGO_FILIAL = value; }
        }

        public static string FILIAL
        {
            get { return empresa.FILIAL; }
            set { empresa.FILIAL = value; }
        }

        public static string NOME
        {
            get { return empresa.NOME; }
            set { empresa.NOME = value; }
        }

        public Empresa(string codigo)
        {
            empresa = new SigaObjects.Empresa();
            DataTable dados = empresa.getEmpresas("M0_CODIGO = '" + codigo + "'");

            if (dados.DefaultView.Count > 0)
            {
                NOME   = dados.DefaultView[0].Row["M0_NOME"].ToString();
                FILIAL = dados.DefaultView[0].Row["M0_FILIAL"].ToString();
                CODIGO = dados.DefaultView[0].Row["M0_CODIGO"].ToString();
                CODIGO_FILIAL = dados.DefaultView[0].Row["M0_CODFIL"].ToString();
            }
            else
            {
                throw new Exception("Empresa não existe");
            }
        }

        
        public static void fillControls(Control control)
        {
            fillControls(control, "M0_NOME", "M0_CODIGO");
        }
        public static void fillControls(Control control,string display, string value)
        {
            if (control.GetType() == typeof(ComboBox))
            {
                ComboBox combo = (control as ComboBox);

                combo.DisplayMember = display;
                combo.ValueMember   = value;

                combo.DataSource = new SigaObjects.Empresa().getEmpresas().DefaultView;
            }
            else
                (control as DataGridView).DataSource = new SigaObjects.Empresa().getEmpresas().DefaultView;
        }

        //public static DataTable getEmpresas()
        //{
        //    return empresa.getEmpresas();
        //}

        
    }
}
