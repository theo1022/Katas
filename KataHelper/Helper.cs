using System;

namespace KataHelper
{
    public class Helper
    {
        public static string[] Enable1()
        {
            return RawData.Enable1Raw.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string[] FirstNames()
        {
            return RawData.FirstNamesRaw.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string[] LastNames()
        {
            return RawData.LastNamesRaw.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] GetRandomNames(int amount, int? seed = null)
        {
            string[] names = new string[amount];

            string[] firstNames = FirstNames();
            string[] lastNames = LastNames();

            Random rand = seed.HasValue ? new Random(seed.Value) : new Random();

            for (int i = 0; i < names.Length; i++)
            {
                string first = firstNames[rand.Next(0, firstNames.Length)];
                string last = lastNames[rand.Next(0, lastNames.Length)];
                names[i] = first + " " + last;
            }

            return names;
        }
    }
}
