using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine()
                .Split(", ");
            Queue<string> songs = new Queue<string>(inputSongs);

            while (songs.Any())
            {
                string[] input = Console.ReadLine()
                    .Split(" ");
                string command = input[0];
                switch (command)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string song = string.Join(" ", input.Skip(1));
                        if (songs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
