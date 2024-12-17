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
    class ShowCompanyProducts : ICommand
    {
        public CompanyServices CompanyServices { get; set; }
        public ProductServices ProductServices { get; set; }
        public string Name => "Show company products";

        public ShowCompanyProducts(ProductServices productServices, CompanyServices companyServices)
        {
            ProductServices = productServices;
            CompanyServices = companyServices;
        }

        public void Execute()
        {
            List<Product> products = ProductServices.GetProductsFromCompany(CompanyServices.GetCompany());
            if (products.Count == 0)
            {
                Console.WriteLine("No products of yours yet :(");
                return;
            }
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
