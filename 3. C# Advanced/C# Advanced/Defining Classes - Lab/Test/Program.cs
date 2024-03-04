using System;
using System.Collections.Generic;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Course cSharpAdvanced = new Course()
            {
                Name = "C# advanced",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(60),
                Lecturer = "Viktor Dakov"
            };

            Course javaAdvanced = new Course()
            {
                Name = "Java advanced",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(60),
                Lecturer = "Asen Ivanov"
            };


            TestClass student = new TestClass()
            {
                FirstName = "Vasil",
                LastName = "Lazarov",
                Age = 22,
                AvrGrade = 5.85,
                Courses = new List<Course>()
            };
            student.Courses.Add(cSharpAdvanced);
            student.Courses.Add(javaAdvanced);

            TestClass student2 = new TestClass();
            student2.FirstName = "Martin";
            student2.LastName = "Kachev";
            student2.Age = 22;
            student2.AvrGrade = 5.66;
            student2.Courses = new List<Course>();
            student2.Courses.Add(cSharpAdvanced);

            student.PrintStudentInfo();
            PrintStudentCourses(student);
            Console.WriteLine();
            student2.PrintStudentInfo();
            PrintStudentCourses(student2);


        }
        static void PrintStudentCourses(TestClass student)
        {
            if(student.Courses.Count > 0)
            {
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} in studing: {course.Name} starting: {course.StartDate:d} ending: {course.EndDate:d} with lecturer {course.Lecturer}.");
                }
            }


        }
    }
}
