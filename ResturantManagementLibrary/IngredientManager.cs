namespace ResturantManagementLibrary
{
    public class IngredientManager
    {
        public enum Ingredient
        {
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