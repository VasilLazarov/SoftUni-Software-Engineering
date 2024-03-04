using System;

namespace ComputerArchitecture
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Computer computer = new Computer("ddz", 4);
            //CPU cpu1 = new CPU("nz1", 2, 1.5);
            //CPU cpu2 = new CPU("nz2", 4, 3.5);
            //CPU cpu3 = new CPU("nz3", 6, 2.5);
            //computer.Add(cpu1);
            //computer.Add(cpu2);
            //computer.Add(cpu3);
            //CPU cpu = computer.MostPowerful();
            //Console.WriteLine(cpu.ToString());
            //Console.WriteLine();

            // Initialize the repository
            Computer computer = new Computer("Gaming Serioux", 4);

            // Initialize entity
            CPU cpu = new CPU("AMD Ryzen 5", 6, 3.7);

            // Print CPU
            Console.WriteLine(cpu);
            // AMD Ryzen 5 CPU:
            // Cores: 6
            // Frequency: 3.7 GHz

            // Add CPU
            computer.Add(cpu);

            // Remove CPU
            Console.WriteLine(computer.Remove("Intel Core i5"));
            // False

            CPU secondCPU = new CPU("Intel Core i7", 8, 4);
            CPU thirdCPU = new CPU("Intel Core i5", 8, 3.9);

            // Add CPU
            computer.Add(secondCPU);
            computer.Add(thirdCPU);

            CPU mostPowerful = computer.MostPowerful();
            Console.WriteLine(mostPowerful);
            // Intel Core i7 CPU:
            // Cores: 8
            // Frequency: 4.0 GHz

            CPU receivedCPU = computer.GetCPU("Intel Core i5");
            Console.WriteLine(receivedCPU);
            // Intel Core i5 CPU:
            // Cores: 8
            // Frequency: 3.9 GHz

            Console.WriteLine(computer.Count);
            // 3
            Console.WriteLine(computer.Remove("Intel Core i5"));
            // True

            Console.WriteLine(computer.Report());
            // CPUs in the Computer Gaming Serioux:
            // AMD Ryzen 5 CPU:
            // Cores: 6
            // Frequency: 3.7 GHz
            // Intel Core i7 CPU:
            // Cores: 8
            // Frequency: 4.0 GHz

        }
    }
}
