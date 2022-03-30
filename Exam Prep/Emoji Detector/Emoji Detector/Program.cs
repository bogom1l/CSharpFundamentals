using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([\:\:]{2}|[\*\*]{2})(?<word>[A-Z]{1}[a-z]{2,})\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            long threshold = 1;

            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    threshold *= c - '0';
                }
            }

            Console.WriteLine($"Cool threshold: {threshold}");

            List<string> final = new List<string>();

            foreach (Match match in matches)
            {
                string currWord = match.Groups["word"].Value;
                int currValue = calculateAsciiValueOfWord(currWord);
                //Console.WriteLine($"word = {currWord}");
                //Console.WriteLine($"currValue = {currValue}");
                if (currValue > threshold)
                {
                    final.Add(match.Value);
                }
            }

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (var item in final)
            {
                Console.WriteLine(item);
            }

        }

        static int calculateAsciiValueOfWord(string word)
        {
            int sum = 0;

            foreach (char c in word)
            {
                sum += (int)c;
            }

            return sum;
        }
    }
}
