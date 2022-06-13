using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{

    public static class RepoFactory
    {
        private static Config config;

        internal const string SETTINGS_DIR = @"C:\Users\Public\Documents\WCStatistics";
        internal const string SETTINGS_FILE = SETTINGS_DIR + @"\AppSettings.json";

        public static IRepo GetRepository()
        {
            try
            {
                config = Config.FromJson(File.ReadAllText("config.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
            switch (config.DataSource)
            {
                case Config.Source.API:
                    return new DataRepo();
                case Config.Source.JSON:
                    return new FileRepo();
                default:
                    return new FileRepo();
            }
        } 
    }
}
