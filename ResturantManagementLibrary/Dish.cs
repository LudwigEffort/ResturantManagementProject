namespace ResturantManagementLibrary
{
    public class Dish
    {
        public enum CategoryList //TODO: move 
        {
            NotCategory,
            Appetizer,
            FirstDish,
            SecondDish,
            SingleDish,
            Dessert
        }

        public string Name { get; set; } = string.Empty;
        public string Description = String.Empty;
        public double Price; //TODO: to private
        //public bool Avaiable; //TODO: for soft delite
        public CategoryList Category;
        public List<IngredientManager.Ingredient> Ingredients;

        public Dish(string name, string description, double price, CategoryList category, List<IngredientManager.Ingredient> ingredients)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Ingredients = ingredients;
        }
    }
}