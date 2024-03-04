using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Core.Interfaces;
using WildFarm.Models.Interfaces;
using WildFarm.Models.Makes;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IMakeAnimals makeAnimal;
        private readonly IMakeFood makeFood;
        private readonly ICollection<IAnimal> animals;
        public Engine()
        {
            makeAnimal = new MakeAnimals();
            makeFood = new MakeFoods();
            animals = new List<IAnimal>();
        }
        public void Run()
        {
            ReadInputCommands();
            PrintAnimals(animals);
        }
        private void ReadInputCommands()
        {
            IAnimal animal = null;
            string inputCommand = string.Empty;
            while ((inputCommand = Console.ReadLine()) != "End")
            {
                try
                {
                    animal = MakeCurrentAnimal(inputCommand);
                    Console.WriteLine(animal.ProduceSound());
                    IFood food = MakeCurrentFood();
                    animal.Eat(food);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    continue;
                }

                animals.Add(animal);
            }
        }


        private IAnimal MakeCurrentAnimal(string inputCommand)
        {
            return makeAnimal.MakeAnimal(inputCommand);
            
        }
        private IFood MakeCurrentFood()
        {
            string foodInfo = Console.ReadLine();
            return makeFood.MakeFood(foodInfo);
        }

        private void PrintAnimals(ICollection<IAnimal> animals)
        {
            foreach(IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
