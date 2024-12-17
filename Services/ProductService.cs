using Kursova.Accounts.Companies;
using Kursova.Products;
using Kursova.Repo;
using Kursova.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Services
{
    class ProductServices : IProductServices
    {
        private readonly ProductRepo productRepo;
        public ProductServices(ProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }
        public void Add(string _name, string _description, double _price, int _quantity, Company company,string _discount_reason, double _discount, ProductTypes type)
        {
            ProductFactory productFactory = new ProductFactory();
            Product product = productFactory.GetProduct(type, _name, _description, _price, _quantity, company, _discount_reason, _discount);
            productRepo.Add(product);
        }

        public Product? GetProduct(int id)
        {
            if (id < 0 || id >= productRepo.GetProductCount())
            {
                throw new Exception("Wrong id!");
            }
            return productRepo.Get(id);
        }

        public void Remove(Product product)
        {
            if (product == null)
            {
                throw new Exception("The product is null! Please provide a valid product");
            }
            if (productRepo.Get(product.Id)==null)
            {
                throw new Exception("The product is not in database");
            }
            productRepo.Remove(product);
        }

        public List<Product> GetAllProducts()
        {
            return productRepo.GetAll();
        }

        public List<Product> GetProductsFromCompany(Company company)
        {
            if (company == null)
            {
                throw new Exception("The company is null! Please provide a valid account");
            }
            return productRepo.GetFromCompany(company);
        }

        public void Bought(Product product, int sum)
        {
            if (product == null)
            {
                throw new Exception("The product is null! Please provide a valid product");
            }
            if (sum > product.Quantity)
            {
                throw new Exception("Cannot buy more of a product than is in stock!");
            }
            if (sum == product.Quantity)
            {
                Remove(product);
                return;
            }
            product.BeingBought(sum);
        }
    }
}
