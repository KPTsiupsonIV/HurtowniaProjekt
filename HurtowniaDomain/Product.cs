using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtowniaDomain
{
    public class Product
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public decimal priceBuy { get; set;}
        public decimal priceSell { get; set;}
        public byte tax { get; set;}


    }
}
