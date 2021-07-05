using System;
using System.Linq;

namespace Lesson_2_5
{
    class Program
    {
        enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        static bool IsWinter(Month month)
        {
            return month is Month.December or Month.January or Month.February;
        }

        static void Main(string[] args)
        {
            Month monthNumber = ConsoleReadMonth();
            var avgDeg = GetAverageDeg();


            Console.WriteLine($"Месяц: {GetMothByNumber((int) monthNumber)}, Средняя температура: {avgDeg}");

            if (IsWinter(monthNumber) && avgDeg > 0)
            {
                Console.WriteLine("Теплая зима");
            }
        }

        static Month ConsoleReadMonth()
        {
            while (true)
            {
                var monthNumber = ConsoleReadNumber("Введите номер месяца от 1 до 12: ");

                if (monthNumber is >= 1 and <= 12)
                {
                    Month month = (Month) monthNumber;
                    return month;
                }
            }
        }

        static int ConsoleReadNumber(string message)
        {
            int parsedNumber;

            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out parsedNumber));

            return parsedNumber;
        }

        static int GetAverageDeg()
        {
            var minDeg = ConsoleReadNumber("Введите минимальную температуру за день: ");
            var maxDeg = ConsoleReadNumber("Введите максимальную температуру за день: ");

            var avgDeg = CalcAverage(minDeg, maxDeg);

            return avgDeg;
        }

        static int CalcAverage(params int[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }

        static string GetMothByNumber(int monthNumber)
        {
            switch (monthNumber)
            {
                case 1:
                    return "Январь";
                case 2:
                    return "Ферлаь";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентабрь";
                case 10:
                    return "Октабрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
                default:
                    return null;
            }
        }
    }
}