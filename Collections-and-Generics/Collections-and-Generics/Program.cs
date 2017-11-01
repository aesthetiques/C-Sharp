using System;
using System.Collections.Generic;

namespace CollectionsAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Car lambo = new Car();
            lambo.CarColor = Color.FireRed;
            Console.WriteLine(lambo.CarColor);

            //Non-generics: 
            /*ArrayLists
             * HashTables
             * Queues
             * Stacks
             * High Enumerables
             * High Collections
             * 
             * The difference between the two is that you can put any data into it that you want to.
             * A Generic doesn't let you do that. It's more strongly typed, in that you must follow the predefined
             * rules that you give it. Because of this, Generics are more performant, due to not boxing and unboxing 
             * the data. Non-generics are often going unused. Ex List below:
             */
            
            List<string> vroomList = new List<string>();
            vroomList.Add("Caleb");
            vroomList.Add("Kyle");
            vroomList.Add("Allie");

            foreach(string name in vroomList)
            {
                Console.WriteLine(name);
            }

            /*Biggest difference between a list or an array is that Lists aren't immutable. Under the hood, a List
             *duplicates an array and doubles its length, and returns a new array which is the list. If you don't 
             * know the size of the completed array, use a list.
             */

            /*Collection Initializers
             *Instead of running through list.Add(); a million times you can do: 
             * when initi
             */
            List<string> initializedList = new List<string> { "caleb", "allie", "kyle" };
            
            foreach(string name in initializedList)
            {
                Console.WriteLine(name);
            }
             
        }
    }
}
