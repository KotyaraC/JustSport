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
    /// Interaction logic for ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        public ProductDetailsWindow(Product product)
        {
            InitializeComponent();
            dsImage.Source = new BitmapImage(new Uri(product.ImagePath, UriKind.RelativeOrAbsolute));
            dsTitle.Text = product.Title;
            dsPrice.Text = string.Format("${0:N2}", product.Price);
            dsQuantity.Text =product.Quantity;
            dsDescription.Text = product.Description;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            var phoneNumberWindow = new PhoneNumberWindow(dsTitle.Text);
            phoneNumberWindow.ShowDialog();
        }
    }
}
