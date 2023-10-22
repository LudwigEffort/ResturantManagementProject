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
                        file.WriteLine("Customer | Tables | StartTime | EndTIme");
                    }
                }
            }
            catch (System.Exception ex)
            {   
                throw new IOException($"An error occurred while creating file: {ex.Message}");
            }
        }

        public List<Reservation> ReadReservation()
        {
            List<Reservation> reservations = new();
            using var input = File.OpenText(reservationDbPath);
            input.ReadLine();
            input.ReadLine();

            while (true)
            {
                string? line = input.ReadLine();

                if (line is null)
                {
                    break;
                }

                var chunks = line.Split('|');

            }
        }
        public void AddReservation(Customer customer, List<Table> tables, DateTime startDate, DateTime endDate)
        {
            using var output = File.AppendText(reservationDbPath);
            string tablelist = string.Join(", ", tables.Select(table => table.ToString()));
            output.WriteLine($"{customer.CustomerId} | {tables} | {startDate} | {endDate}");
        }
    }
}