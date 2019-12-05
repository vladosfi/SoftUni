
namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Procedure
    {
        public int Id { get; set; }

        public int AnimalId { get; set; }
        [Required]
        public Animal Animal { get; set; }

        [Required]
        public int VetId { get; set; }
        public Vet Vet { get; set; }



        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Profession { get; set; }

        [Required, Range(22, 65)]
        public int Age { get; set; }

        [RegularExpression(@"^(\+359[\d]{9})|(0[\d]{9})$")]
        public string PhoneNumber { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new HashSet<ProcedureAnimalAid>();

        //TODO  make calculation 
        public decimal Cost => this.ProcedureAnimalAids.Sum(p=>p.AnimalAid.Price);

        [Required]
        public DateTime DateTime { get; set; }
    }
}