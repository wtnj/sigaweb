using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SigaWebInstaller
{
    public class CONFIG
    {
        private Hashtable myHashtable = new Hashtable();

        public object this[string key]
        {
            get
            {
                object oRet;

                oRet = myHashtable[key];

                if (oRet == null)
                    oRet = new object();

                return oRet;
            }

            set
            {
                myHashtable.Add(key, value);
            }
        }

        private void initializer(string fileConfig)
        {

        }
        public CONFIG()
        { initializer(""); }
        public CONFIG(string fileConfig)
        { initializer(fileConfig); }
    }
}
