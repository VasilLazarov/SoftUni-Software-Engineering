using System;

namespace _4._Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double evaluation = 0;
            double averagePerPresentation = 0;
            double averageForAll = 0;
            int count = 0;
            while (presentationName != "Finish")
            {
                count++;
                for (int i = 1; i <= n; i++)
                {
                    evaluation = double.Parse(Console.ReadLine());
                    averagePerPresentation += evaluation;
                }
                averagePerPresentation /= n;
                Console.WriteLine($"{presentationName} - {averagePerPresentation:f2}.");
                averageForAll += averagePerPresentation;
                averagePerPresentation = 0;
                presentationName = Console.ReadLine();
            }
            averageForAll /= count;
            Console.WriteLine($"Student's final assessment is {averageForAll:f2}.");

        }
    }
}
