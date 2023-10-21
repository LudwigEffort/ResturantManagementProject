using FileManager.Controller;

namespace ResturantManagementLibrary
{
    public class SubDishMenu
    {
        LoginMenu loginMenu = new();
        DishCreate dishCreate = new();
        DishShow dishShow = new();
        DishFileManager dishFileManager = new();


        public void DishMenu()
        {
            List<Dish> dishes = dishFileManager.ReadDish();

            string[] options =
            {
                "1. Add new dish",
                "2. Edit dish", //TODO
                "3. Show all dishes",
                "0. Exit"
            };
            int selectOption;

            loginMenu.ShowMenuOption(options);
            selectOption = loginMenu.ReadChoise();
            dishFileManager.CreateDishDb();

            do
            {
                switch (selectOption)
                {
                    case 1: //DONE: Create new Dish
                        dishCreate.CreateForm();
                        break;

                    case 2: //TODO: Edit Dish
                        break;
                    case 3: //DONE: Show all dishes
                        dishShow.ShowDishes(dishes);
                        break;
                    case 0:
                        loginMenu.StartLoginMenu();
                        break;

                    default:
                        Console.WriteLine($"Wrong Option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 3 && selectOption != 0);
        }
    }
}