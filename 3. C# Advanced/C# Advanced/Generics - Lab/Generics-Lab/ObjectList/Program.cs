namespace ObjectList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //with generics is better because we have type safety
            GenericList<int> intList = new();
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);

            GenericList<string> stringList2 = new();
            stringList2.Add("1");
            stringList2.Add("2");
            stringList2.Add("3");

            //bad - because we don't have type safety and can make mistakes with data types
            ObjectList objectList = new();
            objectList.Add("1");
            objectList.Add(2);
            objectList.Add(DateTime.Now);

        }
    }
}