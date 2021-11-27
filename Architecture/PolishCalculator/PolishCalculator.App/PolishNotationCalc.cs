using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PolishCalculator.App
{
    public class PolishNotationCalc
    {
        private Dictionary<string, Func<double, double, double>> OperatorDictionary =
            new Dictionary<string, Func<double, double, double>>
            {
                {"*", (a, b) => a * b},
                {"/", (a, b) => a / b},
                {"+", (a, b) => a + b},
                {"-", (a, b) => a - b},
            };

        public double Calc(string expr)
        {
            var operands = new Stack<double>();

            if (expr.Trim().Length == 0)
            {
                return 0;
            }

            foreach (var operand in expr.Split(" "))
            {
                double num;
                if (double.TryParse(operand, out num))
                {
                    operands.Push(num);
                    continue;
                }

                Func<double, double, double> calcFunc;
                if (!OperatorDictionary.TryGetValue(operand, out calcFunc))
                {
                    throw new Exception($"Not Supported operand {operand}");
                }

                var second = operands.Pop();
                var first = operands.Pop();

                operands.Push(calcFunc(first, second));
            }

            if (operands.Count > 1)
            {
                throw new Exception("Not validate expr");
            }

            double result;
            return operands.TryPop(out result) ? result : 0;
        }
    }
}