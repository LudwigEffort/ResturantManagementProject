using System.Runtime.ConstrainedExecution;
using FileManager.Controller;
using ResturantManagementLibrary;

namespace ResturantClientApp
{
    class OrderDishMenu
    {
        MainMenu mainMenuClient = MainMenu.GetInstance();
        DishFileManager dishFileManager = new();
        CheckFileManager checkFileManager = new();

        public void StartDishMenu()
        {
            string[] options =
            {
                "1. Print all dishes",
                "2. Print dishes by category",
                "0. Back"
            };
            int selectOption;

            MenuUtils.ShowMenuOption(options);
            selectOption = MenuUtils.ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1: //? print all
                        CreateDishOrderForm();
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

        public void CreateDishOrderForm()
        {
            //TODO: move here switch to print all or by type
            CheckFileManager checkFileManager = new();
            List<Dish> dishes = dishFileManager.ReadDish();
            MenuUtils.ShowDishes(dishes);

            Dictionary<Dish, int> selectedMenu = new Dictionary<Dish, int>();

            while (true)
            {
                Console.WriteLine($"Select a dish (with name) and enter 'end' to complete the order:");
                string dishName = Console.ReadLine();

                if (dishName.ToLower() == "end")
                {
                    break;
                }

                Dish selectedDish = dishes.FirstOrDefault(dish => dish.Name.Equals(dishName, StringComparison.OrdinalIgnoreCase));

                if (selectedDish != null)
                {
                    Console.WriteLine($"How many dish for {selectedDish.Name}: ");
                    int quantity = int.Parse(Console.ReadLine());
                    selectedMenu[selectedDish] = quantity;
                }
                else
                {
                    Console.WriteLine($"Dish not found. Try again.");
                }

                Console.WriteLine($"Enter your Name and Last name: ");
                string customerId = Console.ReadLine();

                checkFileManager.CreateDishOrder(selectedMenu, customerId);
            }

        }
    }
}