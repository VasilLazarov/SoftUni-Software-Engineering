using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.TypeAnimals.Animals
{
    public class Mouse : Mammal
    {
        private const double weightmultiplier = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier
            => weightmultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new HashSet<Type>() { typeof(Fruit), typeof(Vegetable) };


        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
