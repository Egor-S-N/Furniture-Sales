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
using System.Windows.Shapes;
using FurnitureSales.Models;

namespace FurnitureSales
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            try
            {
                BitmapImage photo = new BitmapImage();
                photo.BeginInit();
                
                photo.UriSource = new Uri($"D:\\VS_PROJECTS\\Furniture-Sales-\\FurnitureSales\\FurnitureSales\\Resources\\{Global.User.typeOfAccount}.jpg");
                photo.EndInit();
                profilePhoto.Source = photo;

                profileName.Content = Global.userName;
                profileType.Content = Global.User.typeOfAccount;
            }
            catch (Exception)
            {
    
            }
        }

        private void butBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Global.Autorization.Show();

        }
        private  void Window_Closed(object sender, EventArgs e)
        {
            Global.Autorization.Close();
        }
    }
}
