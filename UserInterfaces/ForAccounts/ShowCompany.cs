using Kursova.Accounts;
using Kursova.Accounts.Companies;
using Kursova.Products;
using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForAccounts
{
    class ShowCompany : ICommand
    {
        public ProductServices ProductServices { get; set; }
        public CompanyServices CompanyServices { get; set; }
        public string Name => "Show account";

        public ShowCompany(CompanyServices companyServices, ProductServices productServices)
        {
            CompanyServices = companyServices;
            ProductServices = productServices;
        }

        public void Execute()
        {
            Console.Clear();
            Company company = CompanyServices.GetCompany();
            if (company == null) {
                throw new Exception("No company was sent");
            }
            Console.WriteLine("\t\tInfo for " + company.Username + "("+company.GetType().Name +")");
            Console.WriteLine("Email:" + company.Email);
            List<Product> products = ProductServices.GetProductsFromCompany(company);
            if (products.Count != 0)
            {
                Console.WriteLine("Your products:");
                foreach (Product product in products)
                {
                    Console.WriteLine(product);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
