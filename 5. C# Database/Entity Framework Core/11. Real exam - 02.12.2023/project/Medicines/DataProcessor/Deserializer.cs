namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Utilities;
    using Newtonsoft.Json.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder output = new();

            ImportPatientsDto[] patientDtos =
                JsonConverter.Deserialize<ImportPatientsDto[]>(jsonString);

            ICollection<Patient> valiadPatients = new List<Patient>();

            foreach (var patientDto in patientDtos)
            {
                if (!IsValid(patientDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Patient patient = new()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = patientDto.AgeGroup,
                    Gender = patientDto.Gender,
                };
                List<int> added = new();
                foreach (var med in patientDto.Medicines)
                {
                    if (added.Contains(med))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    PatientMedicine medicine = new()
                    {
                        MedicineId = med
                    };
                    patient.PatientsMedicines.Add(medicine);
                    added.Add(med);
                }
                valiadPatients.Add(patient);
                output.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));

            }
            context.Patients.AddRange(valiadPatients);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder output = new();

            ImportPharmacyDto[] pharmacyDtos =
                XmlConverter.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            ICollection<Pharmacy> validPharmacies = new List<Pharmacy>();

            foreach (var pharmacyDto in pharmacyDtos)
            {
                if (!IsValid(pharmacyDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                if (pharmacyDto.IsNonStop != "true" && pharmacyDto.IsNonStop != "false")
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Pharmacy pharmacy = new()
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = Convert.ToBoolean(pharmacyDto.IsNonStop),
                };
                ICollection<Medicine> validMedicines = new List<Medicine>();
                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (medicineDto.Producer == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    //if (medicineDto.ProductionDate == DateTime.ParseExact("0001/01/01", "yyyy-MM-dd", CultureInfo.InvariantCulture) 
                    //    || medicineDto.ExpiryDate == DateTime.ParseExact("0001/01/01", "yyyy-MM-dd", CultureInfo.InvariantCulture))
                    //{
                    //    output.AppendLine(ErrorMessage);
                    //    continue;
                    //}
                    if (DateTime.ParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture) >= DateTime.ParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture))//medicineDto.ProductionDate >= medicineDto.ExpiryDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (validMedicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    Medicine medicine = new()
                    {
                        Category = (Category)medicineDto.Category,
                        Name = medicineDto.Name,
                        Price = medicineDto.Price,
                        ProductionDate = DateTime.ParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Producer = medicineDto.Producer,
                    };

                    validMedicines.Add(medicine);
                }
                foreach (var medicine in validMedicines)
                {
                    pharmacy.Medicines.Add(medicine);
                }
                validPharmacies.Add(pharmacy);
                output.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));

            }
            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

    }
}
