using System;

namespace Lesson_3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Поиск наибольшей общей подстроки.");
            var firstString = ReadString("Введите первую строку: ");
            var secondString = ReadString("Введите вторую строку: ");

            var result = findCommonSubString(firstString, secondString);

            if (result.Length == 0)
            {
                Console.WriteLine($"Нету общей подстроки");
                return;
            }

            Console.WriteLine($"Общая подстрока: {result}");
        }

        static string findCommonSubString(string firstString, string secondString)
        {
            var matrix = new int[firstString.Length, secondString.Length];
            var maxLengthSubString = 0;
            var indexSubStringOfFirstString = 0;

            for (int firstStringIndex = 0; firstStringIndex < firstString.Length; firstStringIndex++)
            {
                for (int secondStringIndex = 0; secondStringIndex < secondString.Length; secondStringIndex++)
                {
                    if (firstString[firstStringIndex] == secondString[secondStringIndex])
                    {
                        matrix[firstStringIndex, secondStringIndex] = firstStringIndex == 0 || secondStringIndex == 0
                            ? 1
                            : matrix[firstStringIndex - 1, secondStringIndex - 1] + 1;

                        if (matrix[firstStringIndex, secondStringIndex] > maxLengthSubString)
                        {
                            maxLengthSubString = matrix[firstStringIndex, secondStringIndex];
                            indexSubStringOfFirstString = firstStringIndex;
                        }


                        continue;
                    }

                    matrix[firstStringIndex, secondStringIndex] = 0;
                }
            }

            return firstString.Substring(indexSubStringOfFirstString - maxLengthSubString + 1,
                maxLengthSubString);
        }

        static string ReadString(string message)
        {
            string result;
            do
            {
                Console.Write(message);
                result = Console.ReadLine();
            } while (result == null);

            return result;
        }
    }
}