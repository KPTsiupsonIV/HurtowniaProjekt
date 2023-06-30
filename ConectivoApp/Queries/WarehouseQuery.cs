using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Queries
{
    internal class WarehouseQuery
    {
        public List<Warehouse> warehouseList { get; set; }

        public WarehouseQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                warehouseList = warehouseList = _context.Warehouses.OrderBy(x => x.Priority).ToList();


            }
        }

        public void WarehouseAdd(string name,int quan, int need,int prio)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                Warehouse warehouse = new Warehouse();
                warehouse.ProductName = name;
                warehouse.NowQuantiy = quan;
                warehouse.Priority = prio;
                warehouse.NeededQuantity = need;
                _context.Warehouses.Add(warehouse);
                _context.SaveChanges();


            }
        }

        public List<Warehouse> GetWarehouseById(int id)
        {
            List<Warehouse> GetWarehouseById = new List<Warehouse>();
            foreach (Warehouse warehouse in warehouseList)
            {
                if (warehouse.Id == id)
                {
                    GetWarehouseById.Add(warehouse);
                }
            }
            return GetWarehouseById;
        }

        public void Update(Warehouse warehouseBase)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                Warehouse warehouse = _context.Warehouses.FirstOrDefault(w => w.Id == warehouseBase.Id);

                if (warehouse != null)
                {
                    // Modify the properties of the entity with the new values
                    warehouse.ProductName = warehouseBase.ProductName;
                    warehouse.NeededQuantity = warehouseBase.NeededQuantity;
                    warehouse.Priority = warehouseBase.Priority;
                    warehouse.NowQuantiy = warehouseBase.NowQuantiy;

                    // Save the changes to persist the updates in the database
                    _context.SaveChanges();
                }


            }
        }

        public void Remove(int id)
        {
            using(HurtowniaContext _context = new HurtowniaContext())
            {
                var warehouse = _context.Warehouses.SingleOrDefault( w => w.Id == id);
                _context.Warehouses.Remove(warehouse);
                _context.SaveChanges();
            }
        }

        public void Populate()
        {
            using (var context = new HurtowniaContext())
            {
                var warehouses = new List<Warehouse>
            {
                new Warehouse { ProductName = "wood", NeededQuantity = 20, NowQuantiy = 10, Priority = 1 },
                new Warehouse { ProductName = "steel", NeededQuantity = 30, NowQuantiy = 15, Priority = 2 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 40, NowQuantiy = 20, Priority = 3 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 50, NowQuantiy = 25, Priority = 4 },
                new Warehouse { ProductName = "copper", NeededQuantity = 60, NowQuantiy = 30, Priority = 5 },
                new Warehouse { ProductName = "iron", NeededQuantity = 70, NowQuantiy = 35, Priority = 1 },
                new Warehouse { ProductName = "glass", NeededQuantity = 80, NowQuantiy = 40, Priority = 2 },
                new Warehouse { ProductName = "paper", NeededQuantity = 90, NowQuantiy = 45, Priority = 3 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 100, NowQuantiy = 50, Priority = 4 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 110, NowQuantiy = 55, Priority = 5 },
                new Warehouse { ProductName = "wood", NeededQuantity = 120, NowQuantiy = 60, Priority = 1 },
                new Warehouse { ProductName = "steel", NeededQuantity = 130, NowQuantiy = 65, Priority = 2 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 140, NowQuantiy = 70, Priority = 3 },
                new Warehouse { ProductName = "copper", NeededQuantity = 150, NowQuantiy = 75, Priority = 4 },
                new Warehouse { ProductName = "iron", NeededQuantity = 160, NowQuantiy = 80, Priority = 5 },
                new Warehouse { ProductName = "glass", NeededQuantity = 170, NowQuantiy = 85, Priority = 1 },
                new Warehouse { ProductName = "paper", NeededQuantity = 180, NowQuantiy = 90, Priority = 2 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 190, NowQuantiy = 95, Priority = 3 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 200, NowQuantiy = 100, Priority = 4 },
                new Warehouse { ProductName = "wood", NeededQuantity = 210, NowQuantiy = 105, Priority = 5 },
                new Warehouse { ProductName = "steel", NeededQuantity = 220, NowQuantiy = 110, Priority = 1 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 230, NowQuantiy = 115, Priority = 2 },
                new Warehouse { ProductName = "copper", NeededQuantity = 240, NowQuantiy = 120, Priority = 3 },
                new Warehouse { ProductName = "iron", NeededQuantity = 250, NowQuantiy = 125, Priority = 4 },
                new Warehouse { ProductName = "glass", NeededQuantity = 260, NowQuantiy = 130, Priority = 5 },
                new Warehouse { ProductName = "paper", NeededQuantity = 270, NowQuantiy = 135, Priority = 1 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 280, NowQuantiy = 140, Priority = 2 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 290, NowQuantiy = 145, Priority = 3 },
                new Warehouse { ProductName = "wood", NeededQuantity = 300, NowQuantiy = 150, Priority = 4 },
                new Warehouse { ProductName = "steel", NeededQuantity = 310, NowQuantiy = 155, Priority = 5 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 320, NowQuantiy = 160, Priority = 1 },
                new Warehouse { ProductName = "copper", NeededQuantity = 330, NowQuantiy = 165, Priority = 2 },
                new Warehouse { ProductName = "iron", NeededQuantity = 340, NowQuantiy = 170, Priority = 3 },
                new Warehouse { ProductName = "glass", NeededQuantity = 350, NowQuantiy = 175, Priority = 4 },
                new Warehouse { ProductName = "paper", NeededQuantity = 360, NowQuantiy = 180, Priority = 5 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 370, NowQuantiy = 185, Priority = 1 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 380, NowQuantiy = 190, Priority = 2 },
                new Warehouse { ProductName = "wood", NeededQuantity = 390, NowQuantiy = 195, Priority = 3 },
                new Warehouse { ProductName = "steel", NeededQuantity = 400, NowQuantiy = 200, Priority = 4 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 410, NowQuantiy = 205, Priority = 5 }
            };

                context.Warehouses.AddRange(warehouses);

                // Save the changes to the database
                context.SaveChanges();
            }
        }
    }
}
