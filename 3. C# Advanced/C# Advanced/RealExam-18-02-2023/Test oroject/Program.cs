using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_oroject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));
            Dictionary<string, int> itemCount = new Dictionary<string, int>();
            itemCount.Add("Patch", 0);
            itemCount.Add("Bandage", 0);
            itemCount.Add("MedKit", 0);


            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int currentTextile = textiles.Dequeue();
                int currentMedicament = medicaments.Pop();
                int currentSum = currentMedicament + currentTextile;

                if(currentSum == 30)
                {
                    itemCount["Patch"]++;
                }
                else if (currentSum == 40)
                {
                    itemCount["Bandage"]++;
                }
                else if (currentSum == 100)
                {
                    itemCount["MedKit"]++;
                }
                else if (currentSum > 100)
                {
                    itemCount["MedKit"]++;
                    currentSum -= 100;
                    int addReaminingSumToLastElementsInStack = medicaments.Pop() + currentSum;
                    medicaments.Push(addReaminingSumToLastElementsInStack);
                }
                else
                {
                    currentMedicament += 10;
                    medicaments.Push(currentMedicament);
                }
            }
            if(textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
                PrintDictionary(itemCount);
            }
            else if(medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
                PrintDictionary(itemCount);
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
            else if(textiles.Count == 0)
            {
                Console.WriteLine("Textiles are empty.");
                PrintDictionary(itemCount);
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

        }
        static void PrintDictionary(Dictionary<string, int> items)
        {
            foreach (var item in items.Where(v => v.Value > 0).OrderByDescending(v => v.Value).ThenBy(v => v.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
