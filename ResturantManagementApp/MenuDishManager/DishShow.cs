using FileManager.Controller;
using static ResturantManagementLibrary.Dish;

namespace ResturantManagementLibrary
{
    public class DishShow
    {
        public void ShowDishes(List<Dish> dishes)
        {
            Console.WriteLine($"List of Dishes:");
            Console.WriteLine($"---------------------");
            foreach (var dish in dishes)
            {
                Console.WriteLine($"Name: {dish.Name}");
                Console.WriteLine($"Description: {dish.Description}");
                Console.WriteLine($"Price: {dish.Price}");
                Console.WriteLine($"Category: {dish.Category}");
                Console.Write($"Ingredientes: ");
                foreach (var ingredient in dish.Ingredients)
                {
                    Console.WriteLine(ingredient + ", ");

                }
                Console.WriteLine($"---------------------");
            }
        }

    }
}