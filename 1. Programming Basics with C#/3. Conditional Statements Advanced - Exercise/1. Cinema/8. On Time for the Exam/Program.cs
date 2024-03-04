using System;

namespace _8._On_Time_for_the_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examTimeHours = int.Parse(Console.ReadLine());
            int examTimeMinutes = int.Parse(Console.ReadLine());
            int arrivalTimeHours = int.Parse(Console.ReadLine());
            int arrivalTimeMinutes = int.Parse(Console.ReadLine());
            int difference = (examTimeHours * 60 + examTimeMinutes) - (arrivalTimeHours*60 + arrivalTimeMinutes);
            int hoursForPrint = 0;
            int minutesForPrint = 0;
            
            if(difference >= 0)
            {
                if(difference <= 30)
                {
                    Console.WriteLine("On time");
                }
                else
                {
                    Console.WriteLine("Early");;
                }

                if (difference < 60)
                {
                    minutesForPrint = difference;
                    Console.WriteLine($"{minutesForPrint} minutes before the start");
                }
                else
                {
                    hoursForPrint = difference / 60;
                    minutesForPrint = difference % 60;
                    Console.WriteLine($"{hoursForPrint}:{minutesForPrint:d2} hours before the start");
                }
                
            }
            else if(difference < 0)
            {
                difference = Math.Abs(difference);
                Console.WriteLine("Late");
                if (difference < 60)
                {
                    minutesForPrint = difference;
                    Console.WriteLine($"{minutesForPrint} minutes after the start");
                }
                else
                {
                    hoursForPrint = difference / 60;
                    minutesForPrint = difference % 60;
                    Console.WriteLine($"{hoursForPrint}:{minutesForPrint:d2} hours after the start");
                }
            }
        }
    }
}
