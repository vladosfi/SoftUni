
namespace BookShop.Data.Models
{
    using BookShop.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        //•	Price - decimal in range between 0.01 and max value of the decimal
        //[Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(50,5000)]
        public int Pages { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }
        

        public ICollection<AuthorBook> AuthorsBooks { get; set; } = new HashSet<AuthorBook>();

    }
}
