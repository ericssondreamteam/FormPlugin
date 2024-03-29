﻿using FormPlugin.Data;
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
       // private bool editSpecificQuestion = false;
        private int choosenQuestionNumber;

        public CreateTemplateForm()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "Create Template";
            comboBox1.SelectedText = "Create Template";
            browseButton.Hide();
            chooseTemplateLabel.Hide();
            deleteQuestionButton.Show();
            label1.Hide();
            //editButton.Hide();
            editButton.Enabled = false;
            deleteQuestionButton.Enabled = false;
            addButton.Enabled = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.Equals("Create Template"))
            {
                textBox2.Show();
                label3.Show();
                browseButton.Hide();
                chooseTemplateLabel.Hide();
                label1.Hide();
                deleteQuestionButton.Show();
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
            questionTextBox.Size = new Size(Size.Width - 245, questionTextBox.Size.Height);
            questionList.Size = new Size(Size.Width - 245, Size.Height- 400); ;
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
        private string CreateBodyMail()
        {
            StringBuilder body = new StringBuilder();
            body.Append("<html><body>Hi,<BR>please copy this message, fill form and resend <BR><BR>");
            int questionCounter = 1;
            foreach (object anItem in questionList.Items)
            {
                body.Append("<strong>" + questionCounter + ". " + anItem.ToString() + "</strong>" + "<BR><BR><BR>");
                //body.Append(questionCounter + ". " + anItem.ToString()  + "<BR><BR><BR>");
                questionCounter++;
            }
            body.Append("Best Regards<BR>NC MailBox");
            body.Append("</body></html>");
            return body.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (questionList.Items.Count == 0)
            {
                warningLabelEmpty.Text = "You can't create template with no questions";
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
                            mailItem.HTMLBody = CreateBodyMail();
                            mailItem.SaveAs(Configuration.pathFileTemplate + "\\" + textBox2.Text + ".oft");
                            Close();

                        }
                    }
                }
                else
                {
                    //MessageBox.Show("RZECZYWISCIE ZAPISUJEMY EDYTOWANY PLIK");
                    Outlook.Application outlookApp = new Outlook.Application();
                    MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
                    mailItem.HTMLBody = CreateBodyMail();
                    string nazwaPliku = label1.Text.Substring(17);
                    mailItem.SaveAs(Configuration.pathFileTemplate + "\\" + nazwaPliku);
                    Close();
                }
                
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(questionTextBox.Text.Length > 0)
            {
                if (!czyEdytujemy || (czyEdytujemy && templateZaladowany))
                {
                    questionList.Items.Add(questionTextBox.Text);
                    questionTextBox.Clear();
                }
                else if (czyEdytujemy == true && templateZaladowany == false)
                {

                    MessageBox.Show("First you should load your template to edition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                //NIE MOZESZ DODAC PUSTEGO TEKSTU
            }
            
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            questionList.Items.Clear();
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
                    label1.Text = "You are editing: " + openFileDialog.SafeFileName;

                    Application app = new Application();
                    MailItem mail = app.CreateItemFromTemplate(filePath) as MailItem;
                    List<String> questionsFromTemplate = Tools.GetQuestionsFromEmail(mail.Body);

                    
                    foreach (String s in questionsFromTemplate) {
                        questionList.Items.Add(s);                      
                    }
                    templateZaladowany = true;
                }
            }
            else
                MessageBox.Show("First use 'New template' button from 'Settings'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DeleteQuestionButton_Click(object sender, EventArgs e)
        {
            if(questionList.SelectedIndex != -1)
            {
                if (questionList.SelectedItems != null)
                {
                    questionList.Items.RemoveAt(choosenQuestionNumber);
                }
                else
                {
                    MessageBox.Show("Firstly, please choose an item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                //ZAZNACZ COS XD
            }

            if(questionList.Items.Count == 0)
            {
                deleteQuestionButton.Enabled = false;
                editButton.Enabled = false;
            }
            
        }

        private void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //editSpecificQuestion = true;
            if (questionList.SelectedIndex != -1)
            {
                editButton.Enabled = true;
                deleteQuestionButton.Enabled = true;
            }
            else
            {
                editButton.Enabled = false;
                deleteQuestionButton.Enabled = false;
            }
            questionTextBox.Text=questionList.GetItemText(questionList.SelectedItem);
            choosenQuestionNumber = questionList.SelectedIndex;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if(questionTextBox.Text.Length > 0)
            {
                questionList.Items[choosenQuestionNumber] = questionTextBox.Text;
                questionTextBox.Clear();
            } else
            {
                //<MUSI BYC DLUZSZY NIZ 0
            }
            
        }

        private void FontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void FontFormatButton_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if(font.ShowDialog()==DialogResult.OK)
            {
                questionTextBox.SelectionFont = font.Font;
                questionTextBox.SelectionColor = font.Color;
               // questionTextBox.Selection
            }
            
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            if (questionList.SelectedIndex == -1)
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

        private void DownButton_Click(object sender, EventArgs e)
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

        private void StyleButton_Click(object sender, EventArgs e)
        {
            CreateBodyMail();
            if (questionList.Items.Count == 0)
            {
                warningLabelEmpty.Text = "You can't create template with no questions";
            }
            else
            {
                //check if directory exist
                if (!Directory.Exists(Configuration.pathFileTemplate))
                    Directory.CreateDirectory(Configuration.pathFileTemplate);
                if (czyEdytujemy == false)
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

                            Application outlookApp = new Application();
                            MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
                            mailItem.HTMLBody = CreateBodyMail();
                            mailItem.SaveAs(Configuration.pathFileTemplate + "\\" + textBox2.Text + ".oft");
                            mailItem.Display();
                            Close();
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("RZECZYWISCIE ZAPISUJEMY EDYTOWANY PLIK");
                    Outlook.Application outlookApp = new Outlook.Application();
                    MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
                    mailItem.HTMLBody = CreateBodyMail();
                    string nazwaPliku = label1.Text.Substring(17);
                    mailItem.SaveAs(Configuration.pathFileTemplate + "\\" + nazwaPliku);
                    mailItem.Display();
                    Close();
                }
            }
        }

        private void UpButton_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
