using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportMedicinePharmacyDto
    {

        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

    }
}
