using Kursova.Accounts.Companies;
using Kursova.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
    class ProductFactory
    {
        public Product GetProduct(ProductTypes type, string _name, string _description, double _price, int _quantity,  Company company,string _discount_reason, double _discount) {
            switch (type)
            {
                case ProductTypes.Usual: return new Product(_name, _description, _price, _quantity,company); 
                case ProductTypes.Discount:return new DiscountProduct(_name, _description, _price, _quantity, company, _discount_reason, _discount); 
                default: return null;
            }
        }
    }
}
