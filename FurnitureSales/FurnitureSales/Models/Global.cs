using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FurnitureSales.Models;

namespace FurnitureSales.Models
{
    public class Global
    {
        static FurnitureDBEntities db = new FurnitureDBEntities();
        public static Window Autorization;
        public static dynamic User { get; set; }
        public static string userName { get; set; }
        public static int idAccount { get; set; }

        
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
        private  static void Window_Closed(object sender, EventArgs e)
        {
            Autorization.Close();
        }
    }

}
