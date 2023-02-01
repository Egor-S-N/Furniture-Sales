using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FurnitureSales.Models;

namespace FurnitureSales.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdateSalesPage.xaml
    /// </summary>
    public partial class UpdateSalesPage : Page
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        public UpdateSalesPage()
        {
            InitializeComponent();
            var sale = (from table in db.Sales where table.idSale == Global.Index select table).First();
            FurniturelName.Text = sale.furnitureName;
            ModelName.Text = sale.model;
            soldCount.Text = sale.numberOfSold.ToString();
        }

        private void ButEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sale = (from table in db.Sales where table.idSale == Global.Index select table).First();
                sale.numberOfSold = Convert.ToInt32(soldCount.Text);
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("ERR");
            }
        }
    }
}
