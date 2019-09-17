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
            foreach(string s in dictionary)
            {
                if(mailItem.Subject.ToLower().StartsWith(s.ToLower()))
                {
                    MessageBox.Show("usnieto: " + mailItem.Subject);
                    mailItem.Delete();                    
                    break;
                }
            }
        }
    }
}
