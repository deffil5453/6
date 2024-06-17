using dem.Data;
using dem.Models;
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

namespace dem.View.Users
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string _userName = LoginText.Text;
            string _email = EmailText.Text;
            string _password = PasswordText.Password;
            using (DemDbContext dbContext = new DemDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u=>u.Email== _email);
                if (user == null)
                {
                    user = new User { Name = _userName, Email = _email, Password = _password, RoleId = 1 };
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином или почтой уже есть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}
