﻿
namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportMailDto
    {

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [RegularExpression(@"^[\dA-Za-z\s]+ str\.$")]
        public string Address { get; set; }
    }
}