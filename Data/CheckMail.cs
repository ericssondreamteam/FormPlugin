using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception = System.Exception;
using System.Diagnostics;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Outlook.Application;

namespace FormPlugin
{
    public class CheckMail
    {
        public const String question = "Podaj swój ulubiony kolor:";
        public MailItem mailItem;
        private string filePath;

        public CheckMail(MailItem mailItem)
        {
            this.mailItem = mailItem;
        }

        public void CreateItemFromTemplateAndCheck()
        {
            OlDefaultFolders defaultFolder = OlDefaultFolders.olFolderDrafts;
            Application app = new Application();
            Folder folder = app.Session.GetDefaultFolder(defaultFolder) as Folder;
            MailItem mail = app.CreateItemFromTemplate(filePath, folder) as MailItem;
            mail.Save();

            String formBody = mail.Body;//this is template
            funWithString(formBody);
            String body = mailItem.Body;
            bool myBool = body.Contains(formBody);

            if (myBool == true)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Format is not ok.");
            }
        }

        private void funWithString(string formBody)
        {//"Hi,\r\nplease fill form ;)\r\n\r\n1. Ulubiony kolor\r\n\r\n\r\n2. Podaj swój ulubiony kolor:\r\n\r\n\r\n"
            string[] cos = formBody.Replace("\r","").Split('\n');
            List<string> list = new List<string>();
            foreach (string s in cos)
            {
                if (!s.Equals(""))
                    list.Add(s);
            }
            foreach(string s in list)
            {
                Debug.WriteLine(s);
            }

        }

        public void setFilePath(string path)
        {
            filePath = path;
        }


    }
}


