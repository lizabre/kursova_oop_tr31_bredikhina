using Kursova.Products;
using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForProducts
{
    class ShowAllProducts : ICommand
    {
        public ProductServices ProductServices { get; set; }

        public string Name =>"View all products";

        public ShowAllProducts(ProductServices productServices)
        {
            ProductServices = productServices;
        }

        public void Execute()
        {
            Console.Clear();
            List<Product> products = ProductServices.GetAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products were added to the platform :(");
                return;
            }
            foreach (Product product in products)
            {
                Console.WriteLine(product + "\n");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
