using System;
using System.Linq;
using System.Collections.Generic;

namespace The_Pianist
{
    class Song
    {
        public Song(string name, string comp, string key)
        {
            this.Name = name;
            this.Key = key;
            this.Composer = comp;
        }
        public string Name{ get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Song> songs = new Dictionary<string, Song>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');
                string currName = tokens[0];
                string currComposer = tokens[1];
                string currKey = tokens[2];

                Song currSong = new Song(currName, currComposer, currKey);
                songs[currName] = currSong;
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tokens = input.Split('|');
                string command = tokens[0];

                if (command == "Add")
                {
                    string currName = tokens[1];
                    string currComposer = tokens[2];
                    string currKey = tokens[3];

                    if (songs.ContainsKey(currName))
                    {
                        Console.WriteLine($"{currName} is already in the collection!");
                    }
                    else
                    {
                        Song newSong = new Song(currName, currComposer, currKey);
                        songs.Add(currName, newSong);
                        Console.WriteLine($"{currName} by {currComposer} in {currKey} added to the collection!");
                    }
                }
                else if(command == "Remove")
                {
                    string currName = tokens[1];

                    if (songs.ContainsKey(currName))
                    {
                        songs.Remove(currName);
                        Console.WriteLine($"Successfully removed {currName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {currName} does not exist in the collection.");
                    }
                }
                else if(command == "ChangeKey")
                {
                    string currName = tokens[1];
                    string newKey = tokens[2];

                    if (songs.ContainsKey(currName))
                    {
                        songs[currName].Key = newKey;
                        Console.WriteLine($"Changed the key of {currName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {currName} does not exist in the collection.");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in songs)
            {
                Song currSong = item.Value;
                Console.WriteLine($"{currSong.Name} -> Composer: {currSong.Composer}, Key: {currSong.Key}");
            }
        }
    }
}
