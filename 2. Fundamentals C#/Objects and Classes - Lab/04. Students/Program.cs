using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputCMD = input.Split(' ');
                string firstName = inputCMD[0];
                string lastName = inputCMD[1];
                int age = int.Parse(inputCMD[2]);
                string homeTown = inputCMD[3];

                Student newStudent = new Student(firstName, lastName, age, homeTown);
                students.Add(newStudent);
            }
            string town = Console.ReadLine();
            foreach (Student student in students.Where(s => s.HomeTown == town))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
    }
}
