using Kursova.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Services.Interfaces
{
    interface IClientServices
    {
         void addToBasket(Product product, int sum);
        public void takeFromBasket(int id);
        public void BuyFromBasket();

    }
}
