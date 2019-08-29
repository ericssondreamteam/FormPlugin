using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FormPlugin.Data;
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace FormPlugin.Forms
{
    public partial class SendForm : Form
    {
        bool checkTemplate = false;
        LoadData loadData;
        public SendForm()
        {
            InitializeComponent();
            loadData = new LoadData();
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
                openFileDialog.Title = "Template for email";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    loadData.setPathFile(path);
                    checkTemplate = true;
                    //label3.Text = openFileDialog.SafeFileName;
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
            foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
            {
                loadData.sendMail("RE: " + email.Subject, email.SenderName);
            }
            Close();

        }
    }
}
