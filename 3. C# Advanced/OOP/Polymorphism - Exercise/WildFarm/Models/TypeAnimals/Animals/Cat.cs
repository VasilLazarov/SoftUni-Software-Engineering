using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.TypeAnimals.Animals
{
    public class Cat : Feline
    {
        private const double weightmultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        protected override double WeightMultiplier
            => weightmultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new HashSet<Type>() { typeof(Meat), typeof(Vegetable)};

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
