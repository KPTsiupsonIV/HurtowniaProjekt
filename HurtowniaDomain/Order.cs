using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtowniaDomain
{
    public class Order
    {
        public int Id {  get; set; }
        public int quantiy { get; set; }
        public decimal price { get; set; }
        public int idEmployee { get; set; }
        public decimal commisionValue { get; set; }

    }
}
