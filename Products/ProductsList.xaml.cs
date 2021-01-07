using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Data.SQLite;
using System.Data.Entity;
using System.Configuration;
using Products.ViewModel;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;


namespace Products
{
    /// <summary>
    /// Логика взаимодействия для ProductsList.xaml
    /// </summary>
    public partial class ProductsList : Page
    {
        ProductsApplicationContext db;
        static int fileid = 0;
        string filename = $"products_{fileid}";

        public ProductsList()
        {
            InitializeComponent();

            db = new ProductsApplicationContext();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            CreateFrame.NavigationService.Navigate(new Uri("CreateNew.xaml", UriKind.Relative));
            PlusBtn.Visibility = Visibility.Hidden;
            ApplyBtn.Visibility = Visibility.Visible;
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            PlusBtn.Visibility = Visibility.Visible;
            ApplyBtn.Visibility = Visibility.Hidden;
            UpdateView();
        }

        private void ProductsTable_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateView();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

            var product = ProductsTable.SelectedItem as Product;

            if (ProductsTable.SelectedItem == null) return;

            int id = product.id;    
            CreateFrame.NavigationService.Navigate(new UpdateOld(product, id));

            ApplyBtn.Visibility = Visibility.Visible;
        }

        private void SerializeBtn_Click(object sender, RoutedEventArgs e)
        {
            fileid++;
            List<Product> Products = db.Products.ToList(); 
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream($@"E:\3KURS\PracticePROGR\program\Products\Products\bin\Debug\{filename}.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, Products);
            }
            MessageBox.Show($"Данные сериализованы в файл {filename}");
        }

        private void DeserializeBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
            List<Product> ProdictsSerializeList = new List<Product>();
            using (FileStream fs = new FileStream($@"E:\3KURS\PracticePROGR\program\Products\Products\bin\Debug\{filename}.json", FileMode.OpenOrCreate))
            {
                ProdictsSerializeList = (List<Product>)jsonFormatter.ReadObject(fs);
            }
            MessageBox.Show($"Десериализация из файла {filename} закончена");
            SerializeUpdateView(ProdictsSerializeList);
        }

        private void DateBtn_Click(object sender, RoutedEventArgs e)
        {
            DateCheckWindow dateCheckWindow = new DateCheckWindow();
            dateCheckWindow.Show();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = ProductsTable.SelectedIndex;
            var product = ProductsTable.SelectedItem as Product;
            db.Products.Remove(product);
            db.SaveChanges();
            UpdateView();
        }

        private void UpdateView()
        {
            db.Products.Load();
            ProductsTable.ItemsSource = db.Products.ToList();
        }

        private void SerializeUpdateView(List<Product> prod)
        {
            foreach(Product p in prod)
            {
                if (db.Products.Any(a => a.ExpiryTime == p.ExpiryTime && 
                                         a.GroupName == p.GroupName &&
                                         a.Maker == p.Maker &&
                                         a.ProductionDate == p.ProductionDate &&
                                         a.ProductName == p.ProductName)) continue;
                else db.Products.Add(p);
            }
            db.SaveChanges();

            UpdateView();
        }

        private void SearchUpdateView(string search)
        {
            db.Products.Load();
            List<Product> ProductsListFilter = new List<Product>();

            foreach(Product p in db.Products.ToList())
            {
                if (p.GroupName == search)
                {
                    ProductsListFilter.Add(p);
                }
            }
            ProductsTable.ItemsSource = ProductsListFilter;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchText.Text;
            SearchUpdateView(search);
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
