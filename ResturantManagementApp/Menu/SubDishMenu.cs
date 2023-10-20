using FileManager.Controller;

namespace ResturantManagementLibrary
{
    public class SubDishMenu
    {
        MainMenu mainMenu = new();
        DishCreate dishCreate = new();
        DishFileManager dishFileManager = new();
        public void DishMenu(){
            string[] options = 
            {
                "1. Add new dish",
                "2. Edit dish", //TODO
                "3. Show all dishes",
                "0. Exit"
            };
            int selectOption;

            mainMenu.ShowMenuOption(options);
            selectOption = mainMenu.ReadChoise();
            dishFileManager.CreateDishDb();

            do
            {
                switch (selectOption)
                {
                    case 1: // Create new Dish
                    DishCreate.CreateForm();
                    break;

                    case 2: // Edit Dish
                    break;

                    case 3: // Show all dishes
                    break; 

                    case 0:
                    mainMenu.StartMainMenu();
                    break;

                    default:
                    Console.WriteLine($"Wrong Option!");
                    break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 3 && selectOption != 0);
        }
    }
}