using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtowniaDomain
{
    public class Delivery
    {
        public int Id { get; set; }
        public string supplierName { get; set; }
        public string towarName { get; set; }
        public int quantity { get; set; }
        public decimal priceBrutto { get; set; }
        public decimal priceNetto { get; set; }
        public DateTime deliveryDate { get; set; }

    }
}
