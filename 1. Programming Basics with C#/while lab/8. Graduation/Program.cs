using System;

namespace _8._Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double evaluation = 0;
            int grade = 1;
            int count = 0;
            double averageEvaluation = 0;
            while(grade <= 12)
            {
                evaluation = double.Parse(Console.ReadLine());
                if(evaluation < 4)
                {
                    count++;
                }
                if(count > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {grade - 1} grade");
                    return;
                }
                averageEvaluation += evaluation;
                grade++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {averageEvaluation/12:f2}");
        }
    }
}
