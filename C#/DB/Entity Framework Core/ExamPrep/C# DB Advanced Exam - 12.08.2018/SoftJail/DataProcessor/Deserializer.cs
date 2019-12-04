namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {

            //var departmentsDtos = JsonConvert.DeserializeObject<ImportDepartmentsCellsDto[]>(jsonString);
            var departmentsDtos = JsonConvert.DeserializeObject<Department[]>(jsonString);

            var sb = new StringBuilder();
            var validDepartments = new List<Department>();

            foreach (var departmentDto in departmentsDtos)
            {
                //var cells = new List<Cell>();

                //foreach (var cellDto in departmentDto.Cells)
                //{
                //    cells.Add(new Cell
                //    {
                //        CellNumber = cellDto.CellNumber,
                //        HasWindow = cellDto.HasWindow
                //    });
                //}

                //var department = new Department
                //{
                //    Name = departmentDto.Name,
                //    Cells = cells
                //};

                if (!IsValid(departmentDto) ||
                    !departmentDto.Cells.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validDepartments.Add(departmentDto);

                sb.AppendLine($"Imported {departmentDto.Name} with {departmentDto.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonersDto[]>(jsonString);

            var sb = new StringBuilder();
            var validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {

                if (!IsValid(prisonerDto) ||
                    !prisonerDto.Mails.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = prisonerDto.ReleaseDate == null ? (DateTime?)null :
                        DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                foreach (var mailDto in prisonerDto.Mails)
                {
                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Address = mailDto.Address,
                        Sender = mailDto.Sender
                    };

                    prisoner.Mails.Add(mail);
                }

                validPrisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisonerDto.FullName} {prisonerDto.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisonersDto[]), new XmlRootAttribute("Officers"));

            var officersDtos = (ImportOfficersPrisonersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var officers = new List<Officer>();
            var officersPrisoners = new HashSet<OfficerPrisoner>();

            StringBuilder sb = new StringBuilder();

            //var validDepartments = context.Departments.Select(d => d.Id).ToArray();
            //var validPrisoners = context.Prisoners.Select(p => p.Id).ToArray();

            foreach (var officerDto in officersDtos)
            {
                bool isValidWeapon = Enum.TryParse(officerDto.Weapon,out Weapon weapon);
                bool isValidPosition = Enum.TryParse(officerDto.Position, out Position position);
                //bool isValidDepartment = validDepartments.Contains(officerDto.DepartmentId);
                //bool isValidPrisoner = validPrisoners.Any(p => officerDto.Prisoners.Any(pr => pr.Id == p));

                if (!isValidWeapon || !isValidPosition)// || !isValidDepartment || !isValidPrisoner)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValid = IsValid(officerDto);

                if (isValid)
                {
                    var officer = new Officer
                    {
                        FullName = officerDto.Name,
                        Salary = officerDto.Salary,
                        Position = position,
                        Weapon = weapon,
                        DepartmentId = officerDto.DepartmentId,
                        OfficerPrisoners = officerDto.Prisoners
                            .Select(p => new OfficerPrisoner
                            {
                                PrisonerId = p.Id
                            })
                            .ToArray()
                    };

                    
                    officers.Add(officer);
                    sb.AppendLine($"Imported {officer.FullName} ({officerDto.Prisoners.Count()} prisoners)");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
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