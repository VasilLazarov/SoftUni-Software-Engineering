using System;

namespace _7._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfGroups = int.Parse(Console.ReadLine());
            int numOfPeoples;
            string place;
            double allPeoples = 0.00;
            int Musala = 0;
            int Monblan = 0;
            int Kilimanjaro = 0;
            int K2 = 0;
            int Everest = 0;
            for(int x = 0; x < numOfGroups; x++)
            {
                numOfPeoples = int.Parse(Console.ReadLine());
                if(numOfPeoples <= 5)
                {
                    Musala += numOfPeoples;
                }
                else if(numOfPeoples <= 12)
                {
                    Monblan += numOfPeoples;
                }
                else if( numOfPeoples <= 25)
                {
                    Kilimanjaro += numOfPeoples;
                }
                else if(numOfPeoples <= 40)
                {
                    K2 += numOfPeoples;
                }
                else if(numOfPeoples >= 41)
                {
                    Everest += numOfPeoples;
                }
                allPeoples += numOfPeoples;
            }
            Console.WriteLine($"{Musala / allPeoples * 100:f2}%");
            Console.WriteLine($"{Monblan / allPeoples * 100:f2}%");
            Console.WriteLine($"{Kilimanjaro / allPeoples * 100:f2}%");
            Console.WriteLine($"{K2 / allPeoples * 100:f2}%");
            Console.WriteLine($"{Everest / allPeoples * 100:f2}%");
        }
    }
}
