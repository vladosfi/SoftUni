namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ExportDtos;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context
                .Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.PassportSerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    
                })
                .OrderBy(p => p.Age)
                .ThenBy(p=>p.SerialNumber)
                .ToArray();

            return JsonConvert.SerializeObject(animals, Formatting.Indented);
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context
                .Procedures
                .Select(p => new ExportProceduresDtos
                {
                    Passport = p.Animal.PassportSerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = p.ProcedureAnimalAids.Select(a=> new ExportAnimalAidsDto
                            {
                                Name = a.AnimalAid.Name,
                                Price = a.AnimalAid.Price
                            })
                            .ToArray(),
                    TotalPrice = p.Cost
                })
                .OrderBy(s => DateTime.ParseExact(s.DateTime, @"dd-MM-yyyy", CultureInfo.InvariantCulture))
                .ThenBy(s => s.Passport)
                .ToArray();

            //Serialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(ExportProceduresDtos[]), new XmlRootAttribute("Procedures"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), procedures, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
