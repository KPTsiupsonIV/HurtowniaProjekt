using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectivoApp
{
    /// <summary>
    /// Represents the logic for managing the login state of an application.
    /// </summary>
    public class LoginLogic
    {
        /// <summary>
        /// Gets or sets the ID of the logged-in user.
        /// </summary>
        public static int Id { get; set; }

        /// <summary>
        /// Gets or sets the password of the logged-in user.
        /// </summary>
        public static string? Password { get; set; }

        /// <summary>
        /// Gets or sets the login state. 1 represents logged in, and 0 represents logged out.
        /// </summary>
        public static int IsLogged { get; set; }

        /// <summary>
        /// Checks if the provided identifier and password match an employee in the given list.
        /// </summary>
        /// <param name="identifier">The identifier to check.</param>
        /// <param name="password">The password to check.</param>
        /// <param name="employeeList">The list of employees.</param>
        /// <returns>True if the identifier and password match, otherwise false.</returns>
        public bool IsLoggedIn(int identifier, string password, List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                if (identifier == employee.Id && password == employee.Password)
                {
                    Password = employee.Password;
                    Id = employee.Id;
                    IsLogged = 1;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the login state.
        /// </summary>
        /// <returns>The login state. 1 represents logged in, and 0 represents logged out.</returns>
        public int GetState()
        {
            return IsLogged;
        }

        /// <summary>
        /// Gets the logged-in user's ID.
        /// </summary>
        /// <returns>The user's ID.</returns>
        public int GetId()
        {
            return Id;
        }
    }
}
