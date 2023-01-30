using FurnitureSales.Models;
using FurnitureSales.Pages;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace FurnitureSales
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        private int Index;
        public MainWindow()
        {
            InitializeComponent();
            RefreshgGrid();
            Global.cureGrid = contractsDataGrid;
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
        private void Window_Closed(object sender, EventArgs e)
        {
            Global.Autorization.Close();

            
        }

        private void RefreshgGrid()
        {
            db = new FurnitureDBEntities();
            db.Contarcts.Load();

            contractsDataGrid.ItemsSource = db.Contarcts.Local.Select(x => new
            {
                ID = x.idContract,
                Покупатель = (from org in db.Buyers where org.idBuyer == x.idBuyer select org.nameOfOrganization).First(),
                ДатаРегистрации = x.registrationDate.ToString("dd/MM/yyyy"),
                ДатаИсполнения = x.dueDate.ToString("dd/MM/yyyy"),
                ЗАКАЗ = Orders(x.order)
            }).ToList();


            contractsDataGrid.Items.Refresh();
        }

        private string Orders(int id)
        {
            string res = "";
            var order = from contract in db.ContractsSales where contract.idContract == id select contract;
            foreach (var i in order)
            {
                res += $"TYPE: {i.TypeOfFurniture} COUNT: {i.count}\n";
            }
            return res;
        }

        private void butSort_Click(object sender, RoutedEventArgs e)
        {
            
            Global.colunsNames.Clear();
            foreach(var item in contractsDataGrid.Columns)
            {
                Global.colunsNames.Add(item.Header.ToString());
            }

            SortingWindow sortingWindow = new SortingWindow();
            sortingWindow.Show();


            

        }

        private void butAddNewContract_Click(object sender, RoutedEventArgs e)
        {
            Global.TableState = "New";
            CreateUpdateWindow createWindow = new CreateUpdateWindow("Contracts");
            createWindow.Show();
           
        }
       
        

        private void butDelContract_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Index.ToString(), "Delete contract", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                try
                {

                    var contract = (from table in db.Contarcts where table.idContract == Index select table).First();
                    var values = from table in db.ContractsSales where table.idContract == Index select table;
                    foreach (var item in values)
                    {
                        db.ContractsSales.Remove(item);
                    }
                    db.Contarcts.Remove(contract);
                    db.SaveChanges();
                    MessageBox.Show("DELETED");
                    RefreshgGrid();
                }
                catch
                {
                    MessageBox.Show("ERR");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contractsDataGrid.Items.Refresh();
            RefreshgGrid();
        }

        private void DataGridRow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Index = contractsDataGrid.SelectedIndex + 1;
        }

        private void butUpdateContract_Click(object sender, RoutedEventArgs e)
        {
            Global.Index = Index;
            Global.TableState = "Update";
            CreateUpdateWindow createWindow = new CreateUpdateWindow("Contracts");
            createWindow.Show();
        }
    }
}
