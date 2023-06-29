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
    /// Interaction logic for OrderUpdate.xaml
    /// </summary>
    public partial class OrderUpdate : Window
    {
        public OrderUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the order based on the input fields.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Order object
            Order order = new Order();

            // Parse and assign values from the input fields
            decimal price;
            if (decimal.TryParse(Price.Text, out price))
            {
                order.Price = price;
            }
            else
            {
                MessageBox.Show("Invalid price value.");
                return;
            }

            int quantity;
            if (int.TryParse(Quantiy.Text, out quantity))
            {
                order.Quantiy = quantity;
            }
            else
            {
                MessageBox.Show("Invalid quantity value.");
                return;
            }

            int idEmployee;
            if (int.TryParse(IdEmployee.Text, out idEmployee))
            {
                order.IdEmployee = idEmployee;
            }
            else
            {
                MessageBox.Show("Invalid employee ID value.");
                return;
            }

            decimal commissionValue;
            if (decimal.TryParse(CommisionValue.Text, out commissionValue))
            {
                order.CommisionValue = commissionValue;
            }
            else
            {
                MessageBox.Show("Invalid commission value.");
                return;
            }

            // Perform the update using the OrdersQuery class
            OrdersQuery query = new OrdersQuery();
            query.Update(order);

            MessageBox.Show($"You have updated order {order.Id}");
        }
    }
}