using System;
using Outlook = Microsoft.Office.Interop.Outlook;
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
        public static Outlook.Application zmiennaDoSettinngs;
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            zmiennaDoSettinngs = Application;
            outlookNameSpace = Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            Configuration.Config(outlookNameSpace, ref inbox, Application);
            items = inbox.Items;
            items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
            DefaultReplay.InitDictionary();
            Categories.AddCategorires();
        }

        void items_ItemAdd(object Item)
        {
            if (Item is Outlook.MailItem)
            {
                DefaultReplay.DeleteDefaultReplay(Item as Outlook.MailItem);
                //Automatyczne nadawanie kategorii na wejściu
                try
                {
                    Main.manuallyCheckAutomaticReplyMain(Item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CHECK CONVERSATION: \n" + ex.Message + "\n" + ex.StackTrace,
                        "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //A na dole stara reszta pewnie do usunięcia potem


/*            if (Item is Outlook.MailItem)
            {
                Outlook.MailItem mail = (Outlook.MailItem)Item;
                if (Item != null)
                {
                    if (Directory.Exists(Configuration.pathFileTemplate))
                    {
                        string[] filePaths = Directory.GetFiles(Configuration.pathFileTemplate, "*.oft");
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
            }*/

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
