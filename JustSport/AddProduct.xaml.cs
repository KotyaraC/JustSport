using Microsoft.Win32;
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

namespace JustSport
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private string imagePath;
        public Product Product { get; private set; }
        public AddProduct(Product product)
        {
            InitializeComponent();
            Product = product;
            //Product.ImagePath = ""; 
            DataContext = Product;
        }


        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif|All files (*.*)|*.*";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                imagePath = openFileDialog.FileName;

                ImagePathTextBox.Text = imagePath;
            }
        }

        private void Acert_Click(object sender, RoutedEventArgs e)
        {
            Product.ImagePath = imagePath;
            DialogResult = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
