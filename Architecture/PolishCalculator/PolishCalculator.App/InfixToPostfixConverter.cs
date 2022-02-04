using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PolishCalculator.App
{
    public class InfixToPostfixConverter
    {
        private Dictionary<string, int> LexemPriority = new Dictionary<string, int>
        {
            {"+", 1},
            {"-", 1},
            {"*", 2},
            {"/", 2},
        };

        public string Parse(string infix)
        {
            var stack = new Stack<string>();
            var result = new Stack<string>();

            foreach (var lexem in infix.Split(" "))
            {
                double num;
                if (double.TryParse(lexem, out num))
                {
                    result.Push(num.ToString());
                    continue;
                }

                if (lexem == "(")
                {
                    stack.Push(lexem);
                    continue;
                }

                if (lexem == ")")
                {
                    for (int i = stack.Count - 1; i >= 0; i--)
                    {
                        var stackLastLexem = stack.Pop();

                        if (stackLastLexem == "(") {
                            break;
                        }

                        result.Push(stackLastLexem);
                        continue;
                    }
                    continue;
                }


                if (stack.Count == 0)
                {
                    stack.Push(lexem);
                    continue;
                }

                if (!LexemPriority.TryGetValue(lexem, out var priorityLexem))
                {
                    throw new Exception($"Unknown lexem {lexem}");
                }
                
                LexemPriority.TryGetValue(stack.Peek(), out var priorityLastLexem);
                
                if (
                    priorityLexem - priorityLastLexem <= 0
                )
                {
                    var lastLexem2 = stack.Pop();
                
                    result.Push(lastLexem2);
                
                    for (int i = stack.Count - 1; i >= 0; i--)
                    {
                        LexemPriority.TryGetValue(stack.Peek(), out var lastLexem3);
                
                        if (
                            priorityLexem - lastLexem3 <= 0
                        )
                        {
                            result.Push(stack.Pop());
                            continue;
                        }
                
                        break;
                    }
                
                    stack.Push(lexem);
                    continue;
                }
                
                stack.Push(lexem);
            }
            
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                result.Push(stack.Pop());
            }

            return String.Join(" ", result.Reverse());
        }
    }
}