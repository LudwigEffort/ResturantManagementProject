using System.Globalization;
using FileManager.Controller;
using static ResturantManagementLibrary.Employee;

namespace ResturantManagementLibrary
{
    public class LoginMenu
    {
        string[] options = { "1. Login", "2. Sign Up", "0. Exit" };
        int selectOption;

        public void StartLoginMenu()
        {
            EmployeeController employeeController = new(); //? from file manager
            SubMenuAdmin subMenuAdmin = new();
            employeeController.CreateEmployeeDb();

            ShowMenuOption(options);
            selectOption = ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1: //? Login
                        Console.Clear();
                        if (LoginForm() == true)
                        {
                            subMenuAdmin.StartSubMenuAdmin(); //? start main menu
                        }
                        else
                        {
                            StartLoginMenu();
                        }
                        break;
                    case 2: //? Sign up 
                        Console.Clear();
                        SingUpForm();
                        Console.Clear();
                        StartLoginMenu();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Exit from program...");
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);
        }

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
                Console.Clear();
                Console.WriteLine($"Invalid email or password. Login failed!");
                return false;
            }
        }

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

            LoginForm();
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

        //? Menu utils
        public void ShowMenuOption(string[] options)
        {
            foreach (var item in options)
            {
                Console.WriteLine(item);
            }
        }

        public int ReadChoise()
        {
            int selectOption;
            Console.WriteLine($"Select a option with 1-2:");
            while (!int.TryParse(Console.ReadLine(), out selectOption))
            {
                Console.WriteLine($"Wrong Option!");
            }
            return selectOption;
        }
    }
}