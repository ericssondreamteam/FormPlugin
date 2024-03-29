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

        public static void DeleteConfig()
        {
            if (File.Exists(configFilePath + confFileName))
                File.Delete(configFilePath + confFileName);
        }
        public static void Config(Outlook.NameSpace outlookNameSpace, ref Outlook.MAPIFolder inbox, Outlook.Application app)
        {
            if (LoadConfiguration())
            {
                //super... niech się dzieje zawsze w tle i tyle
                if(FolderEntryID.Equals("") || FolderStoreID.Equals(""))
                {
                    ShowFolderInfo(outlookNameSpace, ref inbox, app);
                    SaveConfiguration();
                }
                else
                    inbox = outlookNameSpace.GetFolderFromID(FolderEntryID, FolderStoreID);
            }
            else
            {
                //nie mamy zapisanej konfiguracji - właściwie to pierwsze uruchomienie
                ShowFolderInfo(outlookNameSpace, ref inbox, app);
                SaveConfiguration();
            }
        }
        private static void ShowFolderInfo(Outlook.NameSpace outlookNameSpace, ref Outlook.MAPIFolder inbox, Outlook.Application app)
        {
            MessageBox.Show("Za chwilę pojawi się okno z wyborem folderu.\n" +
                "Rozsądnym wyborem będzie zaznaczenie folderu \"Inbox\" dla skrzynki \"NC MailBox\"" +
                "\n(jest to wybór skrzynki, dla której będą sprawdzane maile przychodzące pod kątem poprawności)");
            if (app.Session.PickFolder() is Outlook.Folder folder)
            {
                FolderStoreID = folder.StoreID;
                FolderEntryID = folder.EntryID;
                inbox = outlookNameSpace.GetFolderFromID(folder.EntryID, folder.StoreID);
            }
            else
            {
                MessageBox.Show("Ooops . . . Something went wrong in ShowFolderInfo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public static void SaveConfiguration()
        {
            if (Directory.Exists(configFilePath))
                Directory.CreateDirectory(configFilePath);

            StringBuilder settings = new StringBuilder();
            settings.Append(FolderStoreID + "\n");
            settings.Append(FolderEntryID + "\n");
            settings.Append(pathFileTemplate + "\n");

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
                StreamReader file = new StreamReader(configFilePath + confFileName);
                try
                {
                    FolderStoreID = file.ReadLine();
                    FolderEntryID = file.ReadLine();
                    pathFileTemplate = file.ReadLine();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Zla konfiguracja:\n" + e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
