using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor.ImportDtos
{
    public class ImportAnimalsPasportsDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Age { get; set; }
        
        [Required]
        public PassportDto Passport { get; set; }

    }
}
