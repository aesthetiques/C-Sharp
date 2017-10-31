using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            string FizzBuzz(int number)
            {
                return number % 15 == 0 ? "FizzBuzz" : number % 3 == 0 ? "Fizz" : number % 5 == 0 ? "Buzz" : $"Nope: {number}.";
            }
            Console.WriteLine(FizzBuzz(46));
            Console.Read();
        }
    }
}
