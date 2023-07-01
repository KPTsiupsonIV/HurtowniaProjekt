using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp.Queries
{
    /// <summary>
    /// Represents a query class for retrieving and manipulating product data.
    /// </summary>
    internal class ProductsQuery
    {
        /// <summary>
        /// Gets or sets the list of products.
        /// </summary>
        public List<Product> productsList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsQuery"/> class.
        /// </summary>
        public ProductsQuery()
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                productsList = _context.Products.ToList();
            }
        }

        /// <summary>
        /// Retrieves products by their name.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <returns>The list of products with the specified name.</returns>
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

        /// <summary>
        /// Adds a new product to the products table.
        /// </summary>
        /// <param name="product">The product object to add.</param>
        public void AddProduct(Product product)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an existing product in the products table.
        /// </summary>
        /// <param name="product">The updated product object.</param>
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

        /// <summary>
        /// Removes a product from the products table based on its ID.
        /// </summary>
        /// <param name="id">The ID of the product to remove.</param>
        public void Remove(int id)
        {
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                var product = _context.Products.SingleOrDefault(p => p.Id == id);
                _context.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
