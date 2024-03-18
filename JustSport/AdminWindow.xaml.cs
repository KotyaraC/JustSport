using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace JustSport
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public AdminWindow()
        {
            InitializeComponent();
            Loaded += AdminWindow_Loaded;
        }

        private void AdminWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Products.Load();
            DataContext = db.Products.Local.ToObservableCollection();
        }

        private void Click_User(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct(new Product());
            if (addProduct.ShowDialog() == true)
            {
                
                Product product = addProduct.Product;
                db.Products.Add(product);
                db.SaveChanges();
            }
            else { MessageBox.Show("Error"); }
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            Product? product = ProductList.SelectedItem as Product;
            if (product is null) return;

            AddProduct addProduct = new AddProduct(new Product
            {
                Title= product.Title,
                Quantity= product.Quantity,
                Price= product.Price,
                ImagePath= product.ImagePath,
                Category= product.Category,
                Description = product.Description,

        });
            if (addProduct.ShowDialog() == true)
            {
                product = db.Products.Find(addProduct.Product.Id);
                product.ImagePath = product.ImagePath;
                product.Title = addProduct.Product.Title;
                product.Quantity = addProduct.Product.Quantity;
                product.Price = addProduct.Product.Price;
                product.Category = addProduct.Product.Category;
                product.Description = addProduct.Product.Description;

                db.SaveChanges();

            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Product? product = ProductList?.SelectedItem as Product;
            if(product is null)return;
            db.Products.Remove(product);
            db.SaveChanges();
        }

        private void Telephone_Click(object sender, RoutedEventArgs e)
        {
            var editOrderWindow = new EditOrderWindow(new CustomerOrder());
            editOrderWindow.Show();
        }
    }
}
