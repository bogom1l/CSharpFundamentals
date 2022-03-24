using System;
using System.Linq;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Problem 1 - Secret Chat

            string message = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] tokens = input.Split(":|:");
                string command = tokens[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                }
                else if(command == "Reverse")
                {
                    string subString = tokens[1];
                    if (!message.Contains(subString))
                    {
                        Console.WriteLine("error");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (message.Contains(subString))
                    {
                        message = message.Remove(message.IndexOf(subString), subString.Length);
                        message = message + string.Join("", subString.Reverse());
                    }
                }
                else if(command == "ChangeAll")
                {
                    string subString = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(subString, replacement);
                }
                Console.WriteLine(message);

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");

        }
    }
}
