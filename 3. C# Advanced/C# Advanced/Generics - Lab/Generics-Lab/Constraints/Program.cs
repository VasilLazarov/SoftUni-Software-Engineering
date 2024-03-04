using System.Globalization;
using System.Reflection;
using System.Text;

namespace Constraints
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(GetBiggestElement(8,7,11));
            int biggest = GetBiggestElement(8, 7, 11);

            //StringBuilder  sb = new StringBuilder();
            //StringBuilder biggestSb = GetBiggestElement(sb,sb,sb);

            List<Student> students = new()
            {
                new Student(4.20),
                new Student(5.87),
                new Student(5.60),
            };
            Student biggestGradeStudent = GetBiggestElement(students[0], students[1], students[2]);
            Console.WriteLine(biggestGradeStudent.Grade);

            T GetBiggestElement<T>(T first, T second, T third)
                where T : IComparable<T>
            {
                T biggestT = first;
                if(biggestT.CompareTo(second) < 0)
                {
                    biggestT = second;
                }
                if (biggestT.CompareTo(third) < 0)
                {
                    biggestT = third;
                }

                return biggestT;
            }
            void Ddz<T>(T element)
                where T : class, new()
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                element.

            }

        }
    }
    public class Student : IComparable<Student>
    {
        public double Grade { get; set; }

        public Student(double grade)
        {
            Grade = grade;
        }

        public int CompareTo(Student other)
        {
            if(this.Grade < other.Grade)
            {
                return -1;
            }
            else if (this.Grade == other.Grade)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}