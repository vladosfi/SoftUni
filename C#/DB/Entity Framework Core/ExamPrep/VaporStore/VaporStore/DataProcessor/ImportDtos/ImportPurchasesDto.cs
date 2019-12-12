
namespace VaporStore.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ImportPurchasesDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"^[A-Z\d]+-[A-Z\d]+-[A-Z\d]+$")]
        public string ProductKey { get; set; }

        [XmlElement("Card")]
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
