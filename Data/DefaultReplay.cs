using Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormPlugin.Data
{
    class DefaultReplay
    {
        private static List<string> dictionary = new List<string>();

        public static void InitDictionary()
        {
            dictionary.Add("Automatyczna odpowiedź: ");
            dictionary.Add("Autosvar: ");
            dictionary.Add("Automatic Replay: ");
        }
        public static void DeleteDefaultReplay(MailItem mailItem)
        {
            MessageBox.Show("delete: "+ mailItem.Subject);
            foreach(string s in dictionary)
            {
                //MessageBox.Show(mailItem.Subject);
                if(mailItem.Subject.ToLower().StartsWith(s.ToLower()))
                {
                    mailItem.Delete();
                    MessageBox.Show("usnieto");
                    break;
                }
            }
        }
    }
}
