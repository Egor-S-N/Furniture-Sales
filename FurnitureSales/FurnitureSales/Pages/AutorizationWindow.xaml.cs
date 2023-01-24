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

namespace FurnitureSales
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        public AutorizationWindow()
        {
            
            InitializeComponent();

            foreach(var i in db.Accounts)
            {
                MessageBox.Show(i.login + " " + i.password + " " + i.typeOfAccount);
            }

        }
    }
}
