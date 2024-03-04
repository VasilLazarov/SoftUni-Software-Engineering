using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class TestClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double AvrGrade { get; set; }

        public List<Course> Courses { get; set; }

        public void PrintStudentInfo()
        {
            Console.WriteLine("Added student:");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {this.LastName}");
            Console.WriteLine($"Age: {this.Age}");
            Console.WriteLine($"Grade: {this.AvrGrade}");
        }

    }
}
