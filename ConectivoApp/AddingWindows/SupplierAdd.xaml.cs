using ConectivoApp.Data;
using ConectivoApp.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SupplierAdd.xaml
    /// </summary>
    public partial class SupplierAdd : Window
    {
        public SupplierAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the AddButton.
        /// Adds a supplier to the system based on the provided information.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Perform input validation before adding the supplier
            if (ValidateInputs())
            {
                // Create a new Supplier object and assign the input values
                Supplier supplier = new Supplier();
                supplier.Nip = Nip.Text;
                supplier.Discount = int.Parse(Discount.Text);
                supplier.Location = Location.Text;
                supplier.SupplierName = SupplierName.Text;
                supplier.Phone = Phone.Text;

                // Add the supplier using the SupplierQuery class
                SupplierQuery query = new SupplierQuery();
                query.AddSupplier(supplier);
                MessageBox.Show("Succesfully added Suplier");
            }
        }

        /// <summary>
        /// Validates the input values.
        /// </summary>
        /// <returns>True if all inputs are valid, otherwise false.</returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(Nip.Text))
            {
                MessageBox.Show("Please enter the supplier's NIP.");
                return false;
            }

            if (!int.TryParse(Discount.Text, out int discount) || discount < 0)
            {
                MessageBox.Show("Please enter a valid discount value.");
                return false;
            }

            if (string.IsNullOrEmpty(Location.Text))
            {
                MessageBox.Show("Please enter the supplier's location.");
                return false;
            }

            if (string.IsNullOrEmpty(SupplierName.Text))
            {
                MessageBox.Show("Please enter the supplier's name.");
                return false;
            }

            if (string.IsNullOrEmpty(Phone.Text))
            {
                MessageBox.Show("Please enter the supplier's phone number.");
                return false;
            }

            // Validate the phone number using a regular expression for Polish phone numbers
            if (!IsValidPolishPhoneNumber(Phone.Text))
            {
                MessageBox.Show("Please enter a valid Polish phone number.");
                return false;
            }

            return true; // All inputs are valid
        }

        /// <summary>
        /// Validates a phone number based on Polish number format.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is valid, otherwise false.</returns>
        private bool IsValidPolishPhoneNumber(string phoneNumber)
        {
            // The regular expression pattern for Polish phone numbers
            string pattern = @"^\+?(\d{2})?[-\s]?(\d{3})[-\s]?(\d{3})[-\s]?(\d{3})$";

            // Use Regex.IsMatch to validate the phone number against the pattern
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}