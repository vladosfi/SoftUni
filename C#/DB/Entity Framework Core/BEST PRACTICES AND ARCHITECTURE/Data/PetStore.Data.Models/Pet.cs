namespace PetStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using PetStore.Data.Models.Enums;

    using static DataValidation;

    public class Pet
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Price { get; set; }

        [MaxLength(NameMaxLenght)]
        public string Description { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
