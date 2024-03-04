using System;

namespace more_ex._2._Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int peoplesPerDay;
            int doctors = 7;
            int examinedPatients = 0;
            int notExaminedPatients = 0;
            for(int i = 1; i <= period; i++)
            {
                peoplesPerDay = int.Parse((Console.ReadLine()));

                if (i % 3 == 0)
                {
                    if (notExaminedPatients > examinedPatients)
                    {
                        doctors++;
                    }
                }

                if (peoplesPerDay <= doctors)
                {
                    examinedPatients += peoplesPerDay;
                }
                else
                {
                    examinedPatients += doctors;
                    notExaminedPatients += peoplesPerDay - doctors;
                }
                
            }
            Console.WriteLine($"Treated patients: {examinedPatients}.");
            Console.WriteLine($"Untreated patients: {notExaminedPatients}.");
        }
    }
}
