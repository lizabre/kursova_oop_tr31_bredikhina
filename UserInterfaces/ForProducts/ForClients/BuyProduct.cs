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
    class BuyProduct : ICommand
    {
        public ClientServices ClientServices { get; set; }
        public string Name => "Buy priducts in the basket";

        public BuyProduct(ClientServices clientServices)
        {
            ClientServices = clientServices;
        }

        public void Execute()
        {

            if (ClientServices.GetClient() == null)
            {
                Console.WriteLine("No products to buy!");
                return;
            }
            List<(Product, int)> basket_products = ClientServices.GetBasket();
            if (basket_products.Count != 0)
            {
                Console.WriteLine("Products in your basket: ");
                foreach (var item in basket_products)
                {
                    Console.WriteLine(item.Item1 + "\nYou ordered: " + item.Item2);
                }

            }
            ClientServices.BuyFromBasket();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
