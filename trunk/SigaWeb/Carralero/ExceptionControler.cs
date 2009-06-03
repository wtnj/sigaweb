using System;
using System.Collections.Generic;
using System.Text;

namespace Carralero
{
    public class ExceptionControler
    {
        #region Property

        Exception ex = new Exception();
        string strException = "";

        public Exception EXCEPTION
        { 
            get { return ex; } 
            private set { ex = value; } 
        }

        public string StrException
        {
            get { return strException; }
            set { this.strException = value; }
        }

        #endregion

        #region Constructors

        public ExceptionControler(){ }
        public ExceptionControler(Exception e){ this.EXCEPTION = e; }

        #endregion

        #region Getters

        public string getStrException()
        { 
            return getStrException(this.EXCEPTION); 
        }

        public Exception getFullException()
        {
            return getFullException(this.EXCEPTION);
        }

        public static string getStrException(Exception e)
        {
            StringBuilder strEx = new StringBuilder();
            Exception _ex = e;

            do
            {
                strEx.AppendLine(">>> [ " + _ex.Source + " ] <<<");
                strEx.AppendLine(_ex.Message);
                strEx.AppendLine(new string('-', 110));
                strEx.AppendLine();

                _ex = _ex.InnerException;
            } while (_ex != null);

            return strEx.ToString();
        }

        public static Exception getFullException(Exception e)
        {
            string source = "";
            StringBuilder strEx = new StringBuilder();
            Exception _ex = e;
            string stackError = new string('=',110) + "\r\n"
                              + e.StackTrace        + "\r\n"
                              + new string('=',110);
            do
            {
                strEx.AppendLine(_ex.Message);
                strEx.AppendLine(new string('-', 110));
                strEx.AppendLine();
                source = _ex.Source;

                _ex = _ex.InnerException;
            } while (_ex != null);
            strEx.AppendLine(stackError);

            Exception exRet = new Exception(strEx.ToString());
            exRet.Source = source;

            return exRet;
        }

        #endregion

        #region Setters
        public void setException(Exception e)
        {
            this.EXCEPTION = e;
        }
        public void setFullException()
        {
            this.EXCEPTION = getFullException(this.EXCEPTION);
        }
        public void setStrException(Exception e)
        {
            this.StrException = getStrException(this.EXCEPTION);
        }
        #endregion
    }
}