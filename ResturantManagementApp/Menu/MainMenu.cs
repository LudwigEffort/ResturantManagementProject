namespace ResturantManagementLibrary
{
    public class MainMenu
    {
        string[] options = { "1. Login", "2. Sign Up", "0. Exit" };
        int selectOption;

        public void StartMainMenu()
        {
            ShowMenuOption(options);
            selectOption = ReadChoise();
            do
            {
                switch (selectOption)
                {
                    case 1: //? Login
                        Console.Clear();
                        break;
                    case 2: //? Sign up 
                        Console.Clear();
                        SignUpMenu.SingUpForm();
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