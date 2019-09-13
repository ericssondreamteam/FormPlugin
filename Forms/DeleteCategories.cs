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
    public partial class DeleteCategories : Form
    {
        public DeleteCategories()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            GlobalInfo.DeleteCategoriesDateStart = startDate.Value;
            GlobalInfo.DeleteCategoriesDateFinish = finishDate.Value;
            GlobalInfo.DeleteCategoriesConfirmation = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            GlobalInfo.DeleteCategoriesConfirmation = DialogResult.Cancel;
            Close();
        }
    }
}
