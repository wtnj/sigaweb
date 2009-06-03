using System;
using System.Data;
using System.IO;
using com.lowagie.text;
using com.lowagie.text.pdf;

namespace Carralero
{
    public class ExportPdf
    {
        private string strFileName;
        private Table aTable ;
        private Document document = new Document(PageSize.A1.rotate());

        public string FileName
        { get { return strFileName; } set { strFileName = value; } }

        public ExportPdf() { }
        public ExportPdf(string fileName)
        { this.initialize(fileName); }
        public ExportPdf(string fileName, bool visualize)
        { this.initialize(fileName); }

        protected void initialize(string fileName) 
        {
            try
            {
                this.FileName = fileName;                        
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }

        public void setDataTable(DataTable dataTable, bool withHeaders)
        {
            try 
            {
                PdfWriter.getInstance(document, new FileStream(this.FileName, FileMode.Create));                
                document.open();
                //document.addTitle(this.FileName);

                int row = 0;
                int col = 0;
                aTable = new Table(dataTable.Columns.Count, dataTable.Rows.Count); 

                if (withHeaders)
                {
                    foreach (DataColumn dc in dataTable.Columns)
                        setCell(row, col++, dc.Caption);

                    row++;
                    col = 0;
                }

                foreach (DataRow dr in dataTable.Rows)
                {
                    foreach (object o in dr.ItemArray)
                        setCell(row, col++, o);

                    row++;
                    col = 0;
                }

                document.add(aTable);                                           
                document.close();
            }
            catch (Exception e)
            { 
                throw Carralero.ExceptionControler.getFullException(e);
            }
        }           
            
        private void setCell(int row, int col, object value)
        {
            try
            {              
                aTable.setAutoFillEmptyCells(false);
                aTable.setTableFitsPage(true);
                aTable.setPadding(0);
                                           
                aTable.addCell(new Cell(value.ToString()), row, col);
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
    }
}
