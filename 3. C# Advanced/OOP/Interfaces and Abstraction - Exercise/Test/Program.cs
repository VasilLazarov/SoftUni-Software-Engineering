using System;

namespace Test
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Middle middle = new Middle();
            Console.WriteLine(middle.P());
            ILeft left = middle;
            Console.WriteLine(left.P);
        }

    }
    interface ILeft
    {
        string P { get; }
    }
    interface IRight
    {
        string P();
    }

    class Middle : ILeft, IRight
    {
        public string P() { return "from right with method"; }
        string ILeft.P { get { return "from left with property"; } }
    }
}
