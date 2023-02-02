using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Логика взаимодействия для GraphicWindow.xaml
    /// </summary>
    public partial class GraphicWindow : Window
    {
        FurnitureDBEntities database = new FurnitureDBEntities();
        List<KeyValuePair<string, int>> IS = new List<KeyValuePair<string, int>>();

        public GraphicWindow()
        {
            InitializeComponent();

            GetData();
        }

        public GraphicWindow(string table)
        {
            InitializeComponent();

            GetData();
        }

        private void GetData()
        {

            foreach (Sales op in database.Sales)
            {
                
                    IS.Add(new KeyValuePair<string, int>(database.Sales.Where(a => a.idSale == op.idSale).FirstOrDefault().model, database.Sales.Where(s => s.idSale == op.idSale).FirstOrDefault().numberOfSold));
            }
            ((ColumnSeries)GraphicChart.Series[0]).ItemsSource = IS;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
