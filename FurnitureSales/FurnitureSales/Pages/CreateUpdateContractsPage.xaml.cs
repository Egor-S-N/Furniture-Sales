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
using FurnitureSales.Models;
using System.Windows.Shapes;
using System.Data.Entity;

namespace FurnitureSales.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateUpdateContractsPage.xaml
    /// </summary>
    public partial class CreateUpdateContractsPage : Page
    {
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        private List<TextBox> textBoxes = new List<TextBox>();
        int rowIndex = 1, columnIndex = 0;


        FurnitureDBEntities db = new FurnitureDBEntities();
        public CreateUpdateContractsPage()
        {
            InitializeComponent();
            if (Global.TableState == "New")
            {
                AddComboBox();
            }
            else if (Global.TableState == "Update")
            {
                var contracts = (from cont in db.Contarcts where cont.idContract == Global.Index select cont).First();
                DueDate.SelectedDate = contracts.dueDate;
                var sales = (from sale in db.ContractsSales where sale.idContract == Global.Index select sale).ToList();
                var products = (from table in db.TypesOfFurnitures select table).ToList();
                for (int i = 0; i < sales.Count(); i++)
                {

                    MessageBox.Show(sales[i].TypeOfFurniture + "\n" + sales[i].id.ToString());
                    AddComboBox();
                    comboBoxes[i].Text = sales[i].TypeOfFurniture;

                    textBoxes[i].Text = sales[i].count.ToString();
                }
                butAddToDataBase.Content = "Update contract";
                butAddToDataBase.Click -= butAddToDataBase_Click;
                butAddToDataBase.Click += butUpdateDataBase_Click;

            }

        }

        private void AddTypes_Click(object sender, RoutedEventArgs e)
        {
            AddComboBox();
        }

        private void AddComboBox()
        {
            var values = (from table in db.TypesOfFurnitures select table.model).ToList();

            ComboBox combo = new ComboBox();
            TextBox tb = new TextBox();

            Grid.SetRow(combo, rowIndex);
            Grid.SetColumn(combo, columnIndex);

            tb.Width = 150;
            tb.Height = 40;
            Grid.SetRow(tb, rowIndex);
            Grid.SetColumn(tb, columnIndex + 1);
            combo.Height = 40;
            combo.Width = 150;
            ContractsGrid.Children.Add(combo);
            ContractsGrid.Children.Add(tb);
            textBoxes.Add(tb);
            foreach (string item in values)
            {
                ComboBoxItem comboBox = new ComboBoxItem();
                comboBox.Content = item;

                combo.Items.Add(comboBox);
            }
            comboBoxes.Add(combo);


            if (columnIndex < 2)
            {
                columnIndex += 2;
            }
            else
            {
                columnIndex = 0;
                rowIndex += 1;

                ContractsGrid.RowDefinitions.Add(new RowDefinition());
            }

        }

        private void butAddToDataBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                int idContract = db.Contarcts.Max(x => x.idContract) + 1;

                db.Contarcts.Add(new Contarcts
                {
                    idContract = idContract,
                    idBuyer = 1,
                    registrationDate = DateTime.Now,
                    dueDate = DueDate.SelectedDate.Value.Date,
                    order = idContract
                });




                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    int idCS = db.ContractsSales.Max(x => x.id) + 1;
                    db.ContractsSales.Add(new ContractsSales
                    {
                        id = idCS,
                        idContract = idContract,
                        TypeOfFurniture = AddToDB(i).Item1,
                        count = AddToDB(i).Item2
                    });
                    db.SaveChanges();
                }
                MessageBox.Show("Success");
                Global.cureGrid.Items.Refresh();
            }   
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private Tuple<string, int> AddToDB(int id)
        {
            int value;
            if (Int32.TryParse(textBoxes[id].Text, out value))
            {
                ComboBoxItem typeItem = (ComboBoxItem)comboBoxes[id].SelectedItem;
                return new Tuple<string, int>(typeItem.Content.ToString(), value);
            }
            return null;
        }
        private void butUpdateDataBase_Click(object sender, RoutedEventArgs e)
        {   
            
            var contract = (from table in db.Contarcts where table.idContract == Global.Index select table).First();
            contract.dueDate = DueDate.SelectedDate.Value.Date;
            db.Entry(contract).State = EntityState.Modified;
            for (int i = 0; i < comboBoxes.Count; i ++)
            {
                ComboBoxItem typeItem = (ComboBoxItem)comboBoxes[i].SelectedItem;
                var item = typeItem.Content.ToString();
                MessageBox.Show(item);
                var CS = db.ContractsSales.Where(x => x.TypeOfFurniture == item && x.idContract == Global.Index);
                if (CS.Count() != 0)
                {
                    var cs = CS.First();
                    cs.TypeOfFurniture = item;
                    cs.count = Convert.ToInt32(textBoxes[i].Text);
                    db.Entry(cs).State = EntityState.Modified;
                }
                else
                {
                    db.ContractsSales.Add(new ContractsSales
                    {
                        id = db.ContractsSales.Max(x => x.id) + 1,
                        idContract = Global.Index,
                        TypeOfFurniture = item,
                        count = Convert.ToInt32(textBoxes[i].Text)
                    });

                }
            }

            try
            {

                db.SaveChanges();
                MessageBox.Show("SaveSuccess");
            }
            catch
            {
                MessageBox.Show("ERR");
            }
        }
    }
}
