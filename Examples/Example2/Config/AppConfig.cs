using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using SharpConfig;
using Example2.Config.Sections;

namespace Example2.Config
{
    /// <summary>
    /// Load and save configuration.
    /// </summary>
    public class AppConfig
    {
        private const string IniFileName = "AppConfig.ini";

        private static AppConfig _instance;

        static AppConfig()
        {
            Configuration.IgnoreInlineComments = false;
        }

        public static AppConfig GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AppConfig();
            }

            return _instance;
        }

        private string _configFileName;
        private Configuration _config;        

        public GeneralSection General { get; private set; }
        public PrintingSection Printing { get; private set; } 

        public AppConfig()
        {
            General = new GeneralSection();
            Printing = new PrintingSection();

            Load();
        }

        public void Load()
        {
            Assembly asmb = Assembly.GetExecutingAssembly();
            string path = Path.GetDirectoryName(asmb.Location);
            string filename = Path.Combine(path, IniFileName);

            _configFileName = filename;
            _config = Configuration.LoadFromFile(_configFileName, Encoding.UTF8);

            General = _config[GeneralSection.Name].ToObject<GeneralSection>();
            Printing = _config[PrintingSection.Name].ToObject<PrintingSection>();
        }

        public void Save()
        {
            _config.SaveToFile(_configFileName, Encoding.UTF8);
        }
    }

}
