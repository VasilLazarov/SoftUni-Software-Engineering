using System;
using System.Collections.Generic;
using System.Text;

namespace Static
{
    internal class Student
    {
        public string Name { get; set; }


        public static int numberOfStudents { get; set; }

        public void Print()
        {
            Console.WriteLine(Name);
        }


        public static void PrintUniversity()
        {
            Console.WriteLine("SoftUni");
            Console.WriteLine(Student.numberOfStudents);
        }
    }
}
