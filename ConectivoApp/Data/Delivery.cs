using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Data;

public class Delivery
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal PriceBrutto { get; set; }
    public decimal PriceNetto { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? SupplierName { get; set; }
}


