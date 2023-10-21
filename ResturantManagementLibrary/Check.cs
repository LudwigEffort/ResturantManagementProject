namespace ResturantManagementLibrary
{
    public class Check
    {
        public Dictionary<Dish, int> OrderedDishes { get; set; }
        private string _customerId;
        private double _amount;
        public double Tip { get; private set; }
        public double Tax { get; private set; }
        private bool _isPaid;

        public Check(Dictionary<Dish, int> orderedDishes, string customerId, double amount, bool isPaid)
        {
            OrderedDishes = orderedDishes;
            CustomerId = customerId;
            Amount = amount;
            CalcTax();
            CalcTips();
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

        public void CalcTax()
        {
            Tax = _amount * 0.22;
        }

        public void CalcTax(double amount)
        {
            Tax = amount * 0.22;
        }

        public void CalcTips()
        {
            Tip = _amount * 0.05;
        }

        public void CalcTips(double amount)
        {
            Tip = amount * 0.05;
        }

        public bool IsPaid
        {
            get
            {
                return _isPaid;
            }
            set { _isPaid = value; }
        }

        public double CalculateTotalAmout(Dictionary<Dish, int> selectedMenu)
        {
            double totalAmount = 0.0;

            foreach (var kvp in selectedMenu)
            {
                Dish dish = kvp.Key;
                int quantity = kvp.Value;
                double dishPrice = dish.Price;
                totalAmount += dishPrice * quantity;
            }
            return totalAmount + Tax;
        }

    }
}