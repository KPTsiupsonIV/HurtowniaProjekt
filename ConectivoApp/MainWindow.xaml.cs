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
using System.Configuration;
using System.Windows.Threading;
using ConectivoApp.Queries;
using System.Security.AccessControl;
using ConectivoApp.AddingWindows;
using ConectivoApp.UpdatingWindows;

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
        private char queType =' '; 
        public List<Employee> employeeList { get; set; }
       
    
      

        private DeliveryQuery deliveryQuery = new DeliveryQuery();
        private OrdersQuery ordersQuery = new OrdersQuery();
        private SupplierQuery supplierQuery = new SupplierQuery();
        private WarehouseQuery warehouseQuery = new WarehouseQuery();
        private ProductsQuery productsQuery = new ProductsQuery();

        public MainWindow()
        {
            InitializeComponent();
            using(HurtowniaContext _context = new HurtowniaContext())
            {
                _context.Database.EnsureCreated();
                employeeList = _context.Employees.ToList();
            }
            
            
            timer = new DispatcherTimer();
            

            // Set the interval (e.g., 1 second)
            timer.Interval = TimeSpan.FromSeconds(1);

            // Subscribe to the Tick event
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer.Tick += Timer_Tick;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            // Start the timer
            timer.Start();
            if(login == 1)
            {
                timer.Stop();
            }

           

        }



        /// <summary>
        /// Night/Day switch button logic
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var color = MainGrid.Background as SolidColorBrush;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var newColor = color.Color.Equals(Color.FromArgb(0xFF, 0xED, 0xED, 0xED)) ?
                            new SolidColorBrush(Color.FromArgb(0xFF, 0xB8, 0xB9, 0xBA)):
                            new SolidColorBrush(Color.FromArgb(0xFF, 0xED, 0xED, 0xED));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

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




        /// <summary>
        /// Loggin Button logic
        /// </summary>
        private void Loggin_Click(object sender, RoutedEventArgs e)
        {
            if(login == 0)
            {
                loginWindow.Show();
            }
            else
            {
                Application.Current.Shutdown();
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            login = loginWindow.GetState();

            if(login == 1)
            {
                IdText.Text = $"ID: {loginWindow.GetId()}";
                loginWindow.Hide();
                loginButton.Content = "Log Off";
            }
        }
        private void DeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
                queType = 'd';
                searchText.Text = "Search by delivery ID";
                deliveriesGrid.ItemsSource = deliveryQuery.deliveryList;
                DeliveryButtonBorder.BorderThickness = new Thickness(2);
                ProductsButtonBorder.BorderThickness = new Thickness(0);
                OrdersButtonBorder.BorderThickness = new Thickness(0);
                SupplierButtonBorder.BorderThickness = new Thickness(0);
                StockButtonBorder.BorderThickness = new Thickness(0);
            }
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
                queType = 'o';
                searchText.Text = "Search by employee ID";
                deliveriesGrid.ItemsSource = ordersQuery.ordersList;
                DeliveryButtonBorder.BorderThickness = new Thickness(0);
                ProductsButtonBorder.BorderThickness = new Thickness(0);
                OrdersButtonBorder.BorderThickness = new Thickness(2);
                SupplierButtonBorder.BorderThickness = new Thickness(0);
                StockButtonBorder.BorderThickness = new Thickness(0);
            }
        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
                queType = 'w';
                searchText.Text = "Search warehouse by ID";
                //warehouseQuery.Populate();
                deliveriesGrid.ItemsSource = warehouseQuery.warehouseList;
                DeliveryButtonBorder.BorderThickness = new Thickness(0);
                ProductsButtonBorder.BorderThickness = new Thickness(0);
                OrdersButtonBorder.BorderThickness = new Thickness(0);
                SupplierButtonBorder.BorderThickness = new Thickness(0);
                StockButtonBorder.BorderThickness = new Thickness(2);
            }
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
                queType = 's';
                searchText.Text = "Search by supplier Nip";
                deliveriesGrid.ItemsSource = supplierQuery.supplierList;
                DeliveryButtonBorder.BorderThickness = new Thickness(0);
                ProductsButtonBorder.BorderThickness = new Thickness(0);
                OrdersButtonBorder.BorderThickness = new Thickness(0);
                SupplierButtonBorder.BorderThickness = new Thickness(2);
                StockButtonBorder.BorderThickness = new Thickness(0);
            }
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
                queType = 'p';
                searchText.Text = "Search by product name";
                deliveriesGrid.ItemsSource = productsQuery.productsList;
                DeliveryButtonBorder.BorderThickness = new Thickness(0);
                ProductsButtonBorder.BorderThickness = new Thickness(2);
                OrdersButtonBorder.BorderThickness = new Thickness(0);
                SupplierButtonBorder.BorderThickness = new Thickness(0);
                StockButtonBorder.BorderThickness = new Thickness(0);
            }
        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            switch (queType)
            {
                case 'd':
                    int.TryParse(searchText.Text, out int idDelivery);
                    deliveriesGrid.ItemsSource = deliveryQuery.GetDeliveryById(idDelivery);
                    break;
                case 'o':
                    int.TryParse(searchText.Text, out int id);
                    deliveriesGrid.ItemsSource = ordersQuery.GetOrdersByEmployeeId(id);
                    break;
                case 'p':
                    deliveriesGrid.ItemsSource = productsQuery.GetProductsByName(searchText.Text);
                    break;
                case 's':
                    deliveriesGrid.ItemsSource = supplierQuery.GetSupplierByNip(searchText.Text);
                    break;
                case 'w':
                    int.TryParse(searchText.Text, out int idWarehouse);
                    deliveriesGrid.ItemsSource = warehouseQuery.GetWarehouseById(idWarehouse);
                    break;
                default:
                    break;
            }
        }


        private void searchText_GotFocus(object sender, RoutedEventArgs e)
        {
            searchText.Text = string.Empty;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
            switch (queType)
                {
                    case 'd':
                        DeliveryAdd deliveryAdd = new DeliveryAdd();
                        deliveryAdd.Show();
                        break;
                    case 'o':
                        OrdersAdd ordersAdd = new OrdersAdd();
                        ordersAdd.Show();
                        break;
                    case 'p':
                        ProductsAdd productsAdd = new ProductsAdd();
                        productsAdd.Show();
                        break;
                    case 's':
                        SupplierAdd supplierAdd = new SupplierAdd();
                        supplierAdd.Show();
                        break;
                    case 'w':
                        WarehouseAdd warehouseAdd = new WarehouseAdd();
                        warehouseAdd.Show();
                        break;
                    default:
                        if(login == 1)
                        {
                            MessageBox.Show("You have not selected que to add into");
                        }
                        else
                        {
                            MessageBox.Show("You are not logged");
                        }
                        break;
                }
            }
           
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (login == 1)
            {
                switch (queType)
                {
                    case 'd':
                       DeliveryUpdate deliveryUpdate = new DeliveryUpdate();
                        deliveryUpdate.Show();
                        break;
                    case 'o':
                       OrderUpdate orderUpdate = new OrderUpdate();
                        orderUpdate.Show();
                        break;
                    case 'p':
                        ProductsUpdate productsUpdate = new ProductsUpdate();
                        productsUpdate.Show();
                        break;
                    case 's':
                        SupplierUpdate supplierUpdate = new SupplierUpdate();
                        supplierUpdate.Show();
                        break;
                    case 'w':
                       WarehouseUpdate warehouseUpdate = new WarehouseUpdate();
                      warehouseUpdate.Show();
                        break;
                    default:
                        MessageBox.Show("You have not selected que whre you want to make changes");
                        break;
                }
            }
            else
            {
                MessageBox.Show("You are not logged");
            }

        }
    }
}
