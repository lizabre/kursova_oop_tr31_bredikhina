using Kursova.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Accounts
{
    class Client : Account
    {
        public List<(Product, int)> historyProduct { get; set; }
        public List<(Product, int)> basket { get; set; }
        public Client(string _username, string _email, string _password) : base(_username, _email, _password)
        {
            historyProduct = new List<(Product, int)>();
            basket = new List<(Product, int)>();
        }
    }
}
