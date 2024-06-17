using dem.Data;
using dem.Models;
using Microsoft.EntityFrameworkCore;
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

namespace dem.View.Products
{
    /// <summary>
    /// Логика взаимодействия для IndexProduct.xaml
    /// </summary>
    public partial class IndexProduct : Window
    {
        public IndexProduct()
        {
            InitializeComponent();
            LoadProduct();
        }

        private void LoadProduct()
        {
            using (var dbcontext = new DemDbContext())
            {
                ListProduct.ItemsSource = dbcontext.Products.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = ListProduct.SelectedItem as Product;
            var a = MessageBox.Show("Вы действительно хотите удалить?", "Вопрос", MessageBoxButton.YesNoCancel);
            if (a == MessageBoxResult.Yes)
            {
                using (var dbcontext = new DemDbContext())
                {
                    dbcontext.Products.Remove(product);
                    dbcontext.SaveChanges();
                }
                LoadProduct();
            }

        }
    }
}
