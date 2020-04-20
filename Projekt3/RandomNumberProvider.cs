using System;

namespace Projekt3
{
    static class RandomNumberProvider
    {
        static Random Rnd = new Random();

        public static int GetNumber(int max)
        {
            return Rnd.Next(max);
        }
    }
}
