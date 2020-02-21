namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context
                .Projects
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectWithTheirTasksDto
                {
                    TasksCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ExportTasksDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            //Serialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectWithTheirTasksDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var projects = context
                .Employees
                .Where(p => p.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                // && p.v.All(t => t.OpenDate > date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                        .Where(t => t.Task.OpenDate >= date)
                        .Select(t => new
                        {
                            TaskName = t.Task.Name,
                            OpenDate = t.Task.OpenDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString()
                        })
                        .OrderByDescending(t => DateTime.Parse(t.DueDate, CultureInfo.InvariantCulture))
                        .ThenBy(t => t.TaskName)
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(u => u.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(projects, Formatting.Indented);
        }
    }
}