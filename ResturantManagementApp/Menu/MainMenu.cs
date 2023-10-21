namespace ResturantManagementLibrary
{
    public class MainMenu
    {
        LoginMenu loginMenu = new();

        public void StartMainMenu()
        {
            string[] options =
            {
                "1. Dish Manager",
                "2. Orders Manager",
                "3. Tables Manager",
                "4. Employees Manager",
                "5. Warhouse Manager",
                "6. Tax Manager",
                "0. Exit"
            };
            int selectOption;

            MenuUtils.ShowMenuOption(options);
            selectOption = MenuUtils.ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1: //? Dish Manager
                        DishMenu dishMenu = new();
                        dishMenu.StartDishMenu();
                        break;
                    case 2: //? Orders Manager
                        Console.WriteLine($"Not implement");
                        StartMainMenu();
                        break;
                    case 3: //? Tables Manager
                        Console.WriteLine($"Not implement");
                        StartMainMenu();
                        break;
                    case 4: //? Employees Manager
                        Console.WriteLine($"Not implement");
                        StartMainMenu();
                        break;
                    case 5: //? Warhouse Manager
                        Console.WriteLine($"Not implement");
                        StartMainMenu();
                        break;
                    case 6: //? Tax Manager
                        Console.WriteLine($"Not implement");
                        StartMainMenu();
                        break;
                    case 0: //? Exit
                        loginMenu.StartLoginMenu();
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (
                        selectOption != 1 &&
                        selectOption != 2 &&
                        selectOption != 3 &&
                        selectOption != 4 &&
                        selectOption != 5 &&
                        selectOption != 6 &&
                        selectOption != 0
                    );
        }
    }
}