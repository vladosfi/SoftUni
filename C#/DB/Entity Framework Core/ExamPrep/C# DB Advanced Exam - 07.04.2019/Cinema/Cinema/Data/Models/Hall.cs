﻿

namespace Cinema.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hall
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public bool Is4Dx { get; set; }

        [Required]
        public bool Is3D { get; set; }
        
        public ICollection<Projection> Projections { get; set; } = new HashSet<Projection>();

        public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
    }
}
