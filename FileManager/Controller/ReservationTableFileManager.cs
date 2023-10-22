using ResturantManagementLibrary;

namespace FileManager.Controller
{
    public class ReservationTableFileManager
    {
        private const string reservationDbPath = "../FileManager/Database/ReservationDb.csv";

        public void CreateReservationDb()
        {
            try
            {
                if (!File.Exists(reservationDbPath))
                {
                    using (StreamWriter file = File.CreateText(reservationDbPath))
                    {
                        file.WriteLine("- Reservation Database");
                        file.WriteLine("CustomerId | TableId | StartTime | EndTIme");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while creating file: {ex.Message}");
            }
        }

        // public List<Reservation> ReadReservation()
        // {
        //     List<Reservation> reservations = new();
        //     using var input = File.OpenText(reservationDbPath);
        //     input.ReadLine();
        //     input.ReadLine();

        //     while (true)
        //     {
        //         string? line = input.ReadLine();

        //         if (line is null)
        //         {
        //             break;
        //         }

        //         var chunks = line.Split('|');

        //     }
        // }

        public void AddReservation(string customerId, string tableId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (StreamWriter file = File.AppendText(reservationDbPath))
                {
                    file.WriteLine($"{customerId} | {tableId} | {startDate} | {endDate}");
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while adding a reservation: {ex.Message}");
            }
        }

    }
}