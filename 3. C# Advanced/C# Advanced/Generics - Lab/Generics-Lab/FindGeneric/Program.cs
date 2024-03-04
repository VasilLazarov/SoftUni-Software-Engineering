namespace FindGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Student student1 = new("Vasil", 23);
            Student student2 = new("Ani", 19);
            if(student1 == student2)
            {

            }*/
            Console.WriteLine("Results for finding integers:");
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            bool isIntFound = FindElement(arr, 7);
            Console.WriteLine(isIntFound);
            bool isIntFound2 = FindElement(arr, 3);
            Console.WriteLine(isIntFound2);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Results for finding strings:");

            string[] names = new string[] { "Vasil", "Ani", "Ivan" };
            bool isStringFound = FindElement(names, "Ani");
            Console.WriteLine(isStringFound);
            bool isStringFound2 = FindElement(names, "Pesho");
            Console.WriteLine(isStringFound2);

            bool FindElement<T>(T[] array, T element)
            {
                
                foreach(var item in array)
                {
                    if(item.Equals(element))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}