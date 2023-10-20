namespace ResturantManagementLibrary
{
    public class IngredientManager
    {
        public enum Ingredient
        {
            Empty,
            Pasta,
            Salsa,
            Carne,
            Uova,
            Formaggio,
            Guanciale,
            Insalata,
            Patate
        }

        private Dictionary<Ingredient, int> warehouse = new Dictionary<Ingredient, int>();
    }
}