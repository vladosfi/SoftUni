namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Text;
    using TeisterMask.Data.Models.Enums;
    using System.Linq;
    using System.Globalization;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";


        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectsDto[]), new XmlRootAttribute("Projects"));

            var projectsDtos = (ImportProjectsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projects = new List<Project>();

            StringBuilder sb = new StringBuilder();

            foreach (var projectDto in projectsDtos)
            {
                bool isValid = IsValid(projectDto);

                if (isValid)
                {
                    var project = new Project
                    {
                        Name = projectDto.Name,
                        OpenDate = DateTime.ParseExact(projectDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = projectDto.DueDate == null || projectDto.DueDate == string.Empty ? (DateTime?)null : DateTime.ParseExact(projectDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    //Validate tasks 
                    foreach (var task in projectDto.Tasks)
                    {
                        bool isValidTask = IsValid(task);
                        bool isValidExecutionType = Enum.TryParse<ExecutionType>(task.ExecutionType, out ExecutionType executionType);
                        bool isValidLabelTypeType = Enum.TryParse<LabelType>(task.LabelType, out LabelType labelType);

                        //DateTime taskOpenDate = DateTime.ParseExact(task.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //DateTime taskDueDate = DateTime.ParseExact(task.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                        bool isValidTaskOpenDate = DateTime.TryParseExact(task.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                        bool isValidTaskDueDate = DateTime.TryParseExact(task.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);
                        

                        bool isValidOpentaskDate = taskOpenDate > project.OpenDate;
                        bool isValidDuetaskDate = taskDueDate < project.DueDate || project.DueDate == null;

                        if (!isValidTask || !isValidOpentaskDate || !isValidDuetaskDate || !isValidExecutionType || isValidLabelTypeType
                            || isValidTaskOpenDate || isValidTaskDueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        project.Tasks.Add(new Task
                        {
                            Name = task.Name,
                            OpenDate = taskOpenDate,
                            DueDate = taskDueDate,
                            ExecutionType = executionType,
                            LabelType = labelType
                        });
                    };

                    projects.Add(project);

                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDtos = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            var sb = new StringBuilder();
            var validEmployee = new List<Employee>();

            var existingTasksId = context.Tasks.Select(t => t.Id).ToHashSet();

            foreach (var employeeDto in employeesDtos)
            {

                if (!IsValid(employeeDto))// && !existingTasksId.Any(t=> employeeDto.Tasks.Contains(t)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validTasks = new HashSet<int>();

                foreach (var task in employeeDto.Tasks)
                {
                    if (existingTasksId.Contains(task))
                    {
                        validTasks.Add(task);
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }


                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                    EmployeesTasks = validTasks
                            .Select(p => new EmployeeTask
                            {
                                TaskId = p
                            })
                            .ToArray()
                };


                validEmployee.Add(employee);
                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count()} tasks.");
            }

            context.Employees.AddRange(validEmployee);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}