
namespace PetClinic.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ExportProceduresDtos
    {
        [XmlElement("Passport")]
        public string Passport { get; set; }

        [XmlElement("OwnerNumber")]
        public string OwnerNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ExportAnimalAidsDto[] AnimalAids { get; set; }

        [XmlElement("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }

    [XmlType("AnimalAid")]
    public class ExportAnimalAidsDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
