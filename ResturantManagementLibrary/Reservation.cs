namespace ResturantManagementLibrary
{
    public class Reservation
    {
        public string? ReservationId;
        public int PeopleNum;
        public DateTime StartDate;
        public DateTime EndDate;
        public Customer customer;
    }
}