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
    /// Логика взаимодействия для SortingWindow.xaml
    /// </summary>
    public partial class SortingWindow : Window
    {
        List<CheckBox> checkBoxesList = new List<CheckBox>();
        List<Label> LabelsList = new List<Label>();
        public SortingWindow()
        {
            InitializeComponent();

            for (int i = 1; i < Global.colunsNames.Count(); i ++ )
            {

                Label label = new Label();
                label.Content = Global.colunsNames[i];
                label.HorizontalAlignment = HorizontalAlignment.Right;
                label.VerticalAlignment = VerticalAlignment.Center;
                sortingGrid.Children.Add(label);
                LabelsList.Add(label);

                Grid.SetColumn(label, 0);
                Grid.SetRow(label, i);

                CheckBox checkBox = new CheckBox();
                checkBox.Content = "Не сортировать";
                
                checkBox.Checked += Checked;
                checkBox.Unchecked += Unchecked;
                checkBox.HorizontalAlignment = HorizontalAlignment.Left;
                checkBox.VerticalAlignment = VerticalAlignment.Center;
                sortingGrid.Children.Add(checkBox);
                checkBoxesList.Add(checkBox);
                Grid.SetColumn(checkBox, 1);
                Grid.SetRow(checkBox, i);
                Grid.SetRow(butSort, i+1);

                sortingGrid.RowDefinitions.Add(new RowDefinition());
            }
        }
        private void Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.Content = "Сортировать";
        }
        private void Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.Content = "Не сортировать";
        }

        private void butSort_Click(object sender, RoutedEventArgs e)
        {
            Global.colunsNames.Clear();
            for(int i = 0; i < checkBoxesList.Count(); i++)
            {
                if (checkBoxesList[i].IsChecked == true)
                {
                    Global.colunsNames.Add(LabelsList[i].Content.ToString());
                }
            }
            Global.Sorting();
            
        }
    }
}
