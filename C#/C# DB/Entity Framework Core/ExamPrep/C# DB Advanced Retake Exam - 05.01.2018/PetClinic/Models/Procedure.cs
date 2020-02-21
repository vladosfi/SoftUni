
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
        
        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new HashSet<ProcedureAnimalAid>();

        //TODO  make calculation 
        public decimal Cost => this.ProcedureAnimalAids.Sum(p=>p.AnimalAid.Price);

        [Required]
        public DateTime DateTime { get; set; }
    }
}