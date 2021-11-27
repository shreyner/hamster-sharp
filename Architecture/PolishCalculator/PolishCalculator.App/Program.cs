using System;

namespace PolishCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string infix;
            Console.Write("Infix > ");

            while ((infix = Console.ReadLine()) == null || String.IsNullOrWhiteSpace(infix))
            {
                Console.Write("Выражение не может быть пусытм\n");
                Console.Write("Infix > ");
            }

            PolishNotationCalc polishNotationCalc = new ();
            InfixToPostfixConverter infixToPostfixConverter = new();

            var postfix = infixToPostfixConverter.Parse(infix);
            Console.WriteLine($"Postfix > {postfix}");
            Console.WriteLine($"Result > {polishNotationCalc.Calc(postfix)}");
        }
    }
}
