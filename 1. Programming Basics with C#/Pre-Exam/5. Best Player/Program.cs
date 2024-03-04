using System;

namespace _5._Best_Player
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int goals = 0;
            string bestPlayer = "";
            int maxGoals = 0;
            bool headtrick = false;
            while(name != "END")
            {
                goals = int.Parse(Console.ReadLine());
                if (goals > maxGoals)
                {
                    bestPlayer = name;
                    maxGoals = goals;
                }
                if(goals >= 10)
                {
                    Console.WriteLine($"{bestPlayer} is the best player!");
                    Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
                    return;
                }
                else if(goals >= 3)
                {
                    headtrick= true;
                }
                
                name = Console.ReadLine();
                
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (headtrick)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
