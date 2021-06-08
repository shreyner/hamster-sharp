using System;

namespace Lesson_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var mothNumber = parseNumber();
            var mothName = getMothByNumber(mothNumber);

            Console.WriteLine($"Название месяца: {mothName}");
        }

        static string getMothByNumber(int monthNumber)
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

        static int parseNumber()
        {
            int parsingNumber;

            Console.Write("Введите номер месяца: ");
            while (!int.TryParse(Console.ReadLine(), out parsingNumber))
            {
                Console.Write("Введите целове число от 1 до 12: ");
            }

            return parsingNumber;
        }
    }
}