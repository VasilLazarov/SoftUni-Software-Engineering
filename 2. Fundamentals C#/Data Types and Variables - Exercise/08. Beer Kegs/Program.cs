using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string model = "";
            double radius = 0;
            uint height = 0;
            string theBiggestKeg = "";
            double volume = 0;
            double theBiggestVolume = 0;
            for (int i = 0; i < n; i++)
            {
                model = Console.ReadLine();
                radius = double.Parse(Console.ReadLine());
                height = uint.Parse(Console.ReadLine());
                volume = Math.PI * radius * radius * height;
                if(volume > theBiggestVolume)
                {
                    theBiggestVolume = volume;
                    theBiggestKeg = model;
                }
            }
            Console.WriteLine(theBiggestKeg);

        }
    }
}
