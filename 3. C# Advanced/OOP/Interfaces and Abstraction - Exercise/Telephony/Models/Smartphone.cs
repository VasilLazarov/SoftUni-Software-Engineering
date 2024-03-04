using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : IBrowsable, ICallable
    {



        public void Call(string number)
        {
            if (!ValidatePhoneNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Calling... {number}");
        }
        private bool ValidatePhoneNumber(string number)
        {
            if (number.All(c => char.IsDigit(c)))
            {
                return true;
            }
            return false;
        }
        public void Browse(string website)
        {
            if (!ValidateUrl(website))
            {
                throw new ArgumentException("Invalid URL!");
            }
            Console.WriteLine($"Browsing: {website}!");
        }

        private bool ValidateUrl(string website)
        {
            if (website.All(c => !char.IsDigit(c)))
            {
                return true;
            }
            return false;
        }
    }
}
