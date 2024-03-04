using System;

namespace _9._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            int volume = length * width * height;
            double volumeForFillingInCM = volume - (volume * (percentage/100.0));
            double neededLitersOfWater = volumeForFillingInCM / 1000;
            Console.WriteLine(neededLitersOfWater);
        }
    }
}
