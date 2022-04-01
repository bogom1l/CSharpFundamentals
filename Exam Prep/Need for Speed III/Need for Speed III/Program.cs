using System;
using System.Linq;
using System.Collections.Generic;

namespace Need_for_Speed_III
{
    class Car
    {
        public Car(string n, int m, int f)
        {
            this.Name = n;
            this.Mileage = m;   
            this.Fuel = f;
        }
        public string Name{ get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string currName = tokens[0];
                int currMileage = int.Parse(tokens[1]);
                int currFuel = int.Parse(tokens[2]);

                Car currCar = new Car(currName, currMileage, currFuel);

                cars[currName] = currCar;
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tokens = input.Split(" : ");
                string command = tokens[0];

                if (command == "Drive")
                {
                    string currCarName = tokens[1];
                    int currDistance = int.Parse(tokens[2]);
                    int currFuel = int.Parse(tokens[3]);

                    if (currFuel > cars[currCarName].Fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                        input = Console.ReadLine();
                        continue;
                    }

                    cars[currCarName].Mileage += currDistance;
                    cars[currCarName].Fuel -= currFuel;

                    Console.WriteLine($"{currCarName} driven for {currDistance} kilometers. {currFuel} liters of fuel consumed.");

                    if (cars[currCarName].Mileage > 100000)
                    {
                        Console.WriteLine($"Time to sell the {currCarName}!");
                        cars.Remove(currCarName);
                    }
                }
                else if(command == "Refuel")
                {
                    string currCar = tokens[1];
                    int currFuel = int.Parse(tokens[2]);

                    Console.WriteLine($"{currCar} refueled with {75 - cars[currCar].Fuel} liters");

                    if ((cars[currCar].Fuel + currFuel) > 75)
                    {
                        cars[currCar].Fuel = 75;
                    }
                    else
                    {
                        cars[currCar].Fuel += currFuel;
                    }
                }
                else if(command == "Revert")
                {
                    string currCar = tokens[1];
                    int currKM = int.Parse(tokens[2]);

                    cars[currCar].Mileage -= currKM;

                    Console.WriteLine($"{currCar} mileage decreased by {currKM} kilometers");

                    if (cars[currCar].Mileage < 10000)
                    {
                        cars[currCar].Mileage = 10000;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                string carName = car.Value.Name;
                int carMileage = car.Value.Mileage;
                int carFuel = car.Value.Fuel;
                Console.WriteLine($"{carName} -> Mileage: {carMileage} kms, Fuel in the tank: {carFuel} lt.");
            }

        }
    }
}
