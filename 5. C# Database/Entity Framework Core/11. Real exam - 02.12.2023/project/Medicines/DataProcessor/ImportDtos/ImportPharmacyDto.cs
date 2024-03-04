using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Medicines.Utilities.GlobalConstants;


namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {

        [Required]
        [MaxLength(PharmacyNameMaxLength)]
        [MinLength(PharmacyNameMinLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [MinLength(PhoneNumberMinLength)]
        [RegularExpression(PhoneNumberRegex)]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; } = null!;

        [XmlArray("Medicines")]
        public ImportPharmacyMedicineDto[] Medicines { get; set; } = null!;


    }
}
