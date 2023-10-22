using ResturantManagementLibrary;

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

        public List<Table> ReadTable()
        {
            List<Table> tables = new();
            using var input = File.OpenText(tablesDbPath);
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

                string tableId = chunks[0].Trim();
                int capacity = Convert.ToInt32(chunks[1].Trim());
                int availableCount = Convert.ToInt32(chunks[2].Trim());

                Table table = new(tableId, capacity, availableCount);
                tables.Add(table);
            }
            return tables;
        }
    }
}