
namespace ProductShop.Dtos.Export
{
    
    using System.Xml.Serialization;

    public class ExportCustomProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUsersAndProductsDto[] ExportUsersAndProductsDto { get; set; }
    }
}
