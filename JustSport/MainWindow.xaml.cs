using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JustSport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            DataContext = db.Products.Where(p => p.Category == "Food").ToList();


        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Products.Load();
            DataContext = db.Products.Local.ToObservableCollection();

        }



        private void Click_Add(object sender, RoutedEventArgs e)
        {
            // Отримуємо обраний продукт з ListBox
            if (ProductList.SelectedItem is Product selectedProduct)
            {
                // Відкриваємо вікно деталей продукту з вибраним продуктом
                ProductDetailsWindow productDetailsWindow = new ProductDetailsWindow(selectedProduct);
                productDetailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a product first.");
            }
        }






     

        private void Click_dumbbell(object sender, RoutedEventArgs e)
        {
            DataContext = db.Products.Where(p => p.Category == "Dumb-bell").ToList();
        }
        private void Click_Pears(object sender, RoutedEventArgs e)
        {
            DataContext = db.Products.Where(p => p.Category == "Bag").ToList();
        } 
        private void Click_Equipment(object sender, RoutedEventArgs e)
        {
            DataContext = db.Products.Where(p => p.Category == "Equiment").ToList();
        } 
        private void Click_Food(object sender, RoutedEventArgs e)
        {
            DataContext = db.Products.Where(p => p.Category == "Food").ToList();
        }
        private void Click_Admin(object sender, RoutedEventArgs e)
        {
            AdminAudit adminAudit = new AdminAudit();

            if (adminAudit.ShowDialog() == true)
            {







                AdminWindow adminWindow = new AdminWindow();
                var productList = db.Products.ToList();

                adminWindow.DataContext = productList;
                adminWindow.Show();
                this.Close();

            }
        }

    }
}