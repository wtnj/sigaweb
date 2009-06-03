using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects
{
    public class Empresa : SELECT
    {
        private static string M0_CODIGO, M0_CODFIL, M0_FILIAL, M0_NOME;

        public Empresa() { }

        public DataTable getEmpresas()
        {
            return getEmpresas(null);
        }
        public DataTable getEmpresas(string filtro)
        {
            StringBuilder sQuery = new StringBuilder();

            sQuery.AppendLine("use SigaWeb");
            sQuery.AppendLine("SELECT M0_CODIGO, M0_CODFIL, M0_FILIAL, M0_NOME ");
            sQuery.AppendLine("  FROM SIGAMAT ");
            if(filtro != null)
                sQuery.AppendLine(" WHERE " + filtro);

            return this.SelectDataTable(sQuery);
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
