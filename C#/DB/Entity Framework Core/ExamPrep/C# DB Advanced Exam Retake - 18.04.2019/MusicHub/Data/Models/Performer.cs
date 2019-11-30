
namespace MusicHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();
        
•	FirstName– text with min length 3 and max length 20 (required) 
•	LastName– text with min length 3 and max length 20 (required) 
•	Age – integer(in range between 18 and 70) (required)
•	NetWorth – decimal (non-negative, minimum value: 0) (required)
•	PerformerSongs - collection of type SongPerformer

    }
}
