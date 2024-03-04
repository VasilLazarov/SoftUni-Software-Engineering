using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carElements = Console.ReadLine()
                .Split(" ");
            string[] truckElements = Console.ReadLine()
                .Split(" ");
            Vehicle car = new Car(double.Parse(carElements[1]), double.Parse(carElements[2]));
            Vehicle truck = new Truck(double.Parse(truckElements[1]), double.Parse(truckElements[2]));

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] inputCommand = Console.ReadLine()
                    .Split(" ");
                string command = inputCommand[0];
                string vehicletype = inputCommand[1];
                double distanceOrFuel = double.Parse(inputCommand[2]);

                switch (vehicletype)
                {
                    case "Car":
                        if(command == "Drive")
                        {
                            car.Drive(distanceOrFuel);
                        }
                        else if(command == "Refuel")
                        {
                            car.Refuel(distanceOrFuel);
                        }
                        break;
                    case "Truck":
                        if (command == "Drive")
                        {
                            truck.Drive(distanceOrFuel);
                        }
                        else if (command == "Refuel")
                        {
                            truck.Refuel(distanceOrFuel);
                        }
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
    }
}
