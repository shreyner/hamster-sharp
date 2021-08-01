using System;
using System.Collections.Generic;

namespace ADLesson_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNotSorted = new List<int>(new[] {0, 5, 6, 3, 8, 4, 2, 1, 7, 9});

            Console.WriteLine("Input: {0}\nResult: {1}",
                string.Join(
                    ", ",
                    inputNotSorted),
                string.Join(
                    ", ",
                    SortHelpers.BubbleSort(inputNotSorted))
            );
        }
    }
}