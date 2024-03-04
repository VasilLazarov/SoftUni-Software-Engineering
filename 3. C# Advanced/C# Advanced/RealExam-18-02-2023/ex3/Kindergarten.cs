using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {


        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int ChildrenCount { get { return Registry.Count; } }


        public bool AddChild(Child child)
        {
            if(Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] names = childFullName.
                Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            
            return Registry.Remove(Registry.FirstOrDefault(v => v.FirstName == names[0] && v.LastName == names[1]));
        }

        public Child GetChild(string childFullName)
        {
            string[] names = childFullName.
                Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            return Registry.FirstOrDefault(v => v.FirstName == names[0] && v.LastName == names[1]);
        }

        public string RegistryReport()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Registered children in {Name}:");
            foreach (Child child in Registry.OrderByDescending(v => v.Age).ThenBy(v => v.LastName).ThenBy(v => v.FirstName))
            {
                result.AppendLine(child.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
