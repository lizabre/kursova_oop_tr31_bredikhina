using Kursova.Accounts.Companies;
using Kursova.Products;
using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForProducts.ForCompanies
{
    class DeleteProduct : ICommand
    {
        public CompanyServices CompanyServices { get; set; }
        public ProductServices ProductServices { get; set; }
        public string Name => "Delete product";

        public DeleteProduct(ProductServices productServices, CompanyServices companyServices)
        {
            ProductServices = productServices;
            CompanyServices = companyServices;
        }

        public void Execute()
        {
            Console.Clear();
            List<Product> products = ProductServices.GetProductsFromCompany(CompanyServices.GetCompany());
            if (products.Count == 0)
            {
                Console.WriteLine("No products of yours yet :(");
                return;
            }
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "]" + products[i]);
            }
            while (true)
            {
                int temp;
                Console.WriteLine("Enter what product to delete:");
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    if (temp > 0 && temp <= products.Count)
                    {
                        ProductServices.Remove(products[--temp]);
                        break;
                    }
                }
            }
            Console.Clear();
        }
    }
}
