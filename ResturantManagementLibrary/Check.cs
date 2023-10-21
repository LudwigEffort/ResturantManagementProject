namespace ResturantManagementLibrary
{
    public class Check
    {
        public List<Dish> Dishes { get; set; }
        private bool _forTable;
        private double _amount;
        private double _tip;
        public double Tax;
        private bool _isPaid;

        public Check(List<Dish> dishes, bool forTable, double amount, double tip, double tax, bool isPaid)
        {
            Dishes = dishes;
            ForTable = forTable;
            Amount = amount;
            Tip = tip;
            Tax = tax;
            IsPaid = isPaid;
        }

        public bool ForTable
        {
            get { return _forTable; }
            set { _forTable = value; }
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