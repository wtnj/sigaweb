using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Carralero;

namespace SigaObjects.Session.Empresa
{
    public class EmpresaDao : SELECT
    {
        #region Select
        public DataTable getEmpresas_Filiais()
        {
            return getEmpresas_Filiais(null, null);
        }
        public DataTable getEmpresas_Filiais(string filtro)
        {
            return getEmpresas_Filiais(null, filtro);
        }
        public DataTable getEmpresas_Filiais(List<string> empresas_nome)
        {
            return getEmpresas_Filiais(empresas_nome, null);
        }
        public DataTable getEmpresas_Filiais(List<string> empresas_nome, string filtro)
        {
            QUERY = new StringBuilder(fromDatabase);

            QUERY.AppendLine("SELECT M0_CODIGO, M0_NOME, M0_CODFIL, M0_FILIAL");
            QUERY.AppendLine("  FROM SIGAMAT");

            if (empresas_nome != null)
                QUERY.AppendLine(" WHERE M0_NOME IN(" + Funcoes.getStringArr(empresas_nome) + ")");

            if (filtro != null)
            {
                if (empresas_nome != null)
                    QUERY.AppendLine("   AND " + filtro);
                else
                    QUERY.AppendLine(" WHERE " + filtro);
            }

            return getData();
        }
        /// <summary>Varre o banco de dados à procura das empresas cadastradas</summary>
        /// <returns> Todas as empresas cadastradas com distinção no nome </returns>
        public DataTable getEmpresas()
        {
            return getEmpresas(null);
        }
        /// <summary>Varre o banco de dados à procura das empresas cadastradas</summary>
        /// <returns> Todas as empresas cadastradas com distinção no nome </returns>
        /// <param name="filtro">Qualquer tipo de filtro (comparação , conjunto, etc...)</param>
        public DataTable getEmpresas(string filtro)
        {
            QUERY = new StringBuilder(fromDatabase);

            QUERY.AppendLine("SELECT DISTINCT M0_CODIGO, M0_CODIGO + ' - ' + M0_NOME M0_NOME");
            QUERY.AppendLine("  FROM SIGAMAT ");
            
            if(filtro!=null)
                QUERY.AppendLine(" WHERE " + filtro);

            QUERY.AppendLine(" ORDER BY M0_NOME");

            return getData();
        }
        #endregion

        #region Load
        public void Load(List<EmpresaVo> empresas)
        {
            Load(empresas, null, null);
        }
        public void Load(List<EmpresaVo> empresas, List<string> empresas_nome)
        {
            Load(empresas, empresas_nome, null);
        }
        public void Load(List<EmpresaVo> empresas, string filtro)
        {
            Load(empresas, null, filtro);
        }
        public void Load(List<EmpresaVo> empresas, List<string> empresas_nome, string filtro)
        {
            DataTable table = getEmpresas_Filiais(empresas_nome, filtro);
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                EmpresaVo empresa = new EmpresaVo();

                empresa.CODIGO = (string)table.DefaultView[i]["M0_CODIGO"];
                empresa.NOME   = (string)table.DefaultView[i]["M0_NOME"];

                empresa.CODIGO_FILIAL = (string)table.DefaultView[i]["M0_CODFIL"];
                empresa.FILIAL        = (string)table.DefaultView[i]["M0_FILIAL"];

                empresas.Add(empresa);
            }
        }

        public void Load(EmpresaVo empresa, string filtro)
        {
            string strFil = "";
            strFil +=    "M0_CODIGO     = '"+empresa.CODIGO+"'";
            strFil += "   AND M0_CODFIL = '"+empresa.CODIGO_FILIAL+"'";
            if(filtro != null)
                strFil += "   AND "+filtro;

            DataTable table = getEmpresas_Filiais(strFil);
            if (table.DefaultView.Count > 0)
            {
                empresa.CODIGO = (string)table.DefaultView[0]["M0_CODIGO"];
                empresa.NOME   = (string)table.DefaultView[0]["M0_NOME"];

                empresa.CODIGO_FILIAL = (string)table.DefaultView[0]["M0_CODFIL"];
                empresa.FILIAL = (string)table.DefaultView[0]["M0_FILIAL"];
            }
        }
        #endregion
    }
}
