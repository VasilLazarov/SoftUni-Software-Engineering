namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder result = new();

            ImportDistrictDto[] districtDtos =
                XmlConverter.Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            ICollection<District> validDistricts = new List<District>();

            ICollection<Property> addedProperties = new List<Property>();

            foreach (var districtDto in districtDtos)
            {
                if (!IsValid(districtDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                if(!Enum.TryParse(districtDto.Region, out Region regionResult))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                if(validDistricts.Any(d => d.Name == districtDto.Name))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                // try to make regex with if checks
                //idk if it is necessary
                //string postCodeStart = districtDto.PostalCode.Substring(0, 2);
                //string postCodeMidChar = districtDto.PostalCode.Substring(2, 1);
                //string postCodeEnd = districtDto.PostalCode.Substring(3);
                //if (postCodeStart != postCodeStart.ToUpper())
                //{
                //    result.AppendLine(ErrorMessage);
                //    continue;
                //}
                //if (postCodeMidChar != "-")
                //{
                //    result.AppendLine(ErrorMessage);
                //    continue;
                //}
                //if (!int.TryParse(postCodeEnd, out int resInt))
                //{
                //    result.AppendLine(ErrorMessage);
                //    continue;
                //}
                //
                District newDistrict = new()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = regionResult
                };
                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (DateTime.ParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture) == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (addedProperties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (addedProperties.Any(p => p.Address == propertyDto.Address))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    Property newProperty = new()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = DateTime.ParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    };
                    addedProperties.Add(newProperty);
                    newDistrict.Properties.Add(newProperty);
                }
                validDistricts.Add(newDistrict);
                result.AppendLine(string.Format(SuccessfullyImportedDistrict, newDistrict.Name, newDistrict.Properties.Count));

            }
            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder result = new();

            ImportCitizenDto[] citizenDtos = 
                JsonConverter.Deserialize<ImportCitizenDto[]>(jsonDocument);

            ICollection<Citizen> validCitizens = new List<Citizen>();

            foreach (var citizenDto in citizenDtos)
            {
                if (!IsValid(citizenDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.TryParse(citizenDto.MaritalStatus, out MaritalStatus maritalStatusResult))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime currentDate = DateTime.ParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                if (currentDate == DateTime.ParseExact("01-01-0001", "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                Citizen newCitizen = new()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = currentDate,
                    MaritalStatus = maritalStatusResult
                };
                foreach (var propID in citizenDto.Properties)
                {
                    PropertyCitizen newPropCitizen = new()
                    {
                        PropertyId = propID,
                    };
                    newCitizen.PropertiesCitizens.Add(newPropCitizen);
                }
                validCitizens.Add(newCitizen);
                result.AppendLine(string.Format(SuccessfullyImportedCitizen, newCitizen.FirstName, newCitizen.LastName, newCitizen.PropertiesCitizens.Count));

            }
            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
