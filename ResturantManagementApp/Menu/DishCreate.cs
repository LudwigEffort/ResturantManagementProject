using FileManager.Controller;
using static ResturantManagementLibrary.Dish;

namespace ResturantManagementLibrary
{
    public class DishCreate
    {
        public static void CreateForm()
        {
            Console.WriteLine($"Add a new dish");

            Console.WriteLine($"Enter a name of dish");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter a description of dish");
            string description = Console.ReadLine();

            Console.WriteLine($"Enter a price of dish");
            double price = Convert.ToDouble(Console.ReadLine()); //TODO: manage exception

            CategoryList category = ChoiseCategory();

            //PrintIngredient();

            List<IngredientManager.Ingredient> selectedIngredients = ChoiseIngredients();

            //TODO: choise list of ingredients

            DishFileManager.AddDish(name, description, price, category, selectedIngredients);

        }

        public static void PrintCategory()
        {
            Console.WriteLine($"Category list:");
            foreach (var category in Enum.GetValues(typeof(CategoryList)))
            {
                Console.WriteLine($"- {(int)category}. {category}");
            }
        }

        public static CategoryList ChoiseCategory()
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

        public static void PrintIngredient()
        {
            Console.WriteLine($"Ingredient list:");
            foreach (var ingredient in Enum.GetValues(typeof(IngredientManager.Ingredient)))
            {
                Console.WriteLine($"- {(int)ingredient}. {ingredient}");
            }
        }

        public static List<IngredientManager.Ingredient> ChoiseIngredients()
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

    }
}