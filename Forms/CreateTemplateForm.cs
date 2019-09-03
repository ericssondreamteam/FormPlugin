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

        bool czyEdytujemy = false;
        public CreateTemplateForm()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "Create Template";
            comboBox1.SelectedText = "Create Template";
            browseButton.Hide();
            chooseTemplateLabel.Hide();
            deleteTempBut.Hide();
            label1.Hide();

            questionList.AllowDrop = true;
            questionList.DragDrop += new DragEventHandler(dragDrop);
            questionList.DragEnter += new DragEventHandler(dragEnter);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.Equals("Create Template"))
            {
                textBox2.Show();
                label3.Show();
                browseButton.Hide();
                chooseTemplateLabel.Hide();
                deleteTempBut.Hide();
                label1.Hide();
                czyEdytujemy = false;
            }
            if(comboBox1.SelectedItem.Equals("Edit Template"))
            {
                textBox2.Hide();
                label3.Hide();
                browseButton.Show();
                chooseTemplateLabel.Show();
                deleteTempBut.Show();
                label1.Show();
                czyEdytujemy = true;
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
            foreach (object anItem in questionList.Items)
            {
                body.Append("<strong>" + questionCounter + ". " + anItem.ToString() + "<strong>" + "<BR><BR><BR>");
                questionCounter++;
            }         
            return body.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (questionList.Items.Count == 0)
            {
                warningLabelEmpty.Text = "We cannot\n create template\n without any\n questions";
            }
            else
            {
                //check if directory exist
                if (!Directory.Exists(Configuration.pathFileTemplate))
                    Directory.CreateDirectory(Configuration.pathFileTemplate);
                //save tamplate

                if(czyEdytujemy == false)
                {
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
                else
                {
                    MessageBox.Show("RZECZYWISCIE ZAPISUJEMY EDYTOWANY PLIK");
                    Outlook.Application outlookApp = new Outlook.Application();
                    MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
                    mailItem.HTMLBody = createBodyMail();
                    mailItem.SaveAs(Configuration.pathFileTemplate + "\\" + label1.Text);
                    Close();
                }
                
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
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
                    
                }
            }
            else
                MessageBox.Show("First use 'Create Form' button from menu.", "Warning");
        }

        private void dragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dragDrop(object sender, DragEventArgs e)
        {
            questionList.Items.Add(e.Data.ToString());
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if(questionList.SelectedIndex == -1)
            {
                MessageBox.Show("Select item to move up or down", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int newIndex = questionList.SelectedIndex - 1;

                if (newIndex < 0)
                    return;

                object selectedItem = questionList.SelectedItem;

                questionList.Items.Remove(selectedItem);
                questionList.Items.Insert(newIndex, selectedItem);
                questionList.SetSelected(newIndex, true);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (questionList.SelectedIndex == -1)
            {
                MessageBox.Show("Select item to move up or down", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int newIndex = questionList.SelectedIndex + 1;

                if (newIndex > questionList.Items.Count - 1)
                    return;

                object selectedItem = questionList.SelectedItem;

                questionList.Items.Remove(selectedItem);
                questionList.Items.Insert(newIndex, selectedItem);
                questionList.SetSelected(newIndex, true);
            }
        }
    }
}
