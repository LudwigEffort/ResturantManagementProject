using System.Collections;
using FileManager.Controller;
using static ResturantManagementLibrary.Employee;

namespace ResturantManagementLibrary
{
    class SignUpMenu
    {
        public static void SingUpForm()
        {
            Console.WriteLine($"Employee Sign up");

            Console.WriteLine($"Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter your last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine($"Enter your email: ");
            string email = Console.ReadLine();

            Console.WriteLine($"Enter your phone: ");
            string phone = Console.ReadLine();

            Console.WriteLine($"Enter your password: ");
            string password = Console.ReadLine();

            //TODO: print role enums
            //TODO: select my role 
            //TODO: manage date time for employee

            EmployeeController.NewEmployee(name, lastName, email, phone, password, RoleList.Manager, DateTime.Now);
        }

        // public void PrintRole()
        // {
        //     RoleList[] roleLists = (RoleList[])Enum.GetValues(typeof(RoleList));
        //     Console.WriteLine($"Role list:");
        //     for (int i = 0; i < roleLists.Length; i++)
        //     {
        //         Console.WriteLine($"{i + 1}. Role: {roleLists[i]}");
        //     }
        //     Console.WriteLine($"0. Back...");
        // }

    }
}