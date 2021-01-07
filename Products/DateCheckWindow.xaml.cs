using Products.ViewModel;
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
using System.Windows.Shapes;

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для DateCheckWindow.xaml
    /// </summary>
    public partial class DateCheckWindow : Window
    {
        ProductsApplicationContext db;

        public DateCheckWindow()
        {
            InitializeComponent();

            db = new ProductsApplicationContext();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExpiryList_Loaded(object sender, RoutedEventArgs e)
        {
            db.Products.Load();
            List<Product> products = db.Products.ToList();
            List<string> expiry = new List<string>();
            foreach(Product p in products)
            {
                if (ConvertToDateTime(p.ProductionDate).AddDays(Convert.ToInt32(p.ExpiryTime)) < DateTime.Now)
                {
                    expiry.Add($"Продукт '{p.GroupName} - {p.ProductName}' просрочен!");
                }
            }

            this.DataContext = expiry;
        }

        private DateTime ConvertToDateTime(string date)
        {
            try
            {
                string[] Date = date.Split('.');
                int day = Convert.ToInt32(Date[0]);
                int month = Convert.ToInt32(Date[1]);
                int year = Convert.ToInt32(Date[2]);
                return new DateTime(year, month, day);
            }
            catch
            {

            }
            return new DateTime();
        }
    }
}
