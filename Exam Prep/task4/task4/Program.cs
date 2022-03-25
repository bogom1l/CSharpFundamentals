using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@#])(?<word>[A-Za-z]{3,})(\1)(\1)(?<word2>[A-Za-z]{3,})(\1)";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            List<string> matchList = new List<string>();

            foreach (Match currMatch in matches)
            {  
                matchList.Add(currMatch.Value);//currMatch.Value
            }

            List<string> excractedWords = new List<string>();

            foreach (string text in matchList)
            {
                string newCurrWord = string.Empty;
                foreach (char c in text)
                {
                    if (Char.IsLetterOrDigit(c))
                    {
                        newCurrWord += c;
                    }
                }
                excractedWords.Add(newCurrWord);
            }

            List<string> finalWords = new List<string>();

            int cnt = 0;
            foreach (var word in excractedWords)
            {
                int index = word.Length/2 - 1;

                string subString1 = word.Substring(0, index+1);
                string subString2 = word.Substring(index+1, word.Length-index-1);

                string reversedSecondWord = ReverseBG(subString2); 
                
                if (subString1.Equals(reversedSecondWord))
                {
                    //Console.WriteLine("===" + $"{subString1}" + $" -> {cnt}");
                    cnt++;
                    finalWords.Add(subString1);
                }
            }

            if (finalWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                bool isTrue = false;

                for (int i = 0; i < finalWords.Count - 1; i++)
                {
                    string word = finalWords[i];
                    string reversedWord = ReverseBG(word);
                    Console.Write($"{word} <=> {reversedWord}, ");
                    isTrue = true;
                }

                if (isTrue)
                {
                    string lastWord = finalWords[finalWords.Count - 1];
                    string reversedLastWord = ReverseBG(lastWord);
                    Console.Write($"{lastWord} <=> {reversedLastWord}");
                }
            }  

        }

        static string ReverseBG(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
