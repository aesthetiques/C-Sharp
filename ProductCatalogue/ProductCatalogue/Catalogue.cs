using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalogue
{
    class Catalogue<T> : IEnumerable<T>
    {
        T[] products = new T[10];
        int count = 0;

        public void Add(T product)
        {
            products[count] = product;
            count ++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
