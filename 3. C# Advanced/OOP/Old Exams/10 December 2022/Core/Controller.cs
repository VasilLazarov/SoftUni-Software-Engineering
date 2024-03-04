using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if(cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if(size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            if(booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            ICocktail cocktail;
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else //if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            //else
            //{
            //    return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            //}
            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            //if (booths.Models.Any(b => b.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            //{
            //    return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            //}
            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if(delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            if(booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format(OutputMessages.GetBill, $"{booth.CurrentBill:f2}"));
            result.AppendLine(string.Format(OutputMessages.BoothIsAvailable, booth.BoothId));

            booth.Charge();
            booth.ChangeStatus();

            return result.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();
            if(booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople); ;
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            string[] orderElements = order
                .Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderElements[0];
            string itemName = orderElements[1];
            int countOfOrderedPieces = int.Parse(orderElements[2]);
            if(itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
            if(itemTypeName == nameof(Gingerbread)
                || itemTypeName == nameof(Stolen))
            {
                if(!booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(c => c.Name == itemName && c.GetType().Name == itemTypeName);
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                double amount = countOfOrderedPieces * delicacy.Price;
                booth.UpdateCurrentBill(amount);
            }
            else
            {
                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                string size = orderElements[3];
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size && c.GetType().Name == itemTypeName);
                if(cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }
                double amount = countOfOrderedPieces * cocktail.Price;
                booth.UpdateCurrentBill(amount);
            }
            return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
        }
    }
}
