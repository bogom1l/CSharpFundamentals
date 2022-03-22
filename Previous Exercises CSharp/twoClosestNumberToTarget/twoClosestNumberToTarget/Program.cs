using System;
using System.Linq;

namespace twoClosestNumberToTarget
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray(); // { -1, 3, 8, 2, 9, 5 };
            // -1, 3, 8, 2, 9, 5 
            // 1 2 4 5 8

            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray(); //{ 4, 1, 2, 10, 5, 20 }; 
            // 4,1,2,10,5,20
            // 7 3 11 2 1

            Console.WriteLine("Please enter target:");
            int target = int.Parse(Console.ReadLine()); // 24;
            //14
            int arroundTarget = 99;
            int arroundTarget2 = 1;

            int[] arr3 = new int[(arr1.Length * arr2.Length) + 1]; //all possible sums are members of this array
            int arr3index = 0;


            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (((arr1[i] + arr2[j]) > arroundTarget2) && ((arr1[i] + arr2[j]) < arroundTarget))
                    {
                        arr3[arr3index] = arr1[i] + arr2[j];
                        arr3index++;
                        //Console.WriteLine("found");
                    }
                }
            }

            //Console.WriteLine(String.Join(" ", arr3));

            int n1 = number1(arr3, target);
            int n2 = number2(arr3, target);

            Console.WriteLine("The two most closest numbers to the target (one upper and one lower) are: ");
            Console.WriteLine($"n1 = {n1}");
            Console.WriteLine($"n2 = {n2}");

        }

        static int number1(int[] arr3, int target)
        {
            int min1 = 99; //int.Maxvalue ?
            //target = 24;

            for (int i = 0; i < arr3.Length; i++)
            {
                if (arr3[i] > target)
                {
                    if (arr3[i] < min1)
                    {
                        min1 = arr3[i];
                    }
                }
            }
            //Console.WriteLine($"min1 = {min1}");

            return min1;
        }

        static int number2(int[] arr3, int target)
        {
            int max1 = 1; //int.Minvalue?
            //target = 24;

            for (int i = 0; i < arr3.Length; i++)
            {
                if (arr3[i] < target)
                {
                    if (arr3[i] > max1)
                    {
                        max1 = arr3[i];
                    }
                }
            }
            //Console.WriteLine($"max1 = {max1}");

            return max1;
        }


    }
}
