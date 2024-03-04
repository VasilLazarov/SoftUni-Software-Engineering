using System;

namespace more_ex._9._Weather_Forecast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            if (a.Contains("sunny") == true)
            {
                Console.WriteLine("It's warm outside!");
            }
            else
            {
                Console.WriteLine("It's cold outside!");
            }
        }
    }
}
