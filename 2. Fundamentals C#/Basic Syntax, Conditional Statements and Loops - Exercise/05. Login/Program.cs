using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPass = "";
            char[] userN = username.ToCharArray();
            Array.Reverse(userN);
            correctPass = new string(userN);
            int count = 0;
            string password = Console.ReadLine();
            while(password != correctPass)
            {
                
                count++;
                if(count >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
            }
            Console.WriteLine($"User {username} logged in.");
        }
    }
}
