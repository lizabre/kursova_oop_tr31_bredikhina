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
    class AddProduct : ICommand
    {
        public CompanyServices CompanyServices { get; set; }
        public ProductServices ProductServices { get; set; }
        public string Name => "Add product";
        public AddProduct(ProductServices productServices, CompanyServices companyServices)
        {
            ProductServices = productServices;
            CompanyServices = companyServices;
        }

        public void Execute()
        {
            Console.Clear();
            string name, description, discount_reason = "";
            double price, discount = 0;
            int quantity;
            ProductTypes type = ProductTypes.Unassigned;
            while (true)
            {
                int ans;
                Console.WriteLine("Choose product type:\n[1] - Usual \t\t [2] - Discounted");
                if (int.TryParse(Console.ReadLine(), out ans))
                {
                    switch (ans)
                    {
                        case 1: type = ProductTypes.Usual; break;
                        case 2: type = ProductTypes.Discount; break;
                        default: break;
                    }
                    if (type != ProductTypes.Unassigned)
                    {
                        break;
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Enter name of the product: ");
                name = Console.ReadLine();
                if (name != null)
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter description of the product: ");
                description = Console.ReadLine();
                if (description != null)
                {
                    break;
                }
            }
            while (true)
            {
                double temp;
                Console.WriteLine("Enter price of the product: ");
                if (double.TryParse(Console.ReadLine(), out temp))
                {
                    if (temp > 0)
                    {
                        price = temp;
                        break;
                    }
                }
            }
            while (true)
            {
                int temp;
                Console.WriteLine("Enter quantity of the product: ");
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    if (temp > 0)
                    {
                        quantity = temp;
                        break;
                    }
                }
            }
            if (type == ProductTypes.Discount)
            {
                while (true)
                {
                    Console.WriteLine("Enter discount_reason of the product: ");
                    discount_reason = Console.ReadLine();
                    if (discount_reason != null)
                    {
                        break;
                    }
                }
                while (true)
                {
                    double temp;
                    Console.WriteLine("Enter discount of the product: ");
                    if (double.TryParse(Console.ReadLine(), out temp))
                    {
                        if (temp > 0)
                        {
                            discount = temp;
                            break;
                        }
                    }
                }
            }
            ProductServices.Add(name, description, price, quantity, CompanyServices.GetCompany() ,discount_reason, discount, type);
            Console.Clear();
        }
    }
}
