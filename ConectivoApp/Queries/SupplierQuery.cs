using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Queries
{
    /// <summary>
    /// Represents a query class for retrieving and manipulating supplier data.
    /// </summary>
    internal class SupplierQuery
    {
        /// <summary>
        /// Gets or sets the list of suppliers.
        /// </summary>
        public List<Supplier> supplierList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierQuery"/> class.
        /// </summary>
        public SupplierQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                supplierList = _context.Suppliers.ToList();
            }
        }

        /// <summary>
        /// Retrieves suppliers by their NIP (tax identification number).
        /// </summary>
        /// <param name="nip">The NIP of the supplier.</param>
        /// <returns>The list of suppliers with the specified NIP.</returns>
        public List<Supplier> GetSupplierByNip(string nip)
        {
            List<Supplier> supplierByNip = new List<Supplier>();
            foreach (Supplier supplier in supplierList)
            {
                if (supplier.Nip == nip)
                {
                    supplierByNip.Add(supplier);
                }
            }
            return supplierByNip;
        }

        /// <summary>
        /// Adds a new supplier to the suppliers table.
        /// </summary>
        /// <param name="supplier">The supplier object to add.</param>
        public void AddSupplier(Supplier supplier)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an existing supplier in the suppliers table.
        /// </summary>
        /// <param name="supplier">The updated supplier object.</param>
        public void Update(Supplier supplier)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var supplierToUpp = _context.Suppliers.FirstOrDefault(x => x.Id == supplier.Id);
                supplierToUpp.SupplierName = supplier.SupplierName;
                supplierToUpp.Discount = supplier.Discount;
                supplierToUpp.Location = supplier.Location;
                supplierToUpp.Nip = supplier.Nip;
                supplierToUpp.Phone = supplier.Phone;

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a supplier from the suppliers table based on its ID.
        /// </summary>
        /// <param name="id">The ID of the supplier to remove.</param>
        public void Remove(int id)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var supplier = _context.Suppliers.SingleOrDefault(s => s.Id == id);
                _context.Remove(supplier);
                _context.SaveChanges();
            }
        }
    }
}
