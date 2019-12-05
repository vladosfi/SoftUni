﻿
namespace PetClinic.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Passport
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]{7}[\d]{3}$")]
        public string SerialNumber { get; set; }
        public Animal Animal { get; set; }

        [RegularExpression(@"^(\+359[\d]{9})|(0[\d]{9})$")]
        public string OwnerPhoneNumber { get; set; }

        [Required, MinLength(3), MaxLength(30)]
        public string OwnerName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}

