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
    /// Логика взаимодействия для CreateUpdateWorkersPage.xaml
    /// </summary>
    public partial class CreateUpdateWorkersPage : Page
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        public CreateUpdateWorkersPage()
        {
            InitializeComponent();
            if (Global.TableState == "New")
            {
                ButEnter.Click += ButAddNew_Click;
            }
            else if (Global.TableState == "Update")
            {
                var worker = (from table in db.Workers where table.idWorker == Global.Index select table).First();
                SurnameTB.Text = worker.surname;
                NameTB.Text = worker.name;
                PatronymicTB.Text = worker.patronymic;
                PostTB.Text = worker.post;
                LoginTB.Text = db.Accounts.Where(x => x.idAccount == worker.codeAccount).First().login;
                PasswordTB.Text = db.Accounts.Where(x => x.idAccount == worker.codeAccount).First().password;

                Operation.Content = "Update workers";
                ButEnter.Content = "Update worker";
                ButEnter.Click += ButUpdate_Click;
            }
        }

        private void ButAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Accounts acc = new Accounts();
                acc.idAccount = db.Accounts.Max(x=>x.idAccount) + 1;
                acc.login = LoginTB.Text;
                acc.password = PasswordTB.Text;
                acc.typeOfAccount = PostTB.Text;

                db.Accounts.Add(acc);


                db.Workers.Add(new Workers
                {
                    idWorker = db.Workers.Max(x=>x.idWorker) + 1,
                    surname = SurnameTB.Text,
                    name = NameTB.Text,
                    patronymic = PatronymicTB.Text,
                    post = PostTB.Text,
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

                var worker = (from table in db.Workers where table.idWorker == Global.Index select table).First();
                worker.surname = SurnameTB.Text;
                worker.name = NameTB.Text;
                worker.patronymic = PatronymicTB.Text;
                worker.post = PostTB.Text;

                db.Entry(worker).State = EntityState.Modified;

                var account = (from table in db.Accounts where table.idAccount == worker.codeAccount select table).First();
                account.login = LoginTB.Text;
                account.password = PasswordTB.Text;
                account.typeOfAccount = PostTB.Text;

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
