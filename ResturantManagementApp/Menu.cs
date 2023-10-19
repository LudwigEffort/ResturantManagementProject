namespace ResturantManagementLibrary
{
    public class Menu
    {
        string[] options = {"1. Login", "2. Sign Up"}; 
        public void ShowMenu(string[] options){
            foreach (var item in options)
            {
                Console.WriteLine(item);
            }
        }
        public int ReadChoise()
        {
            int selectOption;
            Console.WriteLine($"Select a option with 1-2:");
            while (!int.TryParse(Console.ReadLine(), out selectOption))
            {
                Console.WriteLine($"Wrong Option!");
                Console.WriteLine($"Select a option with 1-2:");
            }
            return selectOption;
        }
    }
}