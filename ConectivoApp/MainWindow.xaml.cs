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
using System.Configuration;
using System.Windows.Threading;

namespace ConectivoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int login = 0;
        private bool dayswitch = true;
        private DispatcherTimer timer;
        public LoginWindow loginWindow = new LoginWindow();
        public List<Delivery> deliveryList { get; set; }
        public List<Employee> employeeList { get; set; }
        public List<Order> orderList { get; set; }
        public List<Product> productList { get; set; }
        public List<Warehouse> warehouseList { get; set; }
        public List<Supplier> supliereList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            using(HurtowniaContext _context = new HurtowniaContext())
            {
               
                deliveryList = _context.Deliveries.ToList();
                employeeList = _context.Employees.ToList();
                orderList = _context.Orders.ToList();
                productList = _context.Products.ToList();
                warehouseList = _context.Warehouses.ToList();
                supliereList = _context.Suppliers.ToList();

            }
            timer = new DispatcherTimer();

            // Set the interval (e.g., 1 second)
            timer.Interval = TimeSpan.FromSeconds(1);

            // Subscribe to the Tick event
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
            



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
            if (dayswitch)
            {
                daySwitch.Source = new BitmapImage(new Uri("images/icons10.png", UriKind.Relative));
                dayswitch = false;
                searchIcon.Source = new BitmapImage(new Uri("images/Search2.png", UriKind.Relative));
            }
            else
            {
                daySwitch.Source = new BitmapImage(new Uri("images/icons9.png", UriKind.Relative));
                dayswitch = true;
                searchIcon.Source = new BitmapImage(new Uri("images/Search.png", UriKind.Relative));
            }

        }

        private void DeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
                deliveriesGrid.ItemsSource = deliveryList;
                DeliveryButtonBorder.BorderThickness = new Thickness(2);
            }
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            loginWindow.Show();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            login = loginWindow.GetState();

            if(login == 1)
            {
                IdText.Text = $"ID: {loginWindow.GetId()}";
                loginWindow.Close();
            }
        }
    }
}
