namespace ResturantManagementLibrary
{
    public class Dish
    {
        public enum CategoryList
        {
            Appetizer,
            FirstDish,
            SecondDish,
            Dessert,
            Drinks
        }

        //private int _dishId;
        public string? Name { get; set; } = string.Empty;
        private string _description = String.Empty;
        public double Price; //TODO: to private
        public int Avaiable; //Da eliminare
        public CategoryList category;
        public List<IngredientManager.Ingredient> Ingredients;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
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
    }
}