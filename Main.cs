using FormPlugin.Data;
using FormPlugin.Forms;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Exception = System.Exception;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace FormPlugin
{
    [ComVisible(true)]
    public class Main : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private static int counter = 0;
        private static bool checkIfFitToTemplate = false;
        private static bool checkIfTemplateWasSend = false;
        private static String pathForTemplate = null;

        public Main()
        {

        }
        public void OnSettingsAction(Office.IRibbonControl control)
        {
            DialogResult dialogResult = MessageBox.Show("Want You edit settings?", "Editing Settings", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Configuration.DeleteConfig();
                NameSpace outlookNameSpace = ThisAddIn.zmiennaDoSettinngs.GetNamespace("MAPI");
                MAPIFolder inbox=outlookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);                
                Configuration.Config(outlookNameSpace, ref inbox, ThisAddIn.zmiennaDoSettinngs.Application);
                MessageBox.Show("Please restart outlook to introduce changes");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
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
        public void CleanCategories(Office.IRibbonControl control)
        {
            DialogResult dr = MessageBox.Show("Do you want to clear all messages from our categories?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                Data.Categories.DeleteAllOurCategoires(DateTime.Now.AddHours(-1));
            }
            
        }

        public void CheckConversation(Office.IRibbonControl control)
        {
            try
            {
                manuallyCheckAutomaticReply();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CHECK CONVERSATION: \n" + ex.Message + "\n" + ex.StackTrace,
                    "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void manuallyCheckAutomaticReply()
        {
            int counter = 0;
            foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
            {
                //DZIAŁA MIMO IŻ NIE POWINNO XD
                if (counter == 0)
                {
                    if (email != null)
                    {
                        check(email);
                        automaticReply(email);
                    }
                    else
                    {
                        MessageBox.Show("Mail jest null XD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                    MessageBox.Show("You choose more than one mail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                counter++;
            }
            Main.counter = 0;
            checkIfFitToTemplate = false;
            checkIfTemplateWasSend = false;
        }

        public static void manuallyCheckAutomaticReplyMain(object Item)
        {
            if (Item is Outlook.MailItem)
            {
                Outlook.MailItem email = (Outlook.MailItem)Item;
                if (Item != null)
                {
                    check(email);
                    automaticReply(email);
                }
                else
                {
                    MessageBox.Show("Mail jest null XD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Main.counter = 0;
            checkIfFitToTemplate = false;
            checkIfTemplateWasSend = false;            
        }

        public static void check(MailItem newEmail)
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
                                               
                        //DO TESTOWANIA
                        /*Folder inFolder = mail.Parent as Folder;
                        string msg = mail.Subject + " in folder " + inFolder.Name + " Sender: " + mail.SenderName + " Date: " + mail.ReceivedTime;*/
                        /*MessageBox.Show(counter + ". " + msg +
                            "\nTemplate was sent: " + isTemplate +
                            "\nTemplate was filled: " + checkTemplate);*/
                        if (checkIfTemplateWasSend)
                            isTemplate = true;
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

        public static void EnumerateConversation(object item, Conversation conversation)
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
                        
                        //DO TESTOWANIA
                        /*Folder inFolder = mailItem.Parent as Folder;
                        string msg = mailItem.Subject + " in folder " + inFolder.Name + " Sender: " + mailItem.SenderName + " Date: " + mailItem.ReceivedTime;*/
                        /*MessageBox.Show(counter + ". " + msg +
                            "\nTemplate was sent: " + isTemplate +
                            "\nTemplate was filled: " + checkTemplate);*/
                        if (checkIfTemplateWasSend)
                            isTemplate = true;
                        if (checkTemplate)
                            checkIfFitToTemplate = checkTemplate;
                    }
                    EnumerateConversation(myItem, conversation);
                }
            }
        }

        public static bool checkTemplateConversation(MailItem mail)
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
                        pathForTemplate = s;
                    }
                }
                if (!anyTemplateSuits)
                {
                    anyTemplateSuits = false;
                }
                return anyTemplateSuits;
            }
            return false;
        }

        public static void automaticReply(MailItem email)
        {

            if(!checkIfTemplateWasSend)
            {
                //ORANGE CATEGORY
                //oznaczCalaKonwersacjeKategoria(email, "You Must Decide");
                ///////////////
                /*MessageBox.Show("Musisz wysłać dopiero template.");*/
            }
            else if (checkIfFitToTemplate)
            {
                //GREEN CATEGORY
                oznaczCalaKonwersacjeKategoria(email, "Good Response");
                ////////////
                /*MessageBox.Show("NIE ODSYŁAMY bo zgadza się template :)" +
                    "\nTemplateWasSend: " + checkIfTemplateWasSend +
                    "\nTemplateFilled: " + checkIfFitToTemplate);*/
            }
            else if (!checkIfFitToTemplate && checkIfTemplateWasSend)
            {
                
                /////////////
                /*MessageBox.Show("ODSYŁAMY automatycznie bo chamy niemyte nie czytajoXD");*/
                DialogResult result = MessageBox.Show("Do you want to send template once again? \n" + email.Subject + ",\n" + Tools.ShowAllReceivers(), "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Outlook.Application oApp = new Outlook.Application();
                    MailItem emailToReply = oApp.CreateItemFromTemplate(pathForTemplate) as MailItem;
                    emailToReply.Subject = "RE: " + email.Subject;
                    emailToReply.To = email.ReplyAll().To;
                    if (email != null)
                    {
                        Outlook.MailItem replyMail = email.Reply();
                        replyMail.HTMLBody = emailToReply.HTMLBody + replyMail.HTMLBody;
                        replyMail.To = email.ReplyAll().To;
                        replyMail.Send();
                    }
                }
                //RED CATEGORY
                oznaczCalaKonwersacjeKategoria(email, "Bad Response");
            }                
        }

        public static void oznaczCalaKonwersacjeKategoria(MailItem email, string category)
        {
            Conversation conv = email.GetConversation();
            SimpleItems simpleItems = conv.GetRootItems();
            foreach (object item in simpleItems)
            {
                if(item is MailItem)
                {
                    MailItem mail = item as MailItem;
                    string existingCategories = mail.Categories;
                    if (string.IsNullOrEmpty(existingCategories))
                    {
                        mail.Categories = category;
                    }
                    else
                    {

                        mail.Categories = existingCategories + ", "+category;
                        
                    }
                    mail.Categories = RemoveUnnecessaryCategories(mail.Categories, category);
                    //mail.Categories = category; //DO ODKOMENTOWANIA
                    //MessageBox.Show("Kategoria nadana " + category); //DO SPRAWDZANIA
                }
                getNextItemFromConversation(item, conv, category);
            }
        }

        public static void getNextItemFromConversation(object email, Conversation conv, String category)
        {
            SimpleItems items = conv.GetChildren(email);
            if (items.Count > 0)
            {
                foreach (object myItem in items)
                {
                    if (myItem is MailItem)
                    { 
                        MailItem mailItem = myItem as MailItem;
                        string existingCategories = mailItem.Categories;
                        if (string.IsNullOrEmpty(existingCategories))
                        {
                            mailItem.Categories = category;
                        }
                        else
                        {

                            mailItem.Categories = existingCategories + ", " + category;

                        }
                        mailItem.Categories = RemoveUnnecessaryCategories(mailItem.Categories, category);
                        //mailItem.Categories = category; //DO ODKOMENTOWANIA
                        //MessageBox.Show("Kategoria nadana " + category); //DO SPRAWDZANIA
                    }
                    getNextItemFromConversation(myItem, conv, category);
                }
            }
        }
        public static string RemoveUnnecessaryCategories(string categories, string addedCategories )
        {

           // MessageBox.Show("Started: "+categories);

            HashSet<string> catWithoutDuplicate = new HashSet<string>();
            string [] cat = categories.Split(',');
            for (int i = 0; i < cat.Length; i++)
            {
                catWithoutDuplicate.Add(cat[i].Trim());
            }
            string finnal = "";
            foreach(string s in catWithoutDuplicate)
            {
                if (!s.Equals("Bad Response") && !s.Equals("Good Response"))
                {
                    if (!finnal.Equals(""))
                        finnal = finnal + ", " + s.Trim();
                    else
                        finnal = s.Trim();
                }
            }
            if (!finnal.Equals(""))
                finnal = finnal + ", " + addedCategories;
            else
                finnal = addedCategories;

           // MessageBox.Show("Finnal: "+finnal);

            return finnal;
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
