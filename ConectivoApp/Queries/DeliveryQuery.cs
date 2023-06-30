using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectivoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ConectivoApp.Queries
{
    internal class DeliveryQuery
    {
        public List<Delivery> deliveryList { get; set; }

        public DeliveryQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                deliveryList = _context.Deliveries.ToList();
            }
        }

        public List<Delivery> GetDeliveryById(int id)
        {
            List<Delivery> deliveryById = new List<Delivery>();
            foreach (Delivery delivery in deliveryList)
            {
                if (delivery.Id == id)
                {
                    deliveryById.Add(delivery);
                }
            }
            return deliveryById;
        }
        public void DeliveryAdd(string productName, int quantity, decimal priceBrutto, decimal priceNetto, DateTime deliveryDate, string supplierName)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                Delivery delivery = new Delivery();
                delivery.ProductName = productName;
                delivery.Quantity = quantity;
                delivery.PriceBrutto = priceBrutto;
                delivery.PriceNetto = priceNetto;
                delivery.DeliveryDate = deliveryDate;
                delivery.SupplierName = supplierName;

                _context.Deliveries.Add(delivery);
                _context.SaveChanges();
            }
        }
        public void Update(Delivery delivery)
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