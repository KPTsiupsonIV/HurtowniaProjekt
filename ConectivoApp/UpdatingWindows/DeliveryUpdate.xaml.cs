
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
    /// Interaction logic for DeliveryUpdate.xaml
    /// </summary>
    public partial class DeliveryUpdate : Window
    {
        public DeliveryUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the UpdateButton.
        /// Updates the delivery details based on the user input.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Delivery object and set its properties based on the user input
            Delivery delivery = new Delivery();

            // Validate and parse DeliveryDate
            if (DateTime.TryParse(DeliveryDate.Text, out DateTime deliveryDate))
            {
                delivery.DeliveryDate = deliveryDate;
            }
            else
            {
                MessageBox.Show("Invalid Delivery Date format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate and parse PriceBrutto
            if (int.TryParse(PriceBrutto.Text, out int priceBrutto))
            {
                delivery.PriceBrutto = priceBrutto;
            }
            else
            {
                MessageBox.Show("Invalid Price Brutto format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate and parse Quantity
            if (int.TryParse(Quantity.Text, out int quantity))
            {
                delivery.Quantity = quantity;
            }
            else
            {
                MessageBox.Show("Invalid Quantity format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate and parse Id
            if (int.TryParse(Id.Text, out int id))
            {
                delivery.Id = id;
            }
            else
            {
                MessageBox.Show("Invalid Id format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Set SupplierName (empty for now)

            // Validate and parse PriceNetto
            if (int.TryParse(PriceNetto.Text, out int priceNetto))
            {
                delivery.PriceNetto = priceNetto;
            }
            else
            {
                MessageBox.Show("Invalid Price Netto format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new DeliveryQuery object and update the delivery
            DeliveryQuery deliveryQuery = new DeliveryQuery();
            deliveryQuery.Update(delivery);
        }
    }
}