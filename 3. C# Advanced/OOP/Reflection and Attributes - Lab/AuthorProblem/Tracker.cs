using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {


        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methodInfos = type.GetMethods(
    BindingFlags.Instance | BindingFlags.Public |
    BindingFlags.Static);

            foreach (var method in methodInfos)
            {
                //AuthorAttribute[] attributes =
                //    method.GetCustomAttributes<AuthorAttribute>().ToArray();
                //if (attributes.Length > 0)
                //{
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes2= method.GetCustomAttributes(false);
                    AuthorAttribute[] attributes =
                    method.GetCustomAttributes<AuthorAttribute>() as AuthorAttribute[];
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
