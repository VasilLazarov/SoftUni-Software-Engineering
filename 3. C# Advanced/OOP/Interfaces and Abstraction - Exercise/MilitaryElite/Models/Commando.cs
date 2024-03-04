using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }


        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine(base.ToString());
            print.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                print.AppendLine($"  {mission.ToString()}");
            }
            return print.ToString().TrimEnd();
        }
    }
}
