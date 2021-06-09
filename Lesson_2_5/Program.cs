using System;

namespace Lesson_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var monthNumber = ConsoleReadMonth();
            var averageDeg = ConsoleReadNumber("Введите среднюю температуру за месяц: ");

            var monthName = GetMothByNumber(monthNumber);

            Console.WriteLine($"Месяц: {monthName}, Средняя температура: {averageDeg}");

            if (monthNumber >= 12 || monthNumber <= 2)
            {
                Console.WriteLine(monthNumber > 0 ? "Теплая зима" : "Нормальная зима");
            }
        }

        static int ConsoleReadMonth()
        {
            int monthNumber;
            while (true)
            {
                monthNumber = ConsoleReadNumber("Введите номер месяца от 1 до 12: ");

                if (monthNumber is >= 1 and <= 12)
                {
                    break;
                }
            }

            return monthNumber;
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