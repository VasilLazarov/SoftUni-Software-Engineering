using Medicines.Data.Models.Enums;
using Medicines.Data.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Utilities;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime givenDate;

            if (!DateTime.TryParse(date, out givenDate))
            {
                throw new ArgumentException("Invalid date format!");

            }

            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(m => m.Medicine.ProductionDate >= givenDate))
                .Select(p => new ExportPatientDto()
                {
                    FullName = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                            .Where(pm => pm.Medicine.ProductionDate >= givenDate)
                            .OrderByDescending(m => m.Medicine.ExpiryDate)
                            .ThenBy(m => m.Medicine.Price)
                            .Select(m => new ExportPatientMedicineDto()
                            {
                                Name = m.Medicine.Name,
                                Price = m.Medicine.Price.ToString("F2"),
                                Producer = m.Medicine.Producer,
                                ExpiryDate = m.Medicine.ExpiryDate.ToString("yyyy-MM-dd"),
                                Category = m.Medicine.Category.ToString().ToLower(),
                            })
                            .ToArray(),
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.FullName)
                .ToArray();

            string result =
                XmlConverter.Serialize(patients, "Patients");

            return result;
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Include(m => m.Pharmacy)
                .Where(m => (int)m.Category == medicineCategory
                            && m.Pharmacy.IsNonStop == true)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new ExportMedicineDto()
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new ExportMedicinePharmacyDto()
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    },
                })
                .ToArray();

            string result =
                JsonConverter.Serialize(medicines, true);


            return result;
        }
    }
}


//<Medicine Category="sedative">
//        <Name>Cetirizine</Name>
//        <Price>11.00</Price>
//        <Producer>ReliefMed Labs</Producer>
//        <BestBefore>2023-10-15T00:00:00</BestBefore>
//      </Medicine>