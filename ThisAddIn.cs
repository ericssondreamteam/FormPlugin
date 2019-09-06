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
                inbox = outlookNameSpace.GetFolderFromID(Configuration.FolderEntryID, Configuration.FolderStoreID);
            }
            else
            {
                //nie mamy zapisanej konfiguracji - właściwie to pierwsze uruchomienie
                //wycztaj pierwszą konfigurację jakisForm
                //zapisz ją do pliku
                ShowFolderInfo();
                Configuration.SaveConfiguration();
            }
        }
        private void ShowFolderInfo()
        {
            Outlook.Folder folder =  Application.Session.PickFolder() as Outlook.Folder;
            if (folder != null)
            {              
                Configuration.FolderStoreID = folder.StoreID;
                Configuration.FolderEntryID = folder.EntryID;               
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
