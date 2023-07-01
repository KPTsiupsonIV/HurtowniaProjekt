using ConectivoApp.Data;
using ConectivoApp.Queries;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ConectivoApp.UpdatingWindows
{
    /// <summary>
    /// Interaction logic for WarehouseUpdate.xaml
    /// </summary>
    public partial class WarehouseUpdate : Window
    {
        public WarehouseUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the Update button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = new Warehouse();

            // Validate and parse the ID
            if (int.TryParse(Id.Text, out int id))
            {
                warehouse.Id = id;
            }
            else
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer value.");
                return;
            }

            warehouse.ProductName = ProductName.Text;

            // Validate and parse the Now Quantity
            if (int.TryParse(NowQuantity.Text, out int nowQuantity))
            {
                warehouse.NowQuantity = nowQuantity;
            }
            else
            {
                MessageBox.Show("Invalid Now Quantity. Please enter a valid integer value.");
                return;
            }

            // Validate and parse the Needed Quantity
            if (int.TryParse(NeededQuantity.Text, out int neededQuantity))
            {
                warehouse.NeededQuantity = neededQuantity;
            }
            else
            {
                MessageBox.Show("Invalid Needed Quantity. Please enter a valid integer value.");
                return;
            }

            // Validate and parse the Priority
            if (int.TryParse(Priority.Text, out int priority))
            {
                warehouse.Priority = priority;
            }
            else
            {
                MessageBox.Show("Invalid Priority. Please enter a valid integer value.");
                return;
            }

            WarehouseQuery query = new WarehouseQuery();
            query.Update(warehouse);

            MessageBox.Show($"You have successfully updated the warehouse with ID {warehouse.Id}.");
        }
    }
}