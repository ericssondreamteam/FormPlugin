using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using Application = Microsoft.Office.Interop.Outlook.Application;
using FormPlugin.Data;

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

        public bool CreateItemFromTemplateAndCheck()
        {
            OlDefaultFolders defaultFolder = OlDefaultFolders.olFolderDrafts;
            Application app = new Application();
            Folder folder = app.Session.GetDefaultFolder(defaultFolder) as Folder;
            MailItem mail = app.CreateItemFromTemplate(filePath, folder) as MailItem;
            List<string> templateLines, receviedMailLines;
            string body = mailItem.Body;
            string templateBody = mail.Body;
            receviedMailLines = Tools.getEmailLineByLine(body);
            templateLines =Tools.getEmailLineByLine(templateBody);
            bool conteinsAllTemplateLine = true;
            foreach(string s in templateLines)
            {
                if(!body.Contains(s))
                {
                    conteinsAllTemplateLine = false;
                    break;
                }
            }

            if (conteinsAllTemplateLine == true && Tools.HaveWeAnswersForAllQuestions(templateLines,receviedMailLines))
            {
                //MessageBox.Show("OK");
                return true;
            }
            else
            {
                //MessageBox.Show("Format is not ok.");
                return false;
            }
        }

       
        public void setFilePath(string path)
        {
            filePath = path;
        }


    }
}


