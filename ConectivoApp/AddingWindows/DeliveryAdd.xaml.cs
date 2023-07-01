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
    /// Interaction logic for DeliveryAdd.xaml
    /// </summary>
    public partial class DeliveryAdd : Window
    {
        public DeliveryAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the AddButton.
        /// Adds a delivery to the system based on the provided information.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Perform input validation before adding the delivery
            if (ValidateInputs())
            {
                // Parse input values and add the delivery using the DeliveryQuery class
                DeliveryQuery query = new DeliveryQuery();
                query.DeliveryAdd(ProductName.Text, int.Parse(Quantity.Text), decimal.Parse(PriceBrutto.Text), decimal.Parse(PriceNetto.Text), DateTime.Parse(DeliveryDate.Text), SupplierName.Text);
            }
        }

        /// <summary>
        /// Validates the input values.
        /// </summary>
        /// <returns>True if all inputs are valid, otherwise false.</returns>
        private bool ValidateInputs()
        {
            // Perform validation for each input field
            if (string.IsNullOrEmpty(ProductName.Text))
            {
                MessageBox.Show("Please enter a product name.");
                return false;
            }

            if (!int.TryParse(Quantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return false;
            }

            if (!decimal.TryParse(PriceBrutto.Text, out decimal priceBrutto) || priceBrutto <= 0)
            {
                MessageBox.Show("Please enter a valid gross price.");
                return false;
            }

            if (!decimal.TryParse(PriceNetto.Text, out decimal priceNetto) || priceNetto <= 0)
            {
                MessageBox.Show("Please enter a valid net price.");
                return false;
            }

            if (!DateTime.TryParse(DeliveryDate.Text, out DateTime deliveryDate))
            {
                MessageBox.Show("Please enter a valid delivery date.");
                return false;
            }

            if (string.IsNullOrEmpty(SupplierName.Text))
            {
                MessageBox.Show("Please enter a supplier name.");
                return false;
            }

            return true; // All inputs are valid
        }
    }
}