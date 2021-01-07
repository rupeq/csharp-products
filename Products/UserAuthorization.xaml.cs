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
    /// Логика взаимодействия для UserAuthorization.xaml
    /// </summary>
    public partial class UserAuthorization : Window
    {
        public UserAuthorization()
        {
            InitializeComponent();

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password1 = textBoxPassword1.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Длина логина должна быть больше 5 символов!";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (password1.Length < 5 || password1.ToLower() == password1)
            {
                textBoxPassword1.ToolTip = "Пароль должен содержать прописные символы и быть не менее 5 символов!";
                textBoxPassword1.Background = Brushes.Red;
            }
            else
            {
                User authUser = null;

                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(user => user.Login == login && user.Password == password1).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show($"Добро пожаловать, {login}!");
                    
                    string text = $"Здравствуйте, {login}";

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.userText.Text = text;
                    mainWindow.Login = login;
                    mainWindow.Password = password1;
                    mainWindow.Email = authUser.Email;
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверно введены данные или пользователя не существует!");
                }
            }
        }

        private void GoToRegistration_Click(object sender, RoutedEventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            userRegistration.Show();

            this.Close();
        }
    }
}
