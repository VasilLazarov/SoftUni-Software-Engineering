using System;

namespace _6._World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());
            double delays = Math.Floor(meters / 15);
            double recordByIvan = meters * timePerMeter + delays * 12.5;
            if(recordByIvan < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {recordByIvan:f2} seconds.");

            }
            else
            {
                Console.WriteLine($"No, he failed! He was {recordByIvan - record:f2} seconds slower.");
            }
        }
    }
}
