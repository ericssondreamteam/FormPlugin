using FormPlugin.Data;
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
    public partial class ChangeThePath : Form
    {
        public ChangeThePath()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0) //&& textBox1.Text is existing path
            {
                //MessageBox.Show(textBox1.Text);
                Configuration.pathFileTemplate = textBox1.Text;
                try
                {
                    if (Directory.Exists(textBox1.Text))
                        Directory.CreateDirectory(textBox1.Text);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                Close();
            }
        }
    }
}
