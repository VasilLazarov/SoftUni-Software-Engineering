using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int[] sequenceForPrint = new int[length];
            int numSeq = 0;
            int maxSeq = 0;
            int startIndex = 0;
            int finalIndex = 0;
            int sampleNum = 0;
            int bestSampleNum = 0;
            int sum = 0;
            int bestSum = 0;
            int stepsForI = 0;
            while (input != "Clone them!")
            {
                int[] sequence = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sampleNum++;
                for (int i = 0; i < sequence.Length; i++)
                {
                    sum += sequence[i];
                }
                for (int i = 0; i < sequence.Length; i = i+stepsForI)
                {
                    if (sequence[i] == 1)
                    {
                        startIndex = i;
                        numSeq++;
                        for (int v = 1; v < sequence.Length; v++)
                        {
                            stepsForI++;
                            if (sequence[i] == sequence[v])
                            {
                                numSeq++;
                                
                            }
                            else
                            {
                                break;
                            }
                            
                        }
                        if (numSeq > maxSeq)
                        {
                            maxSeq = numSeq;
                            sequenceForPrint = sequence;
                            bestSampleNum = sampleNum;
                            bestSum = sum;
                            finalIndex = startIndex;
                        }
                        else if (numSeq == maxSeq)
                        {
                            if(startIndex < finalIndex)
                            {
                                maxSeq = numSeq;
                                sequenceForPrint = sequence;
                                bestSampleNum = sampleNum;
                                bestSum = sum;
                                finalIndex = startIndex;
                            }
                            else if(sum > bestSum)
                            {
                                maxSeq = numSeq;
                                sequenceForPrint = sequence;
                                bestSampleNum = sampleNum;
                                bestSum = sum;
                                finalIndex = startIndex;
                            }
                        }
                        numSeq = 0;
                    }
                    else
                    {
                        stepsForI = 1;
                    }
                }
                sum = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSampleNum} with sum: {bestSum}.");
            Console.WriteLine(String.Join(" ", sequenceForPrint));
        }
    }
}

