using System;
using FormPlugin.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System.Drawing;

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
            editButton.Enabled = false;
            labelWarningError.Hide();
            allReceivers.Hide();
            info.Hide();
            deleteQuestionButton.Enabled = false;
            addButton.Enabled = false;
            if (Directory.Exists(Configuration.pathFileTemplate))
            {
                string path = Configuration.pathFileTemplate + "\\Default.oft";
                if (File.Exists(path))
                {
                    checkTemplate = true;
                    loadData.SetPathFile(path);
                    info.Show();
                    info.Text = "Default.oft" + " is chosen";
                    allReceivers.Text = Tools.ShowAllReceivers();
                    String[] pom = new String[2];
                    foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
                    {
                        pom = email.ReplyAll().To.Split(';');
                        foreach (String s in pom)
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
                    button3.ForeColor = SystemColors.ControlText;
                    string path = openFileDialog.FileName;
                    loadData.SetPathFile(path);
                    checkTemplate = true;
                    info.Show();
                    info.Text = openFileDialog.SafeFileName + " is chosen";
                    allReceivers.Text = Tools.ShowAllReceivers();
                    //MessageBox.Show(allReceivers.Text.ToString());
                    if (weHaventDefaultFile())
                    {
                        String[] pom = new String[2];
                        foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
                        {
                            pom = email.ReplyAll().To.Split(';');
                            foreach (String s in pom)
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
            }
            else
                MessageBox.Show("First use 'Create Form' button from menu.", "Warning");
        }
        bool weHaventDefaultFile()
        {
            if (Directory.Exists(Configuration.pathFileTemplate))
            {
                string path = Configuration.pathFileTemplate + "\\Default.oft";
                if (File.Exists(path))
                {
                    return false;
                }
            }
            return true;
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
            if (questionList.SelectedIndex != -1)
            {
                editButton.Enabled = true;
                deleteQuestionButton.Enabled = true;
            } else
            {
                editButton.Enabled = false;
                deleteQuestionButton.Enabled = false;
            }
                
            string a = allReceivers.Text;
            choosenQuestionNumber = questionList.SelectedIndex;
            questionTextBox.Text = questionList.GetItemText(questionList.SelectedItem);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string to = questionTextBox.Text;
            if(to != null && to.Length > 0)
            {
                reciversAll.Add(to);
                questionList.Items.Add(to);
                questionTextBox.Text = "";
            }
            else
            {
                //WYSIWIETL ZE MUSI BYC JAKAS DLUGOSC
                labelWarningError.Show();
                labelWarningError.Text = "Length of e-mail recipient should be greater than 0";
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string to = questionTextBox.Text;
            if(to != null && to.Length > 0)
                questionList.Items[choosenQuestionNumber] = questionTextBox.Text;
            else
            {
                //WYSWIETLAM GNOJA
                labelWarningError.Show();
                labelWarningError.Text = "Length of e-mail recipient should be greater than 0";
            }
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
            label4.Visible = false;
        }

        private void QuestionTextBox_TextChanged(object sender, EventArgs e)
        {
            if(questionTextBox.Text.Length > 0)
            {
                addButton.Enabled = true;
            }
            else
            {
                addButton.Enabled = false;
            }
        }

        private void SendForm_SizeChanged(object sender, EventArgs e)
        {
            questionTextBox.Size = new Size(Size.Width - 330, questionTextBox.Height);
            questionList.Size = new Size(Size.Width - 330, Size.Height - 450);
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
