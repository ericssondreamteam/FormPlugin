using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FormPlugin.Data
{
    class Configuration
    {
        public static string pathFileTemplate = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Forms_Plugin_Outlook";
        private static string configFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Outlook";
        private static string confFileName = "\\FormPluginConfiguration.txt";

        public static string FolderStoreID { get; set; }
        public static string FolderEntryID { get; set; }
                                      
        
             

        public static void SaveConfiguration()
        {
            if (Directory.Exists(configFilePath))
                Directory.CreateDirectory(configFilePath);
            StringBuilder settings = new StringBuilder();
            settings.Append(FolderStoreID + "\n");
            settings.Append(FolderEntryID + "\n");
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
                
                StreamReader file = new StreamReader(configFilePath + confFileName);
                try {
                    FolderStoreID = file.ReadLine();
                    FolderEntryID = file.ReadLine();
                }catch(Exception e)
                {
                    MessageBox.Show("Zla konfiguracja:\n" + e.Message);
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
