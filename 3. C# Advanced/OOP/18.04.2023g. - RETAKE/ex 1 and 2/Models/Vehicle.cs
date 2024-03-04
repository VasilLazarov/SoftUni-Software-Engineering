using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage
        {
            get { return maxMileage; }
            private set
            {
                maxMileage = value;
            }
        }

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set
            {
                batteryLevel = value;
            }
        }

        public bool IsDamaged
        {
            get { return isDamaged; }
            private set
            {
                isDamaged = value;
            }
        }

        public void ChangeStatus()
        {
            if(IsDamaged == false)
            {
                IsDamaged = true;
            }
            else
            {
                IsDamaged = false;
            }

        }

        public void Drive(double mileage)
        {
            int usedPercentage = (int)Math.Round((mileage / MaxMileage) * 100);
            if (this.GetType().Name == nameof(CargoVan))
            {
                usedPercentage += 5;
            }
            BatteryLevel -= usedPercentage;
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public override string ToString()
        {
            if(IsDamaged == true)
            {
                return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: damaged";
            }
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: OK";
        }
    }
}
