﻿namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarsWithParts
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance{ get; set; }

        [XmlArray("parts")]
        public ExcportCarParts[] Parts { get; set; }



        //<cars>
        //  <car make = "Opel" model="Astra" travelled-distance="516628215">
        //    <parts>
        //      <part name = "Master cylinder" price="130.99" />
        //      <part name = "Water tank" price="100.99" />
        //      <part name = "Front Right Side Inner door handle" price="100.99" />
        //    </parts>
        //  </car>
        //  ...
        //</cars>

    }
}
