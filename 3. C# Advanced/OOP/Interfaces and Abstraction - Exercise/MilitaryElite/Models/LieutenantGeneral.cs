using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();

            print.AppendLine(base.ToString());
            print.AppendLine("Privates:");

            foreach (var currentPrivate in Privates)
            {
                print.AppendLine($"  {currentPrivate.ToString()}");
            }
            return print.ToString().TrimEnd();
        }
    }
}
