using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Extensions
{
    public static class ListShuffleExtension
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list, int howMuch = 1)
        {
            int result = 0;

            if (howMuch <= 0)
            {
                howMuch = 1;
            }

            for (int i = 0; i < howMuch; i++)
            {
                int n = list.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    T value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
                result++;
            }

            Console.WriteLine($"Shuffle counter: {result}");
        }
    }
}
