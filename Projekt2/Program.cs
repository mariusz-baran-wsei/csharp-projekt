// Funkcje, przekazywanie przez wartość i przez referencję

using System;

namespace Projekt2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };

            PrintArray(numbers);
            ReverseArray(numbers);
            PrintArray(numbers);

            Console.ReadKey();
        }

        static void ReverseArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                Swap(ref numbers[i], ref numbers[numbers.Length - i - 1]);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void PrintArray(int[] numbers)
            => Console.WriteLine(String.Join(' ', numbers));
    }
}
