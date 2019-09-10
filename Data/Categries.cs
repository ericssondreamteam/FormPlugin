using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            AddACategory("Good Response",Outlook.OlCategoryColor.olCategoryColorDarkGreen);
            AddACategory("Bad Response",Outlook.OlCategoryColor.olCategoryColorDarkRed);
            AddACategory("You Must Decide",Outlook.OlCategoryColor.olCategoryColorDarkYellow);
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
