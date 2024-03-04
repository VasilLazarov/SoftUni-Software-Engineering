using System;
using System.Collections.Generic;
using System.Text;

namespace Constructors
{
    public class Student
    {
        public Student()
        {
            Name = "Vasil";
            Age = 22;
            Grades = new List<double>();
        }

        public Student(int age,string name)
        {
            this.Age = age;
            this.Name = name;
            Grades = new List<double>();
        }

        public int Age { get; set; }
        public string Name { get; set; }

        public List<double> Grades { get; set; }
    }
}
