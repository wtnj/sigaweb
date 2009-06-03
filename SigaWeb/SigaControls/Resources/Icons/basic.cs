using System;
using System.Collections.Generic;
using System.Text;

using Gizmox.WebGUI.Common.Resources;

namespace SigaControls.Resources.Icons
{
    public class basic
    {
        #region NOME DOS ARQUIVOS
        private static List<object>
            _page_add   , _page_delete , _page_edit, _page_excel
            , _page_view, _page_pdf    , _search;
        #endregion

        #region PROPRIEDADE
        public static List<object> PageAdd      
        {
            get
            {
                _page_add = new List<object>();
                _page_add.Add(new IconResourceHandle("basic.page_add.png"));
                _page_add.Add("Novo");
                return _page_add;
            }
        }
        public static List<object> PageDelete   
        {
            get
            {
                _page_delete = new List<object>();
                _page_delete.Add(new IconResourceHandle("basic.page_delete.png"));
                _page_delete.Add("Excluir");
                return _page_delete;
            }
        }
        public static List<object> PageEdit     
        {
            get
            {
                _page_edit = new List<object>();
                _page_edit.Add(new IconResourceHandle("basic.page_edit.png"));
                _page_edit.Add("Editar");
                return _page_edit;
            }
        }
        public static List<object> PageExcel    
        {
            get
            {
                _page_excel = new List<object>();
                _page_excel.Add(new IconResourceHandle("basic.page_excel.png"));
                _page_excel.Add("Gerar Excel");
                return _page_excel;
            }
        }
        public static List<object> PageView     
        {
            get
            {
                _page_view = new List<object>();
                _page_view.Add(new IconResourceHandle("basic.page_view.png"));
                _page_view.Add("Visualizar");
                return _page_view;
            }
        }
        public static List<object> PagePDF      
        {
            get
            {
                _page_pdf = new List<object>();
                _page_pdf.Add(new IconResourceHandle("basic.page_pdf.png"));
                _page_pdf.Add("Gerar PDF");
                return _page_pdf;
            }
        }
        public static List<object> Search       
        {
            get
            {
                _search = new List<object>();
                _search.Add(new IconResourceHandle("basic.search.png"));
                _search.Add("Pesquisar");
                return _search;
            }
        }
        #endregion
    }
}
