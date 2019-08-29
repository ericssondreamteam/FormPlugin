using FormPlugin.Data;
using Microsoft.Office.Interop.Outlook;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace FormPlugin.Forms
{
    public partial class CreateTemplate : Form
    {
        CreateData data;
        public CreateTemplate(CreateData create)
        {
            data = create;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            data.addQuestion(textBox1.Text);          
            ListViewItem itm;         
            itm = new ListViewItem(textBox1.Text);
            //to oglnie do poprawy, ale napierw tempalate
            listView1.Items.Add(itm);
            textBox1.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //check if directory exist
            if (!Directory.Exists(Configuration.pathFileTemplate))
                Directory.CreateDirectory(Configuration.pathFileTemplate);
            //save tamplate
            if(textBox2.Text.Equals(""))
            {
                label3.Text = "Please enter a name";
            }
            else
            {
                if (ifFileExist(Configuration.pathFileTemplate + "\\" + textBox2.Text + ".oft"))
                {
                    label3.Text = "This file exists. We cannot save";
                }
                else
                {
                    
                    Outlook.Application outlookApp = new Outlook.Application();
                    MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
                    mailItem.HTMLBody = createBodyMail();
                    mailItem.SaveAs(Configuration.pathFileTemplate + "\\"+textBox2.Text+".oft");
                    Close();

                }
            }
           


        }

        private string createBodyMail()
        {
            StringBuilder body = new StringBuilder();
            body.Append("<html><body>Hi,<BR>please fill form ;)<BR><BR>");
            int questionCounter =1;
            foreach(string s in data.getAllQuestions())
            {
                body.Append("<strong>"+questionCounter+". "+s+ "<strong>"+ "<BR><BR><BR>");
                questionCounter++;
            }
            return body.ToString();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (ifFileExist(Configuration.pathFileTemplate + "\\" + textBox2.Text+".oft"))
            {
                label3.Text = "This file exists. Please enter another name";
            }
            else
                label3.Text = "";
            
        }
        bool ifFileExist(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
                return false;
        }
    }
}
