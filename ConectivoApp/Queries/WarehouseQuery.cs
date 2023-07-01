using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConectivoApp.Queries
{
    /// <summary>
    /// Represents a query class for retrieving and manipulating warehouse data.
    /// </summary>
    internal class WarehouseQuery
    {
        /// <summary>
        /// Gets or sets the list of warehouses.
        /// </summary>
        public List<Warehouse> warehouseList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WarehouseQuery"/> class.
        /// </summary>
        public WarehouseQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                warehouseList = _context.Warehouses.OrderBy(x => x.Priority).ToList();
            }
        }

        /// <summary>
        /// Adds a new warehouse record.
        /// </summary>
        /// <param name="productName">The name of the product.</param>
        /// <param name="neededQuantity">The needed quantity of the product.</param>
        /// <param name="nowQuantity">The current quantity of the product.</param>
        /// <param name="priority">The priority of the warehouse record.</param>
        public void WarehouseAdd(string productName, int neededQuantity, int nowQuantity, int priority)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                // Check if a product with the same name already exists in the warehouse
                if (_context.Warehouses.Any(w => w.Product.ProductName == productName))
                {
                    // If the product already exists, display an appropriate notification or take appropriate action
                    MessageBox.Show("Product with the same name already exists in the warehouse.");
                    return;
                }

                // Create a new Warehouse record
                Warehouse warehouse = new Warehouse();
                warehouse.ProductName = productName;
                warehouse.NeededQuantity = neededQuantity;
                warehouse.NowQuantity = nowQuantity;
                warehouse.Priority = priority;

                // Retrieve the Product entity based on the product name
                Product product = _context.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product != null)
                {
                    // If the product is found, assign the corresponding ProductId to the Warehouse record
                    warehouse.ProductId = product.Id;
                }
                else
                {
                    // If the product is not found, create a new Product entity
                    product = new Product { ProductName = productName };
                    _context.Products.Add(product);
                    _context.SaveChanges();

                    // Assign the corresponding ProductId to the Warehouse record
                    warehouse.ProductId = product.Id;
                }

                // Add the record to the warehouse and save the changes to the database
                _context.Warehouses.Add(warehouse);
                _context.SaveChanges();

                MessageBox.Show($"Record added to Warehouse: {productName}");
            }
        }

        /// <summary>
        /// Retrieves warehouse records based on their ID.
        /// </summary>
        /// <param name="id">The ID of the warehouse record.</param>
        /// <returns>The list of warehouse records with the specified ID.</returns>
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

        /// <summary>
        /// Updates a warehouse record.
        /// </summary>
        /// <param name="warehouseBase">The updated warehouse record.</param>
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
                    warehouse.NowQuantity = warehouseBase.NowQuantity;

                    // Save the changes to persist the updates in the database
                    _context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Removes a warehouse record.
        /// </summary>
        /// <param name="id">The ID of the warehouse record to remove.</param>
        public void Remove(int id)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var warehouse = _context.Warehouses.SingleOrDefault(w => w.Id == id);
                _context.Warehouses.Remove(warehouse);
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Populates the warehouse with initial data.
        /// </summary>
        public void Populate()
        {
            using (var context = new HurtowniaContext())
            {
                var warehouses = new List<Warehouse>
            {
                new Warehouse { ProductName = "wood", NeededQuantity = 20, NowQuantity = 10, Priority = 1 },
                new Warehouse { ProductName = "steel", NeededQuantity = 30, NowQuantity = 15, Priority = 2 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 40, NowQuantity = 20, Priority = 3 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 50, NowQuantity = 25, Priority = 4 },
                new Warehouse { ProductName = "copper", NeededQuantity = 60, NowQuantity = 30, Priority = 5 },
                new Warehouse { ProductName = "iron", NeededQuantity = 70, NowQuantity = 35, Priority = 1 },
                new Warehouse { ProductName = "glass", NeededQuantity = 80, NowQuantity = 40, Priority = 2 },
                new Warehouse { ProductName = "paper", NeededQuantity = 90, NowQuantity = 45, Priority = 3 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 100, NowQuantity = 50, Priority = 4 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 110, NowQuantity = 55, Priority = 5 },
                new Warehouse { ProductName = "wood", NeededQuantity = 120, NowQuantity = 60, Priority = 1 },
                new Warehouse { ProductName = "steel", NeededQuantity = 130, NowQuantity = 65, Priority = 2 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 140, NowQuantity = 70, Priority = 3 },
                new Warehouse { ProductName = "copper", NeededQuantity = 150, NowQuantity = 75, Priority = 4 },
                new Warehouse { ProductName = "iron", NeededQuantity = 160, NowQuantity = 80, Priority = 5 },
                new Warehouse { ProductName = "glass", NeededQuantity = 170, NowQuantity = 85, Priority = 1 },
                new Warehouse { ProductName = "paper", NeededQuantity = 180, NowQuantity = 90, Priority = 2 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 190, NowQuantity = 95, Priority = 3 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 200, NowQuantity = 100, Priority = 4 },
                new Warehouse { ProductName = "wood", NeededQuantity = 210, NowQuantity = 105, Priority = 5 },
                new Warehouse { ProductName = "steel", NeededQuantity = 220, NowQuantity = 110, Priority = 1 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 230, NowQuantity = 115, Priority = 2 },
                new Warehouse { ProductName = "copper", NeededQuantity = 240, NowQuantity = 120, Priority = 3 },
                new Warehouse { ProductName = "iron", NeededQuantity = 250, NowQuantity = 125, Priority = 4 },
                new Warehouse { ProductName = "glass", NeededQuantity = 260, NowQuantity = 130, Priority = 5 },
                new Warehouse { ProductName = "paper", NeededQuantity = 270, NowQuantity = 135, Priority = 1 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 280, NowQuantity = 140, Priority = 2 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 290, NowQuantity = 145, Priority = 3 },
                new Warehouse { ProductName = "wood", NeededQuantity = 300, NowQuantity = 150, Priority = 4 },
                new Warehouse { ProductName = "steel", NeededQuantity = 310, NowQuantity = 155, Priority = 5 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 320, NowQuantity = 160, Priority = 1 },
                new Warehouse { ProductName = "copper", NeededQuantity = 330, NowQuantity = 165, Priority = 2 },
                new Warehouse { ProductName = "iron", NeededQuantity = 340, NowQuantity = 170, Priority = 3 },
                new Warehouse { ProductName = "glass", NeededQuantity = 350, NowQuantity = 175, Priority = 4 },
                new Warehouse { ProductName = "paper", NeededQuantity = 360, NowQuantity = 180, Priority = 5 },
                new Warehouse { ProductName = "fabric", NeededQuantity = 370, NowQuantity = 185, Priority = 1 },
                new Warehouse { ProductName = "plastic", NeededQuantity = 380, NowQuantity = 190, Priority = 2 },
                new Warehouse { ProductName = "wood", NeededQuantity = 390, NowQuantity = 195, Priority = 3 },
                new Warehouse { ProductName = "steel", NeededQuantity = 400, NowQuantity = 200, Priority = 4 },
                new Warehouse { ProductName = "aluminum", NeededQuantity = 410, NowQuantity = 205, Priority = 5 }
            };

                context.Warehouses.AddRange(warehouses);

                // Save the changes to the database
                context.SaveChanges();
            }
        }
    }
}
