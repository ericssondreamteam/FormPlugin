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
    public class Functions
    {
        public const String question = "abc";
        public MailItem mailItem;

        public Functions(MailItem mailItem)
        {
            this.mailItem = mailItem;
        }

        public void check(MailItem mailItem)
        {
            bool myBool = mailItem.Body.Contains(question);
            if (myBool == true)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Not ok");
            }
        }


       
    }
}
