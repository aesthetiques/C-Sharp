using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalogue
{
    public class Product
    {
        public string name { get; set; }
        public string description { get; set; }

        public Product(string productName, string productDescription)
        {
            name = productName;
            description = productDescription;
        }
    }
}
