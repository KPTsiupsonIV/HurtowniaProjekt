using ConectivoApp.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using ConectivoApp;

namespace ConectivoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Delivery> deliveryList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            using(HurtowniaContext _context = new HurtowniaContext())
            {
                deliveryList = _context.Deliveries.ToList();
            }
            deliveriesGrid.ItemsSource = deliveryList;
        }



        /// <summary>
        /// Night/Day switch button logic
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var color = MainGrid.Background as SolidColorBrush;
            var newColor = color.Color.Equals(Color.FromArgb(0xFF, 0xED, 0xED, 0xED)) ?
                            new SolidColorBrush(Color.FromArgb(0xFF, 0xB8, 0xB9, 0xBA)):
                            new SolidColorBrush(Color.FromArgb(0xFF, 0xED, 0xED, 0xED));

            MainGrid.Background = newColor;
         
        }

       
    }
}
