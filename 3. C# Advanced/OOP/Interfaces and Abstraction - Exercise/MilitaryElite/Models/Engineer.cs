
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine(base.ToString());
            print.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                print.AppendLine($"  {repair.ToString()}");
            }
            return print.ToString().TrimEnd();
        }
    }
}
