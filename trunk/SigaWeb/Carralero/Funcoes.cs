using System;
using System.Collections.Generic;
using System.Text;

namespace Carralero
{
    public class Funcoes
    {
        public static string getDataStr(DateTime data)
        {
            return getData(data,"yyyyMMdd");
        }
        public static string getDataCompleta(DateTime data)
        {
            return getData(data, "dddd dd/MMMM/yyyy");
        }
        public static string getDataAbreviada(DateTime data)
        {
            return getData(data, "dd-MMM-yy");
        }
        public static string getData(DateTime data)
        {
            return getData(data, "dd/MM/yyyy");
        }
        public static string getData(DateTime data, string formato)
        {
            return data.ToString(formato);
        }

        public static DateTime getDateTime(string data)
        {
            DateTime rData = new DateTime();

            data = data.Trim();
            if (data.Length > 0)
            {
                int ano = int.Parse(data.Substring(0, 4));
                int mes = int.Parse(data.Substring(4, 2));
                int dia = int.Parse(data.Substring(6, 2));

                rData = getDateTime(ano, mes, dia);
            }

            return rData;
        }
        public static DateTime getDateTime(int ano, int mes, int dia)
        {
            return new DateTime(ano, mes, dia);
        }

        public static string strZero( string value)
        { return strZero(value, 6); }
        public static string strZero( string value, int quant)
        {
            return strMore(value, quant, '0');
        }

        public static string strSpace(string value, int quant)
        { return strMore(value, quant, ' '); }
        public static string strMore( string value, int quant, char toCopy)
        {
            int iQtd = (quant - value.Length > 0) ? quant - value.Length : 0;

            return (new string(toCopy, iQtd) + value);
        }

        public static bool   preenchido(object value)
        {
            if (value.GetType() == typeof(string))
            {
                if (value.ToString() != "")   return false;
                if (value.ToString() != null) return false;
            }
            if(value.GetType() == typeof(int))
            {
                if (int.Parse(value.ToString()) > 0) return false;
            }

            return true;
        }

        #region LIST<string> para String(text, text)
        /// <summary>
        /// Transforma List.string. para string com separador, por padrão, ponto e virgula (;)
        /// </summary>
        /// <param name="value">lista de tabelas</param>
        /// <returns>string da lista separada por ponto e virgula (;)</returns>
        public static string getStringArr(List<string> value)
        { return getStringArr(value, "'"); }

        /// <param name="value">lista de tabelas</param>
        /// <param name="sep">separador</param>
        /// <returns>string da lista separada com o separador desejado</returns>
        public static string getStringArr(List<string> value, string sep)
        {
            string sRet = "";
            sep = sep.Trim();
            foreach (string str in value)
            { sRet += "," + sep + str.ToString().Trim() + sep; }

            if (sRet.Length > 0)
                sRet = sRet.Substring(1);

            return sRet;
        }
        public static List<string> IntToStr(List<int> values)
        {
            List<string> newValues = new List<string>();
            foreach (int value in values)
                newValues.Add(value.ToString());
            return newValues;
        }
        #endregion
    }
}
