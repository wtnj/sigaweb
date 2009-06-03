using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Net.Mail;

using Carralero;

#region Controles
    using SigaControls.Report;
    using SigaControls.Session;
    using SigaControls;
#endregion

#region Sessão
    using SigaObjects.Session.SysUsers;
    using SigaObjects.Session.UsersGroups;
    using SigaObjects.Session.Empresa;
    
#endregion

#region AllObjects
    using SigaObjects.Session;
    using SigaObjects.Reports;
    using SigaObjects.CONFIG;
    using SigaObjects.Permissoes;
#endregion

#region Relatório
    using SigaObjects.Reports.Fields;
    using SigaObjects.Reports.Filters;
    using SigaObjects.Reports.GroupBy;
    using SigaObjects.Reports.OrderBy;
    using SigaObjects.Reports.Params;
    using SigaObjects.Reports.Report;
    using SigaObjects.Reports.ReportGroup;
    using SigaObjects.Reports.Table;
#endregion

using REPORT = SigaObjects.Reports;

using System.Configuration;

namespace consoleTest
{
    class Program
    {
        #region Mostra na tela os registros de toda uma coleção de tabelas
        static void showAll(List<DataTable> tableCollection)
        {
            foreach (DataTable table in tableCollection)
            {
                int numberRows = table.DefaultView.Count;
                Console.WriteLine("\tTABELA (" + table.DefaultView.Count + " registro(s))\n");
                for (int i = 0; i < numberRows; i++)
                {
                    int numberColumns = table.Columns.Count;
                    for (int j = 0; j < numberColumns; j++)
                    {
                        Console.WriteLine(
                            table.Columns[j].ColumnName +
                            " : " +
                            table.DefaultView[i][j].ToString());
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        #endregion

        static void Main(string[] args)
        {
            new SigaObjects.Comunicacao.Email().Enviar();
        }
        #region Códigos Comentados
        /*
        #region Executa todas as operações
        static void saveAll()
        {
            //saveFilters();        -- aprovado --
            //saveGroups();         -- aprovado --
            //saveOrders();         -- aprovado --
            //saveParams();         -- aprovado --
            //saveReports();        -- aprovado --
            //saveReportGroups();   -- aprovado --
            //saveTables();         -- aprovado --
        }
        static void deleteAll()
        {
            //deleteFilters();
            //deleteGroups();
            //deleteOrders();
            //deleteParams();
            //deleteTables();       -- aprovado --
            //deleteReports();      -- aprovado --
            //deleteReportGroups(); -- aprovado --
        }
        static void showAll()
        {
            foreach(DataTable table in selectAll())
            {
                int numberRows = table.Rows.Count;
                Console.WriteLine("\tTABELA (" + table.DefaultView.Count + " registro(s))\n");
                for (int i = 0; i < numberRows; i++)
                {
                    int numberColumns = table.Columns.Count;
                    for (int j = 0; j < numberColumns; j++)
                    {
                        Console.WriteLine(
                            table.Columns[j].ColumnName +
                            " : " +
                            table.DefaultView[i][j].ToString());
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Uma lista de todos os registros de todas as tabelas
        private static List<DataTable> selectAll()
        {
            List<DataTable> tables = new List<DataTable>();

            //tables.Add(selectFilters());
            //tables.Add(selectGroups());
            //tables.Add(selectOrders());
            //tables.Add(selectParams());
            tables.Add(selectReports());
            tables.Add(selectReportGroups());
            tables.Add(selectTables());

            return tables;
        }
        #endregion

        #region Retorna Listas com os registros das tabelas para save, delete, select
        static List<REPORT.OrderBy.OrderByVo> getOrders()
        {
            List<REPORT.OrderBy.OrderByVo> orders = new List<REPORT.OrderBy.OrderByVo>();

            orders.Add(new REPORT.OrderBy.OrderByVo(1,1,"SA1.NOME","Nome do cliente"));
            orders.Add(new REPORT.OrderBy.OrderByVo(3,1,"SA1.SOBRENOME","Sobrenome do cliente"));
            orders.Add(new REPORT.OrderBy.OrderByVo(2,1,"SA1.DATANASC","Data de nascimento do cliente"));
            orders.Add(new REPORT.OrderBy.OrderByVo(4,1,"SA1.CPF","Cadastro da pessoa cliente"));
            orders.Add(new REPORT.OrderBy.OrderByVo(5,1,"SA1.RG","Registro geral do cliente"));

            return orders;
        }
        static List<REPORT.GroupBy.GroupByVo> getGroups()
        {
            List<REPORT.GroupBy.GroupByVo> groups = new List<REPORT.GroupBy.GroupByVo>();

            groups.Add(new REPORT.GroupBy.GroupByVo(1,1,"SA1.NOME","Nome do cliente"));
            groups.Add(new REPORT.GroupBy.GroupByVo(3,1,"SA1.SOBRENOME","Sobrenome do cliente"));
            groups.Add(new REPORT.GroupBy.GroupByVo(2,1,"SA1.DATANASC","Data de nascimento do cliente"));
            groups.Add(new REPORT.GroupBy.GroupByVo(4,1,"SA1.CPF","Cadastro da pessoa cliente"));
            groups.Add(new REPORT.GroupBy.GroupByVo(5,1,"SA1.RG","Registro geral do cliente"));

            return groups;
        }
        static List<REPORT.Filters.FiltersVo> getFilters()
        {
            List<REPORT.FiltersFiltersVo> filters = new List<REPORT.FiltersFiltersVo>();

            //filters.Add(new FiltersVo(1,1,"SA1","Nome","Mario","LIKE"));
            //filters.Add(new FiltersVo(2,1,"SA1","DATANASC","01/01/2050",">="));
            //filters.Add(new FiltersVo(3,1,"SA1","DATANASC","31/10/2051","<="));
            filters.Add(new REPORT.Filters.FiltersVo(1, "SA1", "Nome", "MARIO", "LIKE"));
            filters.Add(new REPORT.Filters.FiltersVo(1, "SA1", "DATANASC", "01/01/2009", ">="));
            filters.Add(new REPORT.Filters.FiltersVo(1, "SA1", "DATANASC", "31/10/2010", "<="));
            filters.Add(new REPORT.Filters.FiltersVo(1, "SA1", "SOBRENOME", "asdasd", "IN"));
            filters.Add(new REPORT.Filters.FiltersVo(1, "SA1", "RG", "023340989", "NOT IN"));

            return filters;
        }
        static List<REPORT.Params.ParamsVo> getParams()
        {
            List<REPORT.Params.ParamsVo> parameters = new List<REPORT.Params.ParamsVo>();

            parameters.Add(new REPORT.Params.ParamsVo(1,"SA1","NOME","Capitalize"));
            parameters.Add(new REPORT.Params.ParamsVo(1,"SA1","SOBRENOME","Capitalize"));
            parameters.Add(new REPORT.Params.ParamsVo(1,"SA1","DATANASC","dd/MM/yyyy"));
            parameters.Add(new REPORT.Params.ParamsVo(1,"SA1","CPF","###,###,###-###"));
            parameters.Add(new REPORT.Params.ParamsVo(1,"SA1","RG","##,###,###-#"));

            return parameters;
        }
        static List<REPORT.Report.ReportVo> getReports()
        {
            List<REPORT.Report.ReportVo> reports = new List<REPORT.Report.ReportVo>();

            reports.Add(new REPORT.Report.ReportVo(1, "Relatório do mario", "01", "02", "weasel"));
            reports.Add(new REPORT.Report.ReportVo(1, "Relatório do bruno", "01", "02", "malgayviano"));
            reports.Add(new REPORT.Report.ReportVo(1, "Relatório do douglas", "01", "02", "fozzie"));
            reports.Add(new REPORT.Report.ReportVo(1, "Relatório do fernando", "01", "02", "vovô"));
            reports.Add(new REPORT.Report.ReportVo(1, "Relatório da beth balanco", "01", "02", "beth balanco meu amor"));

            return reports;
        }
        static List<REPORT.ReportGroup.ReportGroupVo> getReportGroups()
        {
            List<REPORT.ReportGroup.ReportGroupVo> reportGroups = new List<REPORT.ReportGroup.ReportGroupVo>();

            reportGroups.Add(new REPORT.ReportGroup.ReportGroupVo("Super Relatórios"));
            reportGroups.Add(new REPORT.ReportGroup.ReportGroupVo("Carralero Relatórios"));
            reportGroups.Add(new REPORT.ReportGroup.ReportGroupVo("Sucobom Soníferos SA"));
            reportGroups.Add(new REPORT.ReportGroup.ReportGroupVo("Rhenen Consultoria"));
            reportGroups.Add(new REPORT.ReportGroup.ReportGroupVo("FSB comércios"));

            return reportGroups;
        }
        static List<REPORT.Table.TableVo> getTables()
        {
            List<REPORT.Table.TableVo> tables = new List<REPORT.Table.TableVo>();

            tables.Add(new REPORT.Table.TableVo(6, "SA1", "INNER", "BA1"));
            tables.Add(new REPORT.Table.TableVo(6, "SA2", "LEFT", "BA2"));
            tables.Add(new REPORT.Table.TableVo(6, "SA3", "INNER", "BA3"));
            tables.Add(new REPORT.Table.TableVo(6, "SA4", "OUTER", "BA4"));
            tables.Add(new REPORT.Table.TableVo(6, "SA5", "RIGHT", "BA5"));

            return tables;
        }
        #endregion

        #region Save
        static int saveOrders()
        {
            return new OrderByDao().save(getOrders());
        }
        static int saveGroups()
        {
            return new GroupByDao().save(getGroups());
        }
        static int saveFilters()
        {
            return new FiltersDao().save(getFilters());
        }
        static int saveParams()
        {
            return new ParamsDao().save(getParams());
        }
        static int saveReports()
        {
            return new ReportDao().save(getReports());
        }
        static int saveReportGroups()
        {
            return new ReportGroupDao().save(getReportGroups());
        }
        static int saveTables()
        {
            return new TableDao().save(getTables());
        }
        #endregion

        #region Delete
        static int deleteOrders()
        {
            return new OrderByDao().delete(getOrders());
        }
        static int deleteGroups()
        {
            return new GroupByDao().delete(getGroups());
        }
        static int deleteFilters()
        {
            return new FiltersDao().delete(getFilters()[0].MAINID);
        }
        static int deleteParams()
        {
            return new ParamsDao().delete(getParams()[0].MAINID);
        }
        static int deleteReports()
        {
            return new ReportDao().delete(getReports()[0].IDREPORTGROUP);
        }
        static int deleteReportGroups()
        {
            return new ReportGroupDao().delete();
        }
        static int deleteTables()
        {
            //return new TableDao().delete(getTables()[0].IDREPORT);
            return 1;
        }
        #endregion

        #region Select
        static DataTable selectOrders(){
            return new OrderByDao().select(1);
        }
        static DataTable selectGroups(){
            return new GroupByDao().select(1);
        }
        static DataTable selectFilters(){
            return new FiltersDao().select(1);
        }
        static DataTable selectParams(){
            return new ParamsDao().select(1);
        }
        static DataTable selectReports(){
            return new ReportDao().select(1);
        }
        static DataTable selectReportGroups(){
            return new ReportGroupDao().select();
        }
        static DataTable selectTables(){
            //return new TableDao().select(6);
            return new DataTable();
        }
        #endregion

        #region SHOWCONFIG
        public static void SHOWCONFIG()
        {
            WRITEln(" "+new string('_', Console.BufferWidth-2));
            WRITEln("Buscando Configuraçoes\r\n...");
            // For read access you do not need to call the OpenExeConfiguraton

            WRITEln("");
            WRITEln("AppSettings:", ConsoleColor.White);
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                Console.WriteLine("Key  : {0}\r\nValue: {1}\r\n", key, value);
            }

            WRITEln("");
            WRITEln("ConnectionStrings:", ConsoleColor.White);
            for (int i=0;i<ConfigurationManager.ConnectionStrings.Count;i++)
            {
                string name = ConfigurationManager.ConnectionStrings[i].Name;
                string value = ConfigurationManager.ConnectionStrings[name].ConnectionString;
                Console.WriteLine("Name : {0}\r\nValue: {1}\r\n", name, value);
            }

            WRITEln("Terminou!");
        }
        #endregion
        #region Evento ControlC (cancelar)
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion
        #region Comandos Comuns de Console
        public static void pause()
        { WRITEln("Pressione qualquer tecla pra continuar...",ConsoleColor.Red); Console.ReadKey(); }

        #region ESCREVE na tela.
        public static void WRITE(object value)
        { WRITE(value, Console.ForegroundColor); }
        public static void WRITE(object value, ConsoleColor textCor)
        { WRITE(value, textCor, Console.BackgroundColor); }
        public static void WRITE(object value, ConsoleColor textCor, ConsoleColor backCor)
        {
            Console.ForegroundColor = textCor;
            Console.BackgroundColor = backCor;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void WRITEln(object value)
        { WRITEln(value, Console.ForegroundColor); }
        public static void WRITEln(object value, ConsoleColor textCor)
        { WRITEln(value, textCor, Console.BackgroundColor); }
        public static void WRITEln(object value, ConsoleColor textCor, ConsoleColor backCor)
        {
            Console.ForegroundColor = textCor;
            Console.BackgroundColor = backCor;
            Console.WriteLine(value);
            Console.ResetColor();
        }
        #endregion

        #region ESCREVE na tela com NUMERO DA LINHA
        public static void WriteWithLine(StringBuilder value)
        { WriteWithLine(value.ToString()); }
        public static void WriteWithLine(string value)
        {
            string[] query = value.Replace("\r", "").Split('\n');

            for (int iRow = 0; iRow < query.Length; iRow++)
            {
                int row = iRow + 1;
                string linha = Carralero.Funcoes.strSpace(row.ToString(), 3) + " ";
                WRITE(linha, ConsoleColor.Yellow);
                WRITEln(query.GetValue(iRow), ConsoleColor.White);
            }
        }
        #endregion
        #endregion
         */
#endregion
    }
}