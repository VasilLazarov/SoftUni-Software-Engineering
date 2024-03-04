using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int destroyedHeadsets = lostGames / 2;
            int destroyedMouses = lostGames / 3;
            int destroyedKeyboards = lostGames / 6;
            int destroyedDisplays = lostGames / 12;
            double rageExpenses = destroyedHeadsets * headsetPrice + destroyedMouses * mousePrice + destroyedKeyboards * keyboardPrice + destroyedDisplays * displayPrice;
            Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");
        }
    }
}
