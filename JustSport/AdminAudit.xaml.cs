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
    /// Interaction logic for AdminAudit.xaml
    /// </summary>
    public partial class AdminAudit : Window
    {
        ApplicationContext db = new ApplicationContext();

        public AdminAudit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            MainWindow mainWindow = new MainWindow();
            string password = new System.Net.NetworkCredential(string.Empty, AdminPass.SecurePassword).Password;
            if (AdminLogin.Text == "Admin" || password == "Admin")
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Error");
                mainWindow.Show();
                this.Close();
            }
        }


    }
}
