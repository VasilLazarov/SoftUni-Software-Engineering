namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);

            Console.WriteLine(strings[2]);
            Console.WriteLine(strings[4]);

            Console.WriteLine(integers[3]);
            Console.WriteLine(integers[5]);
            Console.WriteLine(integers[9]);

        }
    }
}