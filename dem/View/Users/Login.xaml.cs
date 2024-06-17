using dem.Data;
using dem.View.Products;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string _userName = LoginText.Text;
            string _email = EmailText.Text;
            string _password = PasswordText.Password;
            using (DemDbContext dbContext = new DemDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Name == _userName);
                if (user != null)
                {
                    MessageBox.Show("Авторизация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    IndexProduct createProduct = new IndexProduct();
                    createProduct.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}