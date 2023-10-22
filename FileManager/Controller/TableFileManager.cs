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
                        file.WriteLine("TableId | Capacity ");
                        file.WriteLine("TableA1 | 2");
                        file.WriteLine("TableA2 | 2");
                        file.WriteLine("TableB1 | 4");
                        file.WriteLine("TableB2 | 4");
                        file.WriteLine("TableC1 | 8");
                        file.WriteLine("TableC2 | 8");
                        file.WriteLine("TableD1 | 10");
                        file.WriteLine("TableD2 | 10");
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

                Table table = new(tableId, capacity);
                tables.Add(table);
            }
            return tables;
        }
    }
}