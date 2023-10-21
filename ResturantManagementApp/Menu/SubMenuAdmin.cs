namespace ResturantManagementLibrary
{
    public class SubMenuAdmin
    {
        LoginMenu loginMenu = new();
        SubDishMenu subDishMenu = new();


        public void StartSubMenuAdmin()
        {
            string[] options =
            {
                "1. Dish Manager",
                "2. Orders Manager",
                "3. Employee Manager",
                "4. Tables Manager",
                "5. Warhouse Manager",
                "6. Tax Manager",
                "0. Exit"
            };
            int selectOption;

            loginMenu.ShowMenuOption(options);
            selectOption = loginMenu.ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        subDishMenu.DishMenu(); //TODO: remove it and add Dish Menu Manager
                        break;
                    case 0:
                        loginMenu.StartLoginMenu();
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);
        }

    }
}