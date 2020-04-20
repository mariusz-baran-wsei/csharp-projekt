using System;
using System.Collections.Generic;

namespace Projekt4
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

            PopulateAndPrintStack(stack);
            PrintAndClearStack(stack);
        }

        static void PopulateAndPrintStack(Stack<int> stack)
        {
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i + 1);

                Console.WriteLine($"Dodaję na stos: {i + 1}");
            }
        }

        static void PrintAndClearStack(Stack<int> stack)
        {
            while (stack.Count > 0)
            {
                int number = stack.Pop();

                Console.WriteLine($"Zdejmuję ze stosu: {number}");
            }

            Console.WriteLine("Stos jest pusty.");
        }
    }
}
