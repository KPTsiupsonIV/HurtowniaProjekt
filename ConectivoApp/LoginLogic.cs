using ConectivoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ConectivoApp
{
    public class LoginLogic
    {
        public static int Id { get; set; }
        public static string? Password { get; set; }
        public static int isLoged {get; set; }

        public bool IsLogged(int identyfikator, string haslo,List<Employee> lista)
        {
            foreach (var employee in lista)
            {
                if (identyfikator == employee.Id && haslo == employee.Password)
                {
                    
                    Password = employee.Password;
                    Id = employee.Id;
                    isLoged = 1;
                    return true;
                }

            }
            return false;
        }

        public int GetState()
        {
            return isLoged;
        }
        public int GetId()
        {
            return Id;
        }

    }
}
