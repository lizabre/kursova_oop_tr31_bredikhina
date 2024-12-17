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
    class TakeFromBasket : ICommand
    {
        public ClientServices ClientServices { get; set; }
        public ProductServices ProductServices { get; set; }
        public string Name => "Take from basket";

        public TakeFromBasket(ProductServices productServices, ClientServices clientServices)
        {
            ProductServices = productServices;
            ClientServices = clientServices;
        }

        public void Execute()
        {
            Console.Clear();
            List<(Product, int)> basket = ClientServices.GetBasket();
            if (basket.Count == 0 || basket == null)
            {
                Console.WriteLine("Nothing in the basket yet!");
                return;
            }
            for (int i = 0; i < basket.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + basket[i].Item1 + "\nYou ordered: " + basket[i].Item2);
            }
            int answer;
            while (true)
            {
                Console.WriteLine("Choose what to take: ");
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (answer > 0 && answer <= basket.Count)
                    {
                        ClientServices.takeFromBasket(--answer);
                        break;
                    }
                }
            }
            Console.Clear();

        }
    }
}
