using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using JustSport;
using Microsoft.EntityFrameworkCore;
using static JustSport.ApplicationContext;

namespace JustSport
{
    public partial class PhoneNumberWindow : Window
    {
        private string productName;
        ApplicationContext db = new ApplicationContext();
        public PhoneNumberWindow(string productName)
        {
            InitializeComponent();
            DataContext = new ApplicationContext();
            productNameTextBox.Text = productName;
            Loaded += PhoneNumberWindow_Loaded;
        }
        private void PhoneNumberWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.CustomerOrders.Load();
            DataContext = db.CustomerOrders.Local.ToObservableCollection();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string customerName = txtCustomerName.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string productName = productNameTextBox.Text;

                // Перевірка формату номера телефону
                if (!IsValidPhoneNumber(phoneNumber))
                {
                    MessageBox.Show("Invalid phone number format! Please enter a valid phone number.");
                    return;
                }

                using (var db = new ApplicationContext())
                {
                    var order = new CustomerOrder
                    {
                        CustomerName = customerName,
                        PhoneNumber = phoneNumber,
                        ProductName = productName
                    };

                    db.CustomerOrders.Add(order);
                    db.SaveChanges();
                }

                MessageBox.Show("Order placed successfully!");
                Close();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"DbUpdateException occurred: {ex.Message}");
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception: {ex.InnerException.Message}");
                }
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^(\+?3?8?)?\s?\(?(0\d{2})\)?[\s.-]?(\d{3})[\s.-]?(\d{2})[\s.-]?(\d{2})$");
            return regex.IsMatch(phoneNumber);
        }
    }
}
