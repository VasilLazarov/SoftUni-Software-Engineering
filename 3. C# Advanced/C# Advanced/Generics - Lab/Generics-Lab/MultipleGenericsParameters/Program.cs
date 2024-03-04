namespace MultipleGenericsParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new();
            foreach (KeyValuePair<int, string> item in dictionary)
            {

            }

            KeyValuePair<int, string> result = CreateKeyValuePair(5, "pet");

            KeyValuePair<TKey, TValue> CreateKeyValuePair<TKey, TValue>(TKey key, TValue value)
            {
                Console.WriteLine(key);
                Console.WriteLine(value);
                return new KeyValuePair<TKey, TValue>(key, value);
            }

        }
    }
}