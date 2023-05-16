using Microsoft.EntityFrameworkCore;
using HurtowniaDomain;
namespace HurtowniaData
{
    public class HurtowniaContext:DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdB)\\MSSQLLocalDB; Initial Catalog = HurtowniaBase"
                );
        }

    }
}