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

            RoleList role = ChoiseRole();

            //TODO: print role enums
            //TODO: select my role 
            //TODO: manage date time for employee

            EmployeeController.NewEmployee(name, lastName, email, phone, password, role, DateTime.Now);
        }

        public static void PrintRole()
        {
            Console.WriteLine($"Role list:");
            foreach (var role in Enum.GetValues(typeof(RoleList)))
            {
                Console.WriteLine($"- {(int)role}. {role}");
            }
        }

        public static RoleList ChoiseRole()
        {
            RoleList roleChoised = RoleList.WithoutRole;

            do
            {
                PrintRole();
                Console.WriteLine($"Choise a role for new employee (with num)!");
                if (int.TryParse(Console.ReadLine(), out int choise) && Enum.IsDefined(typeof(RoleList), choise))
                {
                    roleChoised = (RoleList)choise;
                    Console.WriteLine($"You are choise: {roleChoised}");
                }
                else
                {
                    Console.WriteLine($"Choise not valid!");
                }
            } while (!Enum.IsDefined(typeof(RoleList), roleChoised));

            return roleChoised;

        }

    }
}