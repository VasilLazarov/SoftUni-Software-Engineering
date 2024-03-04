namespace FirstTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintNumbersInRange(0, n);
            var task = Task.Run(() => PrintNumbersInRange(n, 100));

            Console.WriteLine("Done!");
            task.Wait();
        }

        static void PrintNumbersInRange(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}