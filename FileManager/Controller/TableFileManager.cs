namespace FileManager.Controller
{
    public class TableFileManager
    {
        private const string tablesDbPath = "../FileManager/Database/TablesDb.csv";

        public void CreateTablesDb()
        {
            try
            {
                if (!File.Exists(tablesDbPath))
                {
                    using (StreamWriter file = File.CreateText(tablesDbPath))
                    {
                        file.WriteLine("- Tables Database");
                        file.WriteLine("TableId | Capacity | AvailableCount ");
                        file.WriteLine("TableTwoSeats | 2 | 5 ");
                        file.WriteLine("TableFourSeats | 4 | 8 ");
                        file.WriteLine("TableEightSeats | 8 | 4 ");
                        file.WriteLine("TableTenSeats | 10 | 2 ");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new IOException($"An error occurred while creating file: {ex.Message}");
            }

        }
    }
}