
namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ImportPrisonerDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}