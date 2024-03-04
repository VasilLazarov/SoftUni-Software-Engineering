using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicines.Utilities.GlobalConstants;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientsDto
    {

        [Required]
        [MaxLength(PatientNameMaxLength)]
        [MinLength(PatientNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [Range(0, 2)]
        public AgeGroup AgeGroup { get; set; }

        [Required]
        [Range(0, 1)]
        public Gender Gender { get; set; }

        public int[] Medicines { get; set; } = null!;

    }
}
