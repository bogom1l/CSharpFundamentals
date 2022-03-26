using System;

namespace world_tour
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            string stopStr = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0]; 

                if (command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);   
                    string replacement = tokens[2];

                    stopStr = InsertString(stopStr, index, replacement);
                    Console.WriteLine(stopStr);
                }
                else if(command == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    stopStr = RemoveStringInRage(stopStr, startIndex, endIndex);
                    Console.WriteLine(stopStr);
                }
                else if(command == "Switch")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];

                    stopStr = stopStr.Replace(oldString, newString);

                    Console.WriteLine(stopStr);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stopStr}");
        }

        static string ReplaceAllOccurrances(string originalString, string oldString, string newString)
        {
            string modifiedString = originalString.Replace(oldString, newString);

            return modifiedString;
        }

        static string RemoveStringInRage(string originalString, int startIndex, int endIndex)
        {
            if (!isIndexValid(startIndex, originalString))
            {
                return originalString;
            }
            if (!isIndexValid(endIndex, originalString))
            {
                return originalString;
            }

            string modifiedString = originalString.Remove(startIndex, endIndex - startIndex + 1);
            return modifiedString;
        }

        static string InsertString(string originalString, int index, string replacement)
        {
            if (!isIndexValid(index, originalString))
            {
                return originalString; 
            }

            string modifiedString = originalString.Insert(index, replacement);
            return modifiedString;
        }

        static bool isIndexValid(int i, string s)
        {
            return i >= 0 && i < s.Length;
        }

    }
}
