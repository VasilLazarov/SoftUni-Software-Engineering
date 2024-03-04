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

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            BatteryLevel = BatteryCapacity;
            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
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

        public IReadOnlyCollection<int> InterfaceStandards 
            => interfaceStandards;

        public void Eating(int minutes)
        {
            int produsedEnergy = minutes * ConvertionCapacityIndex;
            BatteryLevel += produsedEnergy;
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
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");

            sb.Append($"--Supplements installed:");
            if (interfaceStandards.Count == 0)
            {
                sb.Append(" none");
            }
            else
            {
                for (int i = 0; i < interfaceStandards.Count; i++)
                {
                    sb.Append($" {interfaceStandards[i]}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
