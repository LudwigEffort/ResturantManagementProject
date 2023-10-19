namespace ResturantManagementLibrary
{
    public class Dish
    {
        private int _dishId;
        public string? Name {get; set;} =string.Empty;
        private string _description = String.Empty;
        public double Price;
        public int Avaiable; //Da eliminare
        public string? Category; // ENUM?
        public List<Ingredient> IngredientsList;
        public string Description {
            get {return _description;}
            set {
                if (value == "")
                {
                    _description = "Empy description";
                }
                else 
                {
                    _description = value;
                }
            }
        }
        public int DishId {
            get {
                return _dishId;
            }
            set {

            }
        }
        public Dish(int dishId, string name, string description, double price, int avaiable, string category, List<Ingredient> ingredients){
            DishId = dishId;
            Name = name;
            Description = description;
            Price = price;
            Avaiable = avaiable;
            Category = category;
            IngredientsList = ingredients;
        }

    }
}