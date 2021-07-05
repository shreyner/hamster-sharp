using System;
using System.Linq;

namespace Lesson_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите числа через пробел: ");

            var enterString = Console.ReadLine();

            var sum = enterString
                .Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Sum();

            Console.Write($"Сумма всех чиссел: {sum}");
        }
    }
}
