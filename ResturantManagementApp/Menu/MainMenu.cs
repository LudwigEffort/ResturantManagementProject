using FileManager.Controller;

namespace ResturantManagementLibrary
{
    public class MainMenu
    {
        string[] options = { "1. Login", "2. Sign Up", "0. Exit" };
        int selectOption;

        public void StartMainMenu()
        {
            EmployeeController employeeController = new();
            LoginMenu loginMenu = new();
            SignUpMenu signUpMenu = new();
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
                        bool loggedIn = loginMenu.LoginForm();
                        if (loggedIn == true)
                        {
                            subMenuAdmin.StartSubMenuAdmin();
                        }
                        else
                        {
                            StartMainMenu();
                        }
                        break;
                    case 2: //? Sign up 
                        Console.Clear();
                        signUpMenu.SingUpForm();
                        Console.Clear();
                        StartMainMenu();
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