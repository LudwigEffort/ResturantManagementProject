using static ResturantManagementLibrary.Dish;

namespace ResturantManagementLibrary
{
    public class MenuUtils
    {
        public static void ShowMenuOption(string[] options)
        {
            foreach (var item in options)
            {
                Console.WriteLine(item);
            }
        }

        public static int ReadChoise()
        {
            int selectOption;
            Console.WriteLine($"Select a option with (number):");
            while (!int.TryParse(Console.ReadLine(), out selectOption))
            {
                Console.WriteLine($"Wrong Option!");
            }
            return selectOption;
        }

        //* Table utils

        //? Print available tables
        public static void ShowAvailableTables(List<Table> tables)
        {
            Console.WriteLine($"List of available tables: ");
            Console.WriteLine($"---------------------");
            foreach (var table in tables)
            {
                Console.WriteLine($"Table Id: {table.TableId}");
                Console.WriteLine($"Table Capacity: {table.Capacity}");
                Console.WriteLine($"Available table num: {table.AvailableCount}");
                Console.WriteLine($"---------------------");
            }
        }


        //* Dish utils

        //? Pritn all dishes (READ)
        public static void ShowDishes(List<Dish> dishes)
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

        //* Dish category

        //? Print dishes by category
        public static List<Dish> ShowDishesByCategory(List<Dish> dishes)
        {
            Console.WriteLine($"Print dishes by categories");
            CategoryList category = ChoiseCategory();

            List<Dish> filteredDishes = dishes.Where(dish => dish.Category == category).ToList();
            return filteredDishes;
        }

        //? Pirnt category (enum)
        public static void PrintCategory()
        {
            Console.WriteLine($"Category list:");
            foreach (var category in Enum.GetValues(typeof(CategoryList)))
            {
                Console.WriteLine($"- {(int)category}. {category}");
            }
        }

        //? Choise category
        public static CategoryList ChoiseCategory()
        {
            CategoryList categoryChoised = CategoryList.NotCategory;

            do
            {
                PrintCategory();
                Console.WriteLine($"Choise a category for dish (with nume):");
                if (int.TryParse(Console.ReadLine(), out int choise) && Enum.IsDefined(typeof(CategoryList), choise))
                {
                    categoryChoised = (CategoryList)choise;
                    Console.WriteLine($"You are choise: {categoryChoised}");
                }
                else
                {
                    Console.WriteLine($"Choise not valid!");
                }
            } while (!Enum.IsDefined(typeof(CategoryList), categoryChoised));

            return categoryChoised;
        }

        //? Form client for make order or reservation 
        public static string CustomerForm()
        {
            Console.WriteLine($"Employee Sign up");

            Console.WriteLine($"Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter your last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine($"Enter your email: ");
            string email = Console.ReadLine();

            Console.WriteLine($"Enter your phone: ");
            string phone = Console.ReadLine();

            Console.WriteLine($"Enter your address: ");
            string address = Console.ReadLine();

            Customer customer = new Customer(name, lastName, email, phone, address);

            return customer.CustomerId;

        }
    }
}