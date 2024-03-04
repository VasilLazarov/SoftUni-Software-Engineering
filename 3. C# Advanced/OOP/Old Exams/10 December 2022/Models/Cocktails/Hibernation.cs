using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double cocktailPrice = 10.50;
        public Hibernation(string cocktailName, string cocktailSize)
            : base(cocktailName, cocktailSize, cocktailPrice)
        {
        }
    }
}
