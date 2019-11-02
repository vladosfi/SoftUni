namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    public class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            //string result = GetEmployeesFullInformation(context);

            Console.WriteLine(result);
        }

        // 03.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = string.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                });

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
