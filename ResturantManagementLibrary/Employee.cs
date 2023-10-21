namespace ResturantManagementLibrary
{
    public class Employee : Person
    {
        public enum RoleList
        {
            WithoutRole,
            Manager,
            Chef,
            Waiter
        }

        private string? _password;
        private RoleList _role;
        private DateTime _workingHours; // No time to adjust, should have been StartWorkingHours and EndWorkingHours
                                        //TODO: manage multi format date (us vs it)

        public Employee(string name, string lastName, string email, string phone, string password, RoleList role, DateTime workingHours) : base(name, lastName, email, phone)
        {
            Password = password;
            Role = role;
            WorkingHours = workingHours;
        }

        public string? Password
        {
            get
            {
                if (string.IsNullOrEmpty(_password))
                {
                    throw new InvalidOperationException("Password is null!");
                }
                return _password;
            }
            set
            {
                _password = value;
                if (string.IsNullOrEmpty(_password))
                {
                    throw new ArgumentNullException(nameof(value), "Password can not be null!"); //Exception not working
                }
            }
        }

        public RoleList Role
        {
            get { return _role; }
            set
            {
                _role = value;
            }
        }

        public DateTime WorkingHours
        {
            get { return _workingHours; }
            set
            {
                _workingHours = value;
            }
        }
    }
}