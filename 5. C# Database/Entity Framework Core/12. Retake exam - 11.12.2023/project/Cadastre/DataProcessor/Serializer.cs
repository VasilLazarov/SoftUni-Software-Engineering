using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            DateTime givenDate;

            if (!DateTime.TryParse("01/01/2000", out givenDate))
            {
                throw new ArgumentException("Invalid date format!");

            }

            var properties = dbContext.Properties
                .Include(p => p.PropertiesCitizens)
                .ThenInclude(pc => pc.Citizen)
                .Where(p => p.DateOfAcquisition >= givenDate)
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new ExportPropertyDto()
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd'/'MM'/'yyyy"),
                    Owners = p.PropertiesCitizens
                        .OrderBy(pc => pc.Citizen.LastName)
                        .Select(pc => new ExportPropertyOwnerDto()
                        {
                            LastName = pc.Citizen.LastName,
                            MaritalStatus = pc.Citizen.MaritalStatus.ToString(),
                        })
                        .ToArray()
                })
                .ToArray();

            string result =
                JsonConverter.Serialize(properties, true);

            return result;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Include(p => p.District)
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyXmlDto()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd'/'MM'/'yyyy")
                })
                .ToArray();


            string result = XmlConverter.Serialize(properties, "Properties");

            return result;
        }
    }
}
