using FormPlugin.Data;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPlugin.Forms
{
    public partial class Check : Form
    {
        CheckMail checkMail;
        bool checkTemplate = false;

        public Check()
        {
            InitializeComponent();
            MailItem mailItem = Globals.ThisAddIn.Application.ActiveExplorer().Selection[1] as MailItem;
            checkMail = new CheckMail(mailItem);
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
                    string path = openFileDialog.FileName;
                    checkMail.setFilePath(path);
                    //MessageBox.Show(path);
                    checkTemplate = true;
                    //label3.Text = openFileDialog.SafeFileName;
                    button2.Text = "CHECK " + openFileDialog.SafeFileName;
                }
            }
            else
                MessageBox.Show("First use 'Create Form' button from menu.", "Warning");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (checkTemplate)
            {
                Close();
                checkMail.check();
            }
            else
                MessageBox.Show("First choose your template", "Warning");

        }
    }
}
