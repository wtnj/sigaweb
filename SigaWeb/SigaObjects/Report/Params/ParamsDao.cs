using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.Params
{
    public class ParamsDao : SELECT
    {
        #region Members
        public static String ValueMember
        {
            get { return "formato"; }
        }
        public static String DisplayMember
        {
            get { return "campo"; }
        }
        #endregion

        #region Listas

        public List<string> getTamanhosAsList(int mainId)
        {
            return getColunaAsList(getTamanhos(mainId));
        }
        public List<string> getTabelaAsList(int mainId)
        {
            return getColunaAsList(getTabelas(mainId));
        }
        public List<string> getCamposAsList(int mainId)
        {
            return getColunaAsList(getCampos(mainId));
        }
        public List<string> getFormatoAsList(int mainId)
        {
            return getColunaAsList(getFormatos(mainId));
        }

        #endregion

        #region Load
        public void Load(List<ParamsVo> parameters, int mainId)
        {
            Load(parameters, mainId, null);
        }
        public void Load(List<ParamsVo> parameters, int mainId, string filtro)
        {
            DataTable table = select(mainId, filtro, false);

            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                ParamsVo param = new ParamsVo();

                Load(param, mainId, null, table.Rows[i]);

                parameters.Add(param);
            }
        }
        public void Load(ParamsVo       param     , int mainId)
        {
            Load(param, mainId, null);
        }
        public void Load(ParamsVo       param     , int mainId, string filtro)
        {
            Load(param, mainId, filtro, null);
        }
        public void Load(ParamsVo       param     , int mainId, string filtro, DataRow row)
        {
            if (row == null)
            {
                DataTable dados = select(mainId, filtro, true);
                if (dados.DefaultView.Count > 0)
                    row = dados.Rows[0];
            }
            
            if (row!=null)
            {
                param.MAINID  = mainId;

                param.ID      = (int)   row["id"     ];
                param.TABELA  = (string)row["tabela" ];
                param.TAMANHO = (int)   row["tamanho"];
                param.CAMPO   = (string)row["campo"  ];
                param.FORMATO = (string)row["formato"];
                param.OBJETO  = (string)row["objeto" ];
            }
        }
        #endregion

        #region Select
        public DataTable select(int mainId)
        {
            return select(mainId, null, false);
        }
        public DataTable select(int mainId, string filtro)
        {
            return select(mainId,filtro,false);
        }
        public DataTable select(int mainId, bool   firstOnly)
        {
            return select(mainId, null, firstOnly);
        }
        public DataTable select(int mainId, string filtro, bool firstOnly)
        {
            new SELECT(firstOnly ? "TOP 1 * " : "*")
                .From( "params")
                .Where("mainId = " + mainId)
                .And(  filtro);

            return getData();
        }

        public DataTable getTamanhos(int mainId)
        {
            return getColunas(mainId,"tamanho");
        }
        public DataTable getTabelas( int mainId)
        {
            return getColunas(mainId,"tabela");
        }
        public DataTable getCampos(  int mainId)
        {
            return getColunas(mainId,"campo");
        }
        public DataTable getFormatos(int mainId)
        {
            return getColunas(mainId,"formato");
        }
        public DataTable getColunas( int mainId, string colunas)
        {
            this.QUERY = new StringBuilder();

            this.QUERY.AppendLine(fromDatabase);
            this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
            this.QUERY.AppendLine("  FROM params");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId);

            return getData();
        }

        private bool existProcedure(string procedurename)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("SELECT OBJECT_ID('" + procedurename + "','P')");
            DataTable dados = this.getData();
            string objectid = dados.Rows[0][0].ToString();
            return String.IsNullOrEmpty(objectid);
        }
        private void CreateRecursiveProcedure()
        {
            if (this.existProcedure("SPR_ParametrosRecursivos"))
            {
                this.QUERY = new StringBuilder(fromDatabase);
                
                this.QUERY.AppendLine("CREATE PROCEDURE SPR_ParametrosRecursivos (@mainId INT = 0, @Nivel INT = 0, @NOMETABELA VARCHAR(80)) AS");
                this.QUERY.AppendLine("IF OBJECT_ID(@NOMETABELA,'U') IS NULL");
                this.QUERY.AppendLine("BEGIN");
                this.QUERY.AppendLine("    exec('CREATE TABLE '+@NOMETABELA+'(id int NOT NULL, Nivel int)')");
                this.QUERY.AppendLine("END");

                this.QUERY.AppendLine("");

                this.QUERY.AppendLine("SET NOCOUNT ON");

                this.QUERY.AppendLine("");

                this.QUERY.AppendLine("DECLARE @id INT, @oldId INT");

                this.QUERY.AppendLine("--Abrindo o 'cursor'");
                this.QUERY.AppendLine("IF @mainId = 0");
                this.QUERY.AppendLine("    SELECT TOP 1 @id = T.id");
                this.QUERY.AppendLine("      FROM RTable T");
                this.QUERY.AppendLine("     WHERE T.mainId = 0");
                this.QUERY.AppendLine("     ORDER BY T.id");
                this.QUERY.AppendLine("ELSE");
                this.QUERY.AppendLine("    SELECT TOP 1 @id = T.id");
                this.QUERY.AppendLine("      FROM RTable T");
                this.QUERY.AppendLine("     WHERE T.mainId = @mainId");
                this.QUERY.AppendLine("     ORDER BY T.id");

                this.QUERY.AppendLine("--Condi��o de parada: n�o encontrar mais pessoas");
                this.QUERY.AppendLine("WHILE @id IS NOT NULL");
                this.QUERY.AppendLine("BEGIN");
                this.QUERY.AppendLine("    --Inserindo registro na tabela tempor�ria");
                this.QUERY.AppendLine("    exec('INSERT INTO '+@NOMETABELA+' VALUES('+@id+','+@Nivel+')')");

                this.QUERY.AppendLine("    --Incrementando n�vel antes de chamar a procedure");
                this.QUERY.AppendLine("    SET @Nivel = @Nivel + 1");

                this.QUERY.AppendLine("    --Buscando todas as pessoas gerenciadas pela pessoa atual");
                this.QUERY.AppendLine("    EXECUTE SPR_ParametrosRecursivos @id, @Nivel, @NOMETABELA");

                this.QUERY.AppendLine("    --Voltando ao n�vel anterior");
                this.QUERY.AppendLine("    SET @Nivel = @Nivel - 1");

                this.QUERY.AppendLine("    --Definindo vari�vel para a pessoa anterior");
                this.QUERY.AppendLine("    SET @oldId = @id");
                this.QUERY.AppendLine("    SET @id    = NULL");

                this.QUERY.AppendLine("    --Pr�xima pessoa");
                this.QUERY.AppendLine("    IF @mainId = 0");
                this.QUERY.AppendLine("        SELECT TOP 1 @id = T.id");
                this.QUERY.AppendLine("          FROM RTable T");
                this.QUERY.AppendLine("         WHERE T.mainId = 0");
                this.QUERY.AppendLine("           AND T.id > @oldId");
                this.QUERY.AppendLine("         ORDER BY T.id");
                this.QUERY.AppendLine("    ELSE");
                this.QUERY.AppendLine("        SELECT TOP 1 @id = T.id");
                this.QUERY.AppendLine("          FROM RTable T");
                this.QUERY.AppendLine("         WHERE T.mainId = @mainId");
                this.QUERY.AppendLine("           AND T.id > @oldId");
                this.QUERY.AppendLine("         ORDER BY T.id");
                this.QUERY.AppendLine("END");

                this.getData();
                this.QUERY = null;
            }
        }

        public DataTable getRecursiveTables(Table.TableVo mainTable, string tablename)
        { return this.getRecursiveTables(mainTable, tablename, 0); }
        public DataTable getRecursiveTables(Table.TableVo mainTable, string tablename, int mainId)
        { return this.getRecursiveTables(mainTable, tablename, mainId, null); }
        public DataTable getRecursiveTables(Table.TableVo mainTable, string tablename, int mainId, string filtro)
        {
            // verifica e cria, se necessario a procedure SPR_ParametrosRecursivos, para essa necessidade.
            //TODO criar modo de add procedure na SigaWeb sem usar o GO e o USE BANCODEDADOS
            //this.CreateRecursiveProcedure();

            // executa query usando a procedure acima.
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("IF OBJECT_ID('@TABELA','U') IS NOT NULL");
            this.QUERY.AppendLine("BEGIN");
            this.QUERY.AppendLine("    DROP TABLE @TABELA");
            this.QUERY.AppendLine("END");
            //this.QUERY.AppendLine("GO");
            this.QUERY.AppendLine("EXECUTE SPR_ParametrosRecursivos "+mainId+", 0, @TABELA");
            //this.QUERY.AppendLine("GO");
            this.QUERY.AppendLine("SELECT DISTINCT RTable.*, params.*");
            this.QUERY.AppendLine("  FROM RTable");
            this.QUERY.AppendLine(" RIGHT JOIN @TABELA TEMP");
            this.QUERY.AppendLine("    ON TEMP.id   = RTable.id");
            this.QUERY.AppendLine("    OR RTable.id = "+mainId);
            this.QUERY.AppendLine(" INNER JOIN params");
            this.QUERY.AppendLine("    ON params.mainId = RTable.id");

            if(!string.IsNullOrEmpty(filtro))
                this.QUERY.AppendLine(" WHERE "+filtro);

            this.QUERY.AppendLine("");
            this.QUERY.AppendLine("DROP TABLE @TABELA");
            
            /* //QUERY RECURSIVA COM METODO QUE S� FUNCIONA NO SQL 2005 ou SUPERIOR(muito mais rapido)
            this.QUERY.AppendLine("WITH TABELAS AS");
            this.QUERY.AppendLine("(");
            this.QUERY.AppendLine("    SELECT main.id          , main.mainId       , main.tabela");
            this.QUERY.AppendLine("         , main.relatedtype , main.relatedtable , main.idReport");
            this.QUERY.AppendLine("      FROM RTable main");
            this.QUERY.AppendLine("     WHERE main.id = " + mainTable.ID);
            this.QUERY.AppendLine("     UNION ALL");
            this.QUERY.AppendLine("    SELECT child.id         , child.mainId      , child.tabela");
            this.QUERY.AppendLine("         , child.relatedtype, child.relatedtable, child.idReport");
            this.QUERY.AppendLine("      FROM TABELAS");
            this.QUERY.AppendLine("     INNER JOIN RTable child");
            this.QUERY.AppendLine("        ON TABELAS.id = child.mainId");
            this.QUERY.AppendLine(")");
            this.QUERY.AppendLine("SELECT distinct *");
            this.QUERY.AppendLine("  FROM TABELAS");
            this.QUERY.AppendLine(" INNER JOIN params");
            this.QUERY.AppendLine("    ON params.mainId = TABELAS.id");
            //*/

            this.QUERY = new StringBuilder(this.QUERY.ToString().Replace("@TABELA", tablename));
            return getData();
        }
        #endregion

        #region Save
        public int save(List<ParamsVo> parameters)
        {
            int cont = 0;
            foreach(ParamsVo param in parameters)
                cont += save(param);
            return cont;
        }
        public int save(ParamsVo param)
        {
            int iRet = 0;

            if(param.ID == 0)
                iRet = insert(param);
            else
                iRet = update(param);
            return iRet;
        }
        #endregion

        #region Insert
        public int insert(ParamsVo param)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery(fromDatabase);
            this.addInQuery("INSERT INTO params (mainId, tabela, campo, formato, tamanho, objeto)");
            this.QUERY.Append("VALUES (");
            this.QUERY.Append(""  + param.MAINID  + "," );
            this.QUERY.Append("'" + param.TABELA  + "',");
            this.QUERY.Append("'" + param.CAMPO   + "',");
            this.QUERY.Append("'" + param.FORMATO + "',");
            this.QUERY.Append("'" + param.TAMANHO + "',");
            this.QUERY.Append("'" + param.OBJETO  + "'" );
            this.QUERY.AppendLine(")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(ParamsVo param)
        {
            this.QUERY = new StringBuilder();

            this.addInQuery(fromDatabase);
            this.addInQuery("UPDATE params");
            this.addInQuery("   SET tamanho = "  + param.TAMANHO + "");
            this.addInQuery("     , tabela  = '" + param.TABELA  + "'" );
            this.addInQuery("     , campo   = '" + param.CAMPO   + "'");
            this.addInQuery("     , formato = '" + param.FORMATO + "'");
            this.addInQuery("     , objeto  = '" + param.OBJETO  + "'");
            this.addInQuery(" WHERE id = " + param.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<ParamsVo> parameters)
        {
            int cont = 0;
            foreach(ParamsVo param in parameters)
                cont += delete(param);
            return cont;
        }
        public int delete(ParamsVo param)
        {
            return delete(param.MAINID, "id = " + param.ID);
        }
        public int delete(int mainId)
        {
            return delete(mainId,null);
        }
        public int delete(int mainId, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.addInQuery("DELETE FROM params");
            this.addInQuery(" WHERE mainId = " + mainId);
            if(filtro != null)
                this.addInQuery("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion
    }
}
