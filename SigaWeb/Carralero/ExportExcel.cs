using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CarlosAg.ExcelXmlWriter; //Microsoft.Office.Interop.Excel;

namespace Carralero
{
    public class ExportExcel
    {
        private string strFileName;
        private string strSheetName = "sheet";
        /*
        protected Excel.Application appExcel = new Excel.ApplicationClass();
        protected Excel.Workbook workbook;
        protected Excel.Worksheet worksheet;*/
        /*
        protected static Excel.AppEvents_WorkbookBeforeCloseEventHandler eventClose;
        protected static Excel.DocEvents_ChangeEventHandler eventChange;
        */
        /// <summary>
        /// using library CarlosAg
        /// </summary>
        protected Workbook      EXbook = new Workbook();
        protected Worksheet     EXsheet;
        protected WorksheetRow  EXrow;
        protected WorksheetCell EXcell;

        public    string FileName
        { get { return strFileName; } set { strFileName = value; } }

        #region CONSTUTOR
        public ExportExcel(string strFileName)
        { this.initialize(strFileName, null, false, false); }
        public ExportExcel(string strFileName, string sheetName)
        { this.initialize(strFileName, sheetName, false, false); }
        public ExportExcel(string strFileName, string sheetName, bool isVisible, bool displayAlerts)
        { this.initialize(strFileName, sheetName, isVisible, displayAlerts); }
        protected void initialize(string strFileName, string sheetName, bool isVisible, bool displayAlerts)
        {
            try
            {
                this.strFileName = strFileName;

                if (sheetName != null)
                    this.strSheetName = sheetName;

                EXsheet = EXbook.Worksheets.Add(this.strSheetName);
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        #endregion

        #region sets
        public void setRow(int row, int startCol, Array values)
        {
            try
            {
                int col = startCol;
                foreach (object o in values)
                    EXsheet.Table.Rows[row].Cells[col++] = new WorksheetCell(o.ToString());
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        public void setCol(int startRow, int col, Array values)
        {
            try
            {
                int row = startRow;
                foreach (object o in values)
                    EXsheet.Table.Rows[row++].Cells[col] = new WorksheetCell(values.ToString());
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        public void setRange(int startRow, int startCol, Array[] values)
        {
            try
            {
                int row = startRow;
                int col = startCol;
                foreach (Array rowCells in values)
                {
                    setCol(row, col, rowCells);
                    row++;
                }
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        public void setDataTable(int startRow, int startCol, DataTable dataTable, bool withHeaders)
        {
            try
            {
                int row = startRow;
                int col = startCol;

                if (withHeaders)
                {
                    foreach (DataColumn dc in dataTable.Columns)
                        setCell(row, col++, dc.Caption);

                    row++;
                    col = startCol;
                }

                foreach (DataRow dr in dataTable.Rows)
                {
                    EXrow = EXsheet.Table.Rows.Add();
                    foreach (object o in dr.ItemArray)
                        setCell(row, col++, o);

                    row++;
                    col = startCol;
                }
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        #endregion

        #region setCell
        public void setCell(int row, int col, object value)
        { setCell(row, col, value, "Arial"); }
        public void setCell(int row, int col, object value, string fontName)
        { setCell(row, col, value, fontName, 12); }
        public void setCell(int row, int col, object value, string fontName, int fontSize)
        { setCell(row, col, value, fontName, fontSize, false, false); }
        public void setCell(int row, int col, object value, bool isBold, bool isItalic)
        { setCell(row, col, value, "Arial", 12, isBold, isItalic); }
        public void setCell(int row, int col, object value, string fontName, int fontSize, bool isBold, bool isItalic)
        {
            try
            {
                //Excel.Range cell = (Excel.Range)worksheet.Cells[row, col];
                //WorksheetCell cell = 
                while (EXsheet.Table.Rows.Count < row)
                    EXsheet.Table.Rows.Add();

                //while (EXsheet.Table.Rows[row].Cells.Count < col)
                //    EXsheet.Table.Rows[row].Cells.Add();

                EXsheet.Table.Rows[row-1].Cells.Add(value.ToString()); //[col] = new WorksheetCell(value.ToString());

                //cell.Index = col;
                //cell = new WorksheetCell(value.ToString());
                //cell.Font.Name = fontName;
                //cell.Font.Size = fontSize;
                //cell.Font.Bold = isBold;
                //cell.Font.Italic = isItalic;
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        #endregion

        public void mergeRange(string startCell, string endCell)
        {
            try
            {
                //Excel.Range range = worksheet.get_Range(startCell, endCell);
                //range.MergeCells = true;
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        public void AddComment(string startCell, string endCell, string strComment)
        {
            try
            {
                //EXcell = EXsheet.Table.Rows[
                //range.AddComment(strComment);
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }

        public void autoFit(string startCell, string endCell)
        {
            try
            {
                //Excel.Range range = worksheet.get_Range(startCell, endCell);
                //range.AutoFit();
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }

        public void clearComment(string startCell, string endCell)
        {
            try
            {
                //Excel.Range range = worksheet.get_Range(startCell, endCell);
                //range.ClearComments();
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        public void clearFormats(string startCell, string endCell)
        {
            try
            {
                //Excel.Range range = worksheet.get_Range(startCell, endCell);
                //range.ClearFormats();
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }
        public void clearRange(string startCell, string endCell)
        {
            try
            {
                //Excel.Range range = worksheet.get_Range(startCell, endCell);
                //range.Clear();
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }

        public void Close()
        {
            try
            {
                EXbook.Save(this.FileName);
                //workbook.Close(true, strFileName, null); appExcel.Quit();
            }
            catch (Exception e)
            { throw Carralero.ExceptionControler.getFullException(e); }
        }

        //private void CellChange(Excel.Range Target)
        //{
            //.Show("CELULA SELECIONADA " + Target.Name);
        //}
        //private void BeforeBookClose(Excel.Workbook MyWorkbook, ref bool Cancel)
        //{
            //MessageBox.Show("Fechando Workbook!");
        //}
    }
}
