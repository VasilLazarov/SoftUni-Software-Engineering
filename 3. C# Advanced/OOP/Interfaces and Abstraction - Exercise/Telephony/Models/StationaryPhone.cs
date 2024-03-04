using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {

            if (!ValidatePhoneNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Dialing... {number}");
        }

        private bool ValidatePhoneNumber(string number)
        {
            if (number.All(c => char.IsDigit(c)))
            {
                return true;
            }
            return false;
        }
    }
}
