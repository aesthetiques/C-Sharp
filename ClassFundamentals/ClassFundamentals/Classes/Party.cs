using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentalsClasses.Classes
{
    class Party
    //Classes can be designed to be inherited from. In this case, 
    //there are a few party types to be created, and they will all 
    //inherit from party. Any further changes can be created as 
    //"grandchildren" through their direct parent. ex: a Birthday class
    //can be created for adults, it could inherit from Birthday, which
    //in turn will inherit from Party, granting all of the Party class'
    //functionality.
    {
        public int NumberOfPeople { get; set; }
        public int Budget { get; set; }
        public bool Liquor { get; set; }
        public string Location { get; set; }
        public string Menu { get; set; }
        public string Entertainment { get; set; }

        public void Dance()
        {
            Console.WriteLine("We dance.");
        }

        public void MeetPpl()
        {
            Console.WriteLine("I like to be as antisocial as possible.");
        }
    }
}
