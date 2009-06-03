using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Carralero
{
    public class DataTables
    {
        #region ...
        #endregion

        #region METHODS
        public static void setColumnVisible(DataTable datatable, bool returnError, string columnName, bool visible)
        {
            try
            {
                datatable.Columns.Remove(columnName);
            }
            catch (Exception err)
            { if (returnError)throw err; }
        }
        #endregion
    }
}
