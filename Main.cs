using FormPlugin.Data;
using FormPlugin.Forms;
using Microsoft.Office.Interop.Outlook;
using System;
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
            MessageBox.Show("Conversation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            int counter = 0;
            foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
            {
                if (counter == 0)
                    check(email);
                else
                    break;
                counter++;
            }
        }

        private void check(MailItem newEmail)
        {
            Conversation conv = newEmail.GetConversation();
            SimpleItems simpleItems = conv.GetRootItems();
            int counter = 0;

            foreach (object item in simpleItems)
            {
                try
                {
                    if (item is MailItem)
                    {
                        counter++;
                        MailItem mail = item as MailItem;
                        Folder inFolder = mail.Parent as Folder;
                        string msg = mail.Subject + " in folder " + inFolder.Name + " Sender: " + mail.SenderName + " Date: " + mail.ReceivedTime;
                        MessageBox.Show(counter + ". " + msg);
                    }
                    EnumerateConversation(item, conv, counter);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void EnumerateConversation(object item, Conversation conversation, int counter)
        {
            int i = counter;
            SimpleItems items = conversation.GetChildren(item);
            if (items.Count > 0)
            {
                foreach (object myItem in items)
                {
                    if (myItem is MailItem)
                    {
                        i++;
                        MailItem mailItem = myItem as MailItem;
                        Folder inFolder = mailItem.Parent as Folder;
                        string msg = mailItem.Subject + " in folder " + inFolder.Name + " Sender: " + mailItem.SenderName + " Date: " + mailItem.ReceivedTime;
                        MessageBox.Show(i + ". " + msg);
                    }
                    EnumerateConversation(myItem, conversation, i);
                }
            }
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
