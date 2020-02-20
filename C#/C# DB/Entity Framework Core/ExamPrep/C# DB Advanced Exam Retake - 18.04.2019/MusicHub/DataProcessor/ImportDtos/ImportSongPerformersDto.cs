
namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Performer")]
    public class ImportSongPerformersDto
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("NetWorth")]
        public int NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public PerformersSongsDto[] PerformersSongs { get; set; }

        //<Performer>
        //  <FirstName>Peter</FirstName>
        //  <LastName>Bree</LastName>
        //  <Age>25</Age>
        //  <NetWorth>3243</NetWorth>
        //  <PerformersSongs>
        //    <Song id = "2" />
        //    < Song id="1" />
        //  </PerformersSongs>
        //</Performer>

    }

    [XmlType("Song")]
    public class PerformersSongsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
