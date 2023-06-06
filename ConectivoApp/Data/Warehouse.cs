using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Data
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int NeededQuantity { get; set; }
        public int NowQuantiy { get; set; }
        public int Priority { get; set; }
    }
}
