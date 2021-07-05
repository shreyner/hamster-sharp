using System;
using System.Linq;

namespace Lesson_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int minDeg = parseNumber("Введите минимальную температуру за день: ");
            int maxDeg = parseNumber("Введите максимальную температуру за день: ");

            int avgDeg = findAverage(minDeg, maxDeg);

            Console.WriteLine($"Средняя температура за день: {avgDeg}");
        }


        static int findAverage(params int[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }

        static int parseNumber(string message)
        {
            int parsedNumber;

            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out parsedNumber))
            {
                Console.WriteLine("Введите целое число");
                Console.Write(message);
            }

            return parsedNumber;
        }
    }
}
