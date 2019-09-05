using FormPlugin.Data;
using FormPlugin.Forms;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Exception = System.Exception;
using Office = Microsoft.Office.Core;

namespace FormPlugin
{
    [ComVisible(true)]
    public class Main : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private static int counter = 0;
        private static bool checkIfFitToTemplate = false;
        private static bool checkIfTemplateWasSend = false;

        public Main()
        {
            //nie jest potrzebne
            //Configuration conf = new Configuration();
        }
        public void CreateForm(Office.IRibbonControl control)
        {
            CreateTemplateForm create = new CreateTemplateForm();
            create.Show();
        }
        public void LoadForm(Office.IRibbonControl control)
        {
            LoadTemplate loadTemplate = new LoadTemplate();
            loadTemplate.Show();
        }
        
 /* May be useful one day
        internal static IEnumerable<MailItem> GetSelectedEmails()
        {
            foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
            {
                yield return email;
            }
        }
 */

        public void CheckMailForm(Office.IRibbonControl control)
        {
            try
            {
                Check check = new Check();
                check.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception");
                _ = ex.Message;
            }


        }
        public void DefultReplay(Office.IRibbonControl control)
        {
            SendForm sendForm = new SendForm();
            sendForm.Show();
        }

        public void CheckConversation(Office.IRibbonControl control)
        {
            int counter = 0;
            foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
            {
                //DZIAŁA MIMO IŻ NIE POWINNO XD
                if (counter == 0)
                {
                    check(email);
                    automaticReply();
                } 
                else
                    MessageBox.Show("You choose more than one mail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                counter++;
            }
            Main.counter = 0;
            checkIfFitToTemplate = false;
        }

        private void check(MailItem newEmail)
        {
            Conversation conv = newEmail.GetConversation();
            SimpleItems simpleItems = conv.GetRootItems();
            bool isTemplate = false;

            foreach (object item in simpleItems)
            {
                try
                {
                    if (item is MailItem)
                    {
                        Main.counter++;
                        MailItem mail = item as MailItem;
                        bool checkTemplate = checkTemplateConversation(mail);
                        Folder inFolder = mail.Parent as Folder;
                        string msg = mail.Subject + " in folder " + inFolder.Name + " Sender: " + mail.SenderName + " Date: " + mail.ReceivedTime;
                        if (checkIfTemplateWasSend)
                            isTemplate = true;

                        MessageBox.Show(counter + ". " + msg +
                            "\nTemplate was sent: " + isTemplate +
                            "\nTemplate was filled: " + checkTemplate);
                        if (checkTemplate)
                            checkIfFitToTemplate = checkTemplate;
                    }
                    EnumerateConversation(item, conv);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void EnumerateConversation(object item, Conversation conversation)
        {
            SimpleItems items = conversation.GetChildren(item);
            bool isTemplate = false;
            if (items.Count > 0)
            {
                foreach (object myItem in items)
                {
                    if (myItem is MailItem)
                    {
                        Main.counter++;
                        MailItem mailItem = myItem as MailItem;
                        bool checkTemplate = checkTemplateConversation(mailItem);
                        Folder inFolder = mailItem.Parent as Folder;
                        string msg = mailItem.Subject + " in folder " + inFolder.Name + " Sender: " + mailItem.SenderName + " Date: " + mailItem.ReceivedTime;
                        if (checkIfTemplateWasSend)
                            isTemplate = true;

                        MessageBox.Show(counter + ". " + msg +
                            "\nTemplate was sent: " + isTemplate +
                            "\nTemplate was filled: " + checkTemplate);
                        if (checkTemplate)
                            checkIfFitToTemplate = checkTemplate;
                    }
                    EnumerateConversation(myItem, conversation);
                }
            }
        }

        private bool checkTemplateConversation(MailItem mail)
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
                        anyTemplateSuits = true;
                    }
                    if(check.checkIfThereIsATemplate())
                    {
                        checkIfTemplateWasSend = true;
                    }
/*                    else
                    {
                        checkIfTemplateWasSend = false;
                    }*/
                }
                if (!anyTemplateSuits)
                {
                    anyTemplateSuits = false;
                }
                return anyTemplateSuits;
            }
            return false;
        }

        private void automaticReply()
        {
            if (checkIfFitToTemplate || Main.counter < 2 || !checkIfTemplateWasSend)
            {
                MessageBox.Show("NIE ODSYŁAMY :)" +
                    "\nTemplateWasSend: " + checkIfTemplateWasSend +
                    "\nTemplateFilled: " + checkIfFitToTemplate + 
                    "\nCountMails: " + Main.counter);
            }
            else if (!checkIfFitToTemplate && checkIfTemplateWasSend)
                MessageBox.Show("ODSYŁAMY automatycznie");
        }


        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("FormPlugin.Main.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
