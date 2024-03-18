using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace JustSport
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DbSportA.db");
        }

      

        
    }
}
