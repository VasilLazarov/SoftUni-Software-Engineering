﻿using System;

namespace _1._Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i <= 23; i++)
            {
                for(int j = 0; j <= 59; j++)
                {
                    Console.WriteLine($"{i}:{j}");
                }
            }
        }
    }
}