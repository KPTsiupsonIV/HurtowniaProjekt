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

namespace ConectivoApp.UpdatingWindows
{
    /// <summary>
    /// Interaction logic for ProductsUpdate.xaml
    /// </summary>
    public partial class ProductsUpdate : Window
    {
        public ProductsUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the UpdateButton.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Product instance
            Product product = new Product();

            // Parse and validate the ID
            if (!int.TryParse(Id.Text, out int id))
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer.");
                return;
            }
            product.Id = id;

            // Parse and validate the tax
            if (!byte.TryParse(Tax.Text, out byte tax))
            {
                MessageBox.Show("Invalid tax. Please enter a valid byte value.");
                return;
            }
            product.Tax = tax;

            // Get the product name
            product.ProductName = ProductName.Text;

            // Parse and validate the selling price
            if (!int.TryParse(PriceSell.Text, out int priceSell))
            {
                MessageBox.Show("Invalid selling price. Please enter a valid integer.");
                return;
            }
            product.PriceSell = priceSell;

            // Parse and validate the buying price
            if (!int.TryParse(PriceBuy.Text, out int priceBuy))
            {
                MessageBox.Show("Invalid buying price. Please enter a valid integer.");
                return;
            }
            product.PriceBuy = priceBuy;

            // Perform the update operation using the ProductsQuery class
            ProductsQuery query = new ProductsQuery();
            query.Update(product);

            // Show a success message
            MessageBox.Show($"You have updated product of ID: {product.Id}");
        }
    }
}
