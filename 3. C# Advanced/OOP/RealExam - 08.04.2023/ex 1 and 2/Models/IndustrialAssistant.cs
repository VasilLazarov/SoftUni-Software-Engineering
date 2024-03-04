using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        public const int batteryCapacity = 40000;
        public const int convertionCapacityIndex = 5000;
        public IndustrialAssistant(string model)
            : base(model, batteryCapacity, convertionCapacityIndex)
        {
        }
    }
}
