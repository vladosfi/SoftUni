namespace PetClinic.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ImportProceduresDto
    {
        [XmlElement("Vet")]
        [Required]
        public string Vet { get; set; }

        [XmlElement("Animal")]
        [Required]
        public string Animal { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidsDto[] AnimalAids { get; set; }
    }

    [XmlType("AnimalAid")]
    public class AnimalAidsDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }
    }
}
