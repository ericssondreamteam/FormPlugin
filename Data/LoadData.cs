using Microsoft.Office.Interop.Outlook;

namespace FormPlugin.Data
{
    public class LoadData
    {
        private string pathFile;
        private string mailTo = "";
        private string subject = "";
        public void CreateMail()
        {
            Application oApp = new Application();
            MailItem mail = oApp.CreateItemFromTemplate(pathFile) as MailItem;
            
            //check if the mailto is fill
            if(mailTo.Length > 0)
                mail.To = mailTo;
            //check if the subject is fill
            if(subject.Length > 0)
                mail.Subject = subject;
            mail.Display(true);
        }

        public void SendMail(string subject, string sender)
        {
            Application oApp = new Application();
            MailItem mail = oApp.CreateItemFromTemplate(pathFile) as MailItem;
            mail.To = sender;
            mail.Subject = subject;
            mail.Send();
        }


        public void SetPathFile(string path)
        {
            pathFile = path;
        }

        public string GetPathFile()
        {
            return pathFile;
        }


        public void SetMailTo(string to)
        {
            mailTo = to;
        }

        public void SetSubject(string sub)
        {
            subject = sub;
        }
    }
}