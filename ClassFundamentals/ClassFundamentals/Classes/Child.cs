using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentalsClasses.Classes
{

    class Child : Birthday
    {
        public string Name { get; set; }

        public void Reaction()
        {
            Console.WriteLine($"{this.Name} is happily surprised!");
        }
    }
}
