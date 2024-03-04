using System;
using System.Linq;

namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());
            int[] currentStateOfTheLift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < currentStateOfTheLift.Length; i++)
            {
                if (currentStateOfTheLift[i] < 4)
                {
                    peoples--;
                    currentStateOfTheLift[i]++;
                    i--;
                }
                if(peoples == 0)
                {
                    break;
                }
            }

            if(peoples == 0 && currentStateOfTheLift.Any(x => x < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(" ", currentStateOfTheLift));
            }
            else if (peoples == 0 && currentStateOfTheLift.All(x => x == 4))
            {
                Console.WriteLine(String.Join(" ", currentStateOfTheLift));
            }
            else if(peoples != 0)
            {
                Console.WriteLine($"There isn't enough space! {peoples} people in a queue!");
                Console.WriteLine(String.Join(" ", currentStateOfTheLift));
            }

        }
    }
}
