using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Carralero
{
    public class ExportTxt
    {
        private string strFileName;
        public string FileName
        { get { return strFileName; } set { strFileName = value; } }

        public ExportTxt() { }
        public ExportTxt(string strFileName) 
        {
            this.initialize(strFileName);
        }

        private void initialize(string strFileName) 
        {
            this.strFileName = strFileName;
        }

        public void setDataTable(DataTable dataTable, bool withHeaders)
        {
            string arq = FileName;
            if (FileName == null) { return; }

            if (!System.IO.File.Exists(arq))
                File.Create(arq).Close();

            TextWriter arquivo = System.IO.File.AppendText(arq);

            try
            {
                string linha = "";
                if (withHeaders)
                {
                    foreach (DataColumn dc in dataTable.Columns)
                        linha = linha + dc.Caption + ";";

                    arquivo.WriteLine(linha);
                }

                foreach (DataRow dr in dataTable.Rows)
                {
                    linha = null;
                    foreach (object o in dr.ItemArray)
                        linha = linha + o.ToString() + ";";

                    arquivo.WriteLine(linha);
                }
                arquivo.Flush();
            }
            catch (Exception e)
            {
                throw Carralero.ExceptionControler.getFullException(e);
            }
            finally
            {
                arquivo.Close();
                arquivo.Dispose();
            }
        }
    }
}
