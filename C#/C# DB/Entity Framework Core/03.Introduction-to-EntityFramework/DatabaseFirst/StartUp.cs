namespace SoftUni
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string result;

            //result = GetEmployeesFullInformation(context);

            //result = GetEmployeesWithSalaryOver50000(context);

            //result = GetEmployeesFromResearchAndDevelopment(context);

            //result = AddNewAddressToEmployee(context);

            //result = GetEmployeesInPeriod(context);

            //result = GetAddressesByTown(context);

            //result = GetEmployee147(context);

            //result = GetDepartmentsWithMoreThan5Employees(context);

            //result = GetLatestProjects(context);

            //result = IncreaseSalaries(context);

            //result = GetEmployeesByFirstNameStartingWithSa(context);

            //result = DeleteProjectById(context);

            result = RemoveTown(context);

            Console.WriteLine(result);
        }

        //15.Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var townToDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            var addressesToDelete = context.Addresses.Where(a => a.Town.Name == "Seattle").ToList();
            var employeesAddress = context
                .Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employeeAddress in employeesAddress)
            {
                employeeAddress.AddressId = null;
            }
                        
            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            sb.AppendLine($"{addressesToDelete.Count} addresses in Seattle were deleted");

            return sb.ToString().TrimEnd();
        }


        //14.Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesProjectsRefference = context.EmployeesProjects.Where(p => p.ProjectId == 2).ToList();

            context.EmployeesProjects.RemoveRange(employeesProjectsRefference);

            var projectToDelete = context.Projects.FirstOrDefault(x=>x.ProjectId == 2);

            context.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context
                .Projects
                .Take(10)
                .Select(p => new
                {
                    p.Name
                })
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        //13.Find Employees by First Name Starting With "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                //.Where(e => e.FirstName.StartsWith("Sa"))
                .Where(e => EF.Functions.Like(e.FirstName,"Sa%"))
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.LastName)
                .Select(e => new
                {
                    fullName = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    e.Salary
                });


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.fullName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //12.Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Where(e => e.Department.Name == "Engineering" ||
                    e.Department.Name == "Tool Design" ||
                    e.Department.Name == "Marketing" ||
                    e.Department.Name == "Information Services")
                 .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.UpdateRange(employees);

            context.SaveChanges();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //11.Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)                
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($@"{
                    string.Join(
                        Environment.NewLine, 
                        project.Name, 
                        project.Description, 
                        project.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture))}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d=>d.Name)
                .Select(d => new
                {
                    deparmentName = d.Name,
                    managerName = string.Join(" ", d.Manager.FirstName, d.Manager.LastName),
                    employees = d.Employees
                        .Select(e => new
                        {
                            employeeFirstName = e.FirstName,
                            employeeLastName = e.LastName,
                            jobTytle = e.JobTitle
                        })
                        .OrderBy(e=>e.employeeFirstName)
                        .ThenBy(e=>e.employeeFirstName)
                        .ToList()
                })
                .ToList();


            foreach (var department in departments)
            {
                sb.AppendLine($"{department.deparmentName} - {department.managerName}");
                foreach (var employee in department.employees)
                {
                    sb.AppendLine($"{string.Join(" ", employee.employeeFirstName,employee.employeeLastName)} - {employee.jobTytle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //09.Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    fullName = string.Join(" ", e.FirstName, e.LastName),
                    jobTitle = e.JobTitle,
                    projects = e.EmployeesProjects
                        .Select(p => p.Project.Name)
                        .OrderBy(p => p)
                })
                .First();


            sb.AppendLine($"{employee.fullName} - {employee.jobTitle}");

            foreach (var project in employee.projects)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }


        //08.Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var adresses = context
                .Addresses
                .Select(a => new
                {
                    employeesCount = a.Employees.Count(),
                    addressText = a.AddressText,
                    townName = a.Town.Name
                })
                .OrderByDescending(a => a.employeesCount)
                .ThenBy(a => a.townName)
                .ThenBy(a => a.addressText)
                .Take(10)
                .ToList();

            foreach (var address in adresses)
            {
                sb.AppendLine($"{address.addressText}, {address.townName} - {address.employeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //07.Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(p => p.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 && s.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    employeeName = string.Join(" ", e.FirstName, e.LastName),
                    managerName = string.Join(" ", e.Manager.FirstName, e.Manager.LastName),
                    projects = e.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                    .ToList()
                })
                .Take(10)
                .ToList();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.employeeName} - Manager: {employee.managerName}");

                foreach (var project in employee.projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        //06.Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addressesText = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address
                });

            foreach (var addressText in addressesText)
            {
                sb.AppendLine($"{addressText.Address.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        //05.Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                });

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //04.Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //03.Employees Full Information
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
