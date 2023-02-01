using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FurnitureSales.Models;

namespace FurnitureSales.Models
{
    public class Global
    {
        static FurnitureDBEntities db = new FurnitureDBEntities();
        public static Window Autorization;
        public static Window cureWindow;
        public static dynamic User { get; set; }
        public static string userName { get; set; }
        public static int idAccount { get; set; }
        public static List<string> colunsNames = new List<string>();
        public static DataGrid cureGrid { get; set; }
        public static string TableState { get; set; }
        public static dynamic Table { get; set; }
        public static int Index { get; set; }
        public static string ModelName { get; set; }
        

        public static void Search()
        {


            if (User != null)
            {
               if (User.typeOfAccount == "Admin" || User.typeOfAccount == "Manager")
                {
                    userName = (from worker in db.Workers where worker.codeAccount == idAccount select worker).First().surname;
                }
               else if (User.typeOfAccount == "Organization")
                {
                    userName = (from buyer in db.Buyers where buyer.codeAccount == idAccount select buyer).First().nameOfOrganization;
                }

            }
        }
        public  static void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public static  void Sorting()
        {
            ICollectionView view =
            CollectionViewSource.GetDefaultView(cureGrid.ItemsSource);
            view.SortDescriptions.Clear();
            foreach (var i in Global.colunsNames)
            {
                SortDescription sortingColumn = new SortDescription(i, ListSortDirection.Ascending);
                view.SortDescriptions.Add(sortingColumn);
            }
            Global.colunsNames.Clear();
        }
    }

}
