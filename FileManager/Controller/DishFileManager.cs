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
                    using (StreamWriter file = File.CreateText(dishDbPath)) { }
                }
            }
            catch (Exception ex)
            {
                throw new IOException("An error occurred while creating file: " + ex.Message);

            }
        }
        private static List<Dish> ReadDish()
        {
            using var input = File.OpenText(dishDbPath);
            input.ReadLine();
            input.ReadLine();

            List<Dish> dishes = new();

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
                string price = chunks[2].Trim();
                string avaiable = chunks[3].Trim();

                // Dish dish = new(name, description, price, avaiable, );
                // dishes.Add(dish);

            }
            return dishes;
        }
        public static void AddDish(string name, string description, double price, Dish.CategoryList category, List<IngredientManager.Ingredient> ingredients)
        {
            using var output = File.AppendText(dishDbPath);
            string ingredientList = string.Join(", ", ingredients.Select(ingredient => ((int)ingredient).ToString()));
            output.WriteLine($"{name}, {description}, {price}, {category}, {ingredientList}");
        }
    }
}