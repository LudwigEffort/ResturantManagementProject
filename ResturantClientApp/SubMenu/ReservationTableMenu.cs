using System.Security.Cryptography.X509Certificates;
using FileManager.Controller;
using ResturantManagementLibrary;

namespace ResturantClientApp
{
    class ReservationTableMenu
    {
        MainMenu mainMenuClient = MainMenu.GetInstance();
        //TODO: add reservation file manager

        public void StartReservationMenu()
        {
            Console.Clear();

            string customerId = MenuUtils.CustomerForm();

            string[] options =
            {
                "1. Make a reservation",
                "0. Back to main menu"
            };

            MenuUtils.ShowMenuOption(options);
            int selectOption = MenuUtils.ReadChoise();

            do
            {
                switch (selectOption)
                {
                    case 1:
                        CreateReservationTableForm(customerId);
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Backing to main menu...");
                        mainMenuClient.StartMainMenu();
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 0);

        }

        public void CreateReservationTableForm(string customerId)
        {
            ReservationTableFileManager reservationTableFileManager = new();

            TableFileManager tableFileManager = new();
            List<Table> tables = tableFileManager.ReadTable();

            MenuUtils.ShowAvailableTables(tables);

            Console.WriteLine($"Enter a table id: ");
            string tableId = Console.ReadLine();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddHours(2);

            reservationTableFileManager.AddReservation(customerId, tableId, startTime, endTime);

            //? make a reservation with method in reservation file manager
        }
    }
}