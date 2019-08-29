using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
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
        }
        public void CreateForm(Office.IRibbonControl control)
        {           
            Forms.CreateTemplate createTemaplate = new Forms.CreateTemplate();
            createTemaplate.ShowDialog();
        }
        public void LoadForm(Office.IRibbonControl control)
        {
            MessageBox.Show("LoadForm");
        }
/*
 * May be useful one day
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
                MailItem mailItem = Globals.ThisAddIn.Application.ActiveExplorer().Selection[1] as MailItem;
                MessageBox.Show("CheckMailForm");
                Functions functions = new Functions(mailItem);
                functions.check(mailItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception");
            }

           
        }
        public void DefultReply(Office.IRibbonControl control)
        {
            MessageBox.Show("DefultReplay");
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
