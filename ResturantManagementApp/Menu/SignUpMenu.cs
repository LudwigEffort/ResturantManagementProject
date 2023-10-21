using System.Globalization;
using FileManager.Controller;
using static ResturantManagementLibrary.Employee;

namespace ResturantManagementLibrary
{
    class SignUpMenu
    {
        MainMenu mainMenu = new();
        public void SingUpForm()
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

            DateTime currentDate = DateTime.Now;
            string formatDate = currentDate.ToString("yyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime date = Convert.ToDateTime(formatDate);

            //TODO: manage date time for employee

            EmployeeController.NewEmployee(name, lastName, email, phone, password, role, date);

            mainMenu.StartMainMenu();
        }

        public static void PrintRole()
        {
            Console.WriteLine($"Role list:");
            foreach (var role in Enum.GetValues(typeof(RoleList)))
            {
                Console.WriteLine($"- {(int)role}. {role}");
            }
        }

        public static RoleList ChoiseRole() //? to learn
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