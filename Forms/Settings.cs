using FormPlugin.Data;
using Microsoft.Office.Interop.Outlook;
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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void CleanCategories_Click(object sender, EventArgs e)
        {
            DeleteCategories delete = new DeleteCategories();
            delete.ShowDialog();
            if (GlobalInfo.DeleteCategoriesConfirmation == DialogResult.OK)
            {
                Data.Categories.DeleteAllOurCategoires(GlobalInfo.DeleteCategoriesDateStart, GlobalInfo.DeleteCategoriesDateFinish);
            }
        }

        private void ChangeObservedFolder_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Want You edit settings?", "Editing Settings", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Configuration.DeleteConfig();
                NameSpace outlookNameSpace = ThisAddIn.zmiennaDoSettinngs.GetNamespace("MAPI");
                MAPIFolder inbox = outlookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                Configuration.Config(outlookNameSpace, ref inbox, ThisAddIn.zmiennaDoSettinngs.Application);
                MessageBox.Show("Please restart outlook to introduce changes");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
