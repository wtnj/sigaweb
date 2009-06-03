using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SigaObjects
{
    public class SXManager : DataMaster
    {
        #region ATRIBUTOS
        private string strEmpresa = "";
        #endregion
        #region PROPRIEDADES
        public string EMPRESA
        {
            get { return strEmpresa; }
            set { strEmpresa = value; }
        }
        #endregion

        #region DEFAULT Display & Value Members
        public static string TableDisplayMember
        { get { return "X2_NOME"; } }
        public static string TableValueMember  
        { get { return "X2_CHAVE"; } }
        public static string FieldDisplayMember
        { get { return "X3_TITULO"; }}
        public static string FieldValueMember  
        { get { return "X3_CAMPO"; } }

        // MOSTRAR CAMPOS
        public static string RelatedFieldsToShow
        {
            get
            {
                return "DISTINCT X2_CHAVE "
                     + ", X2_ARQUIVO      "
                     + ", X2_NOME         "
                     + ", X9_DOM          "
                     + ", X9_CDOM         "
                     + ", X9_EXPDOM       "
                     + ", X9_EXPCDOM      "
                     + ", X9_CONDSQL      ";
            }
        }
        #endregion

        #region Construtor
        public SXManager(string empresa)
        {
            this.initializer();
            this.EMPRESA = empresa;
        }
        private void initializer()
        {
            StringBuilder defaultQuery = new StringBuilder();
            defaultQuery.AppendLine(@"USE @ToDatabase");
            defaultQuery.AppendLine(@"-- ----- --");
            defaultQuery.AppendLine(@"SELECT @ToFields");
            defaultQuery.AppendLine(@"  INTO @ToTable");
            defaultQuery.AppendLine(@"  FROM");
            defaultQuery.AppendLine(@"OPENROWSET( '@Provider'");
            defaultQuery.AppendLine(@"          , 'Driver={@Driver}; DefaultDir=@Directory; SourceType=@SourceType'");
            defaultQuery.AppendLine(@"          , 'SELECT @FromFields");
            defaultQuery.AppendLine(@"               FROM @FromFile' )");

            this.Query = defaultQuery.ToString();
        }
        #endregion

        #region Estruturas e Valeres Padroes
        // Structs
        public struct SX
        {
            public static string SX1 = "SX1";
            public static string SX2 = "SX2";
            public static string SX3 = "SX3";
            public static string SX4 = "SX4";
            public static string SX5 = "SX5";
            public static string SX6 = "SX6";
            public static string SX7 = "SX7";
            public static string SX8 = "SX8";
            public static string SX9 = "SX9";
        }
        public struct Parms
        {
            public static string ToDatabase  = "@ToDatabase";
            public static string ToFields    = "@ToFields";
            public static string ToTable     = "@ToTable";
            public static string Provider    = "@Provider";
            public static string Driver      = "@Driver";
            public static string inDirectory = "@Directory";
            public static string SourceType  = "@SourceType";
            public static string FromFields  = "@FromFields";
            public static string FromFile    = "@FromFile";
        }

        // Objects (Variaveis)
        // valores Padrões (readonly)
        string defToDatabase = "";
        string defProvider   = "MSDASQL";
        string defDriver     = "Microsoft dBASE Driver (*.dbf)";
        string defSourceType = "DBF";
        //
        string toDatabase = "SigaWeb";
        string toFields   = "*";
        string toTable;
        string useProvider;
        string useDriver;
        string inDirectory;
        string sourceType;
        string fromFields = "*";
        string fromFile;
        string sQuery;

        public string ToDatabase 
        {
            get { return toDatabase; }
            set { toDatabase = value; }
        }
        public string ToFields   
        {
            get { return toFields; }
            set { toFields = value; }
        }
        public string ToTable    
        {
            get { return toTable; }
            set { toTable = value; }
        }
        public string UseProvider
        {
            get { return useProvider; }
            set { useProvider = value; }
        }
        public string UseDriver  
        {
            get { return useDriver; }
            set { useDriver = value; }
        }
        public string InDirectory
        {
            get { return inDirectory; }
            set { inDirectory = value; }
        }
        public string SourceType 
        {
            get { return sourceType; }
            set { sourceType = value; }
        }
        public string FromFields 
        {
            get { return fromFields; }
            set { fromFields = value; }
        }
        public string FromFile   
        {
            get { return fromFile; }
            set { fromFile = value; }
        }

        // Propriedades
        public string Query
        {
            get
            {
                string sRet = sQuery;
                sRet = sRet.Replace(Parms.ToDatabase , toDatabase );
                sRet = sRet.Replace(Parms.ToFields   , toFields   );
                sRet = sRet.Replace(Parms.ToTable    , toTable    );
                sRet = sRet.Replace(Parms.Provider   , useProvider);
                sRet = sRet.Replace(Parms.Driver     , useDriver  );
                sRet = sRet.Replace(Parms.inDirectory, inDirectory);
                sRet = sRet.Replace(Parms.SourceType , sourceType );
                sRet = sRet.Replace(Parms.FromFields , fromFields );
                sRet = sRet.Replace(Parms.FromFile   , fromFile   );
                return sRet;
            }
            private set { sQuery = value; }
        }
        #endregion

        public object Import()
        {
            return this.SelectDataTable(this.Query);
        }

        #region TABELAS do DICIONARIO
        /// <summary>
        /// Retorna Todas as tabelas do Dicionario
        /// </summary>
        /// <returns>Dados das tabelas</returns>
        public DataTable getTables()
        { return this.getTables(null); }

        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <returns>Dados das tabelas</returns>
        public DataTable getTables(string filter)
        { return this.getTables(filter, "X2_NOME"); }

        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <param name="ordem" >campos separados por virgula pra organizar o retorno</param>
        /// <returns>Dados das tabelas</returns>
        public DataTable getTables(string filter, string order)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT *"   );
            strQuery.AppendLine("  FROM SX2"+this.EMPRESA+"0 SX2" );
            if (filter != null)
                strQuery.AppendLine(" WHERE " + filter);
            strQuery.AppendLine("ORDER BY " + order);

            return this.SelectDataTable(strQuery);
        }
        public DataRowView getTabela(string table)
        {
            DataRowView drw=null;
            DataTable dt = getTables("X2_CHAVE = '" + table + "'");
            if(dt.DefaultView.Count>0)
                drw=dt.DefaultView[0];

            return drw;
        }
        #endregion

        #region CAMPOS da TABELA DO DICIONARIO
        /// <summary>
        /// Retorna os CAMPOS da Tabela informada
        /// </summary>
        /// <param name="table">Nome da tabela</param>
        /// <returns>Dados dos campos da tabela informada</returns>
        public DataTable getFields(string table)
        { return this.getFields(table, null, "X3_ORDEM"); }

        /// <param name="table" >Nome da tabela</param>
        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <param name="ordem" >campos separados por virgula pra organizar o retorno</param>
        /// <returns>Dados dos campos da tabela informada</returns>
        public DataTable getFields(string table, string filter, string ordem)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT *");
            strQuery.AppendLine("  FROM SX3"+this.EMPRESA+"0 SX3");
            strQuery.AppendLine(" WHERE X3_ARQUIVO  = '" + table + "'");
            strQuery.AppendLine("   AND IsNull(X3_CONTEXT, '') != 'V'");
            if (!isNullOrEmpty(filter))
                strQuery.AppendLine("   AND " + filter);
            if(ordem!=null)
                strQuery.AppendLine(" ORDER BY " + ordem);

            return this.getDataTable(strQuery);
        }
        #endregion

        #region TABELAS RELACIONADAS (Parent & Childrens)
        /// <summary>
        /// Retorna as Tabelas que estao no dominio OU contra-dominio da lista de tabelas desejadas
        /// </summary>
        /// <param name="tables">Lista de tabelas</param>
        /// <returns>Dados das Tabelas Relacionadas</returns>
        public DataTable getRelatedTables(List<string> tables)
        { return this.getRelatedTables(tables, null); }

        /// <param name="tables">Lista de tabelas</param>
        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <returns>Dados das Tabelas Relacionadas</returns>
        public DataTable getRelatedTables(List<string> tables, string filter)
        { return this.getRelatedTables(tables, filter, "SX2.X2_NOME"); }

        /// <param name="tables">Lista de tabelas</param>
        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <param name="ordem">campos separados por virgula pra organizar o retorno</param>
        /// <returns>Dados das Tabelas Relacionadas</returns>
        public DataTable getRelatedTables(List<string> tables, string filter, string ordem)
        {
            string tabelas = getStringArr(tables);
            StringBuilder strQuery = new StringBuilder();
            
            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT DISTINCT SX2.*");
            strQuery.AppendLine("  FROM SX9"+this.EMPRESA+"0 SX9");
            strQuery.AppendLine(" INNER JOIN SX2"+this.EMPRESA+"0 SX2");
            strQuery.AppendLine("    ON SX2.X2_CHAVE = SX9.X9_DOM");
            strQuery.AppendLine("    OR SX2.X2_CHAVE = SX9.X9_CDOM");
            strQuery.AppendLine(" WHERE ( SX9.X9_DOM  IN (" + tabelas + ")");
            strQuery.AppendLine("      OR SX9.X9_CDOM IN (" + tabelas + ") )");
            if (filter != null)
                strQuery.AppendLine("   AND " + filter);
            strQuery.AppendLine(" ORDER BY " + ordem);

            return this.SelectDataTable(strQuery);
        }
        #endregion

        #region TABELAS RELACIONADAS (parent)
        /// <summary>
        /// Retorna as Tabelas que estao no dominio da lista de tabelas desejadas
        /// </summary>
        /// <param name="tables">Lista de tabelas</param>
        /// <returns>Dados das tabelas Pais</returns>
        public DataTable getParentTables(List<string> tables)
        { return this.getParentTables(tables, null); }

        /// <param name="tables">Lista de tabelas</param>
        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <returns>Dados das tabelas Pais</returns>
        public DataTable getParentTables(List<string> tables, string filter)
        { return this.getParentTables(tables, filter, "X2_NOME"); }

        /// <param name="tables">Lista de tabelas</param>
        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <param name="ordem">campos separados por virgula pra organizar o retorno</param>
        /// <returns>Dados das tabelas Pais</returns>
        public DataTable getParentTables(List<string> tables, string filter, string ordem)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT " + RelatedFieldsToShow);
            strQuery.AppendLine("  FROM SX9"+this.EMPRESA+"0 SX9");
            strQuery.AppendLine(" INNER JOIN SX2"+this.EMPRESA+"0 SX2");
            strQuery.AppendLine("    ON SX2.X2_CHAVE = SX9.X9_DOM");
            strQuery.AppendLine(" WHERE SX9.X9_CDOM IN (" + getStringArr(tables) + ")");
            if (filter != null)
                strQuery.AppendLine("   AND " + filter);
            if(ordem!=null)
                strQuery.AppendLine(" ORDER BY " + ordem);

            return this.SelectDataTable(strQuery);
        }

        public DataTable getComboParentTables(List<string> tables, string filter)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT " + RelatedFieldsToShow);
            strQuery.AppendLine("  FROM SX9"+this.EMPRESA+"0 SX9");
            strQuery.AppendLine(" INNER JOIN SX2"+this.EMPRESA+"0 SX2");
            strQuery.AppendLine("    ON SX2.X2_CHAVE = SX9.X9_DOM");
            strQuery.AppendLine(" WHERE SX9.X9_DOM IN (" + getStringArr(tables) + ")");
            if (filter != null)
                strQuery.AppendLine("   AND " + filter);
            
            strQuery.AppendLine(" ORDER BY X2_NOME");

            return this.SelectDataTable(strQuery);
        }
        #endregion

        #region TABELAS RELACIONADAS (childrens)
        /// <summary>
        /// Retorna as Tabelas que estao no contra-dominio da lista de tabelas desejadas
        /// </summary>
        /// <param name="tables">Lista de tabelas</param>
        /// <returns>Dados das tabelas Filhas</returns>
        public DataTable getChildTables(List<string> tables)
        { return this.getChildTables(tables, null); }
        
        /// <param name="tables">Lista de tabelas</param>
        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <returns>Dados das tabelas Filhas</returns>
        public DataTable getChildTables(List<string> tables, string filter)
        { return this.getChildTables(tables, filter, "X2_NOME"); }

        /// <param name="tables">Lista de tabelas</param>
        /// <param name="filter">Filtro de SQL, não usar AND, OR ou derivados no inicio da consulta.</param>
        /// <param name="ordem">campos separados por virgula pra organizar o retorno</param>
        /// <returns>Dados das tabelas Filhas</returns>
        public DataTable getChildTables(List<string> tables, string filter, string ordem)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT " + RelatedFieldsToShow);//DISTINCT SX2.*");
            strQuery.AppendLine("  FROM SX9"+this.EMPRESA+"0 SX9");
            strQuery.AppendLine(" INNER JOIN SX2"+this.EMPRESA+"0 SX2");
            strQuery.AppendLine("    ON SX2.X2_CHAVE = SX9.X9_CDOM");
            strQuery.AppendLine(" WHERE SX9.X9_DOM IN (" + getStringArr(tables) + ")");
            if (filter != null)
                strQuery.AppendLine("   AND " + filter);
            if(ordem!=null)
                strQuery.AppendLine(" ORDER BY " + ordem);

            return this.SelectDataTable(strQuery);
        }

        public DataTable getComboChildTables(List<string> tables, string filter)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT " + RelatedFieldsToShow);
            strQuery.AppendLine("  FROM SX9"+this.EMPRESA+"0 SX9");
            strQuery.AppendLine(" INNER JOIN SX2"+this.EMPRESA+"0 SX2");
            strQuery.AppendLine("    ON SX2.X2_CHAVE = SX9.X9_CDOM");
            strQuery.AppendLine(" WHERE SX9.X9_CDOM IN (" + getStringArr(tables) + ")");
            if (filter != null)
                strQuery.AppendLine("   AND " + filter);
            
            strQuery.AppendLine(" ORDER BY X2_NOME");

            return this.SelectDataTable(strQuery);
        }
        #endregion

        #region CLAUSULAS DAS TABELAS RELACIONADAS
        public List<string> getRelatedClauses(string tabDom, string tabCDom)
        { return this.getRelatedClauses(tabDom, tabCDom, null); }
        public List<string> getRelatedClauses(string tabDom, string tabCDom, string filter)
        { return this.getRelatedClauses(tabDom, tabCDom, filter, "X9_DOM, X9_CDOM"); }
        public List<string> getRelatedClauses(string tabDom, string tabCDom, string filter, string order)
        {
            List<string>  value    = new List<string>();
            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine("USE SigaWeb");
            strQuery.AppendLine("-- ----- --");
            strQuery.AppendLine("SELECT X9_EXPDOM [DOM], X9_EXPCDOM [CDOM]");
            strQuery.AppendLine("  FROM SX9"+this.EMPRESA+"0 SX9");
            strQuery.AppendLine(" WHERE X9_DOM  = '" + tabDom  + "'");
            strQuery.AppendLine("   AND X9_CDOM = '" + tabCDom + "'");
            if (filter != null)
                strQuery.AppendLine("   AND " + filter);
            strQuery.AppendLine(" ORDER BY " + order);

            DataTable dt = this.SelectDataTable(strQuery);

            if (dt.DefaultView.Count > 0)
            {
                value.Add(dt.DefaultView[0].Row["DOM" ].ToString());
                value.Add(dt.DefaultView[0].Row["CDOM"].ToString());
            }

            return value;
        }
        #endregion

        #region LIST<string> para String(text, text)
        /// <summary>
        /// Transforma List.string. para string com separador, por padrão, ponto e virgula (;)
        /// </summary>
        /// <param name="value">lista de tabelas</param>
        /// <returns>string da lista separada por ponto e virgula (;)</returns>
        public static string getStringArr(List<string> value)
        { return getStringArr(value, "'"); }
        
        /// <param name="value">lista de tabelas</param>
        /// <param name="sep">separador</param>
        /// <returns>string da lista separada com o separador desejado</returns>
        public static string getStringArr(List<string> value, string sep)
        {
            string sRet = "";
            sep = sep.Trim();
            foreach (string str in value)
            { sRet += "," + sep + str.ToString().Trim() + sep; }

            if (sRet.Length > 0)
                sRet = sRet.Substring(1);

            return sRet;
        }
        #endregion

        private bool isNullOrEmpty(object oValue)
        {
            return oValue == null;
        }
    }
}
