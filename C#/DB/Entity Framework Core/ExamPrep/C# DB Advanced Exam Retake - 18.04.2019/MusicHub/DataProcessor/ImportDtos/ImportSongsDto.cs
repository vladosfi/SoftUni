
namespace MusicHub.DataProcessor.ImportDtos
{
    using MusicHub.Data.Models.Enums;
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongsDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Duration")]
        public string Duration { get; set; }

        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("AlbumId")]
        public int? AlbumId { get; set; }

        [XmlElement("WriterId")]
        public int WriterId { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        //<Song>
        //  <Name>What Goes Around</Name>
        //  <Duration>00:03:23</Duration>
        //  <CreatedOn>21/12/2018</CreatedOn>
        //  <Genre>Blues</Genre>
        //  <AlbumId>2</AlbumId>
        //  <WriterId>2</WriterId>
        //  <Price>12</Price>
        //</Song>

    }
}
