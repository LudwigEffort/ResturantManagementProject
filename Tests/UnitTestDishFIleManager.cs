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
}