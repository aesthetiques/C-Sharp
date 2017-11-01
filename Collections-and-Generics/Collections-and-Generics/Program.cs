using System;
using System.Collections.Generic;
using static System.Collections.IEnumerable;

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
             * when initialing a list, pass in the values [similar to array instantiation in JS]
             */
            List<string> initializedList = new List<string> { "caleb", "allie", "kyle" };
            
            initializedList.Remove("kyle");

            foreach(string name in initializedList)
            {
                Console.WriteLine(name);
            }

            initializedList.RemoveAt(initializedList.IndexOf("allie"));

            foreach (string name in initializedList)
            {
                Console.WriteLine($"And then there was one. {name}.");
            }

            Car lamborghini = new Car();
            lamborghini.CarColor = Color.FireRed;
            Car corvette = new Car();
            corvette.CarColor = Color.Plum;
            Car rangeRover = new Car();
            rangeRover.CarColor = Color.Mahogany;

            List<Car> carList = new List<Car> { lamborghini, corvette, rangeRover };

            Garage<Car> pacificPlaceGarage = new Garage<Car>();

            pacificPlaceGarage.Add(lamborghini);
            pacificPlaceGarage.Add(corvette);
            pacificPlaceGarage.Add(new Car { CarColor = Color.Plum });

            /*Enumerable means it can be iterated through.
             */
            foreach(Car vehicle in pacificPlaceGarage)
            {
                Console.WriteLine(vehicle.CarColor);
            }

            Console.WriteLine(pacificPlaceGarage);
        }
    }
}
