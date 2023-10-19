using ResturantManagementLibrary;
using static ResturantManagementLibrary.Employee;

namespace FileManager.Controller
{
    public class EmployeeController
    {
        //TODO: read db
        //DOING: write db

        public const string employeeDbPath = "../FileManager/Database/EmployeeDb.csv";
        //RoleList[] roleLists = (RoleList[])Enum.GetValues(typeof(RoleList));
        List<Employee> employees = new();

        private List<Employee> ReadEmployee()
        {
            using var input = File.OpenText(employeeDbPath);
            input.ReadLine();
            input.ReadLine();

            while (true)
            {
                string line = input.ReadLine();

                if (line is null)
                {
                    return employees;
                }

                var chunks = line.Split(',');

                string name = chunks[0].Trim();
                string lastName = chunks[1].Trim();
                string email = chunks[2].Trim();
                string password = chunks[3].Trim();
                RoleList role;
                DateTime workTime = Convert.ToDateTime(chunks[5].Trim());

            }
        }


        //? Sign up
        public static void NewEmployee(string name, string lastName, string email, string phone, string password, Employee.RoleList role, DateTime workingHours)
        {
            using var output = File.AppendText(employeeDbPath);
            output.WriteLine($"{name}, {lastName}, {email}, {phone} {password}, {role}, {workingHours}");
        }
    }
}