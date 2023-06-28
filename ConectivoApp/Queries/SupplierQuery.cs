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
            }
        }
    }
}
