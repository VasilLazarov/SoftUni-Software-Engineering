using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double johnMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());
            int freeBelts = studentsCount / 6;
            double neededMoney = (studentsCount + Math.Ceiling(studentsCount * 0.10)) * priceOfLightsabers + studentsCount * priceOfRobes + (studentsCount - freeBelts) * priceOfBelts;
            if(johnMoney >= neededMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {neededMoney - johnMoney:f2}lv more.");
            }
        }
    }
}
