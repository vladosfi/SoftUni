using System.ComponentModel.DataAnnotations;

namespace BandRegister.Models
{
    public class Band
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Members { get; set; }

        [Required]
        public decimal Honorarium { get; set; }

        [Required]
        public string Genre{ get; set; }
    }
}
