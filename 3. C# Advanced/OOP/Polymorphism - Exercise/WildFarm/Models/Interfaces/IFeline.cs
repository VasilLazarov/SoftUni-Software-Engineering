using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces
{
    public interface IFeline : IMammal
    {
        string Breed { get; }
    }
}
