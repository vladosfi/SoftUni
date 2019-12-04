
namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class ImportOfficersPrisonersDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisonerDto[] Prisoners { get; set; }
    }
}
