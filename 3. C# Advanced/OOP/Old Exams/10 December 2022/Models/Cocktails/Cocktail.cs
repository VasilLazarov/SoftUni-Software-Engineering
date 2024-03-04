using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public Cocktail(string cocktailName, string cocktailSize, double cocktailPrice)
        {
            Name = cocktailName;
            Size = cocktailSize;
            Price = cocktailPrice;
        }

        public string Name 
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size 
        { 
            get { return size; }
            private set { size = value; }
        }

        public double Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (this.Size == "Small")
                {
                    price = value / 3.0;
                }
                else if (this.Size == "Middle")
                {
                    price = (value * 2) / 3.0;
                }
                else if (this.Size == "Large")
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
