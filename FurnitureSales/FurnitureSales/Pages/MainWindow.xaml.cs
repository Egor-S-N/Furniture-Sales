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
        string name = string.Empty;
        FurnitureDBEntities db = new FurnitureDBEntities();
        private int Index;
        public MainWindow()
        {
            InitializeComponent();
            RefreshgGrid();
            Global.cureWindow = this;
            Global.cureGrid = contractsDataGrid;

            BitmapImage photo = new BitmapImage();
            photo.BeginInit();

            photo.UriSource = new Uri($"D:\\VS_PROJECTS\\Furniture-Sales-\\FurnitureSales\\FurnitureSales\\Resources\\{Global.User.typeOfAccount}.jpg");
            photo.EndInit();
            profilePhoto.Source = photo;

            profileName.Content = Global.userName;
            profileType.Content = Global.User.typeOfAccount;


            if (Global.User.typeOfAccount == "Organization")
            {
                WorkersTI.Visibility = Visibility.Hidden;
                SalesTI.Visibility = Visibility.Hidden;
                BuyersTI.Visibility = Visibility.Hidden;
                BuyerPanel.Visibility = Visibility.Visible;
            }
            else if (Global.User.typeOfAccount == "Manager")
            {
                WorkersTI.Visibility = Visibility.Hidden;
                BuyersTI.Visibility = Visibility.Hidden;
                ManagerPanel.Visibility = Visibility.Visible;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Visible;
            }

        }
        //go back to autorization 
        private void butBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Global.Autorization.Show();
            //Global.cureWindow.Close();

        }

        //closing window
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);


        }


        //refreshing contractsGrid
        private void RefreshgGrid()
        {
            db = new FurnitureDBEntities();
            db.Contarcts.Load();
            if (Global.User.typeOfAccount == "Organization")
            {
                contractsDataGrid.ItemsSource = db.Contarcts.Local.Select(x => new
                {
                    ID = x.idContract,
                    Organization = (from org in db.Buyers where org.idBuyer == x.idBuyer select org.nameOfOrganization).First(),
                    RegisterDate = x.registrationDate.ToString("dd/MM/yyyy"),
                    DueDate = x.dueDate.ToString("dd/MM/yyyy"),
                    Order = Orders(x.order)
                }).Where(x => x.Organization == Global.userName).ToList();
            }
            else
            {
                contractsDataGrid.ItemsSource = db.Contarcts.Local.Select(x => new
                {
                    ID = x.idContract,
                    Organization = (from org in db.Buyers where org.idBuyer == x.idBuyer select org.nameOfOrganization).First(),
                    RegisterDate = x.registrationDate.ToString("dd/MM/yyyy"),
                    DueDate = x.dueDate.ToString("dd/MM/yyyy"),
                    Order = Orders(x.order)
                }).ToList();
            }


            contractsDataGrid.Items.Refresh();
        }

        //set orders for all contracts
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


        //multisorting click
        private void butSort_Click(object sender, RoutedEventArgs e)
        {

            Global.colunsNames.Clear();
            foreach (var item in Global.cureGrid.Columns)
            {
                Global.colunsNames.Add(item.Header.ToString());
            }

            SortingWindow sortingWindow = new SortingWindow();
            sortingWindow.Show();




        }
        //new contract
        private void butAddNewContract_Click(object sender, RoutedEventArgs e)
        {
            Global.TableState = "New";
            CreateUpdateWindow createWindow = new CreateUpdateWindow("Contracts");
            createWindow.Show();

        }


        //delete contracts
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
        //refresh click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contractsDataGrid.Items.Refresh();
            RefreshgGrid();
        }

        //double click choise row 
        private void DataGridRow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Index = Global.cureGrid.SelectedIndex + 1;
            MessageBox.Show(name + "\n" + Index.ToString());
        }

        //udapte contracts
        private void butUpdateContract_Click(object sender, RoutedEventArgs e)
        {
            Global.Index = Index;
            Global.TableState = "Update";
            CreateUpdateWindow createWindow = new CreateUpdateWindow("Contracts");
            createWindow.Show();
        }


        //change tables
        private void TabCCC_GotFocus(object sender, RoutedEventArgs e)
        {

            //change datagrid
            TabItem ti = TabCCC.SelectedItem as TabItem;
            if (name != ti.Header.ToString())
            {

            name = ti.Header.ToString();
            switch(ti.Header)
            {
                case "Contracts":
                    Global.cureGrid = contractsDataGrid;
                    break;

                case "Models":
                    db.TypesOfFurnitures.Load();
                    modelsDataGrid.ItemsSource = db.TypesOfFurnitures.Local.Select(x=> new
                    {
                        Model = x.model,
                        Name = x.furnitureName,
                        Sizes = x.furnitureCharacteristics,
                        Price = x.price.ToString() + " $"

                    }).ToList();
                    Global.cureGrid = modelsDataGrid;
                    break;

                case "Sales":
                    db.Sales.Load();
                    SalesDataGrid.ItemsSource = db.Sales.Local.Select(x => new
                    {
                        ID = x.idSale,
                        Name = x.furnitureName,
                        Model = x.model,
                        SoldCount = x.numberOfSold

                    }).ToList();
                    Global.cureGrid = SalesDataGrid;
                    break;

                case "Workers":
                    db.Workers.Load();
                    workersDataGrid.ItemsSource = db.Workers.Local.Select(x => new
                    {
                        ID = x.idWorker,
                        Surname = x.surname,
                        Name = x.name,
                        Patronymic = x.patronymic,
                        Post = x.post,
                        Login = (from login in db.Accounts where login.idAccount == x.codeAccount select login.login).First(),
                        Password = (from password in db.Accounts where password.idAccount == x.codeAccount select password.password).First(),
                    }).ToList();
                    Global.cureGrid = workersDataGrid;
                    break;

                case "Buyers":
                    db.Buyers.Load();
                    buyersDataGrid.ItemsSource = db.Buyers.Local.Select(x => new
                    {
                        ID = x.idBuyer,
                        Organization = x.nameOfOrganization,
                        Adress = x.adress,
                        Phone = x.phone,
                        Login = (from login in db.Accounts where login.idAccount == x.codeAccount select login.login).First(),
                        Password = (from password in db.Accounts where password.idAccount == x.codeAccount select password.password).First(),
                    }).ToList();
                    Global.cureGrid = buyersDataGrid;
                    break;
            }
            }
        }

       
    }
}
