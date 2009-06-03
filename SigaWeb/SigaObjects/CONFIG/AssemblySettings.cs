using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Xml;

namespace SigaObjects.CONFIG
{
    class AssemblySettings
    {
        private IDictionary settings;

        public AssemblySettings()
            : this(Assembly.GetCallingAssembly())
        {
        }

		public AssemblySettings( Assembly asm )
		{
			settings = GetConfig(asm);
		}

		public string this[ string key ]
		{
			get
			{
				string settingValue = null;

				if( settings != null )
				{
					settingValue = settings[key] as string;
				}

				return(settingValue == null ? "" : settingValue);
			}
		}

        public static IDictionary GetConfig()
        {
            return GetConfig(Assembly.GetCallingAssembly());
        }
        public static IDictionary GetConfig(Assembly asm)
        {
            return GetConfig(asm.CodeBase + ".config");
        }
        public static IDictionary GetConfig(string cfgFile)
        {
            return GetConfig(cfgFile, "appSettings");
        }
        public static IDictionary GetConfig(string cfgFile, string nodeName)
        {
            // Open and parse configuration file for specified
            // assembly, returning collection to caller for future
            // use outside of this class.
            //
            try
            {
                //string cfgFile = asm.CodeBase + ".config";
                //const string nodeName = "appSettings";//"assemblySettings";

                XmlDocument doc = new XmlDocument();
                doc.Load(new XmlTextReader(cfgFile));

                XmlNodeList nodes = doc.GetElementsByTagName(nodeName);

                foreach (XmlNode node in nodes)
                {
                    if (node.LocalName == nodeName)
                    {
                        DictionarySectionHandler handler = new DictionarySectionHandler();
                        return (IDictionary)handler.Create(null, null, node);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return (null);
        }
    }
}
