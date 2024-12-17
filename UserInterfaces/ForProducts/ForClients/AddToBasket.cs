using Kursova.Accounts;
using Kursova.Products;
using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForProducts.ForClients
{
    class AddToBasket : ICommand
    {
        public ProductServices ProductServices { get; set; }
        public ClientServices ClientServices { get; set; }
        public string Name => "Add product to basket";

        public AddToBasket(ProductServices productServices, ClientServices clientServices)
        {
            ProductServices = productServices;
            ClientServices = clientServices;
        }
        public int AskQuantity()
        {
            int ans;
            while (true)
            {
                Console.WriteLine("Please enter the quantity:");
                if (int.TryParse(Console.ReadLine(), out ans))
                {
                    if (ans >= 1)
                    {
                        break;
                    }
                }
            }
            return ans;
        }
        public void Execute()
        {
            Console.Clear();
            List<Product> products = ProductServices.GetAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + products[i]);
            }
            int answer;
            while (true)
            {
                Console.WriteLine("Enter product id");
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (answer > 0 || answer <= products.Count)
                    {
                        Product product = products[--answer];
                        if (product != null)
                        {
                            int q = AskQuantity();
                            ClientServices.addToBasket(product, q);
                            ProductServices.Bought(product, q);
                            break;
                        }
                    }
                }
            }
            Console.Clear();
        }
    }
}
