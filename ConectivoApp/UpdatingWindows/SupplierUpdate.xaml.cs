using ConectivoApp.AddingWindows;
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

namespace ConectivoApp.UpdatingWindows
{
    /// <summary>
    /// Interaction logic for SupplierUpdate.xaml
    /// </summary>
    public partial class SupplierUpdate : Window
    {
        public SupplierUpdate()
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
            // Create a new Supplier instance
            Supplier supplier = new Supplier();

            // Get the location
            supplier.Location = Location.Text;

            // Parse and validate the discount
            if (!int.TryParse(Discount.Text, out int discount))
            {
                MessageBox.Show("Invalid discount. Please enter a valid integer.");
                return;
            }
            supplier.Discount = discount;

            // Validate the NIP (tax identification number)
            string nip = Nip.Text;
            if (!IsValidNip(nip))
            {
                MessageBox.Show("Invalid NIP. Please enter a valid Polish tax identification number.");
                return;
            }
            supplier.Nip = nip;

            // Validate the phone number
            string phone = Phone.Text;
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Invalid phone number. Please enter a valid Polish phone number.");
                return;
            }
            supplier.Phone = phone;

            // Get the supplier name
            supplier.SupplierName = SupplierName.Text;

            // Parse and validate the ID
            if (!int.TryParse(Id.Text, out int id))
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer.");
                return;
            }
            supplier.Id = id;

            // Perform the update operation using the SupplierQuery class
            SupplierQuery query = new SupplierQuery();
            query.Update(supplier);
            // Show a success message
            MessageBox.Show($"You have updated the supplier with ID: {supplier.Id}");
        }

        /// <summary>
        /// Validates a Polish phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is valid, otherwise false.</returns>
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Polish phone number pattern (10 digits)
            string pattern = @"^(?:\+?48)?(?:\s?\d{2}){5}$";

            return Regex.IsMatch(phoneNumber, pattern);
        }

        /// <summary>
        /// Validates a Polish NIP (tax identification number).
        /// </summary>
        /// <param name="nip">The NIP to validate.</param>
        /// <returns>True if the NIP is valid, otherwise false.</returns>
        private bool IsValidNip(string nip)
        {
            // Polish NIP pattern (10 digits)
            string pattern = @"^\d{10}$";

            return Regex.IsMatch(nip, pattern);
        }
    }
}
