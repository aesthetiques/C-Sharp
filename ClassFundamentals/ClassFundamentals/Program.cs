using FundamentalsClasses.Classes;
using System;

namespace ClassFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Child brat = new Child();
            brat.Name = "David";
            brat.Reaction();

            Console.ReadLine();
        }
    }
}
