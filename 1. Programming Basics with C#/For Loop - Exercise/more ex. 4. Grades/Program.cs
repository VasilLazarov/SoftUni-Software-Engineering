using System;

namespace more_ex._4._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            double grade = 0;
            int grade2 = 0;
            int grade3 = 0;
            int grade4 = 0;
            int grade5 = 0;
            double averageGrade = 0;
            for(int i = 0; i < students; i++)
            {
                grade = double.Parse(Console.ReadLine());
                averageGrade += grade;
                if(grade <= 2.99)
                {
                    grade2++;
                }
                else if(grade >= 3 && grade <= 3.99)
                {
                    grade3++;
                }
                else if(grade >= 4 && grade <= 4.99)
                {
                    grade4++;
                }
                else if(grade >= 5)
                {
                    grade5++;
                }

            }
            averageGrade /= students;
            Console.WriteLine($"Top students: {(grade5/(double)students)*100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(grade4 / (double)students)*100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(grade3 / (double)students) * 100:f2}%");
            Console.WriteLine($"Fail: {(grade2 / (double)students) * 100:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
