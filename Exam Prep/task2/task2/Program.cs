using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //02. Fancy Barcodes

            int n = int.Parse(Console.ReadLine());

            Regex pattern = new Regex(@"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+");            

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (pattern.IsMatch(input))
                {
                    string number = string.Empty;
                    bool isFound = false;
                    foreach (var c in input)
                    {
                        if (Char.IsDigit(c))
                        {
                            number += c;
                            isFound = true;
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {number}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }

        }
    }
}
