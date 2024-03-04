namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder result = new();

            ImportCreatorDto[] creatorDtos =
                XmlConverter.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            ICollection<Creator> validCreators = new List<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Creator newCreator = new()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName
                };
                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    Boardgame newBoardgame = new()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics,
                    };
                    newCreator.Boardgames.Add(newBoardgame);
                }
                validCreators.Add(newCreator);
                result.AppendLine(string.Format(SuccessfullyImportedCreator, newCreator.FirstName, newCreator.LastName, newCreator.Boardgames.Count));
            }
            context.Creators.AddRange(validCreators);
            context.SaveChanges();


            return result.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder result = new();

            ImportSellerDto[] sellerDtos = 
                JsonConverter.Deserialize<ImportSellerDto[]>(jsonString);

            ICollection<Seller> validSellers = new List<Seller>();

            int[] existingIds = context.Boardgames.Select(x => x.Id).ToArray();

            foreach (var sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                string sellerDtoWebsite = sellerDto.Website;
                if(!(sellerDtoWebsite.Substring(0, 4) == "www.") || !(sellerDtoWebsite.Substring(sellerDtoWebsite.Length - 4) == ".com"))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                string websiteName = sellerDtoWebsite.Substring(4, sellerDtoWebsite.Length - 8);
                char[] chars = websiteName.ToCharArray();
                bool invalidWebsite = false;
                foreach (var item in chars)
                {
                    if (!Char.IsLetterOrDigit(item) && item != '-')
                    {
                        invalidWebsite = true;
                        break;
                    }
                }
                if (invalidWebsite)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                Seller newSeller = new()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };

                foreach (var bgId in sellerDto.Boardgames.Distinct())
                {
                    if (!existingIds.Contains(bgId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    BoardgameSeller boardgameSeller = new()
                    {
                        BoardgameId = bgId
                    };
                    newSeller.BoardgamesSellers.Add(boardgameSeller);
                }
                validSellers.Add(newSeller);
                result.AppendLine(string.Format(SuccessfullyImportedSeller, newSeller.Name, newSeller.BoardgamesSellers.Count));
            }
            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

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
