namespace MusicHub.Data.Models
{
    using MusicHub.Data.Models.Enums;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimestampAttribute Duration { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        [Required]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        [Required]
        [Range(typeof(Decimal), "0.0", "79228162514264337593543950335"]
        public decimal Price { get; set; }

        public ICollection<SongPerformers> SongPerformers { get; set; } = new HashSet<SongPerformers>();
    }
}
