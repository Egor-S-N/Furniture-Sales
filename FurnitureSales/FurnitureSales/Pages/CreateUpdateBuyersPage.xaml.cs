using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace FurnitureSales.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateUpdateBuyersPage.xaml
    /// </summary>
    public partial class CreateUpdateBuyersPage : Page
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        public CreateUpdateBuyersPage()
        {
            InitializeComponent();
            if (Global.TableState == "New")
            {
                ButEnter.Click += ButAddNew_Click;
            }
            else if (Global.TableState == "Update")
            {
                var buyer = (from table in db.Buyers where table.idBuyer == Global.Index select table).First();
                NameTB.Text = buyer.nameOfOrganization;
                AdressTB.Text = buyer.adress;
                PhoneTB.Text = buyer.phone;
                LoginTB.Text = db.Accounts.Where(x => x.idAccount == buyer.codeAccount).First().login;
                PasswordTB.Text = db.Accounts.Where(x => x.idAccount == buyer.codeAccount).First().password;

                Operation.Content = "Update buyers";
                ButEnter.Content = "Update buyer";
                ButEnter.Click += ButUpdate_Click;
            }
        }
        private void ButAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Accounts acc = new Accounts();
                acc.idAccount = db.Accounts.Max(x => x.idAccount) + 1;
                acc.login = LoginTB.Text;
                acc.password = PasswordTB.Text;
                acc.typeOfAccount = "Organization";

                db.Accounts.Add(acc);


                db.Buyers.Add(new Buyers
                {
                   idBuyer = db.Buyers.Max(x=>x.idBuyer) + 1,
                   nameOfOrganization = NameTB.Text,
                   adress = AdressTB.Text,
                   phone = PhoneTB.Text,
                   codeAccount = acc.idAccount
                });


                db.SaveChanges();
                MessageBox.Show("Success");

            }
            catch
            {
                MessageBox.Show("ERR");
            }
        }
        private void ButUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var buyer = (from table in db.Buyers where table.idBuyer == Global.Index select table).First();
                buyer.nameOfOrganization = NameTB.Text;
                buyer.adress = AdressTB.Text;
                buyer.phone = PhoneTB.Text;


                db.Entry(buyer).State = EntityState.Modified;



                var account = (from table in db.Accounts where table.idAccount == buyer.codeAccount select table).First();
                account.login = LoginTB.Text;
                account.password = PasswordTB.Text;
                account.typeOfAccount = "Organization";

                db.Entry(account).State = EntityState.Modified;

                db.SaveChanges();
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("ERR");
            }
        }
    }
}
