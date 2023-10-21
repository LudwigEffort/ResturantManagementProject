using ResturantManagementLibrary;

namespace FileManager.Controller
{
    public class CheckFileManager
    {
        private const string CheckDbPath = "../FileManager/Database/CheckDb.csv";

        // CREATE CHECK DB IF DOESNT EXIST
        public void CreateCheckDb()
        {
            try
            {
                if (!File.Exists(CheckDbPath))
                {
                    using (StreamWriter file  = File.CreateText(CheckDbPath))
                    {
                        file.WriteLine($"- Check Database");
                        file.WriteLine($"Dishes, IsTable, Amout, Tip, Tax, IsPaid");
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new IOException("An error occurred while creating file: " + ex.Message);
            }
        }

        // READ CHECK DB
        public List<Check> ReadCheck()
        {
            List<Check> checks = new();
            using var input = File.OpenText(CheckDbPath);
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

                var checkStrings = chunks[0].Split('-');
                List<Dish> dishes = new();
                foreach (var checkString in checkStrings)
                {
                    Dish dish = ParseDish(checkString);
                    dishes.Add(dish);
                }
                bool forTable = bool.Parse(chunks[1].Trim());
                double amount = double.Parse(chunks[2].Trim());
                double tip = double.Parse(chunks[3].Trim());
                double tax = double.Parse(chunks[4].Trim());
                bool isPaid = bool.Parse(chunks[5].Trim());

                Check check = new(dishes, forTable, amount, tip, tax, isPaid);
                checks.Add(check);
            }
            return checks;
        }

        private Dish ParseDish(string csvString)
        {
            var dishChunks = csvString.Split(',');
            
            string name = dishChunks[0].Trim();
            string description = dishChunks[1].Trim();
            double price = double.Parse(dishChunks[2].Trim());
            Dish.CategoryList categoryList = Enum.TryParse(dishChunks[3].Trim(), out Dish.CategoryList parsedCategory) ? parsedCategory : Dish.CategoryList.NotCategory;
            var ingredientStrings = dishChunks[4].Split(';');
            List<IngredientManager.Ingredient> ingredients = new();

            foreach (var ingredientString in ingredientStrings)
            {
                if (Enum.TryParse(ingredientString.Trim(), out IngredientManager.Ingredient parsedIngredient))
                {
                    ingredients.Add(parsedIngredient);
                }
            }
            return new Dish(name, description, price, categoryList, ingredients);
        }

        public void AddCheck(List<Dish> dishes, bool forTable, double amount, double tip, double tax, bool isPaid){
            using var output = File.AppendText(CheckDbPath);
            foreach (var dish in dishes)
            {
                string dishlist = string.Join("-", dishes.Select(elm => elm.ToString()));
                output.WriteLine($"{dishlist} | {forTable} | {amount} | {tip} | {tax} | {isPaid}");
            }
        }


    }
}