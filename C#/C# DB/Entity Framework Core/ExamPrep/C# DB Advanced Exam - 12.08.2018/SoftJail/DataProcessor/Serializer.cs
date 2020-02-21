namespace SoftJail.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var albums = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                        .Select(o=> new
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(o=>o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(o=>o.Officer.Salary)//.ToString("F2")
                })
                .OrderBy(p => p.Name)
                .ThenBy(p=>p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(albums, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var products = context
                .Prisoners
                .Where(p => prisonersNames.Contains(p.FullName))
                .Select(p => new ExportPrisonersByCellsDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString(@"yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new ExportEncryptedMessagesDto
                    {
                        Description = ReverseString(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            //Serialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonersByCellsDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ReverseString(string myStr)
        {
            return string.Concat(myStr.Reverse());
        }
    }
}