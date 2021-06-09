using System;

namespace Lesson_2_6
{
    class Program
    {
        [Flags]
        enum DayWeek
        {
            Monday = 0b00000001,
            Tuesday = 0b00000010,
            Wednesday = 0b00000100,
            Thursday = 0b00001000,
            Friday = 0b00010000,
            Saturday = 0b01000000,
            Sunday = 0b10000000
        }

        static void Main(string[] args)
        {
            DayWeek WorkDayOfOfficeFirst = DayWeek.Tuesday | DayWeek.Wednesday | DayWeek.Thursday | DayWeek.Friday;
            DayWeek WorkDayOfOfficeSecond = DayWeek.Monday | DayWeek.Tuesday | DayWeek.Wednesday | DayWeek.Thursday |
                                            DayWeek.Friday | DayWeek.Saturday | DayWeek.Sunday;

            Console.WriteLine($"Первый офис работает по: {WorkDayOfOfficeFirst}");
            Console.WriteLine($"Второй офис работает по: {WorkDayOfOfficeSecond}");
        }
    }
}