using System;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects.Reports.Fields
{
    public class FieldsVo
    {
        private int id = 0, mainId = 0;

        private string codigo, grouping;

        #region Getters and Setters
        public int MAINID
        {
            get { return mainId; }
            set { this.mainId = value; }
        }
        public string GROUPING
        {
            get { return grouping; }
            set { this.grouping = value; }
        }
        public string CODIGO
        {
            get { return codigo; }
            set { this.codigo = value; }
        }
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }
        #endregion

        #region Construtor
        public FieldsVo()
        {
        }
        public FieldsVo(int id)
        {
            this.ID = id;
        }
        public FieldsVo(int mainId, string grouping)
        {
            this.MAINID = mainId;
            this.GROUPING = grouping;
        }
        public FieldsVo(int mainId, string grouping, string codigo)
        {
            this.MAINID = mainId;
            this.GROUPING = grouping;
            this.CODIGO = codigo;
        }
        public FieldsVo(int mainId, string grouping, string codigo, int id)
        {
            this.MAINID = mainId;
            this.GROUPING = grouping;
            this.CODIGO = codigo;
            this.ID = id;
        }
        #endregion
    }
}