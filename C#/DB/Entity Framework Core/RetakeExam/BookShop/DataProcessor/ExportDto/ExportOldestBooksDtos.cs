﻿using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class ExportOldestBooksDtos
    {
            [XmlAttribute("Pages")]
            public string Pages { get; set; }

            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("Date")]
            public string Date { get; set; }
        }
    }
