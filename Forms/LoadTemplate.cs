using FormPlugin.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace FormPlugin.Forms
{
    public partial class LoadTemplate : Form
    {
        bool checkTemplate = false;
        LoadData loadData;
        public LoadTemplate()
        {
            InitializeComponent();
            loadData = new LoadData();
            if (Directory.Exists(Configuration.pathFileTemplate))
            {
                string path = Configuration.pathFileTemplate + "\\Default.oft";
                if (File.Exists(path))
                {
                    checkTemplate = true;
                    loadData.SetPathFile(path);
                    label3.Text = "Default.oft";
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkTemplate)
            {
                Close();
                loadData.CreateMail();
            }
            else
                MessageBox.Show("First choose your template", "Warning");
            
        }

        private void Button2_Click(object sender, EventArgs e)
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
                    loadData.SetPathFile(path);
                    checkTemplate = true;
                    label3.Text = openFileDialog.SafeFileName;
                }
            }
            else
                MessageBox.Show("First use 'Create Form' button from menu.", "Warning");
            
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string to = textBox1.Text;
            loadData.SetMailTo(to);
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string subject = textBox2.Text;
            loadData.SetSubject(subject);
        }
    }
}
