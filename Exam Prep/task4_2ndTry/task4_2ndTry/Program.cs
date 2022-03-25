using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace task4_2ndTry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"([@#])(?<word>[A-Za-z]{3,})(\1)(\1)(?<word2>[A-Za-z]{3,})(\1)");

            string message = Console.ReadLine();

            MatchCollection matches = pattern.Matches(message);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            List<string[]> results = new List<string[]>();

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["word"].Value;
                string secondWord = match.Groups["word2"].Value;

                string reversedSecondWord = string.Join("", secondWord.Reverse());

                if (firstWord == reversedSecondWord)
                {
                    results.Add(new string[] { firstWord, secondWord });
                }
            }

            if (results.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                // List<string[]> results = new List<string[]>();
                string[] messages = results.Select(words => $"{words[0]} <=> {words[1]}").ToArray();
                
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", messages));
            }
        }
    }
}
