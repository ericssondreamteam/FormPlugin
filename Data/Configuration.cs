using System;
using System.IO;
using System.Text;

namespace FormPlugin.Data
{
    class Configuration
    {
        public static string pathFileTemplate = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Forms_Plugin_Outlook";
        private static string configFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Outlook";
        private static string confFileName = "\\FormPluginConfiguration.txt";
        public static string ContorlMailFolder { get; set; }
        /*                                UŻYCIE
         static void Config()
        {
            if(Configuration.LoadConfiguration())
            {
                //super... niech się dzieje zawsze w tle i tyle
                Console.WriteLine("Load Conf");
            }
            else
            {
                //nie mamy zapisanej konfiguracji - właściwie to pierwsze uruchomienie
                //wycztaj pierwszą konfigurację jakisForm
                //zapisz ją do pliku
                Configuration.ContorlMailFolder = "NC MailBox";
                Configuration.SaveConfiguration();
                Console.WriteLine("Save Conf");
            }
        }
             */

        public static void SaveConfiguration()
        {
            if (Directory.Exists(configFilePath))
                Directory.CreateDirectory(configFilePath);
            StringBuilder settings = new StringBuilder();
            settings.Append(ContorlMailFolder);
            if (!File.Exists(configFilePath + confFileName))
                File.Create(configFilePath + confFileName).Close();
            File.WriteAllText(configFilePath + confFileName, settings.ToString());


        }

        public static bool LoadConfiguration()
        {
            bool ifConfExist;
            if (Directory.Exists(configFilePath))
                Directory.CreateDirectory(configFilePath);
            if (File.Exists(configFilePath + confFileName))
            {
                //set all settings
                string line;
                StreamReader file = new StreamReader(configFilePath + confFileName);
                while ((line = file.ReadLine()) != null)
                {
                    ContorlMailFolder = line;
                }
                file.Close();
                ifConfExist = true;
                return ifConfExist;
            }
            else
            {
                ifConfExist = false;
                return ifConfExist;
            }


        }
    }
}
