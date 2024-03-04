using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(" ");
                try
                {
                    if (input == "Cat")
                    {
                        Cat cat = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(cat);   //PrintAnimal(input, cat)
                    }
                    else if (input == "Dog")
                    {
                        Dog dog = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(dog);
                    }
                    else if (input == "Frog")
                    {
                        Frog frog = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(frog);
                    }
                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
                        Console.WriteLine(tomcat);
                    }
                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                        Console.WriteLine(kitten);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }

        //public static void PrintAnimal<T>(string animalType, T animal) where T : Animal
        //{
        //    Console.WriteLine(animal.ToString());
        //}
    }
}
