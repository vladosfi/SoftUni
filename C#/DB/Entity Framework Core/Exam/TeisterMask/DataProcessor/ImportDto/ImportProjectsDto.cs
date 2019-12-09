﻿
namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ImportProjectsDto
    {

        [Required, MinLength(2), MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }


        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTaskDto[] Tasks { get; set; }
     

    }
}
