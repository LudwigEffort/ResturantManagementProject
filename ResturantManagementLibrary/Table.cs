namespace ResturantManagementLibrary
{
    public class Table
    {
        public string TableId { get; }
        public int Capacity { get; }
        public int AvailableCount { get; private set; }

        public Table(string tableId, int capacity, int availableCount)
        {
            TableId = tableId;
            Capacity = capacity;
            AvailableCount = availableCount;
        }

    }
}