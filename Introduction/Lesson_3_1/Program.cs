using System;

namespace Lesson_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array =
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9}
            };

            for (int i = 0; i < array.Length; i += 1)
            {
                Console.WriteLine($"Элемент из массива с кардинатами [{i}, {i}]: {array[i][i]}");
            }
        }
    }
}