using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Carralero;

namespace SigaObjects
{
    public class DataMaster
    {
        #region ATIBUTOS
        private static string defaultConnectionString = /*"Initial Catalog=Protheus10;"
                                                      + "Data Source=192.168.1.38;"
                                                      + "UID=siga;"
                                                      + "PWD=msiga;"
                                                      + "Connection timeout=3600;";*/
                                                        "Initial Catalog=dados_protheus;"
                                                      + "Data Source=server2;"
                                                      + "UID=carralero;"
                                                      + "PWD=n@osei@123";
                                                      //Persist Security Info=True";//ConfigurationSettings.AppSettings[0].ToString();
        private static string        strConn = defaultConnectionString;
        private static SqlCommand    sqlComm;
        private static SqlConnection sqlConn;
        private static StringBuilder sQuery  = null;
        #endregion

        #region PROPRIEDADES
        public static string ConnectionString
        {
            get { return DataMaster.strConn; }
            set { DataMaster.strConn = value; }
        }
        public static SqlCommand Command
        {
            get { return DataMaster.sqlComm; }
            set { DataMaster.sqlComm = value; }
        }
        public static SqlConnection Connection
        {
            get { return DataMaster.sqlConn; }
            set { DataMaster.sqlConn = value; }
        }
        protected static StringBuilder Query
        {
            get { return sQuery; }
            set { sQuery = value; }
        }
        #endregion

        #region CONSTRUTOR
        private void MountConnectionString()
        {
            defaultConnectionString = "";
            foreach (DictionaryEntry entry in CONFIG.ExternalConfiguration.getSettings())//"DATABASE.config"))
                defaultConnectionString += entry.Key.ToString() + "=" + entry.Value.ToString() + ";";
        }
        private void initializer(string _ConnString, SqlConnection sqlConnect, SqlCommand sqlCmd)
        {
            ConnectionString = _ConnString;
            if (ConnectionString == null)
            {
                this.MountConnectionString();
                ConnectionString = defaultConnectionString;//"Data Source=server2;Initial Catalog=dados_protheus;Connection timeout=3600;UID=carralero;PWD=n@osei@123";//Trusted_Connection=True";
            }

            Connection = sqlConnect;
            if (Connection == null)
            {
                Connection = new SqlConnection(ConnectionString);
            }

            Command = sqlCmd;
            if (Command == null)
            {
                Command = new SqlCommand();
                Command.CommandTimeout = 3600;
            }
        }

        public DataMaster()
        { this.initializer(null, null, null); }
        public DataMaster(string _ConnString)
        { this.initializer(_ConnString, null, null); }
        public DataMaster(string _ConnString, SqlConnection sqlConnect)
        { this.initializer(_ConnString, sqlConnect, null); }
        public DataMaster(string _ConnString, SqlConnection sqlConnect, SqlCommand sqlCmd)
        {
            this.initializer(_ConnString, sqlConnect, sqlCmd);
        }
        #endregion

        public DataTable SelectDataTable(StringBuilder sQuery)
        { return SelectDataTable(sQuery.ToString()); }
        public DataTable SelectDataTable(string        sQuery)
        {
            DataTable dtNew = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter(sQuery, Connection);
                sqlDA.Fill(dtNew);
            }
            catch (Exception e)
            {
                /*
                SELECT errorSelect = new SELECT();
                errorSelect.addInQuery("BEGIN TRY");
                errorSelect.addInQuery("--- ----- ---");
                errorSelect.addInQuery( sQuery + ";");
                errorSelect.addInQuery("--- ----- ---");
                errorSelect.addInQuery("  END TRY  ");
                errorSelect.addInQuery("BEGIN CATCH");
                errorSelect.addInQuery("    SELECT ERROR_NUMBER()    AS ErrorNumber    ");
                errorSelect.addInQuery("         , ERROR_SEVERITY()  AS ErrorSeverity  ");
                errorSelect.addInQuery("         , ERROR_STATE()     AS ErrorState     ");
                errorSelect.addInQuery("         , ERROR_PROCEDURE() AS ErrorProcedure ");
                errorSelect.addInQuery("         , ERROR_LINE()      AS ErrorLine      ");
                errorSelect.addInQuery("         , ERROR_MESSAGE()   AS ErrorMessage   ");
                errorSelect.addInQuery("  END CATCH;");

                DataTable     dtError      = errorSelect.getData();

                StringBuilder errorMessage = new StringBuilder("Erro(s) = "+dtError.DefaultView.Count);

                foreach(DataRow row in dtError.Rows)
                {
                    errorMessage.Append("Error( "           +row[0].ToString()+" )");
                    errorMessage.Append(", Severity( "      +row[1].ToString()+" )");
                    errorMessage.Append(", State( "         +row[2].ToString()+" )");
                    errorMessage.AppendLine(", Procedure( " +row[3].ToString()+" )");
                    errorMessage.Append(", Line: "          +row[4].ToString() );
                    errorMessage.AppendLine(" - Message \" "+row[5].ToString()+" \"");

                    errorMessage.AppendLine(new string('=', 100));
                }

                errorMessage.Append(ExceptionControler.getFullException(e));
                throw new Exception( errorMessage.ToString() );
                //*/

                throw ExceptionControler.getFullException(e);
            }

            return dtNew;
        }

        protected DataTable getDataTable(string        sQuery)
        { return SelectDataTable(sQuery); }
        protected DataTable getDataTable(StringBuilder sQuery)
        { return SelectDataTable(sQuery); }
    }
}