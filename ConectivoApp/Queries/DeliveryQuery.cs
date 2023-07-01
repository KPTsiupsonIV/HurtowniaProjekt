using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ConectivoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ConectivoApp.Queries
{
    /// <summary>
    /// Represents a query class for retrieving and manipulating delivery data.
    /// </summary>
    internal class DeliveryQuery
    {
        /// <summary>
        /// Gets or sets the list of delivery items.
        /// </summary>
        public List<Data.Delivery> deliveryList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryQuery"/> class.
        /// </summary>
        public DeliveryQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                deliveryList = _context.Deliveries.ToList();
            }
        }

        /// <summary>
        /// Retrieves deliveries by their ID.
        /// </summary>
        /// <param name="id">The ID of the delivery to retrieve.</param>
        /// <returns>The list of deliveries matching the specified ID.</returns>
        public List<Data.Delivery> GetDeliveryById(int id)
        {
            List<Data.Delivery> deliveryById = new List<Data.Delivery>();
            foreach (Data.Delivery delivery in deliveryList)
            {
                if (delivery.Id == id)
                {
                    deliveryById.Add(delivery);
                }
            }
            return deliveryById;
        }

        /// <summary>
        /// Adds a new delivery to the database.
        /// </summary>
        /// <param name="productName">The name of the product for the delivery.</param>
        /// <param name="quantity">The quantity of the product in the delivery.</param>
        /// <param name="priceBrutto">The brutto price of the delivery.</param>
        /// <param name="priceNetto">The netto price of the delivery.</param>
        /// <param name="deliveryDate">The delivery date.</param>
        /// <param name="supplierName">The name of the supplier for the delivery.</param>
        public void DeliveryAdd(string productName, int quantity, decimal priceBrutto, decimal priceNetto, DateTime deliveryDate, string supplierName)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                // Retrieve the product based on the provided product name
                var product = _context.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product == null)
                {
                    // Handle the case when the product doesn't exist
                    MessageBox.Show("The specified product does not exist in the database.");
                    return;
                }

                // Retrieve the supplier based on the provided supplier name
                var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierName == supplierName);
                if (supplier == null)
                {
                    // Handle the case when the supplier doesn't exist
                    MessageBox.Show("The specified supplier does not exist in the database.");
                    return;
                }

                // Create a new Delivery object
                Data.Delivery delivery = new Data.Delivery();
                delivery.Quantity = quantity;
                delivery.PriceBrutto = priceBrutto;
                delivery.PriceNetto = priceNetto;
                delivery.DeliveryDate = deliveryDate;

                // Set the product and supplier for the delivery
                delivery.Product = product;
                delivery.Supplier = supplier;

                _context.Deliveries.Add(delivery);
                _context.SaveChanges();

                MessageBox.Show($"You have added: {productName} delivery to Delivery");
            }
        }

        /// <summary>
        /// Updates an existing delivery in the database.
        /// </summary>
        /// <param name="delivery">The updated delivery object.</param>
        public void Update(Data.Delivery delivery)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var deliveryToUpdate = _context.Deliveries.FirstOrDefault(w => w.Id == delivery.Id);
                deliveryToUpdate.Quantity = delivery.Quantity;
                deliveryToUpdate.PriceBrutto = delivery.PriceBrutto;
                deliveryToUpdate.PriceNetto = delivery.PriceNetto;
                deliveryToUpdate.DeliveryDate = delivery.DeliveryDate;

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a delivery from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the delivery to remove.</param>
        public void Remove(int id)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var delivery = _context.Deliveries.SingleOrDefault(w => w.Id == id);
                _context.Remove(delivery);
                _context.SaveChanges();
            }
        }
    }
}
