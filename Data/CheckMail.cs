using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception = System.Exception;
using System.Diagnostics;
using System.Windows.Forms;

namespace FormPlugin
{
    public class CheckMail
    {
        //public const List<String> constraints;
        public const String question = "Podaj swój ulubiony kolor:";
        public MailItem mailItem;
        private string filePath;

        public CheckMail(MailItem mailItem)
        {
            this.mailItem = mailItem;
        }

        public void check()
        {
            bool myBool = mailItem.Body.Contains(question);
            if (myBool == true)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Format is not ok.");
            }
        }

        public void setFilePath(string path)
        {
            filePath = path;
        }


    }
}


