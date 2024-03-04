using System;

namespace _04._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberStudents = int.Parse(Console.ReadLine());
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            double average = 0;
            for (int i = 1; i <= numberStudents; i++)
            {
                double gradeFromExam = double.Parse(Console.ReadLine());
                if (gradeFromExam >= 5.00)
                {
                    count5++;
                }
                else if (gradeFromExam >= 4.00 && gradeFromExam <= 4.99)
                {
                    count4++;
                }
                else if (gradeFromExam >= 3.00 && gradeFromExam <= 3.99)
                {
                    count3++;
                }
                else if (gradeFromExam < 3.00)
                {

                    count2++;
                }
                average += gradeFromExam;

            }
            Console.WriteLine($"Top students: {((double)count5 / numberStudents) * 100:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {((double)count4 / numberStudents) * 100:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {((double)count3 / numberStudents) * 100:F2}%");
            Console.WriteLine($"Fail: {((double)count2 / numberStudents) * 100:F2}%");
            Console.WriteLine($"Average: {((double)average / numberStudents):F2}");
        }
    }
}