using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Vaseto")]
    [Author("Ani")]
    public class StartUp
    {
        [Author("Pesho")]
        public static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
