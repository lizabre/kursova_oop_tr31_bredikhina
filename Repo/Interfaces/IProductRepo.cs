using Kursova.Accounts.Companies;
using Kursova.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Repo.Interfaces
{
    interface IProductRepo
    {
        public void Add(Product product);
        public void Remove(Product product);
        public void Remove(int id);
        public Product Get(int id);
        public List<Product> GetAll();
        public List<Product> GetFromCompany(Company company);
        public int GetProductCount();
    }
}
