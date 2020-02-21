
namespace SoftJail.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Mail
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [RegularExpression(@"^[\dA-Za-z\s]+ str\.$")]
        public string Address { get; set; }


        [Required]
        public int PrisonerId  { get; set; }
        public Prisoner Prisoner { get; set; }
    }
}