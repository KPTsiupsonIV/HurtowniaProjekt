using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Data
{
    /// <summary>
    /// Represents the database context for the Hurtownia application.
    /// </summary>
    public class HurtowniaContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HurtowniaContext"/> class.
        /// </summary>
        public HurtowniaContext() { }

        /// <summary>
        /// Gets or sets the deliveries DbSet.
        /// </summary>
        public DbSet<Delivery> Deliveries { get; set; }

        /// <summary>
        /// Gets or sets the warehouses DbSet.
        /// </summary>
        public DbSet<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// Gets or sets the orders DbSet.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the employees DbSet.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the suppliers DbSet.
        /// </summary>
        public DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the products DbSet.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Configures the database connection and options.
        /// </summary>
        /// <param name="optionsBuilder">The options builder for configuring the database.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HurtowniaBase");
        }

        /// <summary>
        /// Configures the database model.
        /// </summary>
        /// <param name="modelBuilder">The model builder for configuring the database model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Product)
                .WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ProductId);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Supplier)
                .WithMany(s => s.Deliveries)
                .HasForeignKey(d => d.SupplierId);

            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Product)
                .WithMany(p => p.Warehouses)
                .HasForeignKey(w => w.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Deliveries)
                .WithOne(d => d.Product)
                .HasForeignKey(d => d.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Warehouses)
                .WithOne(w => w.Product)
                .HasForeignKey(w => w.ProductId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOne(o => o.Employee)
                .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Deliveries)
                .WithOne(d => d.Supplier)
                .HasForeignKey(d => d.SupplierId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
