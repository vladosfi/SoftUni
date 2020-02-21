
namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ExportPrisonersByCellsDto
    {

        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportEncryptedMessagesDto[] EncryptedMessages { get; set; }

        //<Prisoner>
        //  <Id>3</Id>
        //  <Name>Binni Cornhill</Name>
        //  <IncarcerationDate>1967-04-29</IncarcerationDate>
        //  <EncryptedMessages>
        //    <Message>
        //      <Description>!?sdnasuoht evif-ytnewt rof deksa uoy ro orez artxe na ereht sI</Description>
        //    </Message>
        //  </EncryptedMessages>
        //</Prisoner>

    }
}
