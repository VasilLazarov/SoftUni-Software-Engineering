using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int interfaceStandard = 10045;
        private const int batteryUsage = 10000;
        public SpecializedArm()
            : base(interfaceStandard, batteryUsage)
        {
        }
    }
}
