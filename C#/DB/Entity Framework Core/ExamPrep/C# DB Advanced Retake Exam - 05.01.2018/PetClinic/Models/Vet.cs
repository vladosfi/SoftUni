namespace PetClinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vet
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Profession { get; set; }

        [Required,Range(22,65)]
        public int Age { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [RegularExpression(@"^(\+359[\d]{9})|(0[\d]{9})$")]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();     
    }
}
