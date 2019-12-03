
namespace Cinema.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ExportTopCustomersDto
    {
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string LastName { get; set; }

        [XmlElement("SpentMoney")]
        public string SpentMoney { get; set; }

        [XmlElement("SpentTime")]
        public string SpentTime { get; set; }
    }
}

//  <Customer FirstName = "Marjy" LastName="Starbeck">
//    <SpentMoney>82.65</SpentMoney>
//    <SpentTime>17:04:00</SpentTime>
//  </Customer>
//  <Customer FirstName = "Jerrie" LastName="O\'Carroll">
//    <SpentMoney>67.13</SpentMoney>
//    <SpentTime>13:40:00</SpentTime>
//  </Customer>
//  <Customer FirstName = "Randi" LastName="Ferraraccio">
//    <SpentMoney>63.39</SpentMoney>
//    <SpentTime>17:42:00</SpentTime>
//  </Customer>...
//</Customers>

