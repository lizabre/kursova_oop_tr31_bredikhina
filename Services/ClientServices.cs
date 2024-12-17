using Kursova.Accounts;
using Kursova.Accounts.Companies;
using Kursova.Products;
using Kursova.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Services
{
    internal class ClientServices : IClientServices
    {
        private Client? client = null;
        public ClientServices() { 

        }
        public void changeClient(Account user)
        {
            if (user is Company)
            {
                return;
            }
            client = (user as Client);
        }
        public Client? GetClient()
        {
            return client;
        }
        public void addToBasket(Product product, int sum)
        {
            if (product == null)
            {
                throw new Exception("Cannot put the product in the basket - doesn't exists");
            }
            client.basket.Add((product, sum));
        }
        public List<(Product, int)> GetBasket()
        {
            return client.basket;
        }
        public List<(Product, int)> GetHistory()
        {
            return client.historyProduct;
        }
        public void takeFromBasket(int id)
        {
            if (id < 0 || id >= client.basket.Count)
            {
                throw new Exception("Wrong id");
            }
            var temp = client.basket[id];
            Product product = temp.Item1;
            if (product == null)
            {
                throw new Exception("Cannot find the product in the basket");
            }
            product.CorrectQuantity(product.Quantity + temp.Item2);
            client.basket.Remove(temp);
        }
        public void BuyFromBasket()
        {
            if (client.basket.Count == 0)
            {
                throw new Exception("Nothing to buy");
            }
            double sum = 0;
            foreach (var item in client.basket)
            {
                sum += item.Item1.Price * item.Item2;
                client.historyProduct.Add(item);
            }
            client.basket.Clear();
            Console.WriteLine("Your sum is:" + sum);
        }
    }
}
