using ConectivoApp.Queries;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ConectivoApp.AddingWindows
{
    /// <summary>
    /// Interaction logic for WarehouseAdd.xaml
    /// </summary>
    public partial class WarehouseAdd : Window
    {
        public WarehouseAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the AddButton click event.
        /// Validates the input values and adds the product to the warehouse if they are valid.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductName.Text;
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Product name is required.");
                return;
            }

            int nowQuantity;
            if (!int.TryParse(NowQuantiy.Text, out nowQuantity) || nowQuantity < 0)
            {
                MessageBox.Show("Now Quantity must be a positive integer.");
                return;
            }

            int neededQuantity;
            if (!int.TryParse(NeededQuantity.Text, out neededQuantity) || neededQuantity < 0)
            {
                MessageBox.Show("Needed Quantity must be a positive integer.");
                return;
            }

            int priority;
            if (!int.TryParse(Priority.Text, out priority) || priority < 0)
            {
                MessageBox.Show("Priority must be a positive integer.");
                return;
            }

            WarehouseQuery query = new WarehouseQuery();
            query.WarehouseAdd(productName, nowQuantity, neededQuantity, priority);
            MessageBox.Show($"You have added: {productName} to Warehouse");
        }
    }
}
