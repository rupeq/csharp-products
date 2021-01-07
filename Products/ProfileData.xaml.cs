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

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для ProfileData.xaml
    /// </summary>
    public partial class ProfileData : Window
    {
        ApplicationContext db;

        public string Login { get; set; }
        public string Password { get; set; }

        public ProfileData()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string email = EmailBox.Text;
            string password = PasswordBox.Text;

            User user = db.Users.Where(u => u.Login == Login && u.Password == Password).FirstOrDefault();

            if (!EmailBox.IsReadOnly)
            {
                if (EmailBox.Text.Length == 0) ;
                else user.Email = email;
            }
            else if (!LoginBox.IsReadOnly)
            {
                if (LoginBox.Text.Length == 0) ;
                else user.Login = login;
            }
            else if (!PasswordBox.IsReadOnly)
            {
                if (PasswordBox.Text.Length == 0);
                else user.Password = password;
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            db.SaveChanges();
            mainWindow.Login = login;
            mainWindow.Password = password;
            mainWindow.Email = email;
            mainWindow.userText.Text = $"Здравствуйте, {login}!";
            this.Close();
        }
    }
}
