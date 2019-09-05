using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;
using FormPlugin.Data;


namespace FormPlugin
{
    public partial class ThisAddIn
    {
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(
                   Outlook.OlDefaultFolders.olFolderInbox);
            MessageBox.Show(outlookNameSpace.Accounts.Count.ToString()+"\n"+outlookNameSpace.Folders.Count);
            
            
            Config();
            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
        }
        void Config()
        {
            if (Configuration.LoadConfiguration())
            {
                //super... niech się dzieje zawsze w tle i tyle
                //Console.WriteLine("Load Conf");
                inbox = outlookNameSpace.GetFolderFromID(Configuration.FolderEntryID, Configuration.FolderStoreID);
            }
            else
            {
                //nie mamy zapisanej konfiguracji - właściwie to pierwsze uruchomienie
                //wycztaj pierwszą konfigurację jakisForm
                //zapisz ją do pliku
                Configuration.ContorlMailFolder = "NC MailBox";
                ShowFolderInfo();
                Configuration.SaveConfiguration();
                //Console.WriteLine("Save Conf");
            }
        }
        private void ShowFolderInfo()
        {
            Outlook.Folder folder =
                Application.Session.PickFolder()
                as Outlook.Folder;
            if (folder != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Folder EntryID:");
                sb.AppendLine(folder.EntryID);
                sb.AppendLine();
                sb.AppendLine("Folder StoreID:");
                sb.AppendLine(folder.StoreID);
                sb.AppendLine();
                Configuration.FolderStoreID = folder.StoreID;
                Configuration.FolderEntryID = folder.EntryID;
                sb.AppendLine("Unread Item Count: "
                    + folder.UnReadItemCount);
                sb.AppendLine("Default MessageClass: "
                    + folder.DefaultMessageClass);
                sb.AppendLine("Current View: "
                    + folder.CurrentView.Name);
                sb.AppendLine("Folder Path: "
                    + folder.FolderPath);
                MessageBox.Show(sb.ToString(),
                    "Folder Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                /* Outlook.Folder folderFromID =
                     Application.Session.GetFolderFromID(
                     folder.EntryID, folder.StoreID)
                     as Outlook.Folder;
                 folderFromID.Display();*/
                inbox = outlookNameSpace.GetFolderFromID(folder.EntryID, folder.StoreID);
            }
        }
        void items_ItemAdd(object Item)
        {
            if (Item is Outlook.MailItem)
            {
                Outlook.MailItem mail = (Outlook.MailItem)Item;
                if (Item != null)
                {
                    if (Directory.Exists(Configuration.pathFileTemplate))
                    {
                        string[] filePaths = Directory.GetFiles(Configuration.pathFileTemplate, "*.oft");
                        // foreach (string s in filePaths)//test czy wczytuje wszytkie templaety
                        //      MessageBox.Show(s);
                        CheckMail check = new CheckMail(mail);
                        bool anyTemplateSuits = false;
                        foreach (string s in filePaths)
                        {
                            check.setFilePath(s);
                            if (check.CreateItemFromTemplateAndCheck())
                            {
                                MessageBox.Show("OK " + s);
                                anyTemplateSuits = true;
                            }


                        }
                        if (!anyTemplateSuits)
                            MessageBox.Show("Email doesn't suit to any template");
                    }

                }
            }  

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Main();
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
