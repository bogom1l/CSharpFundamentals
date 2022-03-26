using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Plant_Discovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Ratings = new List<double>();
        }
        public List<double> Ratings { get; set; }
        public string Name { get; set; }
        public int Rarity { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();
            //TODO:: da q resha s List<Plant>, no kak?? 

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputInfo = Console.ReadLine();
                string[] tokens = inputInfo.Split("<->"); //, StringSplitOptions.RemoveEmptyEntries

                string currName = tokens[0];
                int currRarity = int.Parse(tokens[1]);

                Plant currPlant = new Plant(currName, currRarity);

                plants[currName] = currPlant;
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] tokens = input.Split(": "); //, StringSplitOptions.RemoveEmptyEntries
                string command = tokens[0];
                string info = tokens[1];

                string[] tokens2 = info.Split(" - "); //, StringSplitOptions.RemoveEmptyEntries

                if (command == "Rate")
                {
                    string currPlantName = tokens2[0];

                    if (!plants.ContainsKey(currPlantName))
                    {
                        Console.WriteLine("error");
                        input = Console.ReadLine();
                        continue;
                    }

                    double currRating = double.Parse(tokens2[1]);

                    plants[currPlantName].Ratings.Add(currRating);
                }
                else if (command == "Update")
                {
                    string currPlantName = tokens2[0];

                    if (!plants.ContainsKey(currPlantName))
                    {
                        Console.WriteLine("error");
                        input = Console.ReadLine();
                        continue;
                    }

                    int newRarity = int.Parse(tokens2[1]);

                    plants[currPlantName].Rarity = newRarity;
                }
                else if (command == "Reset")
                {
                    string currPlantName = tokens2[0];

                    if (!plants.ContainsKey(currPlantName))
                    {
                        Console.WriteLine("error");
                        input = Console.ReadLine();
                        continue;
                    }

                    plants[currPlantName].Ratings.Clear();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var kvp in plants)
            {
                Plant currPlant = kvp.Value;
                string currPlantName = currPlant.Name;
                int currRarity = currPlant.Rarity;
                List<double> currPlantRatings = currPlant.Ratings;

                if (currPlant.Ratings.Count > 0)
                {
                    double currAverageRating = currPlantRatings.Average();
                    Console.WriteLine($"- {currPlantName}; Rarity: {currRarity}; Rating: {currAverageRating:f2}");
                }
                else
                {
                    Console.WriteLine($"- {currPlantName}; Rarity: {currRarity}; Rating: {0:f2}");
                }
            }

        }
    }
}
