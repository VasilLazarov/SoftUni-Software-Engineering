using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count 
        { 
            get
            {
                return Multiprocessor.Count;
            }
        }


        public void Add(CPU cpu)
        {
            if(Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            return Multiprocessor.Remove(Multiprocessor.FirstOrDefault(cpu => cpu.Brand == brand));
            //for (int i = 0; i < CPUs.Count; i++)
            //{
            //    if (CPUs[i].Brand == brand)
            //    {
            //        CPUs.RemoveAt(i);
            //    }
            //}
        }

        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(cpu => cpu.Frequency).FirstOrDefault();
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(cpu => cpu.Brand == brand);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"CPUs in the Computer {Model}:");
            foreach(CPU cpu in Multiprocessor)
            {
                result.AppendLine(cpu.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
