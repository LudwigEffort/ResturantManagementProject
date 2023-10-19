namespace ResturantManagementLibrary
{
    public class Employee : Person
    {
        public enum RoleList
        {
            Manager,
            Chef,
            Waiter
        }

        private string? _password;
        private RoleList _role;
        private DateTime _workingHours;

        public Employee(string name, string lastName, string email, string phone, string password, RoleList role, DateTime workingHours) : base(name, lastName, email, phone)
        {
            Password = password;
            Role = role;
            WorkingHours = workingHours;
        }

        public string Password
        {
            get
            {
                if (_password == null)
                {
                    throw new InvalidOperationException("Password is null!");
                }
                return _password;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Password can not be null!");
                }
                _password = value;
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