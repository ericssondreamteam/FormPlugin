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
        Outlook.Application oApp = new Outlook.Application();

        public void createMail()
        {
            Outlook.Application oApp = new Outlook.Application();
            //Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
            Outlook.MailItem mail =
                oApp.CreateItemFromTemplate(
                "C:\\Users\\ELASKAR\\AppData\\Roaming\\Microsoft\\Templates\\lol.oft") as Outlook.MailItem;
            mail.To = "karower98@gmail.com";
            // body, bcc etc...
            mail.Display(true);
        }
    }
}