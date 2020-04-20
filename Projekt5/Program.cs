// Sortedset, liczenie ilości różnych znaków w tekście

using System;
using System.Collections.Generic;

namespace Projekt5
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToCheck = "This is a random text";

            Console.WriteLine($"Distinct letters int text \"{textToCheck}\": {GetDistinctLettersCount(textToCheck)}");
        }

        static int GetDistinctLettersCount(string text)
        {
            string textWithoutSpaces = text.Replace(" ", String.Empty);

            var set = new SortedSet<char>();

            // string can be passed to SortedSet constructor cause it implements IEnumerable interface

            foreach (char c in textWithoutSpaces)
            {
                set.Add(c);
            }

            return set.Count;
        }
    }
}
