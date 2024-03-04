using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        private double currentBill;
        private double turnover;
        private bool isReserved;
        private readonly IRepository<IDelicacy> delicacyMenu;
        private readonly IRepository<ICocktail> cocktailMenu;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            currentBill = 0;
            turnover = 0;
            isReserved = false;
            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
        }

        public int BoothId { get; private set; }

        public int Capacity 
        {
            get { return capacity; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            } 
        }

        public IRepository<IDelicacy> DelicacyMenu 
            => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu 
            => cocktailMenu;

        public double CurrentBill 
        { 
            get { return currentBill; }
            private set
            {
                currentBill = value;
            }
        }

        public double Turnover
        {
            get { return turnover; }
            private set
            {
                turnover = value;
            }
        }

        public bool IsReserved
        {
            get { return isReserved; }
            private set
            {
                isReserved = value;
            }
        }

        public void ChangeStatus()
        {
            if(IsReserved == true)
            {
                IsReserved = false;
            }
            else
            {
                IsReserved = true;
            }
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Booth: {BoothId}");
            result.AppendLine($"Capacity: {Capacity}");
            result.AppendLine($"Turnover: {Turnover:f2} lv");
            result.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in CocktailMenu.Models)
            {
                result.AppendLine($"--{cocktail}");
            }
            result.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                result.AppendLine($"--{delicacy}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
