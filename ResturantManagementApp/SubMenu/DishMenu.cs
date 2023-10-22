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
                "4. Remove dish"
            };
            int selectOption;

            Console.Clear();
            Console.WriteLine($"Dish Menu:");

            MenuUtils.ShowMenuOption(options);
            selectOption = MenuUtils.ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1: //? create a dish
                        CreateDishForm();
                        break;
                    case 2: //? print all dish
                        ShowDishes(dishes);
                        break;
                    case 3: //? edit a dish
                        ShowDishes(dishes);
                        Console.WriteLine("Insert the name of the dish you wish to edit");
                        string tempName = Console.ReadLine();
                        if (dishFileManager.DishFound(tempName))
                        {
                            EditDishForm(tempName);                           
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Name not contained \n");
                            mainMenu.StartMainMenu();
                        }
                        // dishFileManager.EditDishForm(tempName);
                        break;
                    case 4: //? delite a dish
                        Console.WriteLine($"Not implement...");
                        mainMenu.StartMainMenu();
                        break;
                    case 0: //? back to main menu
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
            Console.Clear();
            Console.WriteLine($"Add a new dish:");

            Console.WriteLine($"Enter a name of dish");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter a description of dish");
            string description = Console.ReadLine();

            string checkPrice = "Enter a price of dish";
            double price = DoubleControl(checkPrice); //TODO: manage exception

            CategoryList category = ChoiseCategory();

            List<IngredientManager.Ingredient> selectedIngredients = ChoiseIngredients();

            dishFileManager.AddDish(name, description, price, category, selectedIngredients);

            //TODO: add 
            Console.WriteLine($"This {name} dish was created.");
            StartDishMenu();
        }

        public void PrintCategory()
        {
            Console.WriteLine($"Category list:");
            foreach (var category in Enum.GetValues(typeof(CategoryList)))
            {
                Console.WriteLine($"- {(int)category}. {category}");
            }
        }

        public CategoryList ChoiseCategory()
        {
            CategoryList categoryChoised = CategoryList.NotCategory;

            do
            {
                PrintCategory();
                Console.WriteLine($"Choise a category for dish (with nume):");
                if (int.TryParse(Console.ReadLine(), out int choise) && Enum.IsDefined(typeof(CategoryList), choise))
                {
                    categoryChoised = (CategoryList)choise;
                    Console.WriteLine($"You are choise: {categoryChoised}");
                }
                else
                {
                    Console.WriteLine($"Choise not valid!");
                }
            } while (!Enum.IsDefined(typeof(CategoryList), categoryChoised));

            return categoryChoised;
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

        //? READ
        public void ShowDishes(List<Dish> dishes)
        {
            Console.Clear();
            Console.WriteLine($"List of Dishes:");
            Console.WriteLine($"---------------------");
            foreach (var dish in dishes)
            {
                Console.WriteLine($"Name: {dish.Name}");
                Console.WriteLine($"Description: {dish.Description}");
                Console.WriteLine($"Price: {dish.Price}");
                Console.WriteLine($"Category: {dish.Category}");
                Console.Write($"Ingredientes: ");
                foreach (var ingredient in dish.Ingredients)
                {
                    Console.WriteLine(ingredient + ", ");

                }
                Console.WriteLine($"---------------------");
            }
        }

        // DA SPOSTARE NEGLI UTILS - CONTROLLO INPUT
        public double DoubleControl(string checkPrice){
            string userInput;
            double number;

            do
            {
                Console.WriteLine(checkPrice);
                userInput = Console.ReadLine();
                if (!double.TryParse(userInput, out _))
                {
                    Console.WriteLine("Input Error, try again");
                }
            } while (!double.TryParse(userInput, out number));

            return number;
        }

        //? EDIT
        public void EditDishForm(string name)
        {
            string[] options = 
            {
                "1 - Chage name",
                "2 - Change description",
                "3 - Change Price",
                "4 - Change type of category",
                "5 - Change ingredients (separated by comma)",
                "0 - Exit"
            };
            string newValue;
            
            int selectOption;
            Console.WriteLine($"Insert new data for the dish: {name}");

            do
            {
                MenuUtils.ShowMenuOption(options);
                selectOption = MenuUtils.ReadChoise();
                switch (selectOption)
                {
                    case 1:
                    Console.WriteLine("Insert the new name: ");
                    newValue = Console.ReadLine();
                    dishFileManager.EditDishDB(name, selectOption, newValue);
                    EditDishForm(newValue);
                    break;

                    case 2:
                    Console.WriteLine("Insert a new description");
                    newValue = Console.ReadLine();
                    dishFileManager.EditDishDB(name, selectOption, newValue);
                    break;

                    case 3:
                    newValue = "Insert the new price";
                    double price = DoubleControl(newValue);
                    dishFileManager.EditDishDB(name, selectOption, price);
                    break;
                    
                    case 4:
                    Console.WriteLine("Insert a new category");
                    CategoryList categoryList = ChoiseCategory();
                    dishFileManager.EditDishDB(name, selectOption, categoryList);
                    break;
                    
                    case 5:
                    Console.WriteLine("Insert new ingredients (separated by ';')");
                    PrintIngredient();
                    newValue = Console.ReadLine();
                    dishFileManager.EditDishDB(name, selectOption, newValue);
                    break;
                    
                    case 0: //? back to main menu
                    mainMenu.StartMainMenu();
                    break;

                    default:
                    Console.WriteLine($"Wrong option!");
                    break;
                }
            } while (
                    selectOption != 0
                    );

        }

        //? DELITE

    }
}