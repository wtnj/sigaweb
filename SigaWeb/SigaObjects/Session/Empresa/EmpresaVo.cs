using System;
using System.Collections.Generic;
using System.Text;
//using Gizmox.WebGUI.Forms;
using System.Data;

namespace SigaObjects.Session.Empresa
{
    public class EmpresaVo
    {
        private string 
            M0_CODIGO,
            M0_CODFIL,
            M0_FILIAL,
            M0_NOME;

        public EmpresaVo()
        {
        }
        public EmpresaVo(string M0_CODIGO, string M0_NOME)
        {
            CODIGO = M0_CODIGO;
            NOME = M0_NOME;
        }
        public EmpresaVo(string M0_CODIGO, string M0_CODFIL, string M0_FILIAL, string M0_NOME)
        {
            CODIGO = M0_CODIGO;
            NOME = M0_NOME;

            CODIGO_FILIAL = M0_CODFIL;
            FILIAL = M0_FILIAL;
        }

        public string CODIGO
        {
            get { return M0_CODIGO; }
            set { M0_CODIGO = value; }
        }
        public string CODIGO_FILIAL
        {
            get { return M0_CODFIL; }
            set { M0_CODFIL = value; }
        }
        public string FILIAL
        {
            get { return M0_FILIAL; }
            set { M0_FILIAL = value; }
        }
        public string NOME
        {
            get { return M0_NOME; }
            set { M0_NOME = value; }
        }
    }
}
