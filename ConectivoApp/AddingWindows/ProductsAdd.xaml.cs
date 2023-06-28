using ConectivoApp.Data;
using ConectivoApp.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConectivoApp.AddingWindows
{
    /// <summary>
    /// Interaction logic for ProductsAdd.xaml
    /// </summary>
    public partial class ProductsAdd : Window
    {
        public ProductsAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the AddButton.
        /// Adds a product to the system based on the provided information.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Perform input validation before adding the product
            if (ValidateInputs())
            {
                // Create a new Product object and assign the input values
                Product product = new Product();
                product.ProductName = ProductName.Text;
                product.Tax = byte.Parse(Tax.Text);
                product.PriceSell = decimal.Parse(PriceSell.Text);
                product.PriceBuy = decimal.Parse(PriceBuy.Text);

                // Add the product using the ProductsQuery class
                ProductsQuery query = new ProductsQuery();
                query.AddProduct(product);
                MessageBox.Show("Succesfully added Product");
            }
        }

        /// <summary>
        /// Validates the input values.
        /// </summary>
        /// <returns>True if all inputs are valid, otherwise false.</returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(ProductName.Text))
            {
                MessageBox.Show("Please enter the product name.");
                return false;
            }

            if (!byte.TryParse(Tax.Text, out byte tax) || tax < 0)
            {
                MessageBox.Show("Please enter a valid tax value.");
                return false;
            }

            if (!decimal.TryParse(PriceSell.Text, out decimal priceSell) || priceSell < 0)
            {
                MessageBox.Show("Please enter a valid selling price.");
                return false;
            }

            if (!decimal.TryParse(PriceBuy.Text, out decimal priceBuy) || priceBuy < 0)
            {
                MessageBox.Show("Please enter a valid buying price.");
                return false;
            }

            return true; // All inputs are valid
        }
    }
}