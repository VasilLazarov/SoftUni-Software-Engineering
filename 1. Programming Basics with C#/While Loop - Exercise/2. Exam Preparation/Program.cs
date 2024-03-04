using System;

namespace _2._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfBad = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            int evaluation = 0;
            int count = 0;
            int sum = 0;
            int numOfProblems = 0;
            string lastProblem = "";
            while (name != "Enough")
            {
                evaluation = int.Parse(Console.ReadLine());
                if(evaluation <= 4)
                {
                    count++;
                    
                }
                
                if(count == numOfBad)
                {
                    Console.WriteLine($"You need a break, {count} poor grades.");
                    return;
                }
                sum += evaluation;
                numOfProblems++;
                lastProblem = name;
                name = Console.ReadLine();
            }
            double average = (double)sum / numOfProblems;
            Console.WriteLine($"Average score: {average:f2}");
            Console.WriteLine($"Number of problems: {numOfProblems}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
