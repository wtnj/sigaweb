using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SigaObjects.Reports.Fields
{
    public class FieldsDao : SELECT
    {
        #region Members
        public static String ValueMember
        {
            get { return ""; }
        }
        public static String DisplayMember
        {
            get { return ""; }
        }
        #endregion

        #region Save
        public int save(List<FieldsVo> fields)
        {
            int cont = 0;
            foreach (FieldsVo field in fields)
                cont += save(field);
            return cont;
        }
        public int save(FieldsVo field)
        {
            if (field.ID == 0)
                return insert(field);
            else
                return update(field);
        }
        #endregion

        #region Insert
        public int insert(FieldsVo field)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.Append("INSERT INTO fields");
            this.QUERY.AppendLine("(mainId, codigo, grouping)");

            this.QUERY.Append("VALUES(");
            this.QUERY.Append(""  + field.MAINID   + " ,");
            this.QUERY.Append("'" + field.CODIGO   + "',");
            this.QUERY.Append("'" + field.GROUPING + "'");
            this.QUERY.AppendLine(   ")");

            return getData().DefaultView.Count;
        }
        #endregion

        #region Update
        public int update(FieldsVo field)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("UPDATE fields");
            this.QUERY.AppendLine("   SET mainId   =  " + field.MAINID);
            this.QUERY.AppendLine("     , codigo   = '" + field.CODIGO   + "'");
            this.QUERY.AppendLine("     , grouping = '" + field.GROUPING + "'");
            this.QUERY.AppendLine(" WHERE id = " + field.ID);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Delete
        public int delete(List<FieldsVo> fields)
        {
            int cont = 0;
            foreach (FieldsVo field in fields)
                cont += delete(field);
            return cont;
        }
        public int delete(FieldsVo field)
        {
            return delete(field.MAINID, "id = " + field.ID);
        }
        public int delete(int mainId)
        {
            return delete(mainId, null);
        }
        public int delete(int mainId, string filtro)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("DELETE FROM fields");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId);
            if(filtro != null)
                this.QUERY.AppendLine("   AND " + filtro);

            return getData().DefaultView.Count;
        }
        #endregion

        #region Listas
        public List<string> getCodigoAsList(int mainId)
        {
            return getColunaAsList(getCodigo(mainId));
        }
        #endregion

        #region Colunas
        public DataTable getCodigo(int mainId)
        {
            return getColunas(mainId, "codigo");
        }
        public DataTable getColunas(int mainId, string colunas)
        {
            this.QUERY = new StringBuilder(fromDatabase);

            this.QUERY.AppendLine("SELECT DISTINCT " + colunas);
            this.QUERY.AppendLine("  FROM fields");
            this.QUERY.AppendLine(" WHERE mainId = " + mainId);

            return getData();
        }
        #endregion

        #region Select
        public DataTable select(int mainId)
        {
            return select(mainId, null, false);
        }
        public DataTable select(int mainId, string filtro)
        {
            return select(mainId, filtro, false);
        }
        public DataTable select(int mainId, bool firstOnly)
        {
            return select(mainId,  null, false);
        }
        public DataTable select(int mainId, string filtro, bool firstOnly)
        {
            new SELECT(firstOnly ? "TOP 1 *" : "*")
            .From("fields")
            .Where("mainId = " + mainId)
            .And(filtro);

            return getData();
        }
        #endregion

        #region Load
        public void load(FieldsVo field, int mainId)
        {
            load(field, mainId, null);
        }
        public void load(FieldsVo field, int mainId, string filtro)
        {
            List<FieldsVo> fields = new List<FieldsVo>();
            fields.Add(field);

            load(fields, mainId, null);
        }
        public void load(List<FieldsVo> fields, int mainId)
        {
            load(fields, mainId, null);
        }
        public void load(List<FieldsVo> fields, int mainId, string filtro)
        {
            DataTable table = select(mainId, filtro, false);
            for (int i = 0; i < table.DefaultView.Count; i++)
            {
                FieldsVo field  = new FieldsVo();
                field.MAINID    = mainId;
                field.ID        = (int)table.DefaultView[i]["id"];
                field.CODIGO    = (string)table.DefaultView[i]["codigo"];
                field.GROUPING  = (string)table.DefaultView[i]["grouping"];

                fields.Add(field);
            }
        }
        #endregion
    }
}
