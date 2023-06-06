using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal PriceBuy { get; set; }
        public decimal PriceSell { get; set; }
        public byte Tax { get; set; }


    }
}
