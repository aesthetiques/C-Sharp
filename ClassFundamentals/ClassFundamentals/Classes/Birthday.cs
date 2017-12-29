using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentalsClasses.Classes
{
    class Birthday : Party
    {
        public bool Decorations { get; set; }
        public int NumPresents { get; set; }

        public void EatCake()
        {
            Console.WriteLine("The cake is a lie.");
        }

    }
}
