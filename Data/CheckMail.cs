using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Outlook.Application;

namespace FormPlugin
{
    public class CheckMail
    {
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
            List<string> templateLines, receviedMailLines;
            String body = mailItem.Body;            
            String templateBody = mail.Body;
            receviedMailLines = getEmailLineByLine(body);
            templateLines = getEmailLineByLine(templateBody);
            bool conteinsAllTemplateLine = true;
            foreach(string s in templateLines)
            {
                if(!body.Contains(s))
                {
                    conteinsAllTemplateLine = false;
                    break;
                }
            }

            if (conteinsAllTemplateLine == true)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Format is not ok.");
            }
        }

        private List<string> getEmailLineByLine(string emailContent)
        {
            string[] cos = emailContent.Replace("\r","").Split('\n');
            List<string> nextLineOfEmail = new List<string>();
            foreach (string s in cos)
            {
                if (!s.Equals(""))
                    nextLineOfEmail.Add(s);
            }           
            return nextLineOfEmail;
        }

        public void setFilePath(string path)
        {
            filePath = path;
        }


    }
}


