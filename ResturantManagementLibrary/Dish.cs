namespace ResturantManagementLibrary
{
    public class Dish
    {
        private int _DishId;
        public string? Name;
        private string? _description;
        public double Price;
        public int Avaiable; //Da eliminare
        public string? Category; // ENUM?
        public List<Ingredient> IngredientsList;

        public Dish(int dishId, string name, string description, double price, int avaiable, string category, List<Ingredient> ingredients){
            _DishId = dishId;
            Name = name;
            _description = description;
            Price = price;
            Avaiable = avaiable;
            Category = category;
            IngredientsList = ingredients;
        }
    }
}