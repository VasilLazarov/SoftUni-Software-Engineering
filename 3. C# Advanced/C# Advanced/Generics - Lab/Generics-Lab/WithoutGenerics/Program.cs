namespace WithoutGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object variable = 5;
            variable = "pet";
            variable = new List<int>();

            List<object> intList = new() { 1, 2, 3, 4 };
            //not type safety because:
            intList.Add("Zashto ima string vuv int list"); // not good
            intList.Add(new List<int>()); // not good


            List<object> stringList = new() { "one", "two", "three", "four" };

            PrintList(intList);
            PrintList(stringList);

            void PrintList(List<object> list)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }



        }
    }
}