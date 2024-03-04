using System;

namespace _3._Sum_Prime_Non_Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int sumPrime = 0;
            int sumNotPrime = 0;
            int numInt = 0;
            bool simpleOrPrime = false;
            while(num != "stop")
            {
                numInt = int.Parse(num);

                if(numInt < 0)
                {
                    Console.WriteLine($"Number is negative.");
                    num = Console.ReadLine();
                    continue;
                }
                for(int i = 2; i < numInt; i++)
                {
                    if(numInt % i == 0)
                    {
                        simpleOrPrime = true;
                        break;
                    }
                }
                if (simpleOrPrime)
                {
                    sumNotPrime += numInt;
                }
                else
                {
                    sumPrime += numInt;
                }
                simpleOrPrime = false;
                num = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNotPrime}");       
            
        }
    }
}
