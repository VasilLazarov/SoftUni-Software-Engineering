using System;
using System.Linq;
using System.Security.Cryptography;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "end")
            {
                string[] commandElements = input.Split(" ");
                if (commandElements[0] == "exchange")
                {
                    int index = int.Parse(commandElements[1]);
                    if(index >= numbers.Length || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        ExchangeCommand(numbers, index);
                    }
                }
                else if(commandElements[0] == "max")
                {
                    string oddOrEven = commandElements[1];
                    int indexOfMaxNum = MaxOddOrEvenNumber(numbers, oddOrEven);
                    if(indexOfMaxNum == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(indexOfMaxNum);
                    }
                }
                else if (commandElements[0] == "min")
                {
                    string oddOrEven = commandElements[1];
                    int indexOfMinNum = MinOddOrEvenNumber(numbers, oddOrEven);
                    if (indexOfMinNum == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(indexOfMinNum);
                    }
                }
                else if (commandElements[0] == "first")
                {
                    int count = int.Parse(commandElements[1]);
                    string oddOrEven = commandElements[2];
                    int[] firstNumbers = FirstOddOrEvenElements(numbers, count, oddOrEven);
                    if(count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", firstNumbers)}]");  // .Where(x => x != 0)
                    }
                }
                else if (commandElements[0] == "last")
                {
                    int count = int.Parse(commandElements[1]);
                    string oddOrEven = commandElements[2];
                    int[] lastNumbers = LastOddOrEvenElements(numbers, count, oddOrEven);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", lastNumbers.Reverse())}]"); // .Where(x => x != 0)
                    }
                }
            }
            Console.WriteLine($"[{String.Join(", ", numbers)}]");
        }
        static void ExchangeCommand(int[] numbers, int index)
        {
            for (int i = 0; i <= index; i++)
            {
                int tmp = numbers[0];
                for (int v = 1; v < numbers.Length; v++)
                {
                    numbers[v - 1] = numbers[v];
                }
                numbers[numbers.Length - 1] = tmp;
            }
        }
        static int MaxOddOrEvenNumber(int[] numbers, string oddOrEven)
        {
            int indexOfMaxNum = -1;
            int maxNum = int.MinValue;
            if(oddOrEven == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] %2 != 0)
                    {
                        if(numbers[i] >= maxNum)
                        {
                            indexOfMaxNum = i;
                            maxNum = numbers[i];
                        }
                    }
                }
            }
            else if(oddOrEven == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        if (numbers[i] >= maxNum)
                        {
                            indexOfMaxNum = i;
                            maxNum = numbers[i];
                        }
                    }
                }
            }
            return indexOfMaxNum;
        }
        static int MinOddOrEvenNumber(int[] numbers, string oddOrEven)
        {
            int indexOfMinNum = -1;
            int minNum = int.MaxValue;
            if (oddOrEven == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        if (numbers[i] <= minNum)
                        {
                            indexOfMinNum = i;
                            minNum = numbers[i];
                        }
                    }
                }
            }
            else if (oddOrEven == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        if (numbers[i] <= minNum)
                        {
                            indexOfMinNum = i;
                            minNum = numbers[i];
                        }
                    }
                }
            }
            return indexOfMinNum;
        }
        static int[] FirstOddOrEvenElements(int[] number, int count, string oddOrEven)
        {
            int[] resultNumbers = new int[count];
            int numOfAdded = 0;
            if (oddOrEven == "odd")
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if(numOfAdded >= count)
                    {
                        break;
                    }
                    if(number[i] % 2 != 0)
                    {
                        resultNumbers[numOfAdded] = number[i];
                        numOfAdded++;
                    }
                }
            }
            else if(oddOrEven == "even")
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (numOfAdded >= count)
                    {
                        break;
                    }
                    if (number[i] % 2 == 0)
                    {
                        resultNumbers[numOfAdded] = number[i];
                        numOfAdded++;
                    }
                }
            }
            if (numOfAdded < count)
            {
                resultNumbers = ResizeArray(resultNumbers, numOfAdded);
            }
            return resultNumbers;
        }
        static int[] LastOddOrEvenElements(int[] number, int count, string oddOrEven)
        {
            int[] resultNumbers = new int[count];
            int numOfAdded = 0;
            if (oddOrEven == "odd")
            {
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    if (numOfAdded >= count)
                    {
                        break;
                    }
                    if (number[i] % 2 != 0)
                    {
                        resultNumbers[numOfAdded] = number[i];
                        numOfAdded++;
                    }
                }
            }
            else if (oddOrEven == "even")
            {
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    if (numOfAdded >= count)
                    {
                        break;
                    }
                    if (number[i] % 2 == 0)
                    {
                        resultNumbers[numOfAdded] = number[i];
                        numOfAdded++;
                    }
                }
            }
            if (numOfAdded < count)
            {
                resultNumbers = ResizeArray(resultNumbers, numOfAdded);
            }
            return resultNumbers;
        }
        static int[] ResizeArray(int[] originalArr, int count)
        {
            int[] modifiedArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                modifiedArray[i] = originalArr[i];
            }

            return modifiedArray;
        }
    }
}
