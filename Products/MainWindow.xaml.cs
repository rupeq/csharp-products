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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            if (HomeBtn.IsSelected) MainFrame.NavigationService.Navigate(new Uri("Profile.xaml", UriKind.Relative));
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
           // set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_products.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_products.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.7;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HomeBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomeBtn.Background = Brushes.Violet;
            ProductsBtn.Background = Brushes.Transparent;
            HomeBtn.IsSelected = true;
            ProductsBtn.IsSelected = false;
            MainFrame.Visibility = Visibility.Collapsed;

            MainFrame.NavigationService.Navigate(new Uri("Profile.xaml", UriKind.Relative));
        }

        private void ProductBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomeBtn.Background = Brushes.Transparent;
            ProductsBtn.Background = Brushes.Violet;
            HomeBtn.IsSelected = false;
            ProductsBtn.IsSelected = true;

            MainFrame.NavigationService.Navigate(new Uri("ProductsList.xaml", UriKind.Relative));
        }

        private void CheckProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileData profileData = new ProfileData();
            profileData.Show();
            profileData.LoginBox.Text = Login;
            profileData.PasswordBox.Text = Password;
            profileData.EmailBox.Text = Email;
            this.Close();
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileData profileData = new ProfileData();
            profileData.Show();
            profileData.PasswordBox.IsReadOnly = false;
            profileData.PasswordBox.Text = Password;
            profileData.LoginBox.Text = Login;
            profileData.EmailBox.Text = Email;

            profileData.Login = Login;
            profileData.Password = Password;

            this.Close();
        }

        private void ChangeEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileData profileData = new ProfileData();
            profileData.Show();
            profileData.EmailBox.IsReadOnly = false;
            profileData.PasswordBox.Text = Password;
            profileData.LoginBox.Text = Login;
            profileData.EmailBox.Text = Email;

            profileData.Login = Login;
            profileData.Password = Password;

            this.Close();
        }
    }
}
