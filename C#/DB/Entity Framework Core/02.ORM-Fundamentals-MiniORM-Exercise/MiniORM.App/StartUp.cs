namespace MiniORM.App
{
    using Data;
    using Data.Entities;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var connectinString = "Server=AS0402VGI\\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectinString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });


            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
