using System;
using System.Collections.Generic;
//Problem 3 - P!rates

namespace task3
{
    class City
    {
        public City(string name, int pop, int gold)
        {
            this.Name = name;
            this.Population = pop;
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();

            string firstCommand = Console.ReadLine();

            while (firstCommand != "Sail")
            {
                string[] tokens = firstCommand.Split("||", StringSplitOptions.RemoveEmptyEntries); // Console.ReadLine() ??????????
                string currCityName = tokens[0];
                int currPopulation = int.Parse(tokens[1]);
                int currGold = int.Parse(tokens[2]);

                if (cities.ContainsKey(currCityName))
                {
                    cities[currCityName].Population += currPopulation;
                    cities[currCityName].Gold += currGold;
                }
                else if (!cities.ContainsKey(currCityName))
                {
                    City currCity = new City(currCityName, currPopulation, currGold);
                    cities.Add(currCityName, currCity);
                }

                firstCommand = Console.ReadLine();
            }

            string secondComand = Console.ReadLine();

            while (secondComand != "End")
            {
                string[] tokens = secondComand.Split("=>");

                string command = tokens[0];

                if (command == "Plunder")
                {
                    string currTown = tokens[1];
                    int currPeople = int.Parse(tokens[2]);
                    int currGold = int.Parse(tokens[3]);

                    cities[currTown].Population -= currPeople;
                    cities[currTown].Gold -= currGold;

                    Console.WriteLine($"{currTown} plundered! {currGold} gold stolen, {currPeople} citizens killed.");

                    if (cities[currTown].Gold <= 0 || cities[currTown].Population <= 0)
                    {
                        Console.WriteLine($"{currTown} has been wiped off the map!");
                        cities.Remove(currTown);
                    }
                }
                else if(command == "Prosper")
                { 
                    string currTown = tokens[1];
                    int currGold = int.Parse(tokens[2]);

                    if (currGold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        secondComand = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        cities[currTown].Gold += currGold;
                        Console.WriteLine($"{currGold} gold added to the city treasury. {currTown} now has {cities[currTown].Gold} gold.");
                    }
                }

                secondComand = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var kvp in cities)
                {
                    string currCity = kvp.Key;
                    Console.WriteLine($"{currCity} -> Population: {cities[currCity].Population} citizens, Gold: {cities[currCity].Gold} kg");
                } 
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}
