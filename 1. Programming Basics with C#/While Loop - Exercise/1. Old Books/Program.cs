using System;

namespace _1._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string farouriteBook = Console.ReadLine();
            int count = 0;
            string book = "";
            while(book != "No More Books")
            {
                book = Console.ReadLine();
                
                if (book == farouriteBook)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
                
                if (book == "No More Books")
                {
                    Console.WriteLine($"The book you search is not here!");
                    Console.WriteLine($"You checked {count} books.");
                    break;
                }
                count++;
            }
        }
    }
}
