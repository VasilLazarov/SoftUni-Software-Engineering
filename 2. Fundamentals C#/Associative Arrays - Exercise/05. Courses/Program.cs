using System;
using System.Collections.Generic;

namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses 
                = new Dictionary<string, List<string>>();
            string input;
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputElements = input.Split(" : ");
                if (!courses.ContainsKey(inputElements[0]))
                {
                    courses.Add(inputElements[0], new List<string>() { inputElements[1] });
                }
                else
                {
                    courses[inputElements[0]].Add(inputElements[1]);
                }
            }
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var item in course.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
