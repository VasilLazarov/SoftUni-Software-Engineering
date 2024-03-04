using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] inputPersonInfo = Console.ReadLine()
                    .Split(", ");
              
                people.Add(new Person() { Name = inputPersonInfo[0], Age = int.Parse(inputPersonInfo[1]) });
            }
            string filterType = Console.ReadLine();
            int ageForFilter = int.Parse(Console.ReadLine());
            
            Func<Person, int, bool> filter = GetFilter(filterType);
            people = people.Where(p => filter(p, ageForFilter)).ToList();

            string outputFormat = Console.ReadLine();
            Action<Person> formatedPrint = OutputFormater(outputFormat);

            foreach (var person in people)
            {
                formatedPrint(person);
            }

        }

        static Func<Person, int, bool> GetFilter(string filterType)
        {
            if(filterType == "younger")
            {
                return (p, value) => p.Age < value;

            }

            return (p, value) => p.Age >= value;
            
        }
        static Action<Person> OutputFormater(string outputFormat)
        {
            switch (outputFormat)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
                case "name":
                    return p => Console.WriteLine(p.Name);
                case "age":
                    return p => Console.WriteLine(p.Age);
                default:
                    return null;
            }
        }
    }
    class Person
    {
        public string Name;
        public int Age;
    }
}
