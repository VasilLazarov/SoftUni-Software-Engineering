using System;

namespace _6._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfActor = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double totalPoints = pointsFromAcademy;

            for(int x = 1; x <= n; x++)
            {
                string nameOfAssessor = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());
                totalPoints += nameOfAssessor.Length * points / 2;

                if(totalPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {totalPoints:f1}!");
                    return;
                }

            }
            Console.WriteLine($"Sorry, {nameOfActor} you need {1250.5 - totalPoints:f1} more!");
        }
    }
}
