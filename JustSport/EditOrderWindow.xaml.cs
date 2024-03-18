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

namespace JustSport
{
    /// <summary>
    /// Interaction logic for EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public EditOrderWindow(CustomerOrder customerOrder)
        {
            InitializeComponent();
            Loaded += EditOrderWindow_Loaded;
        }

        private void EditOrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.CustomerOrders.Load();
            DataContext = db.CustomerOrders.Local.ToObservableCollection();
        }

        private void Click_Admin(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            var productList = db.CustomerOrders.ToList();

            adminWindow.DataContext = productList;
            adminWindow.Show();
            this.Close();
        }

       

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            CustomerOrder? customerOrder = ProductOrder?.SelectedItem as CustomerOrder;
            if (customerOrder is null) return;
            db.CustomerOrders.Remove(customerOrder);
            db.SaveChanges();
        }
    }
}
