using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> allProducts = new List<Product>();

            string[] people2 = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string p in people2)
            {
                string[] people = p
                    .Split('=');
                try
                {
                    for (int i = 0; i < people.Length; i += 2)
                    {
                        Person person = new Person(people[i], decimal.Parse(people[i + 1]));
                        persons.Add(person);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            string[] products2 = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string p in products2)
            {
                string[] products = p
                    .Split('=');
                try
                {
                    for (int i = 0; i < products.Length; i += 2)
                    {
                        Product product = new Product(products[i], decimal.Parse(products[i + 1]));
                        allProducts.Add(product);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string input = string.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] inputElements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = inputElements[0];
                string productName = inputElements[1];

                Person person = persons.FirstOrDefault(p => p.Name == personName);
                Product product = allProducts.FirstOrDefault(p => p.Name == productName);

                if(person != null && product != null)
                {
                    Console.WriteLine(person.AddProduct(product)); 
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, persons));
        }
    }
}
