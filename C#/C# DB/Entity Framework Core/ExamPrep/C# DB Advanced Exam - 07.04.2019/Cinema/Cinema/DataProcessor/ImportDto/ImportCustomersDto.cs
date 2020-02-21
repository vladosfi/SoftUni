
namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomersDto
    {
        [Required]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Required]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [XmlElement("Balance")]
        public decimal Balance { get; set; }

        [Required]
        [XmlArray("Tickets")]
        public ImportTicketsDto[] Tickets { get; set; }

    }
}