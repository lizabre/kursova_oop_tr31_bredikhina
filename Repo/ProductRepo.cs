using Kursova.Accounts.Companies;
using Kursova.Products;
using Kursova.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Repo
{
    class ProductRepo : IProductRepo
    {
        private readonly DBContext bContext;
        public ProductRepo(DBContext bContext)
        {
            this.bContext = bContext;
        }

        public void Add(Product product)
        {
            bContext.Products.Add(product);
        }

        public Product Get(int id)
        {
            return bContext.Products[id];
        }


        public List<Product> GetAll()
        {
            return bContext.Products;
        }

        public List<Product> GetFromCompany(Company company)
        {
            return bContext.Products.FindAll(pr => pr.Company == company);
        }

        public int GetProductCount()
        {
            return bContext.Products.Count;
        }

        public void Remove(Product product)
        {
           bContext.Products.Remove(product);
        }

        public void Remove(int id)
        {
            bContext.Products.RemoveAt(id);
        }
    }
}
