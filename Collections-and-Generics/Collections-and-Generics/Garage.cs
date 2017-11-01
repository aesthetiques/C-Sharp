using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsAndGenerics
{
    class Garage<T>
    {
        /*The thing that makes collections unique is that you can use one with any data type
         * We can make Garage a generic collection. we do that by adding the <T> by the class
         * declaration. <T> can be whatever we want it to be. This is saying that it is a 
         * generic Type.
         * Collections are just a type of fancy array. We create one 
        */

        T[] items = new T[10]; //instantiated a new array, [Array(10}]
        int count = 0;

        public void Add (T item)
        {
            items[count] = item;
            count ++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                /*This is going to look at items; at every point in incrementation,
                 * it's going to look at the data point, pull the data and return 
                 * the data that exists there.
                 */
                yield return items[i];
            }
        }
    }
}
