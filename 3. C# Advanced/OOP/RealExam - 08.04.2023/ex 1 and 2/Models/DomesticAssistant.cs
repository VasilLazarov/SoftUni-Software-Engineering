using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        public const int batteryCapacity = 20000;
        public const int convertionCapacityIndex = 2000;
        public DomesticAssistant(string model) 
            : base(model, batteryCapacity, convertionCapacityIndex)
        {
        }
    }
}
