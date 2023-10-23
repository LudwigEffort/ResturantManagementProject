using FileManager.Controller;

namespace Tests;

public class UnitTestDishFileManager
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateDishDb_WhenErrorOccurs_DoesNotThrowException()
    {
        DishFileManager dishFileManager = new();

        try
        {
            dishFileManager.CreateDishDb();
        }
        catch (IOException ex)
        {
            StringAssert.Contains("An error occurred while creating file:", ex.Message);
            return;
        }

        Assert.Fail("Expected IOException was not thrown.");
    }
}