using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace destination_mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            string pattern = @"(\=|\/)([A-Z][a-zA-Z]{2,})(\1)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            List<string> final = new List<string>();
            
            foreach (Match match in matches)
            {
                final.Add(match.Value);
            }

            final = MakeStringsOnlyLetters(final);

            Console.WriteLine($"Destinations: {string.Join(", ", final)}");
            Console.WriteLine($"Travel Points: {CalculateTravelPointsList(final)}");
            */
            //easier solution
            Regex regex2 = new Regex(@"(\=|\/)([A-Z][a-zA-Z]{2,})(\1)");
            MatchCollection matches2 = regex2.Matches(Console.ReadLine());

            List<string> destinations = new List<string>();
            int travelPoints = 0;

            foreach (Match match in matches2)
            {
                string currDestination = match.Groups[2].Value;

                destinations.Add(currDestination);
                travelPoints += currDestination.Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");

        }

        static int CalculateTravelPointsList(List<string> myList)
        {
            int sum = 0;
            foreach (string currText in myList)
            {
                sum += currText.Length;
            }

            return sum;
        }
        static List<string> MakeStringsOnlyLetters(List<string> myList)
        {
            List<string> finalList = new List<string>();

            foreach (string currText in myList)
            {
                string finalString = string.Empty;
                foreach (char c in currText)
                {
                    if (Char.IsLetter(c))
                    {
                        finalString += c;
                    }
                }
                finalList.Add(finalString);
            }
            return finalList;
        }
    }
}
