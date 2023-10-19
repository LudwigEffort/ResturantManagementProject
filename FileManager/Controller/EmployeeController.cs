using ResturantManagementLibrary;

namespace FileManager.Controller
{
    public class EmployeeController
    {
        //TODO: read db
        //TODO: write db

        public const string employeeDbPath = "../FileManager/Database/EmployeeDb.csv";


        public static void NewEmployee(string name, string lastName, string email, string phone, string password, Employee.RoleList role, DateTime workingHours)
        {
            using var output = File.AppendText(employeeDbPath);
            output.WriteLine($"{name}, {lastName}, {email}, {phone} {password}, {role}, {workingHours}");
        }
    }
}