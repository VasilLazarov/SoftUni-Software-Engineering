using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.TypeAnimals.Animals
{
    public class Hen : Bird
    {

        private const double weightmultiplier = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier
            => weightmultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new HashSet<Type>() { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) };


        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
