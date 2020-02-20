
namespace PetClinic.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Vet")]
    public class ImportVetsDto
    {
        [XmlElement("Name")]
        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("Profession")]
        [Required, MinLength(3), MaxLength(50)]
        public string Profession { get; set; }

        [XmlElement("Age")]
        [Required, Range(22, 65)]
        public int Age { get; set; }

        [XmlElement("PhoneNumber")]
        [RegularExpression(@"^(\+359[\d]{9})|(0[\d]{9})$")]
        public string PhoneNumber { get; set; }
    }
}
