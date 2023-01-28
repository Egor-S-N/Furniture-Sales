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
                AddComboBox();
               
            }
            if (Global.contractState == "Update")
            {
                this.Title = "Изменение существующего заказа";
            }


        }

        private void AddComboBox()
        {
            var values = (from table in db.TypesOfFurnitures select table.model).ToList();

            ComboBox combo = new ComboBox();
            combo.Width = 100;
            combo.Height = 30;
            Pole.Children.Add(combo);
            foreach (string item in values)
            {
                ComboBoxItem comboBox = new ComboBoxItem();
                comboBox.Content = item;
                combo.Items.Add(comboBox);
            }

        }
    }
}
