using System;

namespace _5._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double instead = double.Parse(Console.ReadLine())*100;
            int coins = 0;
            while(instead != 0)
            {
                if(instead >= 200)
                {
                    
                    instead -= 200;
                }
                else if(instead >= 100)
                {
                    
                    instead -= 100;
                }
                else if(instead >= 50)
                {
                    
                    instead -= 50;
                }
                else if (instead >= 20)
                {
                    
                    instead -= 20;
                }
                else if (instead >= 10)
                {
                    
                    instead -= 10;
                }
                else if (instead >= 5)
                {
                    
                    instead -= 5;
                }
                else if (instead >= 2)
                {
                    
                    instead -= 2;
                }
                else if(instead >= 1)
                {
                    
                    instead -= 1;
                }
                else if( instead < 1)
                {
                    break;
                }
                coins++;
            }
            Console.WriteLine(coins);
        }
    }
}
