using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {

        public Engine()
        {
            
        }
        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputElements = input
                    .Split(" ");
                string name = inputElements[0];
                string country = inputElements[1];
                int age = int.Parse(inputElements[2]);
                Citizen citizen = new Citizen(name, country, age);
                IResident resident = citizen;
                IPerson person = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            
            }
        }
    }
}
