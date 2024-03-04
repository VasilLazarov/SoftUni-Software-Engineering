using System;

namespace _6._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int totalPieces = length * width;
            string input = Console.ReadLine();
            int cakePieces = 0;

            while (input != "STOP")
            {
                cakePieces = int.Parse(input);
                if (cakePieces <= totalPieces)
                {
                    totalPieces -= cakePieces;
                }
                else
                {
                    Console.WriteLine($"No more cake left! You need {cakePieces - totalPieces} pieces more.");
                    return;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{totalPieces} pieces are left.");
        }
    }
}
