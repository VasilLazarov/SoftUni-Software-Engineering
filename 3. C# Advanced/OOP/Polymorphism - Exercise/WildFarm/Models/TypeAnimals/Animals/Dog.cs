using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.TypeAnimals.Animals
{
    public class Dog : Mammal
    {
        private const double weightmultiplier = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        protected override double WeightMultiplier
            => weightmultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new HashSet<Type>() { typeof(Meat) };


        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
