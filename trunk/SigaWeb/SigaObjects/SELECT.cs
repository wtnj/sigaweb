using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SigaObjects
{
    public class SELECT : DataMaster
    {
        protected static string fromDatabase = "USE SigaWeb\r\n-- ----- --\r\n";
        protected static StringBuilder query = new StringBuilder(fromDatabase);
        protected static string        ident = "";
        public struct AndOrNone
        {
            public static string NONE = " ";
            public static string AND  = "   AND ";
            public static string OR   = "    OR ";
        }
        public StringBuilder QUERY
        {
            get { return query; }
            set { query = value; }
        }
        public string        IdentMargin
        { get { return ident; } set { ident = value; } }

        public SELECT()
        {
            if (!this.QUERY.ToString().Contains(fromDatabase))
                this.addInQuery(fromDatabase + this.QUERY.ToString());

            new SELECT(this.QUERY);
        }
        public SELECT(StringBuilder Query)
        {
            this.QUERY = Query;
        }
        public SELECT(string FIELDS)
        {
            this.QUERY = new StringBuilder();
            
            if (!this.QUERY.ToString().Contains(fromDatabase))
                this.addInQuery(fromDatabase);
            
            this.addInQuery("SELECT " + FIELDS);
        }

        public OPEN   Open( string openWith )
        { return new OPEN(openWith); }
        public CLOSE  Close(string closeWith)
        { return new CLOSE(closeWith); }
        public SELECT Ident(int    setIdent )
        {
            this.IdentMargin = new string(' ', setIdent);
            return this;
        }

        public FROM   From(string  TABLE)
        { return new FROM(TABLE); }
        public FROM   From(string  TABLE, string ALIAS)
        { return new FROM(TABLE, ALIAS); }

        public void addInQuery(StringBuilder value)
        { this.addInQuery(value.ToString()); }
        public void addInQuery(string value)
        { this.QUERY.AppendLine(this.IdentMargin + value); }

        public static string addBrace(string value, string brace)
        { return addBrace(value, brace, null); }
        public static string addBrace(string value, string brace1, string brace2)
        {
            string iniBrace = brace1;
            string fimbrace = (brace2 != null) ? brace2 : brace1;
            return iniBrace + value + fimbrace;
        }

        public DataTable getData()
        {
            //Connection.ConnectionString = @"Initial Catalog=SigaWeb;Data Source=.;Persist Security Info=True";
            return this.getDataTable(this.QUERY);
        }

        /// <summary>
        /// Passe uma tabela com apenas uma coluna.
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <returns>Lista de Strings</returns>
        public List<string> getColunaAsList(DataTable table)
        {
            int registros = table.DefaultView.Count;
            List<string> colunas = new List<string>();

            if (registros <= 0)
                return new List<string>();

            for (int i = 0; i < registros; i++)
            {
                colunas.Add(table.DefaultView[i].Row[0].ToString());
            }

            return colunas;
        }

        //public List<string> getColuna(string columnName)
        //{
        //    return getColuna(columnName, this.getData());
        //}
        //public List<string> getColuna(string columnName, DataTable table)
        //{
        //    List<string> coluna = new List<string>();
        //    int numRegistro = table.DefaultView.Count;

        //    for (int i = 0; i < numRegistro; i++)
        //    {
        //        coluna.Add(table.DefaultView[i].Row[columnName].ToString());
        //    }

        //    return coluna;
        //}

        /// <summary>
        /// SUBCLASSES QUE EXTENDEM O FROM DO SELECT.
        /// </summary>
        #region SUBCLASSES [INNER, ON, AND, ...]
        public class FROM  : SELECT
        {
            public FROM()
            {}
            public FROM(string TABLE)
            { new FROM(TABLE, ""); }
            public FROM(string TABLE, string ALIAS)
            {
                this.QUERY.Append("  FROM " + TABLE);
                this.QUERY.AppendLine(" " + ALIAS);
            }

            public INNER   InnerJoin(string TABLE )
            { return this.InnerJoin(TABLE, ""); }
            public INNER   InnerJoin(string TABLE, string ALIAS)
            { return new INNER(TABLE, ALIAS); }
            public LEFT    LeftJoin( string TABLE )
            { return this.LeftJoin(TABLE, ""); }
            public LEFT    LeftJoin( string TABLE, string ALIAS)
            { return new LEFT(TABLE, ALIAS); }
            public RIGHT   RightJoin(string TABLE )
            { return this.RightJoin(TABLE, ""); }
            public RIGHT   RightJoin(string TABLE, string ALIAS)
            { return new RIGHT(TABLE, ALIAS); }

            public GROUPBY GroupBy(  string FIELDS)
            { return new GROUPBY(FIELDS); }
            public ORDERBY OrderBy(  string FIELDS)
            { return new ORDERBY(FIELDS); }
            public WHERE   Where()
            { return new WHERE(); }
            public WHERE   Where(    bool   first )
            { return new WHERE(first); }
            public WHERE   Where(    string FILTER)
            { return new WHERE(FILTER); }
        }

        public abstract class JOIN : FROM
        {
            public ON  On(string Filtro)
            { return new ON(Filtro); }
            public AND And()
            { return new AND(); }
            public AND And(string FILTER)
            { return new AND(FILTER); }
            public OR  Or()
            { return new OR(); }
            public OR  Or(string FILTER)
            { return new OR(FILTER); }
        }
        public class INNER : JOIN
        {
            public INNER(string TABLE)
            { new INNER(TABLE, ""); }
            public INNER(string TABLE, string ALIAS)
            {
                this.QUERY.Append(" INNER JOIN " + TABLE);
                this.QUERY.AppendLine(" " + ALIAS);
            }
        }
        public class LEFT  : JOIN
        {
            public LEFT(string TABLE)
            { new LEFT(TABLE, ""); }
            public LEFT(string TABLE, string ALIAS)
            {
                this.QUERY.Append("  LEFT JOIN " + TABLE);
                this.QUERY.AppendLine(" " + ALIAS);
            }
        }
        public class RIGHT : JOIN
        {
            public RIGHT(string TABLE)
            { new RIGHT(TABLE, ""); }
            public RIGHT(string TABLE, string ALIAS)
            {
                this.QUERY.Append(" RIGHT JOIN " + TABLE);
                this.QUERY.AppendLine(" " + ALIAS);
            }
        }

        public class AS    : SELECT
        {
            public AS(string name)
            { new AS(name, "[", "]"); }
            public AS(string name, string brace1, string brace2)
            { this.QUERY.Append(" " + brace1 + name + brace2); }
        }
        public class ON    : WHERE 
        {
            public ON(string FILTER)
            { this.addInQuery("    ON " + FILTER); }

            public AND And()
            { return new AND(); }
            public AND And(string Filtro)
            { return new AND(Filtro); }
            public BETWEEN Between(string FIELD, string fromValue, string toValue)
            { return new BETWEEN(FIELD, fromValue, toValue); }
        }
        public class AND   : WHERE 
        {
            public AND()
            { this.QUERY.Append(AndOrNone.AND); }
            public AND(string FILTRO)
            { if (FILTRO != null)this.addInQuery(AndOrNone.AND + FILTRO); }

            public BETWEEN Between(string FIELD, string fromValue, string toValue)
            { return new BETWEEN(FIELD, fromValue, toValue); }
        }
        public class OR    : WHERE 
        {
            public OR()
            { this.QUERY.Append(AndOrNone.OR); }
            public OR(string FILTRO)
            { if (FILTRO != null)this.addInQuery(AndOrNone.OR + FILTRO); }

            public BETWEEN Between(string FIELD, string fromValue, string toValue)
            { return new BETWEEN(FIELD, fromValue, toValue); }

            public AND And()
            { return new AND(); }
            public AND And(string FILTER)
            { return new AND(FILTER); }
        }

        public class BETWEEN : WHERE
        {
            public BETWEEN(string FIELD, string fromValue, string toValue)
            { this.addInQuery(FIELD + " BETWEEN '" + fromValue + "' AND '" + toValue + "'"); }
        }

        public class GROUPBY : FROM 
        {
            public GROUPBY(string FIELDS)
            { this.addInQuery(" GROUP BY " + FIELDS); }
        }
        public class WHERE   : FROM 
        {
            public WHERE()
            { this.QUERY.Append(""); }
            public WHERE(bool first)
            { this.QUERY.Append(" WHERE "); }
            public WHERE(string FILTER)
            { if(FILTER!=null)this.addInQuery(" WHERE " + FILTER); }

            public BETWEEN Between(string FIELD, string fromValue, string toValue)
            { return new BETWEEN(FIELD, fromValue, toValue); }
            public MORE    More(   string FIELD, string value, bool equal)
            { return new MORE(FIELD, value, equal); }
            public LOWER   Lower(  string FIELD, string value, bool equal)
            { return new LOWER(FIELD, value, equal); }
            public AND     And()
            { return new AND(); }
            public AND     And(    string FILTER)
            { return new AND(FILTER); }
            public OR      Or()
            { return new OR(); }
            public OR      Or(     string FILTER)
            { return new OR(FILTER); }
        }
        public class MORE    : WHERE
        {
            public MORE(string FIELD, string value, bool equal)
            { new MORE(AndOrNone.AND, FIELD, value, equal); }
            public MORE(string type, string FIELD, string value, bool equal)
            {
                string simbol = " >? ";
                simbol = simbol.Replace("?", ((equal) ? "=" : ""));
                this.addInQuery(type + FIELD + simbol + value);
            }
        }
        public class LOWER   : WHERE
        {
            public LOWER(string FIELD, string value, bool equal)
            { new MORE(AndOrNone.AND, FIELD, value, equal); }
            public LOWER(string type, string FIELD, string value, bool equal)
            {
                string simbol = " <? ";
                simbol = simbol.Replace("?", ((equal) ? "=" : ""));
                this.addInQuery(type + FIELD + simbol + value);
            }
        }
        public class ORDERBY : FROM 
        {
            public ORDERBY(string FIELDS)
            { this.addInQuery(" ORDER BY " + FIELDS); }
        }

        public class OPEN  : SELECT
        {
            public OPEN(string openWith)
            { this.QUERY.Append(" " + openWith + " "); }
        }
        public class CLOSE : SELECT
        {
            public CLOSE(string closeWith)
            { this.QUERY.Append(" " + closeWith + " "); }
        }
        #endregion
    }
}
