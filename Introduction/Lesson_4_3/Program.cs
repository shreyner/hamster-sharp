using System;
using System.Diagnostics.CodeAnalysis;

namespace Lesson_4_3
{
    enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    class Program
    {
        static void Main(string[] args)
        {
            var monthNumber = ReadMonthNumber();
            var season = GetSeasonByMonthNumber(monthNumber);
            var seasonName = GetSeasonNameBySeason(season);

            Console.WriteLine($"Время года: {seasonName}");
        }

        static Season GetSeasonByMonthNumber(int monthNumber)
        {
            switch (monthNumber)
            {
                case 12:
                case > 0 and <= 2:
                    return Season.Winter;
                case <= 5:
                    return Season.Spring;
                case <= 8:
                    return Season.Summer;
                case <= 11:
                    return Season.Autumn;
                default:
                    return Season.Winter;
            }
        }

        static string GetSeasonNameBySeason(Season season)
        {
            switch (season)
            {
                case Season.Autumn:
                    return "Осень";
                case Season.Spring:
                    return "Весна";
                case Season.Summer:
                    return "Лето";
                case Season.Winter:
                default:
                    return "Зима";
            }
        }

        static int ReadMonthNumber()
        {
            Console.Write("Введите номер месяца: ");
            int parsedMonthNumber;

            while (!int.TryParse(Console.ReadLine(), out int parsedNumber) ||
                   !TryParseMonthNumber(parsedNumber, out parsedMonthNumber))
            {
                Console.Write("Ошибка: введите число от 1 до 12: ");
            }

            return parsedMonthNumber;
        }

        static bool TryParseMonthNumber(int? n, out int monthNumber)
        {
            if (n == null)
            {
                monthNumber = 1;
                return false;
            }

            monthNumber = (int) n;

            return n >= 1 & n <= 12;
        }
    }
}