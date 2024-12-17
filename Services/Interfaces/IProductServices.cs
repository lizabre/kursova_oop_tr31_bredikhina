using Kursova.Accounts.Companies;
using Kursova.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Services.Interfaces
{
    interface IProductServices
    {
        void Add(string _name, string _description, double _price, int _quantity,  Company company, string _discount_reason, double _discount, ProductTypes type);
        void Remove(Product product);
        void Bought(Product product, int sum);
        Product? GetProduct(int id);
        List<Product>? GetAllProducts();
        List<Product>? GetProductsFromCompany(Company company);
    }
}
