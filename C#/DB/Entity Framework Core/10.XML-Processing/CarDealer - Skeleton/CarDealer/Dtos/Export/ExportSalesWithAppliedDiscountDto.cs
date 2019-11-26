
namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSalesWithAppliedDiscountDto
    {
        [XmlElement("car")]
        public ExportCarsWithDistanceAttributeDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }

        //<sale>
        //  <car make = "BMW" model="M5 F10" travelled-distance="435603343" />
        //  <discount>30.00</discount>
        //  <customer-name>Hipolito Lamoreaux</customer-name>
        //  <price>707.97</price>
        //  <price-with-discount>495.58</price-with-discount>
        //</sale>

    }

    public class ExportCarsWithDistanceAttributeDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        //    <car>
        //<make>BMW</make>
        //<model>1M Coupe</model>
        //<travelled-distance>39826890</travelled-distance>
    }
}
