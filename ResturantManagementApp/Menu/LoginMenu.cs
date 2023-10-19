using FileManager.Controller;
using ResturantManagementLibrary;

namespace ResturantManagementLibrary
{
    class LoginMenu
    {
        public void LoginForm(){
            Console.WriteLine($"Employee Login");

            Console.WriteLine($"Enter your email: ");
            string? email = Console.ReadLine();

            Console.WriteLine($"Enter your password: ");
            string? password = Console.ReadLine();

            // Read DB and search if equals

            Console.WriteLine($"Login done. Welcome "); //Print name, lastname
        }
    }
}