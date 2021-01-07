using Products.ViewModel;
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

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для CreateNew.xaml
    /// </summary>
    public partial class CreateNew : Page
    {
        ProductsApplicationContext db;

        public CreateNew()
        {
            InitializeComponent();

            db = new ProductsApplicationContext();
        }


        private void Continue_Click_1(object sender, RoutedEventArgs e)
        {
            string group = Group.Text;
            string name = ProductName.Text;
            string maker = Maker.Text;
            string date = Date.Text;
            if (group == "")
            {
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                try
                {
                    int expiry = Convert.ToInt32(Expiry.Text);

                    Product product = new Product(group, name, maker, date, expiry);

                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Вы были возвращены к таблице продуктов. Введенные данные имели неверный формат.");
                }


                this.Visibility = Visibility.Collapsed;
            }
        }

        public class Item
        {
            public string GroupName { get; set; }
            public string ProductName { get; set; }
            public string Maker { get; set; }
            public string ProductionDate { get; set; }
            public int ExpiryTime { get; set; }

            public Item(string groupName, string productName, string maker, string productionDate, int expiryTime)
            {
                GroupName = groupName;
                ProductName = productName;
                Maker = maker;
                ProductionDate = productionDate;
                ExpiryTime = expiryTime;
            }
        }
    }
}
