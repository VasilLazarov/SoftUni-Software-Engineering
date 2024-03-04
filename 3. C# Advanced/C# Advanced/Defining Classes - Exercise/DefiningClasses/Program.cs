using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeoples = int.Parse(Console.ReadLine());

            Family family1 = new Family();
            for (int i = 0; i < numberOfPeoples; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                family1.AddMember(person);
            }

            //for ex3
            //if(family1.People.Count == 0)
            //{
            //    Person oldestMember = null;
            //
            //    Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
            //}
            //else
            //{
            //    Person oldestMember = family1.GetOldestMember();
            //
            //   Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
            //}
            Person oldestMember = family1.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");




            //for ex4
            //foreach (Person person in family1.People.OrderBy(v => v.Name).Where(v => v.Age > 30))
            //{
            //    Console.WriteLine($"{person.Name} - {person.Age}");
            //}
        }
    }
}
