﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace FormPlugin.Data
{
    class Configuration
    {
        public static string pathFileTemplate = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Forms_Plugin_Outlook";
        private static string configFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Outlook";
        private static string confFileName = "\\FormPluginConfiguration.txt";

        public static string FolderStoreID { get; set; }
        public static string FolderEntryID { get; set; }

        public static void Config(Outlook.NameSpace outlookNameSpace, ref Outlook.MAPIFolder inbox, Outlook.Application app)
        {
            if (LoadConfiguration())
            {
                //super... niech się dzieje zawsze w tle i tyle
                inbox = outlookNameSpace.GetFolderFromID(Configuration.FolderEntryID, Configuration.FolderStoreID);
            }
            else
            {
                //nie mamy zapisanej konfiguracji - właściwie to pierwsze uruchomienie
                //wycztaj pierwszą konfigurację jakisForm
                //zapisz ją do pliku
                ShowFolderInfo(outlookNameSpace, ref inbox, app);
                Configuration.SaveConfiguration();
            }
        }
        private static void ShowFolderInfo(Outlook.NameSpace outlookNameSpace, ref Outlook.MAPIFolder inbox, Outlook.Application app)
        {
            Outlook.Folder folder = app.Session.PickFolder() as Outlook.Folder;
            if (folder != null)
            {
                FolderStoreID = folder.StoreID;
                FolderEntryID = folder.EntryID;
                inbox = outlookNameSpace.GetFolderFromID(folder.EntryID, folder.StoreID);
            }
        }


        private static void SaveConfiguration()
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

        private static bool LoadConfiguration()
        {
            bool ifConfExist;
            if (Directory.Exists(configFilePath))
                Directory.CreateDirectory(configFilePath);
            if (File.Exists(configFilePath + confFileName))
            {
                //set all settings

                StreamReader file = new StreamReader(configFilePath + confFileName);
                try
                {
                    FolderStoreID = file.ReadLine();
                    FolderEntryID = file.ReadLine();
                }
                catch (Exception e)
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
