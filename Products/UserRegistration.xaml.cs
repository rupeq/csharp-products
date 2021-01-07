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
    /// Логика взаимодействия для UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        ApplicationContext db;

        public UserRegistration()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string email = textBoxEmail.Text.ToLower().Trim();

            User isExists = null;

            isExists = db.Users.Where(user => user.Login == login || user.Email == email).FirstOrDefault();
            if (isExists == null)
            {
                string password1 = textBoxPassword1.Password.Trim();
                string password2 = textBoxPassword2.Password.Trim();
                

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
                else if (password1 != password2)
                {
                    textBoxPassword1.Background = Brushes.Red;
                    textBoxPassword2.Background = Brushes.Red;

                    textBoxPassword1.ToolTip = "Пароли должны совпадать!";
                    textBoxPassword2.ToolTip = "Пароли должны совпадать!";
                }
                else if (!email.Contains("@") || !email.Contains("."))
                {
                    textBoxEmail.ToolTip = "Почта введена некорректно!";
                    textBoxEmail.Background = Brushes.Red;
                }
                else
                {
                    User user = new User(login, email, password1);

                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show($"Пользователь {login} успешно зарегистрирован!");

                    UserAuthorization userAuthorization = new UserAuthorization();
                    userAuthorization.Show();
                    this.Close();
                }
            }
            else
            {
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxLogin.BorderBrush = Brushes.Red;

                textBoxLogin.ToolTip = "Пользователь с таким логином или почтой уже зарегистрирован";
                textBoxEmail.ToolTip = "Пользователь с таким логином или почтой уже зарегистрирован";

            }
        }

        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            UserAuthorization userAuthorization = new UserAuthorization();
            userAuthorization.Show();

            this.Close();
        }
    }
}
