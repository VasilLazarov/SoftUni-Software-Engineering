using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;
using WildFarm.Models.TypeAnimals.Animals;

namespace WildFarm.Models.Makes
{
    public class MakeAnimals : IMakeAnimals
    {
        public IAnimal MakeAnimal(string animalInfo)
        {
            string[] animalElements = animalInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = animalElements[0];
            string name = animalElements[1];
            double weight = double.Parse(animalElements[2]);
            switch (type)
            {
                case "Cat":
                    string catLivingRegion = animalElements[3];
                    string catBreed = animalElements[4];
                    return new Cat(name, weight, catLivingRegion, catBreed);
                case "Tiger":
                    string tigerLivingRegion = animalElements[3];
                    string tigerBreed = animalElements[4];
                    return new Tiger(name, weight, tigerLivingRegion, tigerBreed);
                case "Dog":
                    string dogLivingRegion = animalElements[3];
                    return new Dog(name, weight, dogLivingRegion);
                case "Mouse":
                    string mouseLivingRegion = animalElements[3];
                    return new Mouse(name, weight, mouseLivingRegion);
                case "Hen":
                    double henWingSize = double.Parse(animalElements[3]);
                    return new Hen(name, weight, henWingSize);
                case "Owl":
                    double owlWingSize = double.Parse(animalElements[3]);
                    return new Owl(name, weight, owlWingSize);
                    default:
                    throw new Exception("Invalid animal type!");
            }
        }
    }
}
