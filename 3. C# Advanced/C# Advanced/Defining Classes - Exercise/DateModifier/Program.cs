using System;

namespace Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            int differenceInDays = DateModifier.GetDifferenceInDays(startDate, endDate);

            Console.WriteLine(differenceInDays);
        }
    }
}
