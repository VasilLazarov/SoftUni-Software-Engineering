using System;
using System.Collections.Generic;

namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companys 
                = new Dictionary<string, List<string>>();

            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputElements = input.Split(" -> ");
                string companyName = inputElements[0];
                string emplID = inputElements[1];
                if (!companys.ContainsKey(companyName))
                {
                    companys.Add(companyName, new List<string>() { emplID });
                }
                else
                {
                    bool haveThisID = false;
                    foreach (var company in companys)
                    {
                        foreach(string item in company.Value)
                        {
                            if(item == emplID)
                            {
                                haveThisID = true;
                            }
                        }
                    }
                    if (!haveThisID)
                    {
                        companys[companyName].Add(emplID);
                    }
                    
                }
            }
            foreach (var company in companys)
            {
                Console.WriteLine(company.Key);
                foreach (var item in company.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
