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
            //dodanie do naszego modelu danych
            data.addQuestion(textBox1.Text);
            StringBuilder temp = new StringBuilder();
            int questionCounter = 1;
            foreach (string s in data.getAllQuestions())
            {
                temp.Append( questionCounter + ". " + s +"\n");
                questionCounter++;
            }
            label4.Text = temp.ToString();
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
                if (File.Exists(Configuration.pathFileTemplate + "\\" + textBox2.Text + ".oft"))
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
            if (File.Exists(Configuration.pathFileTemplate + "\\" + textBox2.Text+".oft"))
            {
                label3.Text = "This file exists. Please enter another name";
            }
            else
                label3.Text = "";            
        }

        private void CreateTemplate_ClientSizeChanged(object sender, EventArgs e)
        {
            textBox1.Size = new System.Drawing.Size(Size.Width - 215, Size.Height / 2-70);
            button1.Location = new System.Drawing.Point(Size.Width - 135, Size.Height / 2 - 56);
            label4.Location = new System.Drawing.Point(45, Size.Height / 2 );
            label3.Location = new System.Drawing.Point(Size.Width / 2 - 75, Size.Height - 120);
            label4.MaximumSize = new System.Drawing.Size(Size.Width - 225, Size.Height / 2 - 130);

        }

        private void CreateTemplate_Load(object sender, EventArgs e)
        {
            textBox1.Size = new System.Drawing.Size(Size.Width - 215, Size.Height / 2 - 70);
            button1.Location = new System.Drawing.Point(Size.Width - 135, Size.Height / 2 - 56);
            label4.Location = new System.Drawing.Point(45, Size.Height / 2);
            label3.Location = new System.Drawing.Point(Size.Width/2 - 75, Size.Height -120);
            label4.MaximumSize = new System.Drawing.Size(Size.Width - 225, Size.Height / 2 - 130);
        }
    }
}
