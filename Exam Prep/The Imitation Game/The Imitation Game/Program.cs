using System;
using System.Linq;

namespace The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = Console.ReadLine();

            string decryptedMessage = message;

            while (input != "Decode")
            {
                string[] tokens = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(tokens[1]);

                    for (int i = 0; i < numberOfLetters; i++)
                    {
                        decryptedMessage = Move(decryptedMessage);
                    }
                }
                else if(command == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];

                    decryptedMessage = decryptedMessage.Insert(index, value);
                }
                else if(command == "ChangeAll")
                {
                    string subStr = tokens[1];
                    string replacement = tokens[2];

                    decryptedMessage = decryptedMessage.Replace(subStr, replacement);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {decryptedMessage}");

        }
    
        static string Move(string text)
        {
            char firstLetter = text.First();

            text = text.Remove(0, 1);
            text += firstLetter;

            return text;
        }
    
    }
}
