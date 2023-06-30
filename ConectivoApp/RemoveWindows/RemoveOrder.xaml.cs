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

namespace ConectivoApp.RemoveWindows
{
    /// <summary>
    /// Interaction logic for RemoveOrder.xaml
    /// </summary>
    public partial class RemoveOrder : Window
    {
        public RemoveOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes a Order record based on the ID entered.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (!int.TryParse(ID.Text, out int id))
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer ID.");
                return;
            }

            OrdersQuery query = new OrdersQuery();
            query.Remove(id);
            MessageBox.Show($"You have successfully deleted the record from orders where ID: {id}");
        }
    }
}
