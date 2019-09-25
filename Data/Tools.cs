using Microsoft.Office.Interop.Outlook;
using System;  
using System.Collections.Generic;  
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormPlugin.Data  
{  
    class Tools  
    {
        static public List<string> GetEmailLineByLine(string emailContent)
        {
            string[] cos = emailContent.Replace("\r", "").Split('\n');
            List<string> nextLineOfEmail = new List<string>();
            foreach (string s in cos)
            {
                if (!s.Equals(""))
                    nextLineOfEmail.Add(s);
            }
            for(int i=0;i<nextLineOfEmail.Count;i++)
            {
                if(nextLineOfEmail[i].Equals(" "))
                {
                    nextLineOfEmail.RemoveAt(i);
                    i--;
                }
            }
            return nextLineOfEmail;
        }

        static public List<string> GetQuestionsFromEmail(string emailContent)
        {
            string[] cos = emailContent.Replace("\r", "").Split('\n');
            List<string> nextLineOfEmail = new List<string>();
            foreach (string s in cos)
            {
                if (!s.Equals("") && FirstCharacterIsNumber(s))
                    nextLineOfEmail.Add(s.Substring(s.IndexOf(" ")+1));
            }
            return nextLineOfEmail;
        }
        static void ZloWCzytejPostaciTYlkoDoTestow(List<string> template, List<string> recieivedMail)
        {
            StringBuilder s = new StringBuilder();
            s.Append("Template:\n");
            foreach (string ss in template)
                s.Append(ss + "\n");
            s.Append("\nReceived:\n");
            foreach (string ss in recieivedMail)
                s.Append(ss + "\n");
            MessageBox.Show(s.ToString());
        }
        static public bool HaveWeAnswersForAllQuestions(List<string> template, List<string> recieivedMail)
        {
            //ZloWCzytejPostaciTYlkoDoTestow(template, recieivedMail);
            bool haveWe=true;
            for(int i = 0; i < template.Count; i++)
            {
                if (i == template.Count - 1)//ostatnie pytanie
                {
                    for (int l = 0; l < recieivedMail.Count; l++)
                    {
                        if (template[i].Equals(recieivedMail[l]) && FirstCharacterIsNumber(template[i]))
                        {
                            try
                            {   //jeśli nie ma nic po ostatnim pytaniu to wywali wyjątek i zwróci false
                                _ = recieivedMail[l + 1];
                                if (recieivedMail[l + 1].StartsWith("From: ") || recieivedMail[l + 1].StartsWith("Best Regards:"))
                                    return false;
                                return true;
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                _ = e.Message;
                                return false;
                            }
                            catch (ArgumentOutOfRangeException e)
                            {
                                _ = e.Message;
                                return false;
                            }
                        }
                    }
                }
                for (int j = 0; j < recieivedMail.Count; j++)
                {
                    if(template[i].Equals(recieivedMail[j]) && FirstCharacterIsNumber(template[i]))
                    {
                        try
                        {
                            if (template[i + 1].Equals(recieivedMail[j + 1]))//na razie pomijam ostatanie pytanie
                            {
                                return false;
                            }
                            else
                                break;
                        }
                        catch(IndexOutOfRangeException e)
                        {
                            _ = e.Message;
                        }
                        catch(ArgumentOutOfRangeException e)
                        {
                            _ = e.Message;
                        }
                    }
                    
                }
            }
            return haveWe;
        }
        static bool FirstCharacterIsNumber(string s)
        {
            bool answer ;

            char firstCharacter = s.ToCharArray().ElementAt(0);
            answer = char.IsNumber(firstCharacter);

            return answer;
        }

        public static string ShowAllReceivers()
        {
            string allReceiversText = "All receivers: \n";
            int counter = 0;
            foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
            {
                counter++;
                allReceiversText += email.ReplyAll().To + "\n";
            }
            allReceiversText = allReceiversText.Replace(";", "\n");
            return allReceiversText;
        }
    }  
} 