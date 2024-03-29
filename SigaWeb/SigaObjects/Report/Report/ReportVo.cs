using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Report
{
    public class ReportVo
    {
        private bool isLoaded = false;

        private int    id = 0;
        private int    idReportGroup = 0;
        private string nome = "", empresa = "", filial = "", username = "";

        private Table.TableVo table;// = new Table.TableVo();

        #region Getters & Setters
        public bool   LOADED       
        {
            get{ return isLoaded;  }
            set{ isLoaded = value; }
        }

        public int    ID           
        {
            get { return id;}
            set { this.id = value; }
        }
        public int    IDREPORTGROUP
        {
            get { return idReportGroup;}
            set { this.idReportGroup = value; }
        }
        public string NOME         
        {
            get { return nome;}
            set { this.nome = value; }
        }
        public string EMPRESA      
        {
            get { return empresa;}
            set { this.empresa = value; }
        }
        public string FILIAL       
        {
            get { return filial;}
            set { this.filial = value; }
        }
        public string USERNAME     
        {
            get { return username;}
            set { this.username = value; }
        }

        public Table.TableVo TABLE 
        {
            get
            {
                if( table!=null)
                    return table;
                
                return new Table.TableVo();
            }
            set { table = value; }
        }
        #endregion

        #region Construtor
        public ReportVo()
        {
        }
        public ReportVo(int id)
        {
            this.ID = id;
        }
        public ReportVo(int id, int idReportGroup)
        {
            this.ID = id;
            this.IDREPORTGROUP = idReportGroup;
        }
        public ReportVo(string nome, string empresa, string filial, string username)
        {
            this.NOME = nome;
            this.EMPRESA = empresa;
            this.FILIAL = filial;
            this.USERNAME = username;
        }
        public ReportVo(int idReportGroup, string nome, string empresa, string filial, string username)
        {
            this.IDREPORTGROUP = idReportGroup;
            this.NOME = nome;
            this.EMPRESA = empresa;
            this.FILIAL = filial;
            this.USERNAME = username;
        }
        public ReportVo(int id, int idReportGroup, string nome, string empresa, string filial, string username)
        {
            this.ID = id;
            this.IDREPORTGROUP = idReportGroup;
            this.NOME = nome;
            this.EMPRESA = empresa;
            this.FILIAL = filial;
            this.USERNAME = username;
        }
        #endregion
    }
}