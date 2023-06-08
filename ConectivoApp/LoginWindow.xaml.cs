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
        string haslo;
        int state;
        public LoginWindow()
        {
           
            InitializeComponent();
            using (HurtowniaContext _context = new HurtowniaContext())
            {
                employeeList = _context.Employees.ToList();
            }
             
            
        }

        private void buttonlogin_Click(object sender, RoutedEventArgs e)
        {
            Id = int.Parse(username.Text.ToString());
            haslo = password.Password.ToString();
            LoginLogic logika = new LoginLogic();

            if (logika.IsLogged(Id, haslo, employeeList)) { 
                state = 1;
                textIfBad.Text = string.Empty;
            }
            else
            {
                textIfBad.Text = "Wrong Password or Login";
            }

        }
        public int GetId()
        {
            return Id;
        }

        public int GetState()
        {
            return state;
        }
    }
}
