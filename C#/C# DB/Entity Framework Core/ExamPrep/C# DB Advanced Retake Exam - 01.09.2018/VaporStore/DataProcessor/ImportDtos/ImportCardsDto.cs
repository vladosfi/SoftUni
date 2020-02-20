
namespace VaporStore.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Data.Models.Enums;

    public class ImportCardsDto
    {
        [Required]
        [RegularExpression(@"^[\d]{4}[\s][\d]{4}[\s][\d]{4}[\s][\d]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{3}$")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
