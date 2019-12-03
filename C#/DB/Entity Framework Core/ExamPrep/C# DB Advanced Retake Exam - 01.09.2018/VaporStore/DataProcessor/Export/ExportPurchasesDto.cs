
namespace VaporStore.DataProcessor.Export
{
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ExportPurchasesDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        public ExportGameDto Game { get; set; }
    }
}