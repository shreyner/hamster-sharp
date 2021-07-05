using System;

namespace ADLesson_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "На вход подаем {0}, ожидаем 'Простое'. Результат: {1}",
                1,
                PrimeNumber.check(1) ? "Простое" : "Не простое"
            );
            Console.WriteLine(
                "На вход подаем {0}, ожидаем 'Простое'. Результат: {1}",
                2,
                PrimeNumber.check(2) ? "Простое" : "Не простое"
            );
            Console.WriteLine(
                "На вход подаем {0}, ожидаем 'Простое'. Результат: {1}",
                3,
                PrimeNumber.check(3) ? "Простое" : "Не простое"
            );
            Console.WriteLine(
                "На вход подаем {0}, ожидаем 'Не простое'. Результат: {1}",
                4,
                PrimeNumber.check(4) ? "Простое" : "Не простое"
            );
            Console.WriteLine(
                "На вход подаем {0}, ожидаем 'Простое'. Результат: {1}",
                59,
                PrimeNumber.check(59) ? "Простое" : "Не простое"
            );
            Console.WriteLine(
                "На вход подаем {0}, ожидаем 'Не простое'. Результат: {1}",
                60,
                PrimeNumber.check(60) ? "Простое" : "Не простое"
            );
        }
    }
}