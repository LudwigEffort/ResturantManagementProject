using ResturantManagementLibrary;
using static ResturantManagementLibrary.IngredientManager;

namespace FileManager.Controller
{
    public class DishFileManager
    {
        private const string dishDbPath = "../FileManager/Database/DishDb.csv";

        public void CreateDishDb()
        {    //If File doesn't exist, create a new one
            try
            {
                if (!File.Exists(dishDbPath))
                {
                    using (StreamWriter file = File.CreateText(dishDbPath)) 
                    {
                        file.WriteLine($"- Dish Database");
                        file.WriteLine($"Name, Description, Price, Category, Ingredients");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new IOException("An error occurred while creating file: " + ex.Message);

            }
        }
        private static List<Dish> ReadDish()
        {
            List<Dish> dishes = new();
            using var input = File.OpenText(dishDbPath);
            input.ReadLine();
            input.ReadLine();


            while (true)
            {
                string? line = input.ReadLine();

                if (line is null)
                {
                    break;
                }

                var chunks = line.Split(',');

                string name = chunks[0].Trim();
                string description = chunks[1].Trim();
                double price = double.Parse(chunks[2].Trim());
                Dish.CategoryList categoryList = Enum.TryParse(chunks[3].Trim(), out Dish.CategoryList parsedCategory) ? parsedCategory : Dish.CategoryList.NotCategory;
                var ingredientStrings = chunks[4].Split(';');
                List<IngredientManager.Ingredient> ingredients = new();

                foreach (var ingredientString in ingredientStrings)
                {
                    if (Enum.TryParse(ingredientString.Trim(), out IngredientManager.Ingredient parsedIngredient))
                    {
                        ingredients.Add(parsedIngredient);
                    }
                }
                

                Dish dish = new(name, description, price, categoryList, ingredients);
                dishes.Add(dish);
            }
            return dishes;
        }
        public static void AddDish(string name, string description, double price, Dish.CategoryList category, List<IngredientManager.Ingredient> ingredients)
        {
            using var output = File.AppendText(dishDbPath);
            string ingredientList = string.Join("; ", ingredients.Select(ingredient => ((int)ingredient).ToString()));
            output.WriteLine($"{name}, {description}, {price}, {category}, {ingredientList}");
        }
    }
}