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
        private static string ErrorMessage = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var sb = new StringBuilder();
            var validAnimalAids = new List<AnimalAid>();

            foreach (var animalAid in animalAids)
            {
                
                if (!IsValid(animalAid) || validAnimalAids.Any(a=>a.Name == animalAid.Name))
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

                if (!IsValid(animalDto) || !IsValid(animalDto.Passport) || validAnimals.Any(a=>a.Passport.SerialNumber == animalDto.Passport.SerialNumber))
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
                if (IsValid(vetDto) && !vets.Any(p=>p.PhoneNumber == vetDto.PhoneNumber))
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
