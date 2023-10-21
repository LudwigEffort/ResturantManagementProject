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

        public List<Dish> ReadDish()
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

                var chunks = line.Split('|');

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

        //? Make list from db
        // public static void MakeListDishes()
        // {
        //     List<Dish> dishes = ReadDish();

        // }

        //? CREATE
        public void AddDish(string name, string description, double price, Dish.CategoryList category, List<IngredientManager.Ingredient> ingredients)
        {
            using var output = File.AppendText(dishDbPath);
            string ingredientList = string.Join("; ", ingredients.Select(ingredient => ((int)ingredient).ToString()));
            output.WriteLine($"{name} | {description} | {price} | {category} | {ingredientList}");
        }

        public void EditDishForm(string name)
        {
            try
            {
                var lines = File.ReadAllLines(dishDbPath);
                bool found = false;

                for (int i = 1; i < lines.Length; i++)
                {
                    var chunks = lines[i].Split('|');

                    if (chunks.Length >= 0 && chunks[0].Trim().ToLower() == name.Trim().ToLower())
                    {
                        Console.WriteLine("Inserisci i nuovi dati per il piatto:");
                        Console.Write("Nome: ");
                        chunks[0] = Console.ReadLine();
                        Console.Write("Descrizione: ");
                        chunks[1] = Console.ReadLine();
                        Console.Write("Prezzo: ");
                        chunks[2] = Console.ReadLine();
                        Console.Write("Lista delle categorie: ");
                        chunks[3] = Console.ReadLine();
                        Console.Write("Ingredienti: ");
                        chunks[4] = Console.ReadLine();

                        lines[i] = string.Join('|', chunks);
                        found = true;
                    }

                }

                if (!found) //? NOT FOUND
                {
                    Console.WriteLine($"Dish with name: {name} not found.");
                    return;
                }

                File.WriteAllLines(dishDbPath, lines);
            }
            catch (System.Exception ex)
            {
                throw new IOException("An error occurred while editing the file: " + ex.Message);  
            }
        }
        
    }
}