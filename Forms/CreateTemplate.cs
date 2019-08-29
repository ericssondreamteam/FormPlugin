using FormPlugin.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPlugin.Forms
{
    public partial class CreateTemplate : Form
    {
        CreateData data;
        public CreateTemplate(CreateData create)
        {
            data = create;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            data.addQuestion(textBox1.Text);          
            ListViewItem itm;         
            itm = new ListViewItem(textBox1.Text);
            //to oglnie do poprawy, ale napierw tempalate
            listView1.Items.Add(itm);
            textBox1.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //save tamplate
         

        }
    }
}
