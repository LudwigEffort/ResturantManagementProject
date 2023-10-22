namespace ResturantManagementLibrary
{
    public class Table
    {
        public string TableId { get; }
        public int Capacity { get; }

        public Table(string tableId, int capacity)
        {
            TableId = tableId;
            Capacity = capacity;
        }

    }
}