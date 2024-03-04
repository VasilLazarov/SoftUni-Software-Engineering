using System;

namespace _1._Excellent_Result
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rating = double.Parse(Console.ReadLine());

          
                if (rating >= 5.50 && rating <= 6)
                {
                    Console.WriteLine("Excellent!");
                }
                else if (rating >= 4.50 && rating < 5.50)
                {
                    Console.WriteLine("Very Good");
                }
                else if (rating >= 3.50 && rating < 4.50)
                {
                    Console.WriteLine("Good");
                }
                else if (rating >= 3.00 && rating < 3.50)
                {
                    Console.WriteLine("Average");
                }
                else if (rating >= 2 && rating < 3)
                {
                    Console.WriteLine("Weak");
                }
                else
                {
                    Console.WriteLine("Does not exist");
                }
           
        }
    }
}
