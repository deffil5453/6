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

namespace dem.View.Products
{
    /// <summary>
    /// Логика взаимодействия для CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        public CreateProduct()
        {
            InitializeComponent();
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            using (DemDbContext dbContext = new DemDbContext())
            {
                Product product = new Product { Name = TextName.Text };
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                MessageBox.Show("Товар добавлен", "успех");
                IndexProduct indexProduct = new IndexProduct();
                indexProduct.Show();
                this.Close();
            }
        }
    }
}
