namespace ResturantManagementLibrary
{
    class IngredientManager
    {
        public enum Ingredients
        {
            Pasta,
            Salsa,
            Carne,
            Uova
        }

        private Dictionary<Ingredients, int> warehouse = new Dictionary<Ingredients, int>();
    }
}