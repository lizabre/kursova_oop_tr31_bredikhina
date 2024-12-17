using Kursova.Accounts;
using Kursova.Products;
using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForAccounts
{
    internal class ShowClient : ICommand
    {
        public ClientServices ClientServices { get; set; }
        public string Name => "Show account";

        public ShowClient(ClientServices clientServices)
        {
            ClientServices = clientServices;
        }

        public void Execute()
        {
            Console.Clear();
            Client client = ClientServices.GetClient();
            if(client == null)
            {
                throw new Exception("No client was send");
            }
            Console.WriteLine("\t\tInfo for " + client.Username + " (Client) ");
            Console.WriteLine("Email:" + client.Email);
            List<(Product, int)> basket_products = ClientServices.GetBasket();
            List<(Product, int)> history_products = ClientServices.GetHistory();
            if (basket_products.Count != 0)
            {
                Console.WriteLine("Products in your basket: ");
                foreach (var item in basket_products)
                {
                    Console.WriteLine(item.Item1 + "\nYou ordered: " + item.Item2);
                }

            }
            if (history_products.Count != 0)
            {
                Console.WriteLine("Your previous purchases: ");
                foreach (var item in history_products)
                {
                    Console.WriteLine(item.Item1 + "\nYou ordered: " + item.Item2);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
