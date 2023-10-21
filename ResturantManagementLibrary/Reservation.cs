namespace ResturantManagementLibrary
{
    public class Reservation
    {
        private DateTime _startDate;
        private DateTime _endDate;
        public Customer customer;

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException(string.Format("Start Date must not be in the past: {0}", value.ToString()));
                }
                else
                {
                    _startDate = value;
                }
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException(string.Format("Start Date must not be in the past: {0}", value.ToString()));
                }
                else
                {
                    _endDate = value;
                }
            }
        }
    }
}