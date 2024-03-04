using System.Reflection;

namespace _1.Demo1
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Mr. Lazarov!");
            Console.WriteLine("-------------------");

            List<int> list = new()
            {
                1, 2, 3, 4, 5
            };
            List<long> longList = new()
            {
                1, 2, 3, 4
            };
            List<string> stringList = new()
            {
                "one", "two", "tree", "four"
            };
            List<Person> objectList = new()
            {
                new("Vasil", 23),
                new("Ani", 19),
                new("Ivan", 37)
            };

            Console.WriteLine("Printing int list");
            Methods.PrintList(list);
            Console.WriteLine("-------------------");
            Console.WriteLine("Printing long list");
            Methods.PrintList(longList);
            Console.WriteLine("-------------------");
            Console.WriteLine("Printing string list");
            Methods.PrintList(stringList);
            Console.WriteLine("-------------------");
            Console.WriteLine("Printing object list");
            Methods.PrintList(objectList);

        }
    }

    public class Methods
    {
        /*
        public static void PrintList(List<int> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine($"Printing: {i}");
            }
        }
        //can overload method for list with long numbers
        public static void PrintList(List<long> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine($"Printing: {i}");
            }
        }
        public static void PrintList(List<string> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine($"Printing: {i}");
            }
        }
        */

        //make method with generics for all types data
        public static void PrintList<T>(List<T> list)
        {
            Type type = typeof(T);
            T defaultT = default(T);
            T[] array = new T[list.Count];
            int index = 0;
            Console.WriteLine($"Type of list: {type}");
            /*List<Type> normalTypes = new List<Type>() 
            {
                typeof(string),
                typeof(int),
                typeof(long),
                typeof(float),
                typeof(double),
                typeof(decimal),
                typeof(char)
            };
            if (normalTypes.Contains(type))
            {
                Console.WriteLine($"Normal type: {type}");
            }*/

            foreach (var i in list)
            {
                if (type == typeof(Person))
                {
                    PropertyInfo[] properties = type.GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        Console.WriteLine($"{property.Name}: {property.GetValue(i)}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Printing: {i}");
                    array[index++] = i;
                }
            }
        }
    }
}