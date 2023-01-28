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
using System.Windows.Navigation;
using FurnitureSales.Models;
using System.Windows.Shapes;

namespace FurnitureSales.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateUpdateContractsPage.xaml
    /// </summary>
    public partial class CreateUpdateContractsPage : Page
    {
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        int rowIndex = 0, columnIndex = 2;


        FurnitureDBEntities db = new FurnitureDBEntities();
        public CreateUpdateContractsPage()
        {
            InitializeComponent();
        }

        private void AddTypes_Click(object sender, RoutedEventArgs e)
        {
            AddComboBox();
        }

        private void AddComboBox()
        {

            
           
                if (columnIndex < 3)
                {
                    columnIndex += 1;
                }
                else
                {
                    columnIndex = 0;
                    rowIndex += 1;

                    ContractsGrid.RowDefinitions.Add(new RowDefinition());
                }

                var values = (from table in db.TypesOfFurnitures select table.model).ToList();

                ComboBox combo = new ComboBox();
                Grid.SetRow(combo, rowIndex);
                Grid.SetColumn(combo, columnIndex);
                combo.Height = 40;
                combo.Width = 150;
                ContractsGrid.Children.Add(combo);
                foreach (string item in values)
                {
                    ComboBoxItem comboBox = new ComboBoxItem();
                    comboBox.Content = item;

                    combo.Items.Add(comboBox);
                }
                comboBoxes.Add(combo);
           

        }
    }

}
