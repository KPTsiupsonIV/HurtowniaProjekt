using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Queries
{
    internal class SupplierQuery
    {
        public List<Supplier> supplierList { get; set; }

        public SupplierQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                supplierList = _context.Suppliers.ToList();
            }
        }

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
        public void AddSupplier(Supplier supplier)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
        }
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
    }
}
