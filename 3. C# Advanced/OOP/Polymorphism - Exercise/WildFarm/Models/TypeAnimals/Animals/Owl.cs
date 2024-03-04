using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.TypeAnimals.Animals
{
    public class Owl : Bird
    {
        private const double weightmultiplier = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier
            => weightmultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new HashSet<Type>() { typeof(Meat) };


        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
