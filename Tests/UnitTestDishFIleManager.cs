using System.Collections;
using System.ComponentModel;
using FileManager.Controller;
using ResturantManagementLibrary;
using static ResturantManagementLibrary.IngredientManager;

namespace Tests;

public class UnitTestDishFileManager
{
    DishFileManager dishFileManager;
    [SetUp]
    public void Setup()
    {
        dishFileManager = new();
    }

    [Test]
    public void ReadDish_ShouldReturnListOfDishes()
    {
        List<Dish> dishesFromDb = dishFileManager.ReadDish();

        Assert.IsNotNull(dishesFromDb);
        Assert.IsInstanceOf<List<Dish>>(dishesFromDb);
        Assert.IsTrue(dishesFromDb.Count > 0);
    }

    [Test]
    public void AddDish_AddsDishToDb()
    {
        DishFileManager dishFileManager = new DishFileManager();
        string name = "Pasta al burro";
        string description = "Pata con burro, parmigiano e scorza di limone";
        double price = 9.99;
        Dish.CategoryList category = Dish.CategoryList.FirstDish;
        var ingredients = new List<Ingredient>
            {
                Ingredient.Pasta,
                Ingredient.Formaggio
            };
        dishFileManager.AddDish(name, description, price, category, ingredients);
        var dishes = dishFileManager.ReadDish();
        bool dishAdded = dishes.Any(dish =>
            dish.Name == name &&
            dish.Description == description &&
            dish.Price == price &&
            dish.Category == category &&
            dish.Ingredients.SequenceEqual(ingredients)
        );
        Assert.IsTrue(dishAdded, "The dish was not added to the db.");
    }
}