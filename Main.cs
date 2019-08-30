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
            Configuration conf = new Configuration();
        }
        public void CreateForm(Office.IRibbonControl control)
        {
            CreateData question = new CreateData();
            CreateTemplate createTemaplate = new CreateTemplate(question);
            createTemaplate.Show();
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
                //MailItem mailItem = Globals.ThisAddIn.Application.ActiveExplorer().Selection[1] as MailItem;
                //MessageBox.Show("CheckMailForm");
                //CheckMail functions = new CheckMail(mailItem);
                //functions.check(mailItem);
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


            //MessageBox.Show("DefultReplay");
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
