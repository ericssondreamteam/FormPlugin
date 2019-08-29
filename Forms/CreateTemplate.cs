﻿using FormPlugin.Data;
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
            //save tamplate
            Close();
            Outlook.Application outlookApp = new Outlook.Application();
            MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
            mailItem.HTMLBody = createBodyMail();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\Forms";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                
            }

            MessageBox.Show(path);
            mailItem.SaveAs(path+"\\test.oft");//, OlSaveAsType.olTemplate
            // mailItem.Display(true);
            // MessageBox.Show("Your template was successfuly saved");

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
    }
}
