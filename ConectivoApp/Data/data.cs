using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Data
{
    /// <summary>
    /// Represents a delivery entity.
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// Gets or sets the delivery ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product ID (foreign key property).
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the associated product (navigation property).
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the delivery.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the gross price of the delivery.
        /// </summary>
        public decimal PriceBrutto { get; set; }

        /// <summary>
        /// Gets or sets the net price of the delivery.
        /// </summary>
        public decimal PriceNetto { get; set; }

        /// <summary>
        /// Gets or sets the delivery date.
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the supplier ID (foreign key property).
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the associated supplier (navigation property).
        /// </summary>
        public Supplier Supplier { get; set; }

        // Other properties and methods
    }

    /// <summary>
    /// Represents a supplier entity.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the supplier ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the NIP (tax identification number) of the supplier.
        /// </summary>
        public string Nip { get; set; }

        /// <summary>
        /// Gets or sets the location of the supplier.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage offered by the supplier.
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Gets or sets the deliveries associated with the supplier.
        /// </summary>
        public ICollection<Delivery> Deliveries { get; set; }
    }

    /// <summary>
    /// Represents a warehouse entity.
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Gets or sets the warehouse ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product stored in the warehouse.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the needed quantity of the product in the warehouse.
        /// </summary>
        public int NeededQuantity { get; set; }

        /// <summary>
        /// Gets or sets the current quantity of the product in the warehouse.
        /// </summary>
        public int NowQuantity { get; set; }

        /// <summary>
        /// Gets or sets the priority of the warehouse.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the product ID (foreign key property).
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the associated product (navigation property).
        /// </summary>
        public Product Product { get; set; }
    }

    /// <summary>
    /// Represents a product entity.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the buying price of the product.
        /// </summary>
        public decimal PriceBuy { get; set; }

        /// <summary>
        /// Gets or sets the selling price of the product.
        /// </summary>
        public decimal PriceSell { get; set; }

        /// <summary>
        /// Gets or sets the tax rate for the product.
        /// </summary>
        public byte Tax { get; set; }

        /// <summary>
        /// Gets or sets the warehouses associated with the product.
        /// </summary>
        public ICollection<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// Gets or sets the deliveries associated with the product.
        /// </summary>
        public ICollection<Delivery> Deliveries { get; set; }
    }

    /// <summary>
    /// Represents an order entity.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the order.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the employee ID (foreign key property).
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the commission value for the order.
        /// </summary>
        public decimal CommissionValue { get; set; }

        /// <summary>
        /// Gets or sets the associated employee (navigation property).
        /// </summary>
        public Employee Employee { get; set; }
    }

    /// <summary>
    /// Represents an employee entity.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the surname of the employee.
        /// </summary>
        public string EmployeeSurname { get; set; }

        /// <summary>
        /// Gets or sets the commission percentage for the employee.
        /// </summary>
        public int Commission { get; set; }

        /// <summary>
        /// Gets or sets the pension for the employee.
        /// </summary>
        public int Pension { get; set; }

        /// <summary>
        /// Gets or sets the password for the employee.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the orders associated with the employee.
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}