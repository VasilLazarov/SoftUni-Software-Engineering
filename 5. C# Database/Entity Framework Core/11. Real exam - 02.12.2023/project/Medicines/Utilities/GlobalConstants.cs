using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Utilities
{
    public static class GlobalConstants
    {
        //Pharmacy
        public const int PharmacyNameMaxLength = 50;
        public const int PharmacyNameMinLength = 2;

        public const string PhoneNumberRegex = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s]?\d{3}[-]?\d{4}$";
        //[RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s]?\d{3}[-]?\d{4}$")]
        public const int PhoneNumberMaxLength = 14; 
        public const int PhoneNumberMinLength = 14;


        //Medicine
        public const int MedicineNameMaxLength = 150;
        public const int MedicineNameMinLength = 3;

        public const decimal MedicinePriceMax = 1000.00m;
        public const decimal MedicinePriceMin = 0.01m;

        public const int ProducerNameMaxLength = 100;
        public const int ProducerNameMinLength = 3;


        //Patient
        public const int PatientNameMaxLength = 100;
        public const int PatientNameMinLength = 5;


    }
}
