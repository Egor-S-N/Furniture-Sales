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
    /// Логика взаимодействия для CreateUpdateFurnityreTypesPage.xaml
    /// </summary>
    public partial class CreateUpdateFurnityreTypesPage : Page
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        public CreateUpdateFurnityreTypesPage()
        {
            InitializeComponent();

            if (Global.TableState == "New")
            {
                ButEnter.Click += AddNew_Click;
            }
            else if (Global.TableState == "Update")
            {
                Operation.Content = "Update furniture";
                ButEnter.Content = "Update furniture";
                ButEnter.Click += Update_Click;
                var prod = (from table in db.TypesOfFurnitures where table.model == Global.ModelName select table).First();
                ModelName.Text = prod.model;
                FurniturelName.Text = prod.furnitureName;
                WidthTB.Text = prod.furnitureCharacteristics.Split('x')[0];
                HeightTB.Text =  prod.furnitureCharacteristics.Split('x')[1];
                PriceTB.Text = prod.price.ToString();

            }
        }


        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.TypesOfFurnitures.Add(new TypesOfFurnitures
                {
                    model = ModelName.Text,
                    furnitureName = FurniturelName.Text,
                    furnitureCharacteristics = WidthTB.Text + "x" + HeightTB.Text,
                    price = Convert.ToInt32(PriceTB.Text)
                });
            db.SaveChanges();
                MessageBox.Show("Save success");
                Global.cureGrid.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("ERR");
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            var prod = (from table in db.TypesOfFurnitures where table.model == Global.ModelName select table).First();
            prod.model = ModelName.Text;
            prod.furnitureName = FurniturelName.Text;
            prod.furnitureCharacteristics = WidthTB.Text + "x" + HeightTB.Text;
            prod.price = Convert.ToInt32(PriceTB.Text);
            db.Entry(prod).State = EntityState.Modified;
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
