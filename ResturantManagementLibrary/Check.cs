namespace ResturantManagementLibrary
{
    public class Check
    {
        public List<Dish> Dishes { get; set; }
        private string _customerId;
        private double _amount;
        private double _tip;
        public double Tax;
        private bool _isPaid;

        public Check(List<Dish> dishes, string customerId, double amount, double tip, double tax, bool isPaid)
        {
            Dishes = dishes;
            CustomerId = customerId;
            Amount = amount;
            Tip = tip;
            Tax = tax;
            IsPaid = isPaid;
        }

        public string? CustomerId
        {
            get
            {
                if (string.IsNullOrEmpty(_customerId))
                {
                    throw new InvalidOperationException("Andress is null");
                }
                return _customerId;
            }
            set
            {
                _customerId = value;
                if (string.IsNullOrEmpty(_customerId))
                {
                    throw new ArgumentNullException(nameof(value), "Andress can not be null!");
                }
            }
        }




        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Value cannot be a negative");
                }
                else
                {
                    _amount = value;
                }
            }
        }

        public double Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Value cannot be a negative");
                }
                else
                {
                    _amount = value;
                }
            }
        }

        public bool IsPaid
        {
            get
            {
                return _isPaid;
            }
            set { _isPaid = value; }
        }

    }
}