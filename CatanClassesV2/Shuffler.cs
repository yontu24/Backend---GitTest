using System;
using System.Collections.Generic;
using System.Text;

namespace Catan
{
    public static class Shuffler
    {
        private static Random rng = new Random();
        public static List<T> Shuffle<T>(this IList<T> list)
        {
            List<T> copy = new List<T>(list);

            int n = copy.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = copy[k];
                copy[k] = copy[n];
                copy[n] = value;
            }

            return copy;
        }
    }
}
