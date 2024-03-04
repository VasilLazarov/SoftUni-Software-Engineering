using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        public int InterfaceStandard { get; private set; }

        public int BatteryUsage { get; private set; }

        public Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }
    }
}
