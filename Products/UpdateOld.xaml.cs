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
    /// Логика взаимодействия для UpdateOld.xaml
    /// </summary>
    public partial class UpdateOld : Page
    {
        ProductsApplicationContext db;

        private int pid;
        public UpdateOld(Product product, int id)
        {
            InitializeComponent();
            db = new ProductsApplicationContext();

            Group.Text = product.GroupName;
            ProductName.Text = product.ProductName;
            Maker.Text = product.Maker;
            Date.Text = product.ProductionDate;
            Expiry.Text = product.ExpiryTime.ToString();

            pid = id;
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            var product = db.Products.Find(pid);

            product.GroupName = Group.Text;
            product.ProductName = ProductName.Text;
            product.Maker = Maker.Text;
            product.ProductionDate = Date.Text;
            product.ExpiryTime = Convert.ToInt32(Expiry.Text);

            db.SaveChanges();

            this.Visibility = Visibility.Collapsed;
        }
    }
}
