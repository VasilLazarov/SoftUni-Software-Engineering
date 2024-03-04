using System;

namespace Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "Vasil";

            student.Print();
            Student.PrintUniversity();

            Student.numberOfStudents = 1000;
            Console.WriteLine(Student.numberOfStudents);
        }
    }
}
