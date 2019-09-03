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

        private bool czyEdytujemy = false;
        private bool templateZaladowany = false;
        private bool editSpecificQuestion = false;
        private int choosenQuestionNumber;

        public CreateTemplateForm()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "Create Template";
            comboBox1.SelectedText = "Create Template";
            browseButton.Hide();
            chooseTemplateLabel.Hide();
            deleteTempBut.Hide();
            deleteQuestionButton.Hide();
            label1.Hide();
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
                deleteQuestionButton.Hide();
                czyEdytujemy = false;
                templateZaladowany = false;
                questionList.Items.Clear();
            }
            if(comboBox1.SelectedItem.Equals("Edit Template"))
            {
                textBox2.Hide();
                label3.Hide();
                browseButton.Show();
                chooseTemplateLabel.Show();
                deleteTempBut.Show();
                label1.Show();
                label1.Text = String.Empty;
                deleteQuestionButton.Show();
                czyEdytujemy = true;
                //templateZaladowany = false;
                questionList.Items.Clear();
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
            if(!czyEdytujemy || (czyEdytujemy && templateZaladowany))
            {
                if (!editSpecificQuestion)
                {

                    questionList.Items.Add(questionTextBox.Text);
                    questionTextBox.Clear();
                }
                else
                {
                    //DODAJ zamiana elementu w listBox
                    //questionList.Items[choosenQuestionNumber].Text= questionTextBox.Text;
                    questionTextBox.Clear();
                    editSpecificQuestion = false;
                }
            }
            else if(czyEdytujemy == true && templateZaladowany == false)
            {
                MessageBox.Show("First you should load your template to edition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
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
                    label1.Show();
                    label1.Text = openFileDialog.SafeFileName;

                    Application app = new Application();
                    MailItem mail = app.CreateItemFromTemplate(filePath) as MailItem;
                    List<String> questionsFromTemplate = Tools.getQuestionsFromEmail(mail.Body);

                    
                    foreach (String s in questionsFromTemplate) {
                        questionList.Items.Add(s);                      
                    }
                    templateZaladowany = true;
                }
            }
            else
                MessageBox.Show("First use 'Create Form' button from menu.", "Warning");
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

        private void QuestionList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            editSpecificQuestion = true;
            questionTextBox.Text= e.Item.Text;
            choosenQuestionNumber = e.ItemIndex;
        }

        private void DeleteQuestionButton_Click(object sender, EventArgs e)
        {
            if(questionList.SelectedItems!=null)
            {
                //DODAJ usuwanko z listBox
                //questionList.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Firstly, please choose an item");
            }
        }
    }
}
