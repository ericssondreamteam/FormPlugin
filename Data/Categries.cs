﻿using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace FormPlugin.Data
{
    class Categories
    {

        public static void EnumerateCategories()
        {
            Outlook.Categories categories =
                ThisAddIn.zmiennaDoSettinngs.Session.Categories;
            foreach (Outlook.Category category in categories)
            {
                Debug.WriteLine(category.Name);
                Debug.WriteLine(category.CategoryID);
            }
        }

        private static void AddACategory(string categoryName, Outlook.OlCategoryColor color)
        {
            Outlook.Categories categories =
                ThisAddIn.zmiennaDoSettinngs.Session.Categories;
            if (!CategoryExists(categoryName))
            {
                _ = categories.Add(categoryName,
                    color);
            }
        }

        internal static void AddCategorires()
        {
            AddACategory("Good Response",Outlook.OlCategoryColor.olCategoryColorGreen);
            AddACategory("Bad Response",Outlook.OlCategoryColor.olCategoryColorOrange);

        }
        public DateTime dateTime;
        public static void  DeleteAllOurCategoires(DateTime date)
        {
            Outlook.Application oApp = new Outlook.Application();
            NameSpace oNS = oApp.GetNamespace("mapi");
            MAPIFolder oInbox2 = oApp.ActiveExplorer().CurrentFolder as MAPIFolder;
            Items oItems = oInbox2.Items;

            //Sort all items
            oItems.Sort("[ReceivedTime]", true);
            MailItem email1 = null;
            foreach (object collectionItem in oItems)
            {
                try
                {
                    email1 = collectionItem as MailItem;
                    if (email1 != null)
                    {
                        if (email1.ReceivedTime > date)
                            email1.Categories = RemoveUnnecessaryCategories(email1.Categories);
                        else
                            break;
                    }
                }
                catch(System.Exception e)
                {
                    _ = e.Message;
                }
            }


        }
        private static string RemoveUnnecessaryCategories(string categories)
        {
            //MessageBox.Show("Started: "+categories);
            HashSet<string> catWithoutDuplicate = new HashSet<string>();
            string[] cat = categories.Split(',');
            for (int i = 0; i < cat.Length; i++)
            {
                catWithoutDuplicate.Add(cat[i].Trim());
            }
            string finnal = "";
            foreach (string s in catWithoutDuplicate)
            {
                if (!s.Trim().Equals("You Must Decide") && !s.Equals("Bad Response") && !s.Equals("Good Response"))
                {
                    if (!finnal.Equals(""))
                        finnal = finnal + ", " + s.Trim();
                    else
                        finnal = s.Trim();
                }
            }          
            //MessageBox.Show("Finnal: "+finnal);
            return finnal;
        }
        private static bool CategoryExists(string categoryName)
        {
            try
            {
                Outlook.Category category =
                    ThisAddIn.zmiennaDoSettinngs.Session.Categories[categoryName];
                if (category != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
    }
}
