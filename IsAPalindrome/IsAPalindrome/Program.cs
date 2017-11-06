using System;

namespace IsAPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsItAPalindrome("hannah"));
        }
        public static bool IsItAPalindrome(string word)
        {
            var isPal = true;
            char[] wordArray = word.ToCharArray();
            for(int i = 0; i < wordArray.Length / 2; i++)
            {
                if(wordArray[i] != wordArray[wordArray.Length - i - 1])
                {
                    isPal = false;
                }
            }
            return isPal;
        }
    }
}
