using System;

namespace _7._Projects_Creation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectNumber = int.Parse(Console.ReadLine());
            int timeForAllProjects = projectNumber * 3;
            Console.WriteLine($"The architect {name} will need {timeForAllProjects} hours to complete {projectNumber} project/s.");
        }
    }
}
