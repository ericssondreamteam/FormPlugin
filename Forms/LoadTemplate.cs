using FormPlugin.Data;
using System;
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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkTemplate)
            {
                Close();
                loadData.createMail();
            }
            else
                MessageBox.Show("First choose your template", "Warning");
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string pathTemplate = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
            openFileDialog.InitialDirectory = pathTemplate;
            //openFileDialog.DefaultExt = "oft";
            openFileDialog.Filter = "oft files (*.oft)|*.oft|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Title = "Template for email";


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                loadData.setPathFile(path);
                checkTemplate = true;
                label3.Text = openFileDialog.SafeFileName;
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string to = textBox1.Text;
            loadData.setMailTo(to);
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string subject = textBox2.Text;
            loadData.setSubject(subject);
        }
    }
}
