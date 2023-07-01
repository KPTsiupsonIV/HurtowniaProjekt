using ConectivoApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Queries
{
    /// <summary>
    /// Represents a query class for retrieving and manipulating order data.
    /// </summary>
    internal class OrdersQuery
    {
        /// <summary>
        /// Gets or sets the list of orders.
        /// </summary>
        public List<Order> ordersList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersQuery"/> class.
        /// </summary>
        public OrdersQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                ordersList = _context.Orders.ToList();
            }
        }

        /// <summary>
        /// Retrieves orders by the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The list of orders associated with the specified employee ID.</returns>
        public List<Order> GetOrdersByEmployeeId(int id)
        {
            return ordersList.Where(o => o.EmployeeId == id).ToList();
        }

        /// <summary>
        /// Populates the orders table with random order data.
        /// </summary>
        public void PopulateOrders()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                Random random = new Random();
                for (int i = 0; i < 50; i++)
                {
                    var order = new Order
                    {
                        Quantity = random.Next(1, 100),                        // Generates a random number between 1 and 100 for Quantity
                        Price = (decimal)random.NextDouble() * 1000,           // Generates a random decimal number between 0 and 1000 for Price
                        EmployeeId = random.Next(1, 10),                       // Generates a random number between 1 and 10 for EmployeeId
                        CommissionValue = (decimal)random.NextDouble() * 100   // Generates a random decimal number between 0 and 100 for CommissionValue
                    };
                    _context.Orders.Add(order);
                }
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds a new order to the orders table.
        /// </summary>
        /// <param name="order">The order object to add.</param>
        public void OrdersAdd(Order order)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an existing order in the orders table.
        /// </summary>
        /// <param name="order">The updated order object.</param>
        public void Update(Order order)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var orderToUpdate = _context.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (orderToUpdate != null)
                {
                    orderToUpdate.Quantity = order.Quantity;
                    orderToUpdate.Price = order.Price;
                    orderToUpdate.CommissionValue = order.CommissionValue;
                    orderToUpdate.EmployeeId = order.EmployeeId;
                    _context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Removes an order from the orders table based on its ID.
        /// </summary>
        /// <param name="id">The ID of the order to remove.</param>
        public void Remove(int id)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var order = _context.Orders.FirstOrDefault(o => o.Id == id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                }
            }
        }
    }
}
