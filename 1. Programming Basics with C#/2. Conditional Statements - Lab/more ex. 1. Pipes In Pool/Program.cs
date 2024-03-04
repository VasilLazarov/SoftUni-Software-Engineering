using System;

namespace more_ex._1._Pipes_In_Pool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pipe1LitersPerHour = int.Parse(Console.ReadLine());
            int pipe2LitersPerHour = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());
            double litersForALlTime = (pipe1LitersPerHour + pipe2LitersPerHour) * hours;
            if (litersForALlTime <= volume)
            {
                double percentageOfVolume = (litersForALlTime / volume)*100;
                double persentageForPipe1 = ((pipe1LitersPerHour * hours) / litersForALlTime) * 100;
                double persentageForPipe2 = ((pipe2LitersPerHour * hours) / litersForALlTime) * 100;
                Console.WriteLine($"The pool is {percentageOfVolume:f2}% full.Pipe 1: {persentageForPipe1:f2}%.Pipe 2: {persentageForPipe2:f2}%.");
            }
            else if(litersForALlTime > volume)
            {
                double litersMore = Math.Abs(volume - litersForALlTime);
                Console.WriteLine($"For {hours:f2} hours the pool overflows with {litersMore:f2} liters.");
            }
        }
    }
}
