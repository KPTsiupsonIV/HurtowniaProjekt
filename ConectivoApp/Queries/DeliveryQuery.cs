using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectivoApp.Data;

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
            foreach(Delivery delivery in deliveryList)
            {
                if (delivery.Id == id)
                {
                    deliveryById.Add(delivery);
                }
            }
            return deliveryById;
        }
        public void DeliveryAdd(string productName,int quantity,decimal priceBrutto,decimal priceNetto,DateTime deliveryDate,string supplierName)
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
            }
        }
    }
}