using FileManager.Controller;
using ResturantManagementLibrary;

namespace ResturantManagementLibrary
{
    class LoginMenu
    {
        public bool LoginForm()
        {
            Console.WriteLine($"Employee Login");

            Console.WriteLine($"Enter your email: ");
            string? email = Console.ReadLine();

            Console.WriteLine($"Enter your password: ");
            string? password = Console.ReadLine();

            if (EmployeeController.IsLogged(email, password))
            {
                Console.WriteLine($"Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine($"Invalid email or password. Login failed!");
                return false;
            }


        }
    }
}