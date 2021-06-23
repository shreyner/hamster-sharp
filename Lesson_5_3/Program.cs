using System;
using System.IO;

namespace Lesson_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            byte someNumber;
            do
            {
                Console.Write("Введите число от 0 до 255: ");
            } while (!byte.TryParse(Console.ReadLine(), out someNumber));


            File.WriteAllBytes("./binary.bin", new[] {someNumber});
        }
    }
}