namespace ResturantManagementLibrary
{
    public class Customer : Person
    {
        private string? _address;

        public Customer(string name, string lastName, string email, string phone, string address) : base(name, lastName, email, phone)
        {
            Address = address;
        }

        public string? Address
        {
            get
            {
                if (string.IsNullOrEmpty(_address))
                {
                    throw new InvalidOperationException("Andress is null");
                }
                return _address;
            }
            set
            {
                if (string.IsNullOrEmpty(_address))
                {
                    throw new ArgumentNullException(nameof(value), "Andress can not be null!");
                }
                _address = value;
            }
        }
    }
}