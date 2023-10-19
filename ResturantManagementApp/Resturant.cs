namespace ResturantManagementLibrary
{
    class Resturant
    {
        public static void Main(){
            var menu = new Menu();
            int selectOption;

            do
            {
                selectOption = menu.ReadChoise();

                
                switch (selectOption)
                {
                    case 1: // Login case
                    Console.Clear();
                    break;

                    case 2: // Sign-up case
                    break;

                    default:
                    break;
                }
            } while (true);
        }
    }
}
