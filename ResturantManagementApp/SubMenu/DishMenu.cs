using FileManager.Controller;
using static ResturantManagementLibrary.Dish;

namespace ResturantManagementLibrary
{
    class DishMenu
    {
        MainMenu mainMenu = new();
        DishFileManager dishFileManager = new();

        public void StartDishMenu()
        {
            List<Dish> dishes = dishFileManager.ReadDish();

            string[] options =
            {
                "1. Create a dish",
                "2. Shows all dishes",
                "3. Edit a dish",
                "4. Remove dish",
                "0. Back..."
            };
            int selectOption;

            Console.WriteLine($"Dish Menu:");

            MenuUtils.ShowMenuOption(options);
            selectOption = MenuUtils.ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1: //? create a dish
                        Console.Clear();
                        CreateDishForm();
                        break;
                    case 2: //? print all dish
                        Console.Clear();
                        MenuUtils.ShowDishes(dishes);
                        StartDishMenu();
                        break;
                    case 3: //? edit a dish
                        Console.Clear();
                        Console.WriteLine($"Not implement...");
                        mainMenu.StartMainMenu();
                        break;
                    case 4: //? delite a dish
                        Console.Clear();
                        Console.WriteLine($"Not implement...");
                        mainMenu.StartMainMenu();
                        break;
                    case 0: //? back to main menu
                        Console.Clear();
                        mainMenu.StartMainMenu();
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
                        selectOption != 0
                    );
        }

        //? CREATE
        public void CreateDishForm()
        {
            Console.WriteLine($"Add a new dish:");

            Console.WriteLine($"Enter a name of dish");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter a description of dish");
            string description = Console.ReadLine();

            Console.WriteLine($"Enter a price of dish");
            double price = Convert.ToDouble(Console.ReadLine()); //TODO: manage exception

            CategoryList category = MenuUtils.ChoiseCategory();

            List<IngredientManager.Ingredient> selectedIngredients = ChoiseIngredients();

            dishFileManager.AddDish(name, description, price, category, selectedIngredients);

            //TODO: add 
            Console.WriteLine($"This {name} dish was created.");
            StartDishMenu();
        }



        public void PrintIngredient()
        {
            Console.WriteLine($"Ingredient list:");
            foreach (var ingredient in Enum.GetValues(typeof(IngredientManager.Ingredient)))
            {
                Console.WriteLine($"- {(int)ingredient}. {ingredient}");
            }
        }

        public List<IngredientManager.Ingredient> ChoiseIngredients()
        {
            List<IngredientManager.Ingredient> selectedIngredients = new();

            do
            {
                PrintIngredient();
                Console.WriteLine($"Choise ingredients for the dish (separated by comma):");
                string[] ingredientChoise = Console.ReadLine().Split(',');

                foreach (var choise in ingredientChoise)
                {
                    if (int.TryParse(choise, out int ingredientValue) && Enum.IsDefined(typeof(IngredientManager.Ingredient), ingredientValue))
                    {
                        selectedIngredients.Add((IngredientManager.Ingredient)ingredientValue);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid ingredients: {choise}");

                    }
                }

            } while (selectedIngredients.Count == 0);

            return selectedIngredients;
        }

        //? EDIT

        //? DELITE

    }
}