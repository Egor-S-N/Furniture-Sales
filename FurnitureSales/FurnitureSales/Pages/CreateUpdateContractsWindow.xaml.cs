using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using FurnitureSales.Models;

namespace FurnitureSales.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateUpdateContracts.xaml
    /// </summary>
    public partial class CreateUpdateContracts : Window
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        public CreateUpdateContracts()
        {
            InitializeComponent();

            if (Global.contractState == "New")
            {
                this.Title = "Создание нового заказа";
                var values = (from table in db.TypesOfFurnitures select table.model).ToList();
                foreach(string item in values)
                {
                    ComboBoxItem comboBox = new ComboBoxItem();
                    comboBox.Content = item;
                    COMBO.Items.Add(comboBox);
                }
                //ComboBox comboBox = new ComboBox();
                //Grid.SetRow(comboBox, 0);
                //Grid.SetColumn(comboBox, 0);
                //COMBO.ItemsSource = values;
                //foreach (var value in values)
                //{
                //    //ComboBoxItem comboBoxItem = new ComboBoxItem();
                //    //comboBoxItem.Content = value.ToString();
                //    comboBox.Items.Add(value.ToString());
                //}
                



            }
            if (Global.contractState == "Update")
            {
                this.Title = "Изменение существующего заказа";
                var contarcts = (Contarcts)Global.Table;
                
            }


        }
    }
}
