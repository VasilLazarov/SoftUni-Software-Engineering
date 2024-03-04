using System;

namespace Constructors
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine($"{student.Name} - {student.Age}");
            student.Grades.Add(5.69);
            student.Grades.Add(4.22);
            student.Grades.Add(3.66);
            student.Grades.Add(6.00);
            student.Grades.Add(4.75);
            Console.WriteLine(string.Join(", ", student.Grades));
            
            Console.WriteLine();

            Student student2 = new Student(69, "Ivan");
            Console.WriteLine($"{student2.Name} - {student2.Age}");
            student2.Grades.Add(2.82);
            student2.Grades.Add(3.55);
            student2.Grades.Add(4.80);
            Console.WriteLine(string.Join(", ", student2.Grades));




        }
    }
}
