namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.Models;

    public class Deserializer
    {
        private static string ErrorMessage = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var sb = new StringBuilder();
            var validAnimalAids = new HashSet<AnimalAid>();

            foreach (var animalAid in animalAids)
            {
                
                if (!IsValid(animalAid) )
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
            throw new NotImplementedException();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
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
