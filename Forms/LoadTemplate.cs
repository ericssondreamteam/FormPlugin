using FormPlugin.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPlugin.Forms
{
    public partial class LoadTemplate : Form
    {
        public LoadTemplate()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
            //Thread.Sleep(1000);
            LoadData loadData = new LoadData();
            loadData.createMail();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult)
        }
    }
}
