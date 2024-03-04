using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }

        void CompleteMission();
    }
}
