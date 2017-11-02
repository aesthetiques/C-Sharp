using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalogue
{
    public class Product
    {
        private string name;
        private string description;
        public string Name
        {
            get { return name; }
            set {  name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }



        public Product(string productName, string productDescription)
        {
            name = productName;
            description = productDescription;
        }
    }
}
