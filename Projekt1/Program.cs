// Wykorzystanie bloku try catch

using System;

namespace Projekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number1 = GetNumberFromUser("Podaj pierwszą liczbę: ");
                double number2 = GetNumberFromUser("Podaj drugą liczbę: ");

                Console.WriteLine($"Suma liczb {number1} i {number2} wynosi: {number1 + number2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Proszę podać tylko liczby");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static double GetNumberFromUser(string message)
        {
            Console.Write(message);

            string text = Console.ReadLine();

            return Double.Parse(text.Replace('.', ','));
        }
    }
}

