using FormPlugin.Data;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Application = Microsoft.Office.Interop.Outlook.Application;
using System.Collections.Generic;

namespace FormPlugin.Forms
{
    public partial class CreateTemplateForm : Form
    {
        CreateData data;
        public CreateTemplateForm()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "Create Template";
            comboBox1.SelectedText = "Create Template";
            browseButton.Hide();
            chooseTemplateLabel.Hide();
            deleteTempBut.Hide();
            label1.Hide();
            data = new CreateData();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.Equals("Create Template"))
            {
                browseButton.Hide();
                chooseTemplateLabel.Hide();
                deleteTempBut.Hide();
                label1.Hide();
            }
            if(comboBox1.SelectedItem.Equals("Edit Template"))
            {
                browseButton.Show();
                chooseTemplateLabel.Show();
                deleteTempBut.Show();
                label1.Show();
            }
        }

        private void ResizeEvent(object sender, EventArgs e)
        {
            questionTextBox.Size = new Size(Size.Width - 215, 137);
            questionList.Size = new Size(Size.Width - 215, Size.Height- 420); ;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(Configuration.pathFileTemplate + "\\" + textBox2.Text + ".oft"))
            {
                warningLabelName.Text = "This file exists. Please enter another name";
            }
            else
                warningLabelName.Text = "";
        }
        private string createBodyMail()
        {
            StringBuilder body = new StringBuilder();
            body.Append("<html><body>Hi,<BR>please fill form ;)<BR><BR>");
            int questionCounter = 1;
            foreach (string s in data.getAllQuestions())
            {
                body.Append("<strong>" + questionCounter + ". " + s + "<strong>" + "<BR><BR><BR>");
                questionCounter++;
            }
            return body.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (data.getAllQuestions().Count == 0)
            {
                warningLabelEmpty.Text = "We cannot\n create template\n without any\n questions";
            }
            else
            {
                //check if directory exist
                if (!Directory.Exists(Configuration.pathFileTemplate))
                    Directory.CreateDirectory(Configuration.pathFileTemplate);
                //save tamplate
                if (textBox2.Text.Equals(""))
                {
                    warningLabelName.Text = "Please enter a name";
                }
                else
                {
                    if (File.Exists(Configuration.pathFileTemplate + "\\" + textBox2.Text + ".oft"))
                    {
                        warningLabelName.Text = "This file exists. We cannot save";
                    }
                    else
                    {

                        Outlook.Application outlookApp = new Outlook.Application();
                        MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
                        mailItem.HTMLBody = createBodyMail();
                        mailItem.SaveAs(Configuration.pathFileTemplate + "\\" + textBox2.Text + ".oft");
                        Close();

                    }
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //dodanie do naszego modelu danych
            data.addQuestion(questionTextBox.Text);
            StringBuilder temp = new StringBuilder();
            int questionCounter = 1;
            foreach (string s in data.getAllQuestions())
            {
                temp.Append(questionCounter + ". " + s + "\n");
                questionCounter++;
            }
            //richTextBox1.Text = temp.ToString(); dodanie do tabeli
            questionList.Items.Add(questionTextBox.Text);
            questionTextBox.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (Directory.Exists(Configuration.pathFileTemplate))
            {
                openFileDialog.InitialDirectory = Configuration.pathFileTemplate;
                openFileDialog.Filter = "oft files (*.oft)|*.oft|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = false;
                openFileDialog.Title = "Template for email";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    //loadData.setPathFile(path);
                    //checkTemplate = true;
                    label1.Text = openFileDialog.SafeFileName;

                    //TERAZ PROSZE PANSTWA PAN KAROL
                    //questionList
                    Application app = new Application();
                    MailItem mail = app.CreateItemFromTemplate(filePath) as MailItem;
                    List<String> questionsFromTemplate = Tools.getQuestionsFromEmail(mail.Body);

                    
                    foreach (String s in questionsFromTemplate) {
                        //MessageBox.Show(s);
                        questionList.Items.Add(s);
                    }
                    
                    //questionList.Text = temp.ToString();
                }
            }
            else
                MessageBox.Show("First use 'Create Form' button from menu.", "Warning");
        }
    }
}
