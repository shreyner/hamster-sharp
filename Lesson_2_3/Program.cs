using System;

namespace Lesson_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = parseNumber();

            Console.WriteLine((number % 2) == 0 ? "Введенное число четное" : "Введенное число не четное");
        }

        static int parseNumber()
        {
            int parsedNumber;

            do
            {
                Console.WriteLine("Введите целое число: ");
            } while (!int.TryParse(Console.ReadLine(), out parsedNumber));

            return parsedNumber;
        }
    }
}