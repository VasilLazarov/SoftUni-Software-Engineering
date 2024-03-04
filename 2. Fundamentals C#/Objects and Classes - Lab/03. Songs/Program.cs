using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] input = Console.ReadLine()
                .Split("_");
                string typeList = input[0];
                string name = input[1];
                string time = input[2];
                Song newSong = new Song(typeList, name, time);
                songs.Add(newSong);
            }
            string inputCMD = Console.ReadLine();
            if(inputCMD == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs.Where(s => s.TypeList == inputCMD))
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
