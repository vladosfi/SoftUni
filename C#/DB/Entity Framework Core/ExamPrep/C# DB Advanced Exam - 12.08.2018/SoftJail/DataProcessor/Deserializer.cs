namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {

            var departmentsDtos = JsonConvert.DeserializeObject<ImportDepartmentsCellsDto[]>(jsonString);

            var sb = new StringBuilder();
            var validDepartments = new List<Department>();

            foreach (var departmentDto in departmentsDtos)
            {
                var cells = new List<Cell>();

                if (!IsValid(departmentDto) && 
                    !IsValid(departmentDto.Cells.All(IsValid)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var cellDto in departmentDto.Cells)
                {
                    cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }
                
                var department = new Department
                {
                    Name = departmentDto.Name,
                    Cells = cells
                };

                validDepartments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}