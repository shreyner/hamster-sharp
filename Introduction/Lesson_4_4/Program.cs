using System;

namespace Lesson_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = ConsoleReadNumber();

            Console.WriteLine($"Числа фибоначи: {Fib(number)}");
        }

        static int Fib(int num)
        {
            if (num is 0 or 1)
            {
                return num;
            }

            if (num < 0) // для отрицательных
            {
                return Fib(num + 2) - Fib(num + 1);
            }

            return Fib(num - 1) + Fib(num - 2);
        }

        static int ConsoleReadNumber()
        {
            int parsedNumber;
            Console.Write("Введите натуральное число: ");
            while (!int.TryParse(Console.ReadLine(), out parsedNumber))
            {
                Console.Write("Введите натуральное число: ");
            }

            return parsedNumber;
        }
    }
}