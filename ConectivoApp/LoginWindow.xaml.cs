using ConectivoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

namespace ConectivoApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public List<Employee> employeeList { get; set; }
        int Id;
        string? haslo;
        int state;

        /// <summary>
        /// Initializes a new instance of the LoginWindow class.
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();

            using (HurtowniaContext _context = new HurtowniaContext())
            {
                // Retrieve the list of employees from the database
                _context.Database.EnsureCreated();
                employeeList = _context.Employees.ToList();
            }
        }

        /// <summary>
        /// Handles the click event of the buttonlogin button.
        /// Validates the login credentials entered by the user.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void buttonlogin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(username.Text, out int id))
            {
                Id = id;
                haslo = password.Password.ToString();
                LoginLogic logika = new LoginLogic();

                if (logika.IsLoggedIn(Id, haslo, employeeList))
                {
                    state = 1;
                    textIfBad.Text = string.Empty;
                }
                else
                {
                    textIfBad.Text = "Wrong Password or Login";
                }
            }
            else
            {
                textIfBad.Text = "Invalid ID format";
            }
        }

        /// <summary>
        /// Gets the ID of the logged-in user.
        /// </summary>
        /// <returns>The ID of the logged-in user.</returns>
        public int GetId()
        {
            return Id;
        }

        /// <summary>
        /// Gets the state of the login operation.
        /// </summary>
        /// <returns>The state of the login operation (1 if successful, 0 otherwise).</returns>
        public int GetState()
        {
            return state;
        }
    }
}
