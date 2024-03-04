using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.TypeAnimals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }

        protected abstract IReadOnlyCollection<Type> PrefferedFoods { get; }
        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if(!PrefferedFoods.Any(f => f.Name == food.GetType().Name))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightMultiplier;
        }

    }
}
