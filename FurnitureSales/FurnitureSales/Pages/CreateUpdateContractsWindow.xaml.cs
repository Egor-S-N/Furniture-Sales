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
    /// Логика взаимодействия для CreateUpdateContracts.xaml
    /// </summary>
    public partial class CreateUpdateContracts : Window
    {
        FurnitureDBEntities db = new FurnitureDBEntities();
        public CreateUpdateContracts()
        {
            InitializeComponent();
            if(Global.contractState == "New")
            {
                this.Title = "Создание нового заказа";
            }
            if (Global.contractState == "Update")
            {
                this.Title = "Изменение существующего заказа";
                var a = Convert.ChangeType(Global.Table, typeof(Contarcts));
                foreach(var i in a )
                {
                    MessageBox.Show(i.ToString());
                }
            }


        }
    }
}
