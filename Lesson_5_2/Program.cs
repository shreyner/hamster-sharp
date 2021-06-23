using System;
using System.IO;

namespace Lesson_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateNow = DateTime.UtcNow;
            var fileName = "./currentTime.txt";

            File.AppendAllText(fileName, $"{dateNow.ToString("O")}\n");
        }
    }
}
