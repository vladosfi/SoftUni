
namespace VaporStore.DataProcessor.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserPurchasesByTypeDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public ExportPurchasesDto[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}
