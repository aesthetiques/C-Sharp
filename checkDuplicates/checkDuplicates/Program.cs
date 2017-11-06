using System;
using System.Collections.Generic;

namespace checkDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ContainsDuplicates("hello");
        }

        public static int ContainsDuplicates(string str)
        {
            var numDupes = 0;
            char checkSubStr = ' ';
            List<char> charList = new List<char>(str);

            while (charList.Count > 0)
            {
                checkSubStr = charList[0];
                charList.RemoveAt(0);
                if (charList.Contains(checkSubStr)) numDupes++;
                while (charList.Contains(checkSubStr))
                {
                    charList.Remove(checkSubStr);
                }
            }

            Console.WriteLine($"number of dupes: {numDupes}");
            return numDupes;
        }

    }

}
