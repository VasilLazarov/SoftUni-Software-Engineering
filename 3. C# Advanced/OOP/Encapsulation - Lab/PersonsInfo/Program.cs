using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine().Split();
                    Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            //decimal percentage = decimal.Parse(Console.ReadLine());
            //persons.ForEach(p => p.IncreaseSalary(percentage));
            ////persons.OrderBy(p => p.FirstName)
            ////       .ThenBy(p => p.Age)
            ////       .ToList()
            ////       .ForEach(p => Console.WriteLine(p.ToString()));
            //persons.ForEach(p => Console.WriteLine(p));
            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine(team);

        }
    }
}
