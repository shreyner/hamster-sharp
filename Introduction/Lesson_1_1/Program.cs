using System;

namespace Lesson_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's your name? ");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}. Today [{DateTime.Today}]");
        }
    }
}
