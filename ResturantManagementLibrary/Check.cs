namespace ResturantManagementLibrary
{
    public class Check
    {
        private int _checkId;
        private double _amount;
        private double _tip;
        public double Tax;
        private bool _isPaid;

        public int CheckId{
            get 
            {
                return _checkId;
            }
            set
            {

            }
        }
        public double Amount {
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
        public double Tip {
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
        public bool IsPaid{
            get
            {
                return _isPaid;
            }
            set{}
        }
        public Check(int checkId, double amount, double tip, double tax, bool isPaid){
            CheckId = checkId;
            Amount = amount;
            Tip = tip;
            Tax = tax;
            IsPaid = isPaid;
        }
    }
}