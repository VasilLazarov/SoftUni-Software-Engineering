using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double cocktailPrice = 13.50;
        public MulledWine(string cocktailName, string cocktailSize) 
            : base(cocktailName, cocktailSize, cocktailPrice)
        {
        }
    }
}
