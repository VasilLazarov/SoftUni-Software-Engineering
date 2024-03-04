using System;

namespace more_ex._4._Transport_Price
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string periodOfTheDay = Console.ReadLine();
            double taxiDay = kilometers * 0.79 + 0.70;
            double taxiNight = kilometers * 0.90 + 0.70;
            double busDayNight = kilometers * 0.09;
            double trainDayNight = kilometers * 0.06;
            if(kilometers < 20)
            {
                if(periodOfTheDay == "day")
                {
                    Console.WriteLine($"{taxiDay:f2}");
                }
                else if(periodOfTheDay == "night")
                {
                    Console.WriteLine($"{taxiNight:f2}");
                }
            }
            else if(kilometers >= 20 && kilometers < 100)
            {
                if (periodOfTheDay == "day")
                {
                    if (taxiDay < busDayNight)
                    {
                        Console.WriteLine($"{taxiDay:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"{busDayNight:f2}");
                    }
                }
                else if (periodOfTheDay == "night")
                {
                    if (taxiNight < busDayNight)
                    {
                        Console.WriteLine($"{taxiNight:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"{busDayNight:f2}");
                    }
                }
            }
            else if(kilometers >= 100)
            {
                if (periodOfTheDay == "day")
                {
                    if (taxiDay < busDayNight && taxiDay < trainDayNight)
                    {
                        Console.WriteLine($"{taxiDay:f2}");
                    }
                    else if(busDayNight<trainDayNight)
                    {
                        Console.WriteLine($"{busDayNight:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"{trainDayNight:f2}");
                    }
                }
                else if (periodOfTheDay == "night")
                {
                    if (taxiNight < busDayNight && taxiNight < trainDayNight)
                    {
                        Console.WriteLine($"{taxiNight:f2}");
                    }
                    else if(busDayNight < trainDayNight)
                    {
                        Console.WriteLine($"{busDayNight:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"{trainDayNight:f2}");
                    }
                }
            }
        }
    }
}
