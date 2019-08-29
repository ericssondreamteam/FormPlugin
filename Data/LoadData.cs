using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;

namespace FormPlugin.Data
{
    public class LoadData
    {
        private string pathFile;
        private string mailTo = "";
        private string subject = "";
        public void createMail()
        {
            Outlook.Application oApp = new Outlook.Application();
            //Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
            Outlook.MailItem mail =
                oApp.CreateItemFromTemplate(pathFile) as Outlook.MailItem;
            
            //check if the mailto is fill
            if(mailTo.Length > 0)
                mail.To = mailTo;
            //check if the subject is fill
            if(subject.Length > 0)
                mail.Subject = subject;
            mail.Display(true);
        }

        public void setPathFile(string path)
        {
            pathFile = path;
        }

        public void setMailTo(string to)
        {
            mailTo = to;
        }

        public void setSubject(string sub)
        {
            subject = sub;
        }
    }
}