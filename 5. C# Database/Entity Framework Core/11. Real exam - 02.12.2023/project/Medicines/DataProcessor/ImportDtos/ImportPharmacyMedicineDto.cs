using Medicines.Data.Models.Enums;
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
    [XmlType("Medicine")]
    public class ImportPharmacyMedicineDto
    {
        [Required]
        [MaxLength(MedicineNameMaxLength)]
        [MinLength(MedicineNameMinLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range((double)MedicinePriceMin, (double)MedicinePriceMax)]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlAttribute("category")]
        public int Category { get; set; }

        [Required]
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; }

        [Required]
        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; }

        [Required]
        [MaxLength(ProducerNameMaxLength)]
        [MinLength(ProducerNameMinLength)]
        [XmlElement("Producer")]
        public string Producer { get; set; } = null!;
    }
}
