using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalogue
{
    class Catalogue<T> : IEnumerable<T>
    {
        T[] products = new T[10];
        public T[] Products
        {
            get { return products; }
            set { products = value; }
        }
        int count = 0;

        public void Add(T product)
        {
            products[count] = product;
            count++;
            if(count == products.Length - 1)
            {
                Reallocate();
            }
        }

        public bool Remove(T product)
        {
            bool removed = false;
            for(int i = count; i > 0; i++)
            {
                T target = (T)Products[i];
                if(target.name == product.name)
                {

                }
            }
            return removed;
        }
        
        
        public bool Compare<T>(T prod1, T prod2) where T : class
        {
            return prod1 == prod2;
        }

        public void Reallocate()
        {
            T[] expansion = new T[Products.Length * 2];
            for(int i = 0; i < count; i++)
            {
                expansion[i] = Products[i];
            }
            Products = expansion;
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
