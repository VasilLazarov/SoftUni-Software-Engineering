using System;
using System.Text;

namespace a29._Favorite_Movie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int sum = 0;
            int maxPoints = 0;
            string favoriteMovie = "";
            int count = 0;
            while (name != "STOP")
            {
                count++;
                for (int i = 0; i < name.Length; i++)
                {
                    if (Char.IsUpper(name[i]))
                    {
                        sum += name[i] - name.Length;
                    }
                    else if (Char.IsLower(name[i]))
                    {
                        sum += name[i] - 2 * name.Length;
                    }
                    else
                    {
                        sum += name[i];
                    }
                }
                if (sum > maxPoints)
                {
                    favoriteMovie = name;
                    maxPoints = sum;
                }
                sum = 0;
                if (count >= 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"The best movie for you is {favoriteMovie} with {maxPoints} ASCII sum.");
        }
    }
}
