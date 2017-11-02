using System;

namespace ProductCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue<Product> techCatalogue = new Catalogue<Product>();
            techCatalogue.Add(new Product("Galaxy Note 8", "6.3in Phablet Android Device"));
            techCatalogue.Add(new Product("Google Pixel 2 XL", "6in Phablet Android Device"));
            techCatalogue.Add(new Product("Dell XPS 15 2017", "15in Ultrabook, near bezelless display, Windows 10"));
            techCatalogue.Add(new Product("Nvidia 980ti", "Next generation gaming GPU"));

            foreach(Product product in techCatalogue)
            {
                Console.WriteLine($"{product.name} {product.description}");
            }



        }
    }
}
