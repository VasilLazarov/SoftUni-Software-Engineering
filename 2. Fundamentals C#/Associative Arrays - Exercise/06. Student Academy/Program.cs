using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> grades 
                = new Dictionary<string, double>();

            int numberOfGrades = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfGrades; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, grade);
                }
                else
                {
                    grades[name] = (grades[name] + grade)/2;
                }
            }
            foreach(var grade in grades.Where(v => v.Value >= 4.5))
            {
                Console.WriteLine($"{grade.Key} -> {grade.Value:f2}");
            }
        }
    }
}
