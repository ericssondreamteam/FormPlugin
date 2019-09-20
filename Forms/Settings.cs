using FormPlugin.Data;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Windows.Forms;
using Exception = System.Exception;

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

        private void LoadForm_Click(object sender, EventArgs e)
        {
            LoadTemplate loadTemplate = new LoadTemplate();
            loadTemplate.Show();
        }

        private void TESTCheckMail_Click(object sender, EventArgs e)
        {
            try
            {
                Check check = new Check();
                check.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception");
                _ = ex.Message;
            }
        }

        private void TESTCheckConv_Click(object sender, EventArgs e)
        {
            try
            {
                Main.manuallyCheckAutomaticReply();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CHECK CONVERSATION: \n" + ex.Message + "\n" + ex.StackTrace,
                    "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
