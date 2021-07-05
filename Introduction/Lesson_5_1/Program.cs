using System;
using System.IO;
using System.Text;

namespace Lesson_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст для записи в файл: ");
            var someText = Console.ReadLine();

            var fileName = "./text.txt";
            File.WriteAllText(fileName, someText, Encoding.UTF8);
        }
    }
}