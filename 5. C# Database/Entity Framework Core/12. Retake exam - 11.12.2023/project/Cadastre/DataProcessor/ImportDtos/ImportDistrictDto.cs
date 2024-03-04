﻿using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {

        [Required]
        [MaxLength(80)]
        [MinLength(2)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        [RegularExpression(@"\b[A-Z]{2}[-]\d{5}\b")]
        [XmlElement("PostalCode")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [XmlAttribute("Region")]
        public string Region { get; set; } = null!;

        [XmlArray("Properties")]
        public ImportDistrictPropertyDto[] Properties { get; set; } = null!;

    }
}
