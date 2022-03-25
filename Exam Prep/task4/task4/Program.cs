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

            foreach (Match currMatch in matches)
            {
                //Console.WriteLine($"currMatch Value = {currMatch.Value}");
            }

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

            

            foreach (var item in matchList)
            {
                item.Trim();
                //Console.WriteLine(item);
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

            foreach (var item in excractedWords)
            {
                item.Trim();
                //Console.WriteLine(item);
            }

            List<string> finalWords = new List<string>();

            int cnt = 0;

            foreach (var word in excractedWords)
            {
                int index = word.Length/2 - 1;
                //Console.WriteLine($"word = {word}, index = {index}");

                string subString1 = word.Substring(0, index+1);
                string subString2 = word.Substring(index+1, word.Length-index-1);

                //subString1 = subString1.Trim();
                //subString2 = subString2.Trim();

                //Console.WriteLine($"subString1 = {subString1}");
                //Console.WriteLine($"subString2 = {subString2}");

                subString2 = ReverseBG(subString2); 
                //Console.WriteLine($"REVERSED subString2 = {subString2}");

                
                if (subString1.Equals(subString2))
                {
                    //Console.WriteLine("===" + $"{subString1}" + $" -> {cnt}");
                    cnt++;
                    finalWords.Add(subString1);
                }
            }

                if (finalWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                    Environment.Exit(0);
                }


            if (finalWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
            }
            //foreach (string word in finalWords)
            //{
            //    string reversedWord = ReverseBG(word);
            //    Console.Write($"{word} <=> {reversedWord}, ");
            //}


            bool isTrue = false;

            for (int i = 0; i < finalWords.Count-1; i++)
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

        static string ReverseBG(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
