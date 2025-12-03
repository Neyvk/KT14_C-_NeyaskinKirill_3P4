using System;
using System.Collections.Generic;

class Program
{

    static int EvaluateExpression(string expression)
    {
        Dictionary<char, int> precedence = new Dictionary<char, int>
        {
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2}
        };

        List<string> postfix = InfixToPostfix(expression, precedence);
        return EvaluatePostfix(postfix);
    }

    static List<string> InfixToPostfix(string expr, Dictionary<char, int> precedence)
    {
        Stack<char> stack = new Stack<char>();
        List<string> output = new List<string>();

        int i = 0;
        while (i < expr.Length)
        {
            char c = expr[i];

            if (char.IsDigit(c))
            {
                string num = "";
                while (i < expr.Length && char.IsDigit(expr[i]))
                {
                    num += expr[i];
                    i++;
                }
                output.Add(num);
                continue;
            }

            if (precedence.ContainsKey(c))
            {
                while (stack.Count > 0 && precedence[stack.Peek()] >= precedence[c])
                {
                    output.Add(stack.Pop().ToString());
                }
                stack.Push(c);
            }
            i++;
        }

        while (stack.Count > 0)
        {
            output.Add(stack.Pop().ToString());
        }

        return output;
    }

    static int EvaluatePostfix(List<string> postfix)
    {
        Stack<int> stack = new Stack<int>();

        foreach (var token in postfix)
        {
            if (int.TryParse(token, out int num))
            {
                stack.Push(num);
            }
            else
            {
                int b = stack.Pop();
                int a = stack.Pop();
                int res = token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => throw new Exception("Неизвестный оператор")
                };
                stack.Push(res);
            }
        }

        return stack.Pop();
    }

    static void Main()
    {
        Console.WriteLine("Введите арифметическое выражение");
        string input = Console.ReadLine();

        int result = EvaluateExpression(input);
        Console.WriteLine($"Результат: {result}");
    }
}
