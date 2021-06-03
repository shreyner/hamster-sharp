using System;

namespace Lesson1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Квадратное уравнение");


            var a = readA("Введите a: ");
            var b = readNumber("Введите B: ");
            var c = readNumber("Введите C: ");

            var discriminant = Math.Pow(b, 2) - 4 * a * c;

            Console.WriteLine($"Дискриминант равен: {discriminant}");

            if (discriminant < 0)
            {
                Console.WriteLine($"Не имеет корней");
                return;
            }

            if (discriminant == 0)
            {
                var x1 = (-1 * b) / (2 * a);
                Console.WriteLine($"Имеет один корень: {x1}");
                return;
            }

            if (discriminant > 0)
            {
                var x1 = (-1 * b + Math.Sqrt(discriminant)) / (2 * a);
                var x2 = (-1 * b - Math.Sqrt(discriminant)) / (2 * a);

                Console.WriteLine($"Имеет два корня: {x1}, {x2}");
                return;
            }


            Console.ReadLine();
        }

        static int readNumber(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введите целое число");
                }
            }
        }

        static int readA(string message)
        {
            while (true)
            {
                try
                {
                    var a = readNumber(message);

                    if (a == 0)
                    {
                        throw new Exception();
                    }

                    return a;
                }
                catch
                {
                    Console.WriteLine("Введите целое число не равное 0");
                }
            }
        }
    }
}