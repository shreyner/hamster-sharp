using System;
using System.Linq;

namespace Lesson_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            var someString = Console.ReadLine();
            var reverseString = string.Join("", someString.ToArray().Reverse());


            Console.WriteLine($"Введенная строка на оборот: {reverseString}");
        }
    }
}
