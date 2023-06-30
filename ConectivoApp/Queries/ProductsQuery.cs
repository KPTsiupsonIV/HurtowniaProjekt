using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Queries
{
    internal class ProductsQuery
    {
        public List<Product> productsList { get; set; }

        public ProductsQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                productsList = _context.Products.ToList();
            }
        }

        public List<Product> GetProductsByName(string name)
        {
            List<Product> productsByName = new List<Product>();
            foreach (Product product in productsList)
            {
                if (product.ProductName == name)
                {
                    productsByName.Add(product);
                }
            }
            return productsByName;
        }
        public void AddProduct(Product product)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
               _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var productToUpdate = _context.Products.FirstOrDefault(w => w.Id == product.Id);
                productToUpdate.PriceSell = product.PriceSell;
                productToUpdate.PriceBuy = product.PriceBuy;
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Tax = product.Tax;

                _context.SaveChanges();
            }
        }
    }
}
