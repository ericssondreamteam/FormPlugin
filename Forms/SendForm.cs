using System;
using FormPlugin.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;

namespace FormPlugin.Forms
{
    public partial class SendForm : Form
    {
        bool checkTemplate = false;
        LoadData loadData;
        String [] recivers;
        int choosenQuestionNumber;
        List<String> reciversAll;
        public SendForm()
        {
            InitializeComponent();
            loadData = new LoadData();
            reciversAll = new List<String>();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (Directory.Exists(Configuration.pathFileTemplate))
            {
                openFileDialog.InitialDirectory = Configuration.pathFileTemplate;
                openFileDialog.Filter = "oft files (*.oft)|*.oft|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = false;
                openFileDialog.Title = "Send mail with template";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    loadData.SetPathFile(path);
                    checkTemplate = true;
                    button3.Text = openFileDialog.SafeFileName + " is choosen";
                    allReceivers.Text = Tools.ShowAllReceivers();
                    MessageBox.Show(allReceivers.Text.ToString());
                    
                    String[] pom = new String[2];
                    foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
                    {
                        pom = email.ReplyAll().To.Split(';');
                        foreach(String s in pom)
                        {
                            reciversAll.Add(s);
                        }
                        //MessageBox.Show(pom);
                    }
                    for (int i = 0; i < pom.Length; i++)
                    {
                        questionList.Items.Add(pom[i].Trim());
                    }
                    
                    
                }
            }
            else
                MessageBox.Show("First use 'Create Form' button from menu.", "Warning");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(checkTemplate)
            {
                foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
                {
                    Outlook.Application oApp = new Outlook.Application();
                    MailItem emailToReply = oApp.CreateItemFromTemplate(loadData.GetPathFile()) as Outlook.MailItem;
                    emailToReply.Subject = "RE: " + email.Subject;

                    emailToReply.To = email.ReplyAll().To;

                    //recivers = reciversAll.ToArray();
                    reciversAll = new List<String>();
                    foreach (String k in questionList.Items)
                    {
                        reciversAll.Add(k);
                    }
                    recivers = reciversAll.ToArray();


                    foreach (String s in recivers)
                    {
                        //MessageBox.Show(s);
                    }
                    
                    if (email != null)
                    {
                        Outlook.MailItem replyMail = email.Reply();
                        replyMail.HTMLBody = emailToReply.HTMLBody + replyMail.HTMLBody;
                        replyMail.To = String.Join("; ", recivers);
                        //replyMail.Display(true);
                        replyMail.Send();
                    }
                }
                Close();
            }
            else
                MessageBox.Show("First choose your template", "Warning");

        }
        private void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = allReceivers.Text;
            //MessageBox.Show(a);
            //questionTextBox.Text = questionList.GetItemText(questionList.SelectedItem);
            choosenQuestionNumber = questionList.SelectedIndex;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string to = questionTextBox.Text;
            if(to != null)
            {
                reciversAll.Add(to);
                questionList.Items.Add(to);
                questionTextBox.Text = "";
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            questionList.Items[choosenQuestionNumber] = questionTextBox.Text;
            questionTextBox.Clear();
        }
        private void DeleteQuestionButton_Click(object sender, EventArgs e)
        {
            if (questionList.SelectedItems != null)
            {
                questionList.Items.RemoveAt(choosenQuestionNumber);
            }
            else
            {
                MessageBox.Show("Firstly, please choose an item");
            }
        }

        private void SendForm_Load(object sender, EventArgs e)
        {

        }

        private void QuestionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
