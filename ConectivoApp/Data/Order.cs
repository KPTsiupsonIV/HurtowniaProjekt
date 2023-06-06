using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantiy { get; set; }
        public decimal Price { get; set; }
        public int IdEmployee { get; set; }
        public decimal CommisionValue { get; set; }

    }
}
