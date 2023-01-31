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
            Global.Autorization = this;
            this.Closed += Global.Window_Closed;
          
        }

        private void butEnter_Click(object sender, RoutedEventArgs e)
        {
            var users = from account in db.Accounts where account.login == loginTextBox.Text && account.password == passwordHideBox.Password select account;
            if (users.Count() != 0)
            {
                Global.User = users.First();
                Global.idAccount = users.First().idAccount;
                Global.Search();

                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.Show();
            }
            else
            {
                errorLogin.Visibility = Visibility.Visible;
                errorPassword.Visibility = Visibility.Visible;
            }

        }

        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            showHidePassword.Content = "Скрыть пароль";
            passwordShowTextBox.Text = passwordHideBox.Password;
            passwordShowTextBox.Visibility = Visibility.Visible;
            passwordHideBox.Visibility = Visibility.Hidden;
        }
        private void HidePassword(object sender, RoutedEventArgs e)
        {
            showHidePassword.Content = "Показать пароль";
            passwordHideBox.Password = passwordShowTextBox.Text;
            passwordShowTextBox.Visibility = Visibility.Hidden;
            passwordHideBox.Visibility = Visibility.Visible;
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            errorLogin.Visibility = Visibility.Hidden;
            errorPassword.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
