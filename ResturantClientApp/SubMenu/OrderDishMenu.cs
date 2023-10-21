using FileManager.Controller;
using ResturantManagementLibrary;

namespace ResturantClientApp
{
    class OrderDishMenu
    {
        MainMenu mainMenuClient = MainMenu.GetInstance();
        DishFileManager dishFileManager = new();

        public void StartDishMenu()
        {
            string[] options =
            {
                "1. Print all dishes",
                "2. Print dishes by category",
                "0. Back"
            };
            int selectOption;

            ResturantManagementLibrary.MenuUtils.ShowMenuOption(options);
            selectOption = ResturantManagementLibrary.MenuUtils.ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1: //? print all
                        List<Dish> dishes = dishFileManager.ReadDish();
                        ResturantManagementLibrary.MenuUtils.ShowDishes(dishes);
                        break;
                    case 2: //? print by category
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Back...");
                        mainMenuClient.StartMainMenu();
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 0);

        }

        public void CreateDishOrder()
        {

        }
    }
}