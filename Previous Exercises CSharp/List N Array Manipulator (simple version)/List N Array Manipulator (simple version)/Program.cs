using System;
using System.Collections.Generic;
using System.Linq;

namespace ListS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //* Array Manipulator

            List<int> myList = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            int count = 1;
            string evenORodd = string.Empty;

            while (command != "end")
            {
                string[] token = command.Split();

                string action = token[0];

                if (action == "exchange")
                {
                    int index = int.Parse(token[1]);
                    if (index > myList.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }
                    List<int> exchangedList = exchangeList(myList, index);
                    myList = exchangedList;
                    //Console.WriteLine(String.Join(" ", exchangedList));
                }

                if (command == "min even")
                {
                    int minEindex = minEven(myList);
                    if (minEindex < 0)
                        Console.WriteLine("No Matches");
                    else
                        Console.WriteLine(minEindex);
                }
                if (command == "min odd")
                {
                    int minOindex = minOdd(myList);
                    if (minOindex < 0)
                        Console.WriteLine("No Matches");
                    else
                        Console.WriteLine(minOindex);
                }
                if (command == "max even")
                {
                    int maxEindex = maxEven(myList);
                    if (maxEindex < 0)
                        Console.WriteLine("No Matches");
                    else
                        Console.WriteLine(maxEindex);
                }
                if (command == "max odd")
                {
                    int maxOindex = maxOdd(myList);
                    if (maxOindex < 0)
                        Console.WriteLine("No Matches");
                    else
                        Console.WriteLine(maxOindex);
                }

                if (action == "first")
                {
                    count = int.Parse(token[1]);
                    evenORodd = token[2];

                    if (count > myList.Count)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }

                    if (evenORodd == "even")
                    {
                        List<int> firstEvenList = firstEven(myList, count);
                        Console.Write("[");
                        Console.Write(String.Join(", ", firstEvenList));
                        Console.Write("]");
                        Console.WriteLine();
                    }
                    else if (evenORodd == "odd")
                    {
                        List<int> firstOddList = firstOdd(myList, count);
                        Console.Write("[");
                        Console.Write(String.Join(", ", firstOddList));
                        Console.Write("]");
                        Console.WriteLine();
                    }
                }
                if (action == "last") //sometimes dont work... have to fix em
                {
                    count = int.Parse(token[1]);
                    evenORodd = token[2];
                    if (evenORodd == "even")
                    {
                        List<int> lastEvenList = lastEven(myList, count);
                        Console.Write("[");
                        Console.Write(String.Join(", ", lastEvenList));
                        Console.Write("]");
                        Console.WriteLine();
                    }
                    else if (evenORodd == "odd")
                    {
                        List<int> lastOddList = lastOdd(myList, count);
                        Console.Write("[");
                        Console.Write(String.Join(", ", lastOddList));
                        Console.Write("]");
                        Console.WriteLine();
                    }
                }

                command = Console.ReadLine();
            }

            Console.Write("[");
            Console.Write(String.Join(", ", myList));
            Console.Write("]");

        }

        static List<int> exchangeList(List<int> myList, int index)
        {
            List<int> exchangedList = new List<int>();

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 0; i < myList.Count; i++)
            {
                if (i > index)
                {
                    list2.Add(myList[i]);
                }
                else
                {
                    list1.Add(myList[i]);
                }
            }
            //Console.WriteLine(String.Join(" , ", list1));
            //Console.WriteLine(String.Join(" - ", list2));

            for (int i = 0; i < list2.Count; i++)
            {
                exchangedList.Add(list2[i]);
            }
            for (int i = 0; i < list1.Count; i++)
            {
                exchangedList.Add(list1[i]);
            }

            //Console.WriteLine(String.Join(" _ ", exchangedList));
            return exchangedList;
        }

        static int minEven(List<int> myList)
        {
            int minEven = int.MaxValue;
            int minEvenIndex = -1;

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] % 2 == 0)
                {
                    if (myList[i] < minEven)
                    {
                        minEven = myList[i];
                        minEvenIndex = i;
                    }
                }
            }
            return minEvenIndex;
        }

        static int minOdd(List<int> myList)
        {
            int minOdd = int.MaxValue;
            int minOddIndex = -1;

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] % 2 != 0)
                {
                    if (myList[i] < minOdd)
                    {
                        minOdd = myList[i];
                        minOddIndex = i;
                    }
                }
            }
            return minOddIndex;
        }


        static int maxEven(List<int> myList)
        {
            int maxEven = int.MinValue;
            int maxEvenIndex = -1;

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] % 2 == 0)
                {
                    if (myList[i] > maxEven)
                    {
                        maxEven = myList[i];
                        maxEvenIndex = i;
                    }
                }
            }
            return maxEvenIndex;
        }

        static int maxOdd(List<int> myList)
        {
            int maxOdd = int.MinValue;
            int maxOddIndex = -1;

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] % 2 != 0)
                {
                    if (myList[i] > maxOdd)
                    {
                        maxOdd = myList[i];
                        maxOddIndex = i;
                    }
                }
            }
            return maxOddIndex;
        }

        static List<int> firstEven(List<int> myList, int count)
        {
            List<int> firstEven = new List<int>();
            int cnt = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] % 2 == 0)
                {
                    firstEven.Add(myList[i]);
                    cnt++;
                }
                if (cnt == count)
                {
                    return firstEven;
                }
            }
            return firstEven;
        }

        static List<int> firstOdd(List<int> myList, int count)
        {
            List<int> firstOdd = new List<int>();
            int cnt = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] % 2 != 0)
                {
                    firstOdd.Add(myList[i]);
                    cnt++;
                }
                if (cnt == count)
                {
                    return firstOdd;
                }
            }
            return firstOdd;
        }

        static List<int> lastEven(List<int> myList, int count)
        {
            List<int> lastEven = new List<int>();
            int cnt = 0;

            for (int i = myList.Count - 1; i >= 0; i--)
            {
                if (myList[i] % 2 == 0)
                {
                    lastEven.Add(myList[i]);
                    cnt++;
                }
                if (cnt == count)
                {
                    return lastEven;
                }
            }
            Array.Reverse(lastEven.ToArray());
            return lastEven;
        }

        static List<int> lastOdd(List<int> myList, int count)
        {
            List<int> lastOdd = new List<int>();
            int cnt = 0;

            for (int i = myList.Count - 1; i >= 0; i--)
            {
                if (myList[i] % 2 != 0)
                {
                    lastOdd.Add(myList[i]);
                    cnt++;
                }
                if (cnt == count)
                {
                    return lastOdd;
                }
            }
            Array.Reverse(lastOdd.ToArray());
            return lastOdd;
        }


    }
}
