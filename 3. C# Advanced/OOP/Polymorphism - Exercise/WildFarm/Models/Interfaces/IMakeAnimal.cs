using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces
{
    public interface IMakeAnimals
    {
        IAnimal MakeAnimal(string animalInfo);
    }
}
