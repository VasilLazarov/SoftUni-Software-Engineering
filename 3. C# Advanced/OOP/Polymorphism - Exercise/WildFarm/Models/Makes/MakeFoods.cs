using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;
using WildFarm.Models.TypeAnimals.Animals;

namespace WildFarm.Models.Makes
{
    public class MakeFoods : IMakeFood
    {
        public IFood MakeFood(string foodInfo)
        {
            string[] foodElements = foodInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = foodElements[0];
            int quantity = int.Parse(foodElements[1]);
            switch (type)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    throw new Exception("Invalid food type!");
            }
        }
    }
}
