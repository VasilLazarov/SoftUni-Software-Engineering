using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private readonly List<int> interfaceStandards;

        public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            interfaceStandards = new List<int>();
            BatteryLevel = BatteryCapacity;
        }

        public string Model 
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get
            {
                return batteryCapacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel 
        {
            get { return batteryLevel; }
            private set { batteryLevel = value; }
        }

        public int ConvertionCapacityIndex
        {
            get { return convertionCapacityIndex; }
            private set { convertionCapacityIndex = value; }
        }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards;

        public void Eating(int minutes)
        {
            int chargingBattery = ConvertionCapacityIndex * minutes;
            BatteryLevel += chargingBattery;
            if(BatteryLevel > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if(BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            int interfaceStandartOfCurrentSupplement = supplement.InterfaceStandard;
            interfaceStandards.Add(interfaceStandartOfCurrentSupplement);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{this.GetType().Name} {Model}:");
            output.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            output.AppendLine($"--Current battery level: {BatteryLevel}");
            if(interfaceStandards.Count == 0)
            {
                output.AppendLine($"--Supplements installed: none");
            }
            else
            {
                output.AppendLine($"--Supplements installed: {string.Join(" ", InterfaceStandards)}");
            }
            
            return output.ToString().TrimEnd();
        }
    }
}
