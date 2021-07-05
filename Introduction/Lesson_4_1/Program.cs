using System;

namespace Lesson_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFullName("Светлана", "Шарова", "Иванова"));
            Console.WriteLine(GetFullName("Антонида", "Мясникова", "Владимировна"));
            Console.WriteLine(GetFullName("Степан", "Нестеров", "Вадимов"));
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }
    }
}