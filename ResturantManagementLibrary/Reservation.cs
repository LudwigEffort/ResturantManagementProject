namespace ResturantManagementLibrary
{
    public class Reservation
    {
        // private string _reservationId = String.Empty;
        private int _peopleNum;
        private DateTime _startDate;
        private DateTime _endDate;
        public Customer customer;

        // public string ReservationId{
        //     get
        //     {
        //         return _reservationId;
        //     }
        //     set
        //     {
        //         if (value == "")
        //         {
        //             _reservationId = "Empy description";
        //         }
        //         else 
        //         {
        //             _reservationId = value;
        //         }
        //     }
        // }
        public int PeopleNum {
            get
            {
                return _peopleNum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Value cannot be a negative");
                }
                else
                {
                    _peopleNum = value;
                }
            }
        }
        public DateTime StartDate{
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
        public DateTime EndDate{
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