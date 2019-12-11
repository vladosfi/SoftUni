namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ImportDtos;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";
        private const string SuccessfullyImportedProcedure = "Record successfully imported.";


        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var sb = new StringBuilder();
            var validAnimalAids = new List<AnimalAid>();

            foreach (var animalAid in animalAids)
            {

                if (!IsValid(animalAid) || validAnimalAids.Any(a => a.Name == animalAid.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validAnimalAids.Add(animalAid);
                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animalsDtos = JsonConvert.DeserializeObject<ImportAnimalsPasportsDto[]>(jsonString);

            var sb = new StringBuilder();
            var validAnimals = new List<Animal>();

            foreach (var animalDto in animalsDtos)
            {
                if (!IsValid(animalDto) || 
                    !IsValid(animalDto.Passport) || 
                    validAnimals.Any(a => a.Passport.SerialNumber == animalDto.Passport.SerialNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animal = new Animal
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age,
                    Passport = new Passport
                    {
                        SerialNumber = animalDto.Passport.SerialNumber,
                        OwnerName = animalDto.Passport.OwnerName,
                        OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, @"dd-MM-yyyy", CultureInfo.InvariantCulture)
                    }
                };

                validAnimals.Add(animal);
                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportVetsDto[]), new XmlRootAttribute("Vets"));

            var vetsDtos = (ImportVetsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var vets = new List<Vet>();

            StringBuilder sb = new StringBuilder();

            foreach (var vetDto in vetsDtos)
            {
                if (IsValid(vetDto) && 
                    !vets.Any(p => p.PhoneNumber == vetDto.PhoneNumber || vetDto.PhoneNumber == null))
                {
                    var vet = new Vet
                    {
                        Name = vetDto.Name,
                        Profession = vetDto.Profession,
                        Age = vetDto.Age,
                        PhoneNumber = vetDto.PhoneNumber
                    };

                    vets.Add(vet);
                    sb.AppendLine($"Record {vet.Name} successfully imported.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProceduresDto[]), new XmlRootAttribute("Procedures"));

            var proceduresDtos = (ImportProceduresDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var procedures = new List<Procedure>();

            StringBuilder sb = new StringBuilder();

            var existingVets = context.Vets.ToArray();
            var existingAnimals = context.Animals.ToArray();
            var existingAnimalAids = context.AnimalAids.ToArray();

            Console.WriteLine("-------------------------------------------------------------------------------------");
            foreach (var procedureDto in proceduresDtos)
            {

                if (IsValid(procedureDto) &&
                    procedureDto.AnimalAids.All(IsValid) &&
                    existingVets.Any(v => v.Name == procedureDto.Vet) &&
                    existingAnimals.Any(a => a.PassportSerialNumber == procedureDto.Animal) &&
                    procedureDto.AnimalAids.Any(p => existingAnimalAids.Any(a => a.Name == p.Name)) &&
                    !procedureDto.AnimalAids.Any(p => procedureDto.AnimalAids.Count(pr => pr.Name == p.Name) > 1)
                    )
                {
                    var procedure = new Procedure
                    {
                        Vet = existingVets.Where(v => v.Name == procedureDto.Vet).First(),
                        Animal = existingAnimals.Where(a => a.PassportSerialNumber == procedureDto.Animal).First(),
                        DateTime = DateTime.ParseExact(procedureDto.DateTime, @"dd-MM-yyyy", CultureInfo.InvariantCulture)
                    };

                    foreach (var aidDto in procedureDto.AnimalAids)
                    {
                        var aid = existingAnimalAids.Where(a => a.Name == aidDto.Name).First();
                        procedure.ProcedureAnimalAids.Add(new ProcedureAnimalAid
                        {
                            AnimalAidId = aid.Id
                        });
                    }

                    procedures.Add(procedure);
                    sb.AppendLine(SuccessfullyImportedProcedure);
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Procedures.AddRange(procedures);
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
