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
    /// Interaction logic for OrdersAdd.xaml
    /// </summary>
    public partial class OrdersAdd : Window
    {
        public OrdersAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the AddButton.
        /// Adds an order to the system based on the provided information.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Perform input validation before adding the order
            if (ValidateInputs())
            {
                // Create a new Order object and assign the input values
                Order order = new Order();
                order.Price = decimal.Parse(Price.Text);
                order.CommisionValue = decimal.Parse(CommisionValue.Text);
                order.IdEmployee = int.Parse(IdEmployee.Text);
                order.Quantiy = int.Parse(Quantiy.Text);

                // Add the order using the OrdersQuery class
                OrdersQuery query = new OrdersQuery();
                query.OrdersAdd(order);

                MessageBox.Show("Successfully added the order.");
            }
        }

        /// <summary>
        /// Validates the input values.
        /// </summary>
        /// <returns>True if all inputs are valid, otherwise false.</returns>
        private bool ValidateInputs()
        {
            // Validate Price input
            if (!decimal.TryParse(Price.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid price.");
                return false;
            }

            // Validate CommisionValue input
            if (!decimal.TryParse(CommisionValue.Text, out decimal commisionValue) || commisionValue < 0)
            {
                MessageBox.Show("Please enter a valid commission value.");
                return false;
            }

            // Validate IdEmployee input
            if (!int.TryParse(IdEmployee.Text, out int idEmployee) || idEmployee <= 0)
            {
                MessageBox.Show("Please enter a valid employee ID.");
                return false;
            }

            // Validate Quantity input
            if (!int.TryParse(Quantiy.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return false;
            }

            return true; // All inputs are valid
        }
    }
}