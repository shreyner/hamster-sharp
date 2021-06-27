using System;

namespace Lesson_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = "some secret password";
            Console.WriteLine("Enter password:");
            var input = Console.ReadLine();
            Console.WriteLine("After decompile");
            if (input == secret)
            {
                Console.WriteLine("Welcome!");
                return;
            }
        }
    }
}