using System;
using System.Collections.Generic;

namespace checkDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }

        public int ContainsDuplicates(string str)
        {
            var numDupes = 0;
            char checkSubStr;
            char[] stringArray = str.ToLower().ToCharArray();
            LinkedList<char> charList = new LinkedList<char>();

            foreach (char letter in stringArray)
            {
                charList.AddLast(letter);
            }

            int charListCount = charList.Count;

            while (charListCount != 0)
            {
                checkSubStr = charList.First.Value;
                charList.RemoveFirst();
                if (charList.Contains(checkSubStr)) numDupes++;
                while (charList.Contains(checkSubStr))
                {
                    charList.Remove(checkSubStr);
                }

            }

            return numDupes;
        }
    }

}
