#region USING
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
#endregion

namespace SigaObjects.CONFIG
{
    class ExternalConfiguration
    {
        public static List<DictionaryEntry> getSettings()                     
        {
            return getSettings(AssemblySettings.GetConfig());
        }
        public static List<DictionaryEntry> getSettings(string filename)      
        {
            return getSettings(AssemblySettings.GetConfig(filename));
        }
        public static List<DictionaryEntry> getSettings(string filename, string nodeName)
        {
            return getSettings(AssemblySettings.GetConfig(filename, nodeName));
        }
        public static List<DictionaryEntry> getSettings(Assembly asm)         
        {
            return getSettings(AssemblySettings.GetConfig(asm));
        }
        public static List<DictionaryEntry> getSettings(IDictionary iSettings)
        {
            List<DictionaryEntry> confs = new List<DictionaryEntry>();

            foreach (DictionaryEntry entry in iSettings)
            {
                confs.Add(entry);
            }

            return confs;
        }

        public static string getSettingByKey(string sKey, string filename)    
        {
            foreach(DictionaryEntry entry in getSettings(filename))
                if(entry.Key.ToString() == sKey)
                    return entry.Value.ToString();

            return null;
        }
    }
}
