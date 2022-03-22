using System;
using System.Linq;
using System.Collections.Generic;

namespace dd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string currCompanyName = tokens[0];
                string currEmpoyeeID = tokens[1];

                if (!myDictionary.ContainsKey(currCompanyName))
                {
                    myDictionary[currCompanyName] = new List<string>();
                }
                if (!myDictionary[currCompanyName].Contains(currEmpoyeeID))
                {
                    myDictionary[currCompanyName].Add(currEmpoyeeID);
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in myDictionary)
            {
                string currCompanyName = kvp.Key;
                List<string> currCompany_EmployeeList = kvp.Value;

                Console.WriteLine($"{currCompanyName}");

                foreach (var item in currCompany_EmployeeList)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }



    }

}
