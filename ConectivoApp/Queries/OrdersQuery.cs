using ConectivoApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Queries
{
    internal class OrdersQuery
    {

        public List<Order> ordersList { get; set; }

        public OrdersQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                ordersList = _context.Orders.ToList();
            }
        }

        public List<Order> GetOrdersByEmployeeId(int id)
        {
            List<Order> orders = new List<Order>();
            foreach(var order in ordersList)
            {
                if (order.IdEmployee == id)
                {
                    orders.Add(order);
                }
            }
            return orders;
        }

        public void PopulateOrders()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                for (int i = 0; i < 50; i++)
                {
                    Random random = new Random();
                    var order = new Order
                    {
                        Quantiy = random.Next(1, 100),                // Generates a random number between 1 and 100 for Quantity
                        Price = (decimal)random.NextDouble() * 1000,    // Generates a random decimal number between 0 and 1000 for Price
                        IdEmployee = random.Next(1, 10),                // Generates a random number between 1 and 10 for EmployeeId
                        CommisionValue = (decimal)random.NextDouble() * 100  // Generates a random decimal number between 0 and 100 for CommissionValue
                    };
                    _context.Orders.Add(order);
                }
                _context.SaveChanges();
            }
        }

        public void OrdersAdd(Order orders)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                _context.Orders.Add(orders);
                _context.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                Order orderToUpdate = _context.Orders.FirstOrDefault(w => w.Id == order.Id);
                orderToUpdate.Quantiy = order.Quantiy;
                orderToUpdate.Price = order.Price;
                orderToUpdate.CommisionValue = order.CommisionValue;
                orderToUpdate.IdEmployee = order.IdEmployee;
            }
        }
    }
}
