using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks; 
 
namespace FormPlugin.Data  
{  
    class Tools  
    {
        static public List<string> getEmailLineByLine(string emailContent)
        {
            string[] cos = emailContent.Replace("\r", "").Split('\n');
            List<string> nextLineOfEmail = new List<string>();
            foreach (string s in cos)
            {
                if (!s.Equals(""))
                    nextLineOfEmail.Add(s);
            }
            return nextLineOfEmail;
        }

        static public List<string> getQuestionsFromEmail(string emailContent)
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
        static public bool HaveWeAnswersForAllQuestions(List<string> template, List<string> recieivedMail)
        {
            bool haveWe=true;
            for(int i = 0; i < template.Count; i++)
            {
                if (i == template.Count - 1)
                {
                    for (int l = 0; l < recieivedMail.Count; l++)
                    {
                        if (template[i].Equals(recieivedMail[l]) && FirstCharacterIsNumber(template[i]))
                        {
                            try
                            {
                                _ = recieivedMail[l + 1];
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

        static public string ParseRtfToHTML(int questionCounter, string anItem)
        {
            StringBuilder body = new StringBuilder();
            body.Append("<div style >");

            return body.ToString();
        }
        class FontProperties
        {
            public int size;
            public string color;
            public bool isItalic;
            public bool isBold;
            public string fontName;

        }
    }  
} 